---
name: refactor-analysis
description: Automatically scans the TizenFX codebase on a rotating schedule to discover .NET 8 / C# 12+ refactoring targets and register them as GitHub Issues.
---

## TizenFX Refactoring Target Discovery and Issue Registration Pipeline

### Overview
A pipeline that scans the TizenFX codebase for .NET 8 and C# 12+ modernization/optimization opportunities, drafts concrete application plans, and automatically registers them as GitHub Issues.
Each created issue explicitly states that it is a `refactoring` objective.

### Repository
- **Repo**: samsung/TizenFX (GitHub)
- **CLI**: `gh` CLI (authenticated)

---

### Pipeline Flow

```
① Auto-select target area and scan → ② Optimization feasibility analysis (Self-Reflection)
  → [Pass] ③ Draft refactoring application plan → ④ Auto-register GitHub Issue
  → [Reject] Discard (low ROI / high risk)
```

---

### Stage ①: Auto-select Target Area and Scan

**Automatic directory rotation logic:**
Because the scan scope is broad, the scan area is automatically rotated on every run.

1. First run `gh repo clone samsung/TizenFX`, or `git pull` the existing clone to sync
2. Collect the main namespace directories under `src/`:
   ```bash
   ls -d src/Tizen.*/
   ```
3. Check which directories have already been analyzed by inspecting existing `ai-task` labeled issues:
   ```bash
   gh issue list --repo samsung/TizenFX --label "ai-task" --state all --json title --jq '.[].title' | grep -oP '\[Scope: [^\]]+\]'
   ```
4. **Prioritize directories that have not yet been scanned**, but once every directory has been covered once, re-scan starting with the one scanned longest ago
5. Scan only **1–2 directories per run** (to allow for in-depth analysis)

**Scan Philosophy — 4 Evaluation Lenses (lens-based, not category-based)**

Rather than "hunting" for a fixed list of patterns, **observe the code through 4 evaluation lenses**. A single finding may hit multiple lenses at once; the more it overlaps, the higher its grade.

In priority order:

#### 🚀 Lens 1: Performance (Highest Priority)
The most important lens. Target measurable performance improvements.
- **Reduce allocations**: `ToList/ToArray` in hot paths, `new` inside loops, boxing/unboxing, closure allocation (lambda capture)
- **Buffer handling**: opportunities to apply `Span<T>`/`Memory<T>`, `ArrayPool<T>`, `stackalloc` (small fixed size)
- **New .NET 8 types**: `FrozenDictionary`/`FrozenSet` (read-only lookup), `SearchValues<T>` (char search), `CollectionsMarshal`
- **Task optimization**: apply `ValueTask` (hot path), use `IAsyncEnumerable`, remove `.Result`/`.Wait()` (also prevents deadlocks)
- **LOH / GC pressure**: allocation patterns for arrays ≥85KB, short-lived large objects

#### 🆕 Lens 2: .NET 8 / C# 12 Modernization
Modernize with the latest language and runtime features.
- **C# 12**: Collection expressions `[1, 2, ..x]`, primary constructors (class/struct), `ref readonly` parameters
- **C# 11**: `required` members, generic math, raw string literals `"""..."""`
- **C# 10~9**: file-scoped namespaces, `record struct`, switch expression, `init` accessor
- **.NET 8 APIs**: `ArgumentException.ThrowIfNull(x)`, `ArgumentOutOfRangeException.ThrowIfNegative`, `TimeProvider`
- **Nullable reference types**: introduce `#nullable enable`, ensure NRT consistency

#### 🧹 Lens 3: Clean Code
Improve readability and maintainability (within internal/private scope).
- Eliminate duplication (DRY), extract common logic
- Split methods that violate single responsibility (one method doing too much)
- Reduce deep nesting / complexity (guard clauses, early return)
- Remove dead code, unused private members
- Improve naming — **limited to internal/private only** (public API renames forbidden)

#### 📐 Lens 4: .NET Coding Guidelines
Adherence to official guidelines. Based on [Microsoft Design Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines).
- async/await consistency: remove `.Result`, `.Wait()` (cause deadlocks)
- IDisposable pattern: `using` declaration, consistent propagation
- Exception handling: overly broad `catch (Exception)`, swallowed exceptions, mismatched exception types
- Naming conventions (public APIs are immutable; only internals are in scope)

**Lens overlap → grade ↑**: if a finding hits both Performance and Modernization, it ranks higher than a single-lens finding (see Stage ②).

**Quantitative heuristics** (to minimize subjective judgment):
- switch conversion candidates: 5+ `case` branches, each ≥ 3 lines
- allocation inside loops: `new` or LINQ chain inside `for/foreach`
- heavy methods: cyclomatic complexity ≥ 10, or ≥ 100 lines

---

### Stage ②: Optimization Feasibility Analysis and Grade Assignment

#### 2-1. Safety Gate

For each finding, self-verify against the following criteria:

1. Can the **Public API Signature** be preserved? (no signature changes)
2. Can the **Public API Behavior** be preserved? (no behavior changes)
3. For Performance-lens findings, is a meaningful benchmark benefit expected?
4. Does it avoid affecting **Native Interop / P/Invoke** marshalling?
5. Does it maintain **Tizen API Level 12+** compatibility? (when using new .NET APIs, confirm support per Tizen API Level)

→ **Fails even one of these → discard** (low ROI / high risk)

#### 2-2. Grade Assignment

For items passing the gate, assign a grade using this matrix.

| Grade | Condition | Action |
|---|---|---|
| 🔴 **Critical** | Performance lens + hot path + **measurable numerical improvement** expected, OR bug risk (async deadlock, missing IDisposable, NullReferenceException path) | Discover ✓ prioritize PR |
| 🟡 **Improvement** | Modernization / Clean Code / Coding Guidelines lens with clear readability/maintainability gains, OR a Performance improvement that is not on a hot path | Discover ✓ |
| 🟢 **Nice-to-have** | Style preference, plain naming taste, marginal theoretical improvement, weak lens match | **Exclude** (do not register) |

**Grade tie-breaking rules:**
- If 🔴 Critical is claimed without measurable numerical evidence → **downgrade** to 🟡 Improvement
- **Two or more overlapping lenses** can promote the grade by one step
  - e.g., Modernization only → 🟡, but Performance + Modernization → consider 🔴
- **Bug risk** accompanied (async deadlock, swallowed exception, missing dispose, etc.) → **auto-🔴**
- When in doubt, classify as **🟢 conservatively** (exclude from discovery). Over-discovery is worse than under-discovery.

**"Hot path" judgment guide:**
- Rendering loops, event handlers, frequently called property getters/setters
- User interaction paths (touch/gesture/layout)
- Initialization paths are *not* hot paths (avoid applying performance criteria to one-shot code)

---

### Stage ③: Draft Refactoring Application Plan

For items that pass, author a Markdown plan.

**Required plan structure:**
```markdown
[Type: Refactoring]
[Scope: {scanned directory name, e.g., src/Tizen.NUI}]
[Priority: 🔴 Critical | 🟡 Improvement]
[Lens: Performance, Modernization, Clean Code, Coding Guidelines] (list all applicable lenses)

## Observation
{Describe the current state of the code and the problem pattern}

## Problem
{Why refactoring is needed — describe from each applicable lens's perspective}

## Proposed Improvement
{Concrete refactoring approach with Before/After code snippets}

### Target Files
- `{file path 1}`
- `{file path 2}`

## Expected Impact (Quantitative Metrics)
{**Required** for 🔴 Critical; write if possible for 🟡 Improvement}
- e.g., `allocation per call: 3 → 0`, `execution time: ~120ns → ~80ns`, `LOH allocations: eliminated`
- For non-Performance lenses: readability/complexity metrics (cyclomatic complexity, LOC, etc.)

## API Compatibility Check
- Public API signature change: none / {description}
- Behavior change: none / {description}
- Tizen API Level floor: {maintained / raise required — specify}

## Impact Scope
- Number of call sites for the modified symbol (measured via rg): `approx. N locations`
- Distinguish impact within the same assembly vs. other assemblies
- If >100 sites, recommend splitting the scope
```

**Important:**
- The top of the body must include `[Type: Refactoring]`, `[Priority: ...]`, and `[Lens: ...]` so that the downstream agent (refactor-execute) can recognize the mode/priority.
- If 🔴 Critical has **no quantitative metric** in "Expected Impact", send it back to Stage ② for re-evaluation and downgrade to 🟡.

---

### Stage ④: GitHub Issue Auto-Registration

**Duplicate check (required before registration):**
```bash
gh issue list --repo samsung/TizenFX --label "ai-task" --state open --json title,body --jq '.[] | .title + " " + .body'
```
→ Skip registration if an issue for the same file/pattern already exists

**Issue registration:**
```bash
gh issue create --repo samsung/TizenFX \
  --title "[AI Refactoring] {finding name} [Scope: {directory}]" \
  --body-file issue_plan.md \
  --label "ai-task"
```

---

### Constraints
- Create at most **5** issues per run (🔴 Critical first, then 🟡 Improvement)
- 🟢 Nice-to-have items are **not registered** (excluded at discovery)
- 🔴 Critical grade **must include a quantitative metric** (expected impact figures). Without one, downgrade to 🟡 or exclude.
- Scan priority: **Performance > Modernization > Clean Code > Coding Guidelines** (lens order)
- For items hitting multiple lenses, **list all applicable lenses** in `[Lens: ...]` in the issue body
- Public API signature/behavior changes are forbidden (must pass the safety gate)
- Tizen API Level 12+ compatibility must be maintained
- Duplicate issues must not be registered (always verify existing issues before registering)
- Include the scanned directory and date in the issue title so scans can be traced

### Reporting
- **Scan info**: directories scanned in this run, directories scheduled for the next run
- **Grade distribution**: 🔴 Critical N / 🟡 Improvement M (registered counts)
- **Lens distribution**: Performance X, Modernization Y, Clean Code Z, Coding Guidelines W (overlap counted)
- **Created issue list**: number, title, link, grade, lenses
- **Discard summary**:
  - Safety gate failures: N (classified by reason: API signature / behavior / Tizen API Level / interop / negligible impact)
  - 🟢 Nice-to-have classifications: M (brief reason)
- **Anomalies**: number of items that claimed 🔴 Critical but were downgraded to 🟡 due to missing quantitative metrics (if any)
