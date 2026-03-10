# QA Fix Request

**Status**: REJECTED
**Date**: 2026-01-23T16:54:00Z
**QA Session**: 1

## Critical Issues to Fix

### 1. Missing Duplicate Directory Validation (CRITICAL)

**Problem**: The `RenameDirectory` method does not check if a directory with the new name already exists in the same parent directory. This violates Acceptance Criteria #5: "Renaming to an existing directory name throws appropriate exception". The current implementation will silently overwrite an existing directory, potentially causing data loss.

**Location**: `src/Atypical.VirtualFileSystem.Core/SystemOperations/Commands/Rename/VFS.Rename.cs:39-48`

**Current Code**:
```csharp
var oldName = directoryNode.Name;
var newPath = new VFSDirectoryPath($"{directoryPath.Parent}/{newName}");
var updatedDirectoryNode = directoryNode.UpdatePath(newPath);

// ... parent updates ...

// This will SILENTLY OVERWRITE if newPath already exists!
Index[newPath] = updatedDirectoryNode;
```

**Required Fix**:
Add validation to check if the destination path already exists before attempting the rename:

```csharp
var oldName = directoryNode.Name;
var newPath = new VFSDirectoryPath($"{directoryPath.Parent}/{newName}");

// ADD THIS VALIDATION:
if (Index.ContainsKey(newPath))
    ThrowVirtualNodeAlreadyExists(newPath);

var updatedDirectoryNode = directoryNode.UpdatePath(newPath);
```

**Pattern Reference**: This follows the same pattern used in `CreateDirectory` operation:
- File: `src/Atypical.VirtualFileSystem.Core/SystemOperations/Commands/Create/VFS.Create.cs`
- Method: `AddToIndex()` at line 50-55
- Uses `TryAdd()` and throws `ThrowVirtualNodeAlreadyExists()` if key exists

**Verification Steps**:
1. Add the 3-line validation check after line 39 in `VFS.Rename.cs`
2. Build the project: `dotnet build src/Atypical.VirtualFileSystem.Core/`
3. Verify compilation succeeds with 0 errors

---

### 2. Missing Test for Duplicate Directory Validation (CRITICAL)

**Problem**: No test exists to verify that renaming to an existing directory name throws an exception. This is required to validate Acceptance Criteria #5.

**Location**: `tests/Atypical.VirtualFileSystem.UnitTests/SystemOperations/Commands/VirtualFileSystem_MethodRenameDirectory_Tests.cs`

**Required Fix**:
Add a new test method to the test class:

```csharp
[Fact]
public void RenameDirectory_throws_exception_when_target_name_already_exists()
{
    // Arrange
    _vfs.CreateDirectory(new VFSDirectoryPath("dir1/dir2/dir3"));
    _vfs.CreateDirectory(new VFSDirectoryPath("dir1/dir2/existing"));

    // Act
    Action action = () => _vfs.RenameDirectory(
        new VFSDirectoryPath("dir1/dir2/dir3"),
        "existing"
    );

    // Assert
    action.Should()
        .Throw<VirtualFileSystemException>()
        .WithMessage("The node 'vfs://dir1/dir2/existing' already exists in the index.");
}
```

**Pattern Reference**: This follows the same pattern as existing duplicate tests:
- File: `tests/Atypical.VirtualFileSystem.UnitTests/SystemOperations/Commands/VirtualFileSystem_MethodCreateDirectory_Tests.cs`
- Test: `CreateDirectory_throws_an_exception_if_the_directory_already_exists()` at line 54-66

**Verification Steps**:
1. Add the test method at the end of the `VirtualFileSystem_MethodRenameDirectory_Tests` class
2. Run rename directory tests: `dotnet test tests/Atypical.VirtualFileSystem.UnitTests/ --filter "FullyQualifiedName~RenameDirectory"`
3. Verify the new test passes
4. Verify all existing RenameDirectory tests still pass (should be 26 total now)

---

## Acceptance Criteria Validation

After implementing the fixes above, the following acceptance criteria must be verified:

- [x] AC #1: Renaming a directory updates all child paths correctly ✓
- [x] AC #2: DirectoryRenamed event contains correct old and new paths ✓
- [x] AC #3: Rename operation is correctly recorded for undo/redo ✓
- [x] AC #4: Renaming works for deeply nested directories ✓
- [ ] AC #5: Renaming to an existing directory name throws appropriate exception ✗ **MUST FIX**

---

## Final Verification

After implementing both fixes, run the following commands to verify:

```bash
# 1. Build the core project
dotnet build src/Atypical.VirtualFileSystem.Core/

# 2. Run all RenameDirectory tests (should be 26 tests now)
dotnet test tests/Atypical.VirtualFileSystem.UnitTests/ --filter "FullyQualifiedName~RenameDirectory"

# 3. Run full test suite to check for regressions
dotnet test

# 4. Run DemoCli to verify integration still works
dotnet run --project src/Atypical.VirtualFileSystem.DemoCli/
```

**Expected Results**:
- Core project builds with 0 errors
- 26 RenameDirectory tests pass (25 existing + 1 new)
- Full test suite: 380 passing, 4 failing (pre-existing locale issues)
- DemoCli runs without errors

---

## Commit Message

After fixes are complete, commit with:

```bash
git add src/Atypical.VirtualFileSystem.Core/SystemOperations/Commands/Rename/VFS.Rename.cs
git add tests/Atypical.VirtualFileSystem.UnitTests/SystemOperations/Commands/VirtualFileSystem_MethodRenameDirectory_Tests.cs

git commit -m "fix: add validation to prevent renaming to existing directory name (qa-requested)

- Add duplicate directory check in VFS.Rename.cs before rename operation
- Add test to verify exception is thrown when renaming to existing name
- Fixes acceptance criteria #5: renaming to existing name throws exception
- Follows same pattern as CreateDirectory duplicate validation"
```

---

## After Fixes

Once fixes are complete:
1. Commit changes with the message above
2. Update build-progress.txt with fix details
3. QA will automatically re-run validation
4. If all acceptance criteria pass, QA will approve sign-off

---

**Priority**: CRITICAL - Blocks production deployment
**Estimated Time**: 15 minutes
**Complexity**: Low (simple validation check + test)
**Risk**: High if not fixed (potential data loss from silent overwrites)
