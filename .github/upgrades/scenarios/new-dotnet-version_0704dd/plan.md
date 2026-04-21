# Plano de Migração: Atualização para .NET 8.0

- TOC
  - Executive Summary
  - Migration Strategy
  - Dependency Analysis
  - Project-by-Project Plans
  - Package Update Reference
  - Breaking Changes Catalog
  - Testing Strategy
  - Risk Management
  - Source Control
  - Success Criteria

---

## 1. Executive Summary

### Selected Strategy
**All-At-Once Strategy** - All projects upgraded simultaneously in a single coordinated operation.

Rationale:
- Total projects: 1 (small solution)
- Current target: .NET 5.0; Proposed target: .NET 8.0
- Assessment shows the project is SDK-style and compatible with an all-at-once upgrade
- Package updates are available for EF Core and related packages

Key goals:
- Update project `TargetFramework` to `net8.0`
- Update NuGet packages listed in assessment to suggested versions
- Restore, build and resolve compilation errors
- Run tests and validate behavior

Critical notes:
- No Git repository detected; ensure you back up the current source before applying changes
- EF Core packages require coordinated upgrades to matching major versions

## 2. Migration Strategy

### Approach
Selected: **All-At-Once** — perform an atomic upgrade of all projects and package references in a single coordinated change set.

Justification:
- Single project solution (1 project) — low risk and straightforward dependency graph
- Assessment indicates most APIs are compatible; main changes involve NuGet package versions and `TargetFramework`
- Faster path to supported runtime for hosting (Azure App Service supports .NET 8)

Scope (atomic operations):
- Update `TargetFramework` to `net8.0` in `ProductAPI.csproj`
- Update all package references to the suggested versions from assessment
- Validate and update any `Directory.Build.*` or central package management files if present
- Restore, build, and fix compilation or package-API issues
- Run test projects (if any) and ensure passing

Source control note:
- No Git repo detected. Create a backup copy or initialize source control before making changes. Prefer a single commit representing the atomic upgrade when you apply changes.

## 3. Detailed Dependency Analysis
Summary:
- Total projects: 1
- No project-to-project dependencies (leaf and root are the same project)
- No circular dependencies detected

Migration ordering:
- All projects simultaneously (single project) — no per-project ordering required beyond the atomic update

Critical dependency notes:
- EF Core packages and tooling must be upgraded together to the versions listed in the package reference section to avoid mismatches at runtime/build time


## 4. Project-by-Project Plans
### Project: ProductAPI.csproj

Current State:
- TargetFramework: `net5.0`
- SDK-style: True
- Project type: AspNetCore
- Files: 13
- Lines of code: 391

Target State:
- TargetFramework: `net8.0`
- Updated NuGet packages as listed in §5 Package Update Reference

Migration Steps (what to do, executor will perform these atomically):
1. Update `TargetFramework` in `ProductAPI.csproj` to `net8.0`.
2. Update package references to suggested versions (see §5).
3. Restore dependencies (`dotnet restore`).
4. Build solution and fix any compilation errors introduced by package/framework changes.
5. Run tests (if present) and fix test failures.
6. Verify application runs on .NET 8 locally and in the target hosting environment.

Validation Checklist:
- [ ] `ProductAPI.csproj` targets `net8.0`
- [ ] All package references updated to suggested versions
- [ ] Solution builds with 0 errors
- [ ] Tests pass
- [ ] No remaining high/critical security vulnerabilities reported for NuGet packages


## 5. Package Update Reference
Aggregate updates (from assessment):

| Package | Current Version | Target Version | Projects Affected | Reason |
|---|---:|---:|---|---|
| Microsoft.EntityFrameworkCore | 5.0.5 | 8.0.25 | ProductAPI.csproj | Framework compatibility / EF Core major upgrade |
| Microsoft.EntityFrameworkCore.Design | 5.0.5 | 8.0.25 | ProductAPI.csproj | Design tooling compatibility |
| Microsoft.EntityFrameworkCore.SqlServer | 5.0.5 | 8.0.25 | ProductAPI.csproj | SQL Server provider compatibility |
| Microsoft.EntityFrameworkCore.Tools | 5.0.5 | 8.0.25 | ProductAPI.csproj | Build/tools compatibility |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 5.0.2 | 8.0.23 | ProductAPI.csproj | Scaffolding tooling |
| Swashbuckle.AspNetCore | 5.6.3 | (compatible) | ProductAPI.csproj | Compatible — no change required |

Notes:
- All package updates recommended by the assessment must be applied as part of the atomic upgrade.
- EF Core family packages must be upgraded together to avoid runtime/compile mismatches.
- If the project uses central package management (Directory.Packages.props), update versions there instead of per-project.

## 6. Breaking Changes Catalog
Expected areas to validate (likely breaking changes or work to be done):

- EF Core 5 -> 8 changes:
  - Some APIs removed or changed; review usage of `DbContextOptionsBuilder` extensions and migration APIs
  - Behavior changes in query translation or client evaluation — run integration tests that exercise queries

- ASP.NET Core hosting changes:
  - Minimal hosting model differences are optional; existing Program.cs patterns should continue to work but validate startup behavior

- Obsolete APIs:
  - The assessment found negligible source-incompatible APIs. Any obsolete warnings should be fixed during build.

Action: During the atomic upgrade build, capture all compiler errors and map them to required code changes. Document each change as part of the execution logs.

## 7. Testing & Validation Strategy
Testing levels and expectations:

- Unit Tests: Run all unit tests (if present). Fix test code for updated package APIs as needed.
- Integration Tests: Run integration tests that exercise EF Core and database interactions.
- Build Validation: The atomic upgrade task must end with a successful build with 0 errors.
- Manual Run: Start the application locally and exercise key endpoints (e.g., `GET /api/Products`, `POST /api/Products`). These are validation steps, not automated tasks.

Test projects discovered: none explicitly listed in assessment — if test projects exist, include them in the execution step.

## 8. Risk Management
Risk summary:

- Medium — EF Core major upgrade introduces potential behavior and API changes. Mitigation: run integration tests, review query usage, and upgrade EF packages as a group.
- Low — Single project, small codebase reduces complexity.
- Critical: No Git repo detected — risk of losing current working state. Mitigation: create a repo or make a backup before applying changes.

Rollback:
- Keep a backup of the original source. If problems occur after the atomic upgrade, restore the backup and investigate failures.

## 9. Source Control Strategy
Recommendations:

- Initialize a Git repository if one does not exist and create a branch named `upgrade/dotnet8` (or your preferred name).
- Make one atomic commit that includes:
  - `TargetFramework` changes
  - Package version updates
  - Any code changes required to compile
- Use a single PR for review to simplify validation for reviewers.

If you cannot create a repo in the environment where the upgrade will be applied, create a zip backup of the current source before applying changes.

## 10. Success Criteria
The upgrade is complete when all of the following are true:

1. All projects target `net8.0`.
2. All package updates from §5 are applied.
3. Entire solution builds with 0 errors.
4. All unit and integration tests pass.
5. No critical or high-severity NuGet security vulnerabilities remain unresolved.
6. Application runs and responds to basic API calls (e.g., `GET /api/Products`).

---

*End of plan.*

---

*Gerado automaticamente — substitua placeholders com detalhes se necessário.*