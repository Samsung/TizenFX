---
name: refactor-execute
description: Automatically processes TizenFX ai-task issues (dispatching between refactoring/feature modes) and creates a PR.
---

## TizenFX AI Bot Universal Task Pipeline (Refactoring / Feature Combined)

### Overview
A universal automation pipeline that sequentially processes GitHub Issues labeled `ai-task`.
The task mode is dynamically determined based on the `[Type: Refactoring]` keyword in the issue body or explicit instructions in comments.

### Repository
- **Repo**: samsung/TizenFX (GitHub)
- **CLI**: `gh` CLI (authenticated)

---

### Pipeline Flow

```
⓪ Discover target Issues (ai-task)
  → ① Determine task mode (Refactoring vs Feature/Bug)
    → [Refactoring] Refactor + guarantee API preservation → Build → Benchmark → PR
    → [Feature/Bug] Implement feature + tests → Build → PR
```

---

### Stage ⓪: Universal Issue Discovery

```bash
gh issue list --repo samsung/TizenFX --label "ai-task" --state open --json number,title,createdAt --jq 'sort_by(.createdAt) | .[]'
```
- Process the oldest issue first
- **Process at most 2 issues per run** (to maintain quality)
- Always terminate after 2 issues even if more are pending

---

### Stage ①: Mode Determination and Feedback Absorption

Fetch the selected issue details and comments:
```bash
gh issue view {NUMBER} --repo samsung/TizenFX --comments
```

**Mode dispatch criteria:**
1. **[Refactoring mode]**: The issue body contains `[Type: Refactoring]`, or comments explicitly request refactoring/optimization.
   → Apply benchmark and rollback stages.
2. **[Feature-centric mode]**: Any other bug fix or feature request.
   → Skip benchmark, focus on unit test validation.

---

### Stage ②: Branch Creation and Pre-Validation

1. Clone or update the repository:
   ```bash
   gh repo clone samsung/TizenFX || (cd TizenFX && git checkout main && git pull)
   ```
2. Create a working branch:
   ```bash
   git checkout -b ai-task/issue-{ID}
   ```
3. **[Refactoring mode]** Self-reflection on potential API compatibility breaks:
   - Enumerate public API surface of the target area
   - Verify by design that the API signature remains unchanged after the refactor

---

### Stage ③: Code Modification

- Modify source per the analysis/plan in the issue
- **Refactoring mode**: Strictly preserve state/behavior, keep public API signatures intact
- **Feature-centric mode**: Implement per spec, account for edge cases

---

### Stage ④: Build Verification and Testing

1. Build verification (required):
   ```bash
   dotnet build
   ```
   → Must have 0 errors. Fix errors and rebuild if any occur.

2. **[Feature-centric mode]** Unit tests:
   ```bash
   dotnet test
   ```
   → Existing tests must pass. Add missing test cases when necessary.

---

### Stage ⑤: [Refactoring Mode Only] Benchmark and Rollback Validation

1. Add a comparative benchmark to `test/Tizen.Benchmark.Gallery/`
2. Attempt to deploy and run on an `sdb` device

**When sdb-related errors/issues occur (device not connected, deploy failure, execution error, etc.):**
- **Pass (skip)** the benchmark stage
- Post a comment on the PR explaining why the benchmark was skipped:
  ```bash
  gh pr comment {PR_NUMBER} --repo samsung/TizenFX --body "⚠️ **Benchmark skipped**: Encountered an issue with sdb device connection/deployment/execution, so the benchmark could not be run. Manual benchmark verification is required. Error: {error summary}"
  ```
- Also note "Benchmark: skipped (sdb error)" in the PR Verification section

**On successful execution:**
- If the execution log shows a **performance regression of 5% or more (median)**, automatically roll back the code:
  ```bash
  git checkout -- .
  ```
  → After rollback, retry from Stage ③ with a different approach (max 1 retry)
  → If a regression persists on retry, leave a comment on the issue and move to the next issue

---

### Stage ⑥: PR Creation and Issue Linking

0. Perform a final .NET expert review over the full set of changes.

1. Commit and push changes:
   ```bash
   git add -A
   git commit -m "Refactor: {change summary} (Fixes #{ID})"
   git push origin HEAD
   ```

2. Write the PR description (pr_description.md):
   ```markdown
   ## Summary
   {Summary of the changes}

   ## Changes
   {List of changed files and what changed in each}

   ## Mode
   {Refactoring / Feature}

   ## Verification
   - [ ] Build: passed
   - [ ] Tests: {passed / N/A}
   - [ ] Benchmark: {result summary / skipped (sdb error: reason) / N/A}

   Fixes #{ID}
   ```

3. Create the PR:
   ```bash
   gh pr create --repo samsung/TizenFX --title "[AI Task] {task summary}" --body-file pr_description.md --label "ai-task"
   ```

3-1. Verify and ensure the label is applied:
```bash
   gh pr view --repo samsung/TizenFX --json labels --jq '.labels[].name' | grep -q "ai-task" || \
   gh pr edit --repo samsung/TizenFX --add-label "ai-task"
```

4. After processing the current issue, if fewer than 2 issues have been handled and more are queued, return to Stage ⓪. **Always terminate once 2 issues have been processed.**

---

### Constraints
- **At most 2 issues per run** (this limit is absolute)
- When performing refactoring-only changes, behavior preservation is mandatory
- If build errors cannot be resolved in 2 consecutive attempts, comment on the issue and skip it
- Prefer small, reviewable PRs over large sweeping changes

### Reporting
- Processed issue numbers and links
- Created PR links
- Task mode per issue (Refactoring / Feature)
- Benchmark result (where applicable) or skip reason
- Reason for any skipped issues
