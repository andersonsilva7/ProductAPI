# ProductAPI .NET 8.0 Upgrade Tasks

## Overview

This document tracks the atomic upgrade of `ProductAPI` from .NET 5.0 to .NET 8.0, including prerequisites verification, the consolidated framework/package upgrade, test execution, and a final commit. Tasks follow the plan's All-At-Once approach and reference the plan sections for specifics.

**Progress**: 3/4 tasks complete (75%) ![0%](https://progress-bar.xyz/75)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-04-14 00:39)*
**References**: Plan §2 Migration Strategy, Plan §8 Risk Management

- [✓] (1) Verify required .NET SDK/runtime version installed per Plan §2 (install if missing)
- [✓] (2) Runtime/SDK version meets minimum requirements for `net8.0` (**Verify**)
- [✓] (3) Check compatibility of configuration and central package files (e.g., `global.json`, `Directory.Packages.props`, `Directory.Build.props`) per Plan §2 (if present)
- [✓] (4) Configuration files compatible with target version (**Verify**)

### [✓] TASK-002: Atomic framework and package upgrade with compilation fixes *(Completed: 2026-04-14 00:49)*
**References**: Plan §4 Project-by-Project Plans, Plan §5 Package Update Reference, Plan §6 Breaking Changes Catalog

- [✓] (1) Update `TargetFramework` to `net8.0` in `ProductAPI.csproj` per Plan §4 (all project file changes listed in the plan)
- [✓] (2) Update NuGet package references to the target versions per Plan §5 (EF Core family and other listed packages). If central package management is used, update versions in `Directory.Packages.props` instead (Plan §5)
- [✓] (3) Restore dependencies (`dotnet restore`) for the solution/project per Plan §5
- [✓] (4) Build solution and fix all compilation errors caused by framework/package upgrades, addressing items in Plan §6 Breaking Changes Catalog
- [✓] (5) Rebuild solution to verify fixes applied; solution builds with 0 errors (**Verify**)

### [✓] TASK-003: Run tests and validate upgrade *(Completed: 2026-04-14 00:49)*
**References**: Plan §7 Testing & Validation Strategy, Plan §6 Breaking Changes Catalog

- [✓] (1) Run test projects listed in Plan §7. If no test projects are listed, run `dotnet test` on the solution file/path per Plan §7 (execute available unit and integration tests)
- [✓] (2) Fix any test failures (reference Plan §6 for common breaking-change fixes)
- [✓] (3) Re-run tests after fixes
- [✓] (4) All tests pass with 0 failures (**Verify**)

### [⊘] TASK-004: Final commit
**References**: Plan §9 Source Control Strategy

- [⊘] (1) Commit all changes with message: "TASK-004: Complete atomic upgrade to .NET 8.0"









