# TizenFX AI Maintenance Skills

A collection of Claude skills that automate maintenance of the TizenFX repo. Run periodically via Windows Scheduled Task, or invoke manually through the `claude -p` CLI.

## Skill List

| Skill | Role | Trigger |
|---|---|---|
| [`pr-code-review`](./pr-code-review/SKILL.md) | Posts code-review comments on every open PR and responds to new reviewer comments | Open PRs (excluding drafts) |
| [`pr-review-check`](./pr-review-check/SKILL.md) | Evaluates reviews on `ai-task` labeled PRs and either applies them to the code or replies (MAX_AI_ROUNDS=3) | `ai-task` labeled open PRs |
| [`refactor-analysis`](./refactor-analysis/SKILL.md) | Uses 4 evaluation lenses (Performance / Modernization / Clean Code / Coding Guidelines) to discover refactoring targets and register GitHub Issues | Rotating scan over `src/Tizen.*` directories |
| [`refactor-execute`](./refactor-execute/SKILL.md) | Picks up `ai-task` issues, dispatches to refactoring/feature mode, and opens a PR | `ai-task` labeled open Issues |
| [`issue-triage`](./issue-triage/SKILL.md) | Posts a first-pass technical answer and mentions the relevant CODEOWNERS reviewer on un-triaged issues. Comment-only — no labels, no assigning, no code changes. | Open Issues without `ai-task` and without an assignee |

## Pipeline Relationships

```
refactor-analysis → Issue(ai-task)
                        ↓
                  refactor-execute → PR(ai-task)
                                        ↓
                    ┌─── pr-code-review (applies to all PRs)
                    │
                    └─── pr-review-check (ai-task PRs — apply/respond to reviews)

(parallel track — independent of the refactor pipeline)

community Issue (no ai-task, no assignee)
    ↓
issue-triage → posts first-pass answer + mentions CODEOWNERS reviewer
    ↓
human maintainer reviews and decides (assign, label, or close)
```

## One-time Setup

### 1. Dedicated AI TizenFX Clone

**Keep this clone separate from your daily-development clone.** These skills perform destructive operations like `git reset --hard` and branch creation, which can cause dirty state / branch conflicts if mixed with work-in-progress.

```powershell
# Example: dedicated clone at C:\Users\<user>\workspace\AIAgent\TizenFX
mkdir "$env:USERPROFILE\workspace\AIAgent"
cd "$env:USERPROFILE\workspace\AIAgent"
gh repo clone samsung/TizenFX
```

### 2. Environment Variable (user-level, persistent)

Register `TIZENFX_ROOT` permanently, pointing to the dedicated clone. Takes effect in new cmd/PowerShell sessions.

**PowerShell (recommended — avoids escaping issues with special characters):**
```powershell
[Environment]::SetEnvironmentVariable(
    "TIZENFX_ROOT",
    "C:\Users\samsung1!\workspace\AIAgent\TizenFX",
    "User"
)
```

**cmd:**
```cmd
setx TIZENFX_ROOT "C:\Users\samsung1!\workspace\AIAgent\TizenFX"
```

**Verify (open a new session):**
```powershell
$env:TIZENFX_ROOT  # should print the path you set
```

### 3. `gh` CLI Authentication

The skills call the GitHub API, so authentication is required (user-level auth is inherited by the AI clone):

```powershell
gh auth login
```

### 4. (Optional) Register Windows Scheduled Task

If you want periodic execution, register the PowerShell scripts under the Scripts folder as Scheduled Tasks.

## Execution Flow

Each PS script **automatically**:

1. Verifies that `TIZENFX_ROOT` is set → aborts on error if missing
2. Moves into `TIZENFX_ROOT` and runs `git fetch origin && git checkout main && git reset --hard origin/main` → syncs main to latest
3. Reads the corresponding SKILL.md, strips the frontmatter, and pipes the body into `claude -p` via stdin

Manual invocation (example — pr-code-review):

```powershell
& "$env:USERPROFILE\Scripts\tizenfx-pr-code-review.ps1"
```

Or without the PS script:

```powershell
cd $env:TIZENFX_ROOT
git fetch origin; git checkout main; git reset --hard origin/main
Get-Content "$env:TIZENFX_ROOT\skills\pr-code-review\SKILL.md" -Raw |
    claude -p --allowedTools "Bash(gh:*,git:*,dotnet:*)"
```

> **Caution:** automatic sync assumes the **dedicated AI clone**. Never point `TIZENFX_ROOT` to a regular-development clone — `reset --hard` will wipe your work.

## Common Constraints

- `gh` CLI required (authenticated)
- `dotnet` SDK required (build verification in refactor-execute)
- Per-run cap exists (5 PRs, 5 Issues, etc.) — see each SKILL.md
- Public API signature/behavior must not change (refactor-analysis / refactor-execute)
- Tizen API Level 12+ compatibility must be maintained

## Notes When Editing Skills

- **The top `---` frontmatter block in each SKILL.md** is stripped by the PS script, and only the body is piped into `claude -p`. The frontmatter structure must be preserved.
- Cross-skill logic (e.g., the `🤖 [AI Review]` prefix convention on AI comments) is spread across multiple skills — any change must consider the full pipeline impact.
- If a skill `name:` is changed, update the PS script path (`$env:TIZENFX_ROOT\skills\<name>`) accordingly.

## Related Documents

- [Microsoft .NET Design Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines)
- [Tizen .NET official documentation](https://docs.tizen.org/application/dotnet/)
