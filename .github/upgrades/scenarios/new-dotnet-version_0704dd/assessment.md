# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v8.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [ProductAPI.csproj](#productapicsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 1 | All require upgrade |
| Total NuGet Packages | 6 | 5 need upgrade |
| Total Code Files | 11 |  |
| Total Code Files with Incidents | 1 |  |
| Total Lines of Code | 391 |  |
| Total Number of Issues | 10 |  |
| Estimated LOC to modify | 0+ | at least 0,0% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [ProductAPI.csproj](#productapicsproj) | net5.0 | 🟢 Low | 9 | 0 |  | AspNetCore, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 1 | 16,7% |
| ⚠️ Incompatible | 0 | 0,0% |
| 🔄 Upgrade Recommended | 5 | 83,3% |
| ***Total NuGet Packages*** | ***6*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 193 |  |
| ***Total APIs Analyzed*** | ***193*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| Microsoft.EntityFrameworkCore | 5.0.5 | 8.0.25 | [ProductAPI.csproj](#productapicsproj) | Recomenda-se a atualização do pacote NuGet |
| Microsoft.EntityFrameworkCore.Design | 5.0.5 | 8.0.25 | [ProductAPI.csproj](#productapicsproj) | Recomenda-se a atualização do pacote NuGet |
| Microsoft.EntityFrameworkCore.SqlServer | 5.0.5 | 8.0.25 | [ProductAPI.csproj](#productapicsproj) | Recomenda-se a atualização do pacote NuGet |
| Microsoft.EntityFrameworkCore.Tools | 5.0.5 | 8.0.25 | [ProductAPI.csproj](#productapicsproj) | Recomenda-se a atualização do pacote NuGet |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 5.0.2 | 8.0.23 | [ProductAPI.csproj](#productapicsproj) | Recomenda-se a atualização do pacote NuGet |
| Swashbuckle.AspNetCore | 5.6.3 |  | [ProductAPI.csproj](#productapicsproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;ProductAPI.csproj</b><br/><small>net5.0</small>"]
    click P1 "#productapicsproj"

```

## Project Details

<a id="productapicsproj"></a>
### ProductAPI.csproj

#### Project Info

- **Current Target Framework:** net5.0
- **Proposed Target Framework:** net8.0
- **SDK-style**: True
- **Project Kind:** AspNetCore
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 13
- **Number of Files with Incidents**: 1
- **Lines of Code**: 391
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ProductAPI.csproj"]
        MAIN["<b>📦&nbsp;ProductAPI.csproj</b><br/><small>net5.0</small>"]
        click MAIN "#productapicsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 193 |  |
| ***Total APIs Analyzed*** | ***193*** |  |

