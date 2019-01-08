# SharpPaste
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/phonicmouse/SharpPaste/master/LICENSE)
[![Travis CI](https://img.shields.io/travis/phonicmouse/SharpPaste.svg?style=flat-square&logo=travis)](https://travis-ci.org/phonicmouse/SharpPaste)
[![AppVeyor](https://img.shields.io/appveyor/ci/phonicmouse/sharppaste.svg?style=flat-square&logo=appveyor)](https://ci.appveyor.com/project/phonicmouse/sharppaste)
[![Gitter](https://img.shields.io/badge/chat_on-gitter-green.svg?style=flat-square&logo=gitter-white&colorB=ed1965)](https://gitter.im/SharpPasteZ)

Cross-platform C# pastebin with client-side AES-256 encryption that just works, made with :heart: in Italy :it:.


## Installation

### Linux
**Dependencies:**
- Mono Runtime (see [Supported Mono Versions](#supported-mono-versions) for a full list of supported versions)
- Nuget (to automatically download all required C# dependencies)
- XSP4 (see [hosting asp.net with xsp](http://www.mono-project.com/docs/web/aspnet/#aspnet-hosting-with-xsp) for more details)


**Instructions:**

Use our simple one-liner installer (currently supports Ubuntu, Debian, Raspbian and CentOS)[**TODO**]:
```
curl https://get.sharppaste.nl | bash
```

Or install by *hand*:
- Add Mono repositories for your distro:
  - [Ubuntu](http://www.mono-project.com/download/#download-lin-ubuntu)
  - [Debian](http://www.mono-project.com/download/#download-lin-debian)
  - [Raspbian](http://www.mono-project.com/download/#download-lin-raspbian)
  - [Centos](http://www.mono-project.com/download/#download-lin-centos)
- Install required packages:
  - Ubuntu, Debian and Raspbian: `sudo apt install -y mono-xsp nuget`
  - CentOS: `sudo yum install -y xsp nuget`
- Download latest release:
  - From our website `wget https://get.sharppaste.nl/latest.tar.gz`[**TODO**]
  - Or, from our [releases page](https://github.com/phonicmouse/SharpPaste/releases) (be sure to download the latest .tar.gz file)
- Extract archive to `/opt`: `tar -xvf latest.tar.gz -C /opt/sharppaste`
- Go to app's directory: `cd /opt/sharppaste`
- Download nuget packages: `nuget restore`
- Build app: `msbuild`
- Create database directory: `mkdir -p /opt/sharppaste/Databases`
- Test app by running `xsp` and then check by opening http://127.0.0.1:9000 in your browser if everything works
- Add xsp user to run it in background: `sudo useradd -d /opt/sharppaste -r xsp`
- Fix permissions: `sudo chmod -R xsp:xsp /opt/sharppaste`
- Copy `sharppaste.service` to systemd's services directory: `sudo cp /opt/sharppaste/Scripts/sharppaste.service /etc/systemd/system/sharppaste.service`
- Reload systemd services: `sudo systemctl daemon-reload`
- Enable SharpPaste service (to let it start st system's startup): `sudo systemctl enable`
- Start SharpPaste service: `sudo service sharppaste start`
- Enjoy! 😜🔥
## Specifics

### Software Used

- Mono - C# Cross-Platform Compiler
- NancyFX - Open Source Web Framework
- LiteDB - Embedded Database
- [Strong PwGen](https://gist.github.com/jacobbuck/4247179) - Strong key generator
- Scrypt.js - Key hashing algorithm (used for AES256 keys)
- AES-JS - Library to encrypt data using AES directly in your browser
- Bootstrap 3 - UI Framework
- Bootstrap Flat Theme - UI Theme
- jQuery - DOM Framework
- Prism - Syntax Highlighter

### Supported Mono Versions

| Version        | Supported          |
|:--------------:|:------------------:|
| latest (5.4.1) | :white_check_mark: |
| 5.4.1          | :white_check_mark: |
| 5.2.0          | :white_check_mark: |
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


### License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fphonicmouse%2FSharpPaste.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fphonicmouse%2FSharpPaste?ref=badge_large)
