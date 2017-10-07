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

### Linux/Mac OS X
**Dependencies:**
* Mono (see [Supported Mono Versions](#supported-mono-versions) for a full list of supported versions)
* XSP ( [latest](https://github.com/mono/xsp) version should be fine)


**Instructions:**
1. Install ```mono``` ([Linux](http://www.mono-project.com/docs/getting-started/install/linux/) or [OS X](http://www.mono-project.com/docs/getting-started/install/mac/))
2. Install [```xsp```](https://github.com/mono/xsp/blob/master/INSTALL)
3. Install ```nuget```
4. Clone SharpPaste repository ```git clone https://github.com/phonicmouse/SharpPaste.git```
5. Enter repo's directory ```cd SharpPaste```
6. Restore packages ```nuget restore```
7. Build Solution ```xbuild SharpPaste.sln```
8. Start [XSP Web Server](http://www.mono-project.com/docs/web/aspnet/#aspnet-hosting-with-xsp) ```xsp``` or ```xsp4``` if you get errors with the first one
9. Done. Enjoy! :stuck_out_tongue_winking_eye:


## Specifics

#### Supported Mono Versions

| Version        | Supported          |
|:--------------:|:------------------:|
| latest (5.4.0) | :interrobang:      |
| stable (5.2.x) | :white_check_mark: |
| 5.0.1          | :white_check_mark: |
| 4.8.1          | :white_check_mark: |
| 4.6.2          | :white_check_mark: |
| 4.4.2          | :white_check_mark: |
| 4.2.x          | :x:                |
| 4.0.x          | :x:                |
| 3.x.x          | :x:                |
| 2.x.x          | :x:                |
| 1.x.x          | :x:                |

See [Travis CI](https://travis-ci.org/phonicmouse/SharpPaste) for more details.

#### Package Versions
| Package Name            | Current Version | 
|-------------------------|:---------------:|
| Bootstrap               | 3.3.7           |
| Bootstrap Flat          | 3.3.4           | 
| jQuery                  | 3.2.1           | 
| LiteDB                  | 3.1.4           | 
| MlkPwgen                | 0.3.0           | 
| Nancy                   | 1.4.4           | 
| Nancy Hosting (ASP.NET) | 1.4.1           |
| Nancy Hosting (Self)    | -----           | 
| Newtonsoft.Json         | 10.0.3          | 
