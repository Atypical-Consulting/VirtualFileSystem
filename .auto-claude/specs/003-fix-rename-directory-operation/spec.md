# Fix Rename Directory Operation

Fix the known issue with directory rename operations to ensure they work correctly across all scenarios including nested directories and files.

## Rationale
This is documented technical debt that affects the reliability of the library. The TODO in DemoCli indicates this is a known issue that needs resolution.

## User Stories
- As a .NET developer, I want to rename directories reliably so that I can test directory management code
- As a library user, I expect rename operations to maintain consistency with nested contents

## Acceptance Criteria
- [ ] Renaming a directory updates all child paths correctly
- [ ] DirectoryRenamed event contains correct old and new paths
- [ ] Rename operation is correctly recorded for undo/redo
- [ ] Renaming works for deeply nested directories
- [ ] Renaming to an existing directory name throws appropriate exception
