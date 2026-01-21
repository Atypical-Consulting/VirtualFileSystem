// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Octokit;

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Implementation of GitHub write operations using Octokit.
/// </summary>
public sealed class GitHubWriteService : IGitHubWriteService
{
    private const string ProductHeaderValue = "Atypical.VirtualFileSystem.GitHub";

    /// <inheritdoc />
    public async Task<bool> HasWriteAccessAsync(string owner, string repository, string accessToken)
    {
        try
        {
            var client = CreateClient(accessToken);
            var repo = await client.Repository.Get(owner, repository);
            return repo.Permissions?.Push == true;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc />
    public async Task<GitHubForkResult> ForkRepositoryAsync(string owner, string repository, string accessToken)
    {
        try
        {
            var client = CreateClient(accessToken);

            // Check if fork already exists
            var user = await client.User.Current();

            try
            {
                var existingFork = await client.Repository.Get(user.Login, repository);
                if (existingFork.Fork && existingFork.Parent?.Owner?.Login == owner)
                {
                    return new GitHubForkResult(
                        Success: true,
                        ForkOwner: user.Login,
                        ForkUrl: existingFork.HtmlUrl);
                }
            }
            catch (NotFoundException)
            {
                // Fork doesn't exist, we'll create it
            }

            // Create fork
            var fork = await client.Repository.Forks.Create(owner, repository, new NewRepositoryFork());

            // Wait for fork to be ready (GitHub processes forks asynchronously)
            var maxAttempts = 10;
            for (var i = 0; i < maxAttempts; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));

                try
                {
                    var forkRepo = await client.Repository.Get(user.Login, repository);
                    if (forkRepo.Size > 0 || i == maxAttempts - 1)
                    {
                        return new GitHubForkResult(
                            Success: true,
                            ForkOwner: user.Login,
                            ForkUrl: forkRepo.HtmlUrl);
                    }
                }
                catch
                {
                    // Fork not ready yet
                }
            }

            return new GitHubForkResult(
                Success: true,
                ForkOwner: fork.Owner.Login,
                ForkUrl: fork.HtmlUrl);
        }
        catch (Exception ex)
        {
            return new GitHubForkResult(
                Success: false,
                ErrorMessage: $"Failed to fork repository: {ex.Message}");
        }
    }

    /// <inheritdoc />
    public async Task<GitHubBranchResult> CreateBranchAsync(
        string owner,
        string repository,
        string branchName,
        string? fromBranch,
        string accessToken)
    {
        try
        {
            var client = CreateClient(accessToken);

            // Get the reference to branch from
            var sourceBranch = fromBranch;
            if (string.IsNullOrEmpty(sourceBranch))
            {
                var repo = await client.Repository.Get(owner, repository);
                sourceBranch = repo.DefaultBranch;
            }

            var reference = await client.Git.Reference.Get(owner, repository, $"heads/{sourceBranch}");
            var sha = reference.Object.Sha;

            // Create new branch
            var newReference = await client.Git.Reference.Create(owner, repository, new NewReference($"refs/heads/{branchName}", sha));

            return new GitHubBranchResult(
                Success: true,
                BranchName: branchName,
                CommitSha: newReference.Object.Sha);
        }
        catch (Exception ex)
        {
            return new GitHubBranchResult(
                Success: false,
                ErrorMessage: $"Failed to create branch: {ex.Message}");
        }
    }

    /// <inheritdoc />
    public async Task<GitHubCommitResult> CommitChangesAsync(
        string owner,
        string repository,
        string branch,
        string message,
        IReadOnlyList<GitHubFileCommit> files,
        string accessToken)
    {
        try
        {
            var client = CreateClient(accessToken);

            // Get the current commit SHA for the branch
            var branchRef = await client.Git.Reference.Get(owner, repository, $"heads/{branch}");
            var baseCommitSha = branchRef.Object.Sha;

            // Get the base tree
            var baseCommit = await client.Git.Commit.Get(owner, repository, baseCommitSha);
            var baseTreeSha = baseCommit.Tree.Sha;

            // Create blobs for all files and build tree
            var treeItems = new List<NewTreeItem>();

            foreach (var file in files)
            {
                // Create blob for file content
                var blob = await client.Git.Blob.Create(owner, repository, new NewBlob
                {
                    Content = file.Content,
                    Encoding = EncodingType.Utf8
                });

                treeItems.Add(new NewTreeItem
                {
                    Path = file.Path,
                    Mode = "100644", // Regular file
                    Type = TreeType.Blob,
                    Sha = blob.Sha
                });
            }

            // Create new tree
            var newTree = await client.Git.Tree.Create(owner, repository, new NewTree
            {
                BaseTree = baseTreeSha,
                Tree = { }
            });

            // Add tree items
            var treeRequest = new NewTree { BaseTree = baseTreeSha };
            foreach (var item in treeItems)
            {
                treeRequest.Tree.Add(item);
            }

            newTree = await client.Git.Tree.Create(owner, repository, treeRequest);

            // Create commit
            var newCommit = await client.Git.Commit.Create(owner, repository, new NewCommit(message, newTree.Sha, baseCommitSha));

            // Update branch reference
            await client.Git.Reference.Update(owner, repository, $"heads/{branch}", new ReferenceUpdate(newCommit.Sha));

            return new GitHubCommitResult(
                Success: true,
                CommitSha: newCommit.Sha);
        }
        catch (Exception ex)
        {
            return new GitHubCommitResult(
                Success: false,
                ErrorMessage: $"Failed to commit changes: {ex.Message}");
        }
    }

    /// <inheritdoc />
    public async Task<GitHubPullRequestResult> CreatePullRequestAsync(
        string owner,
        string repository,
        string title,
        string? body,
        string headBranch,
        string baseBranch,
        string accessToken,
        bool isDraft = false)
    {
        try
        {
            var client = CreateClient(accessToken);

            var newPr = new NewPullRequest(title, headBranch, baseBranch)
            {
                Body = body,
                Draft = isDraft
            };

            var pr = await client.PullRequest.Create(owner, repository, newPr);

            return new GitHubPullRequestResult(
                Success: true,
                PullRequestNumber: pr.Number,
                PullRequestUrl: pr.HtmlUrl);
        }
        catch (Exception ex)
        {
            return new GitHubPullRequestResult(
                Success: false,
                ErrorMessage: $"Failed to create pull request: {ex.Message}");
        }
    }

    private static GitHubClient CreateClient(string accessToken)
    {
        var client = new GitHubClient(new ProductHeaderValue(ProductHeaderValue))
        {
            Credentials = new Credentials(accessToken)
        };
        return client;
    }
}
