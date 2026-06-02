# Copy File and Directory Operations

Implement copy operations for files and directories, including recursive directory copy with proper event emission and undo/redo support.

## Rationale
Copy is a fundamental file system operation that's currently missing. Users need this to simulate realistic file management workflows. This is a known gap in the current implementation.

## User Stories
- As a .NET developer, I want to copy files and directories in the virtual file system so that I can test code that performs backup or duplication operations
- As a test author, I want copy operations to emit events so that I can verify my application reacts correctly to file copies

## Acceptance Criteria
- [ ] CopyFile creates a new file with identical content at the target path
- [ ] CopyDirectory recursively copies all files and subdirectories
- [ ] FileCopied and DirectoryCopied events are emitted
- [ ] Copy operations are added to change history for undo/redo
- [ ] Attempting to copy to an existing path throws appropriate exception
- [ ] Fluent API supports chaining copy operations
