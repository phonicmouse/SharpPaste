# SharpPaste
[![Build Status](https://img.shields.io/travis/phonicmouse/SharpPaste.svg?style=flat-square)](https://travis-ci.org/phonicmouse/SharpPaste)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/phonicmouse/SharpPaste/master/LICENSE)

A simple and Open-Source C# ASP.NET/NancyFX pastebin, made with :heart: in Italy :it:.

## Software Used
* Mono - C# Cross-Platform Compiler
* XSP - Cross-Platform ASP.NET Server
* NancyFX - Web Framework
* LiteDB - Embedded Database
* Bootstrap - UI Framework
* Bootstrap Flat Theme - UI Theme
* jQuery - DOM Framework
* Prism (JS & CSS) - Syntax Highlighter

## Installation

### Linux
**Dependencies:**
* Mono (see [Supported Mono Versions](#supported-mono-versions) for a full list of supported versions)
* XSP ( [latest](https://github.com/mono/xsp) version should be ok)


**Instructions:**
1. Install [mono](http://www.mono-project.com/docs/getting-started/install/linux/)
2. Install [XSP](https://github.com/mono/xsp/blob/master/INSTALL)
3. Clone SharpPaste repository ```git clone https://github.com/phonicmouse/SharpPaste.git```
4. Enter repo's directory ```cd SharpPaste```
5. Build Solution ```xbuild SharpPaste.sln```
6. Start XSP Web Server ```xsp``` or ```xsp4``` if you get errors with the first one
7. Done. Enjoy!

## Specifics

#### Supported Mono Versions

| Version        | Supported          |
|:--------------:|:------------------:|
| latest (5.0.0) | :interrobang:      |
| stable (4.8.x) | :white_check_mark: |
| 4.8.0          | :white_check_mark: |
| 4.6.2          | :white_check_mark: |
| 4.4.2          | :white_check_mark: |
| 4.2.x          | :x:                |
| 4.0.x          | :x:                |
| 3.x.x          | :x:                |
| 2.x.x          | :x:                |
| 1.x.x          | :x:                |

See [CI](https://travis-ci.org/phonicmouse/SharpPaste) for more details.

#### Package Versions
| Package Name         | Current Version | Previous Version(s)     |
|----------------------|:---------------:|:-----------------------:|
| Bootstrap            | 3.3.7           | 3.3.4                   |
| Bootstrap Flat       | 3.3.4           | 3.3.4                   |
| jQuery               | 3.1.1           | 3.1.1                   |
| LiteDB               | 3.1.0           | 2.0.0                   |
| MlkPwgen             | 0.3.0           | 0.2.0                   |
| Nancy                | 1.4.3           | 1.4.3                   |
| Nancy.Hosting.Aspnet | 1.4.1           | 1.4.1                   |
| Newtonsoft.Json      | 9.0.1           | 9.0.1                   |
