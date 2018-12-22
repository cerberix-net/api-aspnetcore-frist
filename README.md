# README

## Abstract

This solution provides a quick starting point for api development. It's built using [asp.net core web api](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1). Optional modules are available. Each module is decribed below.

>> But frist, a quick start!

### Quick Start

1. Open your :heart: shell. (e.g. `bash`, `powershell`, ...)
2. Navigate to folder on your drive to receive the clone.
3. Use `git` to clone from GitHub:

``` git clone https://github.com/cerberix-net/api-aspnetcore-frist.git ``` 

>> No really; it's that easy. :trophy: 

4. To build, run the following commands:

``` cd src ```<br/>
``` dotnet restore ```<br/>
``` dotnet build ```<br/>

**Note:** The baseline api provides a *ping* endpoint here: `/ping` If all goes well, you will receive an `HTTP/200 OK` and *PONG* message.

### Modules

There are optional modules available. Each module has a separate branch to keep the baseline api as minimal as possible. Here are the available modules:

* [config](#config)
* [docker](#docker)
* [healthcheck](#healthcheck)
* [hangfire](#hangfire)

<a name="config"></a>
#### Config

This module adds api configuration properties report to its `/config` endpoint. Here's an example response:

```json
{
  application: "Api",
  properties: {
    assemblyName: "Api",
    version: "1.0.0.0",
    buildHash: "a05b544f74",
    buildDate: "2018-12-21 11:11 AM PST"
  },
  info: {
    config: "http://localhost:54901/Config"
  }
}
```

To install, run the following `git` command from your :heart: shell:

``` git pull origin config ``` [see footnote](#1)

<a name="docker"></a>
#### Docker

This module provides the setup necessary to deploy api to a Linux `docker` container. 

To install, run the following `git` command from your :heart: shell:

``` git pull origin docker ``` [see footnote](#1)

<a name="healthcheck"></a>
#### HealthCheck

This module provides an integration w/ cerberix:tm: health check modules, in order to verify health of dependent services which may be critical for api to function properly. 

Only the core health check package is installed by default. This keeps the baseline dependencies as minimal as possible. There are a number of optional health checkers available.
To find out more about available health checks & their example uses, please review this [doc](https://github.com/cerberix-net/util-nuget-healthcheck).

**Note:** There are other examples in the `Startup.cs` file `ConfigureServices` method.

To install, run the following `git` command:

``` git pull origin healthcheck ``` [see footnote](#1)

<a name="hangfire"></a>
#### Hangfire

This module provides an integration w/ [Hangfire.io](https://www.hangfire.io/) in order to schedule and process jobs on a background service.

It comes with *in-memory* job storage option by default. [see footnote](#2)

To install, run the following `git` command:

``` git pull origin hangfire ``` [see footnote](#1)

### Footnotes

<a name="1"></a>
1. This command will pull the module changes directly into your working branch.

![](https://pbs.twimg.com/media/DAX73pVUIAAYPz1.jpg)
 
<a name="2"></a>
2. Hangfire supports a wide variety of persistent storage providers: [Sql Server](http://docs.hangfire.io/en/latest/configuration/using-sql-server.html) & [Redis](http://docs.hangfire.io/en/latest/configuration/using-redis.html) to name a few. This configuration exercise is outside the scope of module.