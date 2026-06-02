# Recursive Directory Operations

Enhance directory operations to support recursive delete, recursive size calculation, and recursive file enumeration with configurable depth limits.

## Rationale
Real file systems support recursive operations. This addresses common testing scenarios where developers need to work with entire directory trees.

## User Stories
- As a .NET developer, I want to recursively enumerate files in the virtual file system so that I can test file search functionality
- As a test author, I want to recursively delete directories so that I can clean up test data efficiently

## Acceptance Criteria
- [ ] DeleteDirectory supports recursive deletion option
- [ ] GetDirectorySize returns total size of all files recursively
- [ ] EnumerateFiles supports SearchOption.AllDirectories equivalent
- [ ] Depth limit parameter prevents excessive recursion
- [ ] All recursive operations emit appropriate events
