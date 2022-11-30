# Virtual File System

A virtual file system implementation in modern C#.

When writing applications in .NET, you often need to write or read the contents of a file. .NET provides `System.IO` namespace dedicated to this purpose. But how do we deal with the filesystem when testing our code?

"Virtual File System" is an attempt to solve this problem. Currently, this library is at an early stage of development. If you need additional functionality, I invite you to open an issue to discuss it.


## Badges

_Social buttons_

[![Atypical-Consulting - VirtualFileSystem](https://img.shields.io/static/v1?label=Atypical-Consulting&message=VirtualFileSystem&color=blue&logo=github)](https://github.com/Atypical-Consulting/VirtualFileSystem "Go to GitHub repo")
[![License: BSD-3-Clause](https://img.shields.io/badge/License-BSD--3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)
[![stars - VirtualFileSystem](https://img.shields.io/github/stars/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)
[![forks - VirtualFileSystem](https://img.shields.io/github/forks/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)


_Repo metadata_

[![GitHub tag](https://img.shields.io/github/tag/Atypical-Consulting/VirtualFileSystem?include_prereleases=&sort=semver&color=blue)](https://github.com/Atypical-Consulting/VirtualFileSystem/releases/)
[![issues - VirtualFileSystem](https://img.shields.io/github/issues/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/pulls)
[![GitHub contributors](https://img.shields.io/github/contributors/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/graphs/contributors)
[![GitHub last commit](https://img.shields.io/github/last-commit/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/commits/master)

_Call-to-Action buttons_

[![View site - GH Pages](https://img.shields.io/badge/View_site-GH_Pages-2ea44f?style=for-the-badge)](https://atypical-consulting.github.io/VirtualFileSystem/)
[![view - Documentation](https://img.shields.io/badge/view-Documentation-blue?style=for-the-badge)](/docs/ "Go to project documentation")


## What is a virtual file system and why should I use it?
A virtual file system is a data structure that represents a file system in memory. It is used to simulate a file system on a computer. It is useful for testing purposes, for example, when you want to test a file system without actually creating files on the hard drive.


## License

This project is licensed under the terms of the BSD-3-Clause license.
If you use this library in your project, please consider adding a link to this repository in your project's README.

This project is maintained by [Atypical Consulting](https://www.atypical.consulting/). If you need help with this project, please contact us from this repository by opening an issue.
