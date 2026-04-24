---
name: pr-review-check
description: For AI-generated PRs labeled `ai-task` in TizenFX, evaluates human/AI review feedback and either applies it to the code or responds. AI comments are capped at MAX_AI_ROUNDS=3 — beyond that they are skipped entirely to prevent infinite loops.
---

## TizenFX AI PR Review Feedback Application Pipeline

### Overview
For open PRs in samsung/TizenFX that carry the `ai-task` label:
1. **Human reviewer comments** → always attempt to apply (ask if ambiguous)
2. **AI reviewer comments** (`🤖 [AI Review]` left by `pr-code-review`) → apply the decision matrix, then apply or respond
3. **Only push when the build passes**

All comments and commit messages are written in **English**.

### 🔁 Infinite-loop convergence mechanism (important)

`pr-code-review` re-reviews whenever new commits are added. So each time AI feedback is applied and committed, additional AI review can be triggered — a **bounded termination** mechanism is required.

- **Cap**: `MAX_AI_ROUNDS = 3`
- **Counter**: number of commits on the current PR branch whose message contains an `Applied-AI-Comments:` trailer
- **On exceed**: AI comments are **neither applied nor responded to — fully skipped** (recorded as `max-ai-rounds` in the report)
- **Human comments are not capped** (they are not the cause of the loop)

### Repository
- **Repo**: samsung/TizenFX (GitHub)
- **Local clone**: a pre-cloned local working directory (e.g., `~/src/TizenFX`)
- **CLI**: `gh`, `git`, `dotnet` (all authenticated/installed)

---

### Stage ①: List Target PRs

```bash
gh pr list --repo samsung/TizenFX --label "ai-task" --state open \
  --json number,title,headRefName,baseRefName,updatedAt,isDraft,url \
  --jq '[.[] | select(.isDraft | not)]
         | sort_by(.updatedAt) | reverse
         | .[] | @json'
```

- `draft` PRs are **skipped**
- Sort by most recently updated, **max 5 PRs per run**

---

### Stage ②: AI Round Count → AI Comment Handling Mode

Counting via `gh api` is possible before checkout, but `git log` after checkout is faster and more accurate. So measurement happens **after Stage ⑤**.

Handling mode:
- `AI_ROUNDS < 3` → **active**: apply the AI comment decision matrix
- `AI_ROUNDS ≥ 3` → **skip**: bypass AI comment handling entirely (no application, no response)

---

### Stage ③: Collect New Comments (separated: human / AI)

**Core rule: consider only new comments after the last commit timestamp.**

```bash
LAST_COMMIT_AT=$(gh api repos/samsung/TizenFX/pulls/{NUMBER}/commits \
  --jq '.[-1].commit.committer.date')
```

**Outdated-comment exclusion rule**: review comments with `position == null` are outdated — the diff has evolved and the anchor is gone. These are likely unrelated to the current code, so **skip them at the collection stage**. (Issue comments have no line anchor, so "outdated" does not apply.)

**Collect human comments** (review + issue):
```bash
HUMAN_REVIEW=$(gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
  --jq ".[] | select(.created_at > \"$LAST_COMMIT_AT\")
             | select(.body | startswith(\"🤖 [AI Review]\") | not)
             | select(.position != null)
             | {id, path, line, body, user: .user.login, created_at}")

HUMAN_ISSUE=$(gh api repos/samsung/TizenFX/issues/{NUMBER}/comments \
  --jq ".[] | select(.created_at > \"$LAST_COMMIT_AT\")
             | select(.body | startswith(\"🤖 [AI Review]\") | not)
             | {id, body, user: .user.login, created_at}")
```

**Collect AI comments** (review only — AI only leaves inline comments):
```bash
AI_REVIEW=$(gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
  --jq ".[] | select(.created_at > \"$LAST_COMMIT_AT\")
             | select(.body | startswith(\"🤖 [AI Review]\"))
             | select(.position != null)
             | {id, path, line, body, in_reply_to_id, created_at}")
```

---

### Stage ④: Delta Judgment — Proceed / Skip

- Human comments ≥ 1 → **proceed** (always)
- Human comments == 0 && AI mode == `active` && AI comments ≥ 1 → **proceed**
- Human comments == 0 && (AI mode == `skip` || AI comments == 0) → **skip** (`no-delta`)

---

### Stage ⑤: Branch Checkout + Merge-conflict Detection

```bash
cd {TIZEN_FX_LOCAL_PATH}
git fetch origin
gh pr checkout {NUMBER}
git pull --rebase origin {headRefName}
```

**On merge conflict:**
```bash
if git status --porcelain | grep -qE '^(UU|AA|DD)'; then
  git rebase --abort 2>/dev/null
  git reset --hard HEAD
  # Record reason `merge-conflict` and move to next PR
fi
```

After checkout, **measure AI round count** (to finalize Stage ② decision):
```bash
AI_ROUNDS=$(git log "origin/{baseRefName}..HEAD" \
  --grep="^Applied-AI-Comments:" --oneline | wc -l)
```

---

### Stage ⑥: Apply Human Comments

For each human comment:

1. Inspect `path`, `line`, `body` to understand the requested change
2. Evaluate from a `.NET / C# / Tizen` perspective
3. Action:
   - **Valid** → modify the code (add the comment id to `Applied-Human-Comments`)
   - **Ambiguous** → do not modify; instead ask a question via reply in Stage ⑨
   - **Clearly incorrect** → do not modify; reply in Stage ⑨ with a factual disagreement

**Application principles:**
- **No public API signature changes**
- Re-verify any change that could break the build

---

### Stage ⑦: AI Comment Handling (only when AI mode == `active`)

If AI mode is `skip`, **skip this entire stage**. Do not even leave response comments.

#### 7-1. Priority Filter (first pass)

**"Not every AI comment deserves to be applied."** Only meaningful, reasonable suggestions qualify. Because pr-code-review leaves a severity marker (🔴/🟡) on each comment, reuse it as the first-pass filter.

| AI comment type | Apply? | Notes |
|---|---|---|
| 🔴 **Critical** (bugs, broken build, public API compatibility, null safety, memory leaks) | **Apply candidate** (proceed to decision matrix) | Highest priority |
| 🟡 **Suggestion** + objectively measurable improvement (performance, obvious readability, duplicate removal, modern C# feature adoption) | **Apply candidate** | |
| 🟡 **Suggestion** + subjective preference (naming taste, style) | **Ignore** | No response either |
| No marker / nitpick-ish | **Ignore** | No response either |

Ignored items do not receive a response comment either (to prevent noise). This mirrors pr-code-review's "no-nitpick" policy.

#### 7-2. Decision Matrix (applied only to items passing the first-pass filter)

| Verdict | Action | Response template |
|---|---|---|
| Valid + unapplied | Modify code | `Addressed in {SHA}` (reply in Stage ⑨) |
| Already addressed (a previous commit's diff already resolved the finding) | Response only | `Already addressed in {SHA}` |
| Misjudged / not applicable | Response only | `Respectfully disagree: {technical reason}` |

"Already addressed" judgment guide:
- Check the diff of the last ~3 commits at that `path:line`
- See whether the flagged pattern has already been removed/improved
- When unsure, do **not** classify as "valid + unapplied" — prefer **"already addressed" for safety** (loop prevention)

Applied AI comment IDs are added to the `Applied-AI-Comments` list.

---

### Stage ⑧: Build Verification (only the changed csproj, selective build)

Performed only when there are applied changes. A full TizenFX build takes a very long time, so **only the `.csproj` that owns each changed file is built**.

#### 8-1. Locate Affected csprojs

```bash
# Current staged/working-tree changed file list
CHANGED_FILES=$(git diff --cached --name-only; git diff --name-only)

# Find the first .csproj by walking up from each file
find_parent_csproj() {
  local dir
  dir=$(dirname "$1")
  while [ "$dir" != "." ] && [ "$dir" != "/" ]; do
    local csproj
    csproj=$(ls "$dir"/*.csproj 2>/dev/null | head -1)
    [ -n "$csproj" ] && echo "$csproj" && return
    dir=$(dirname "$dir")
  done
}

CHANGED_CSPROJS=$(echo "$CHANGED_FILES" | while read -r f; do
  [ -n "$f" ] && find_parent_csproj "$f"
done | sort -u)
```

#### 8-2. Run the Build

```bash
BUILD_EXIT=0
BUILD_LOG=/tmp/build-{NUMBER}.log
: > "$BUILD_LOG"

if [ -z "$CHANGED_CSPROJS" ]; then
  # Changes live outside any csproj (docs, .github, etc.) — skip build but treat as pass
  echo "No csproj affected; skipping build." | tee -a "$BUILD_LOG"
else
  for csproj in $CHANGED_CSPROJS; do
    echo "=== Building: $csproj ===" | tee -a "$BUILD_LOG"
    dotnet build "$csproj" -c Release 2>&1 | tee -a "$BUILD_LOG"
    rc=${PIPESTATUS[0]}
    [ "$rc" -ne 0 ] && BUILD_EXIT=$rc
  done
fi
```

> **Limitations of selective builds**: compile errors in downstream projects (projects that reference the changed csproj) cannot be detected here. Public API signature changes are already forbidden by this pipeline, so this is usually safe; anything edge-casey is caught by CI. This step only serves as a "quick first gate".

#### 8-3. Build Failure Handling (EXIT != 0)

1. Roll back all local changes:
   ```bash
   git reset --hard origin/{headRefName}
   ```

2. Report failure on the PR:
   ```bash
   gh pr comment {NUMBER} --repo samsung/TizenFX --body "🤖 [AI Review]
   Attempted to address review feedback but build failed. Changes not pushed — manual review required.

   <details><summary>Build error excerpt</summary>

   \`\`\`
   {first 3–5 lines of the error, including which csproj failed}
   \`\`\`
   </details>"
   ```

3. Record reason as `build-failed` and move to the next PR.

---

### Stage ⑨: Commit + Push + Response Comments

**Commit message convention** (combine trailers based on what was applied):

```
Address review feedback

{one-line summary of what changed}

Applied-Human-Comments: {id,id,...}
Applied-AI-Comments: {id,id,...}
```

- Human only → `Applied-Human-Comments:` only
- AI only → `Applied-AI-Comments:` only (this is required for round counting +1)
- Both → both

```bash
git add -A
git commit -m "{format above}"
git push origin HEAD
```

**Response comments:**

Human application summary (issue comment):
```bash
gh pr comment {NUMBER} --repo samsung/TizenFX --body "🤖 [AI Review]
Addressed review feedback in commit {SHORT_SHA}. Summary: {summary}"
```

Individually reply to each AI comment via `in_reply_to` (using the Stage ⑦ template):
```bash
gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
  -f body="🤖 [AI Review]
{response template}" \
  -F in_reply_to={AI_COMMENT_ID}
```

**Ambiguous human comments left for question** — reply with a question:
```bash
gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
  -f body="🤖 [AI Review]
{question — 1–3 sentences}" \
  -F in_reply_to={HUMAN_COMMENT_ID}
```

---

### Constraints
- Target label: **`ai-task`**
- Draft PRs are skipped
- **`MAX_AI_ROUNDS = 3`**: beyond the cap, AI comments are fully skipped (no application/response). Human comments are not capped.
- **Commit-message trailer convention is mandatory** (`Applied-Human-Comments:` / `Applied-AI-Comments:`) — the basis for round counting and traceability
- **AI comment application priority filter**: only 🔴 Critical / 🟡 Suggestion items with objective improvement are applied. Subjective preferences/nitpicks are ignored without response.
- **Outdated comments are excluded at collection** (review comments with `position == null`)
- On build failure: **local rollback, do not push**
- Build is **only the csproj containing the changed file** (no full-repo build)
- On merge conflict: skip (`rebase --abort` + `reset --hard`)
- **No public API signature changes**
- When "already addressed" vs "unapplied" is ambiguous, **classify as "already addressed" for safety** (loop prevention)
- **Max 5 PRs per run**
- All comments and commit messages are in **English**
- Every AI-authored comment starts with `🤖 [AI Review]`

### Reporting
- **Applied**: PR number, link, commit SHA, human/AI comment counts (separated)
- **Partial application**: separately record applied / asked-question / declined (disagree)
- **Skipped**: PR number + reason
  - `no-delta`: no eligible items
  - `draft`: draft PR
  - `merge-conflict`: merge conflict
  - `build-failed`: build failed (local rollback performed)
  - `quota-5`: per-run cap of 5 reached
- **AI round cap reached**: separate section (PR number + current round count) — informational report; AI comments were not processed
- **Errors**: PR number + error summary
