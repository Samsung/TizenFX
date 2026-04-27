---
name: issue-triage
description: For TizenFX issues that lack the `ai-task` label and have no assignee, posts an English first-pass technical answer plus a CODEOWNERS-based reviewer mention. Comments only — never assigns, never edits labels, never modifies code.
---

## TizenFX Issue Triage Pipeline

### Overview
For open issues in `samsung/TizenFX` that have **not** been claimed by a human owner and are **not** already in the AI execution queue (`ai-task` label):

1. Post a **first-pass technical response** in English summarising the issue and offering an initial analysis or pointer.
2. Identify the most likely code area, look up `.github/CODEOWNERS`, and **mention** the matching reviewer(s) so they can self-assign.

This skill **never**:
- modifies code,
- creates PRs or branches,
- assigns issues (`gh issue edit --add-assignee`),
- adds or removes labels,
- closes issues.

It only **comments**. All decisions stay with the humans involved.

All comments are written in **English** and prefixed with `🤖 [AI Triage]` so future runs can skip already-triaged issues.

### Repository
- **Repo**: samsung/TizenFX (GitHub)
- **CLI**: `gh` CLI (authenticated)
- **CODEOWNERS path**: `.github/CODEOWNERS` in the repo working tree

### Constants

```
MAX_ISSUES_PER_RUN   = 5
STALE_THRESHOLD_DAYS = 90        # Issues with updatedAt older than this are skipped
DEFAULT_FALLBACK     = @JoonghyunCho   # When CODEOWNERS lookup fails
COMMENT_PREFIX       = 🤖 [AI Triage]
```

---

### Pipeline Flow

```
⓪ Discover triage candidates
  → ① Apply skip filters
    → ② For each survivor (max 5):
      a. Fetch issue body + comments
      b. Identify likely code area
      c. CODEOWNERS lookup
      d. Draft first-pass technical response
      e. Post comment (mention only — no assign, no label)
```

---

### Stage ⓪: Discover Open Triage Candidates

```bash
gh issue list --repo samsung/TizenFX --state open \
  --json number,title,createdAt,updatedAt,assignees,labels,author \
  --jq '[.[]
         | select((.labels // []) | map(.name) | index("ai-task") | not)
         | select((.assignees // []) | length == 0)]
        | sort_by(.updatedAt) | reverse'
```

- Drops issues with `ai-task` label (handled by `refactor-execute`)
- Drops issues with any assignee (someone is already on it)
- Sorted by `updatedAt` descending (most recently active first)

---

### Stage ①: Apply Skip Filters

Filter the candidate list down further. **In order**, drop an issue when any of these holds:

1. **Already triaged by AI** — issue has at least one comment whose body starts with `🤖 [AI Triage]`.
   ```bash
   gh issue view {N} --repo samsung/TizenFX --comments \
     --json comments --jq '.comments[] | select(.body | startswith("🤖 [AI Triage]"))' \
     | head -1
   ```
   Non-empty result → skip.

2. **Stale** — `updatedAt` is older than `STALE_THRESHOLD_DAYS` (90 days).
   - Compute: `(now - updatedAt) in days`. If `> 90`, skip.
   - Reason: Re-engaging a long-dormant thread creates noise; re-activation is a human decision.

3. **Author is a bot** — `author.login` ends with `[bot]` or matches a known bot list (`dependabot`, `renovate`, `github-actions`).
   - Skip; bots typically don't need triage answers.

After filters, take **up to `MAX_ISSUES_PER_RUN` (5)** issues, oldest-`updatedAt`-first among the survivors so we drain the older ones first.

---

### Stage ②a: Fetch Issue Detail

For each selected issue:

```bash
gh issue view {N} --repo samsung/TizenFX --comments \
  --json title,body,comments,labels,author
```

Read **all** comments (not only the body) so we don't repeat what someone has already answered.

---

### Stage ②b: Identify Likely Code Area

Goal: produce a list of **candidate repo paths** for CODEOWNERS lookup.

Heuristics (apply all that match):

1. **Explicit code references in body** — file paths like `src/Tizen.Sensor/...`, `Tizen.NUI.Layout`, fully-qualified class names like `BluetoothErrorFactory`.
2. **Title keywords** — namespace fragments (`NUI`, `Sensor`, `Bluetooth`, `Application`) map to `src/Tizen.NUI/`, `src/Tizen.Sensor/`, etc.
3. **Code blocks** — `using Tizen.Foo;` reveals the namespace, which maps to a `src/Tizen.Foo/` directory (verify by `ls src/Tizen.Foo*` if uncertain).

If **no path can be inferred**, emit a single placeholder candidate of `(unknown)` and proceed to Stage ②c with the fallback owner.

Cap candidate paths at **3** to keep CODEOWNERS lookup focused — the most-mentioned path wins ties.

---

### Stage ②c: CODEOWNERS Lookup

Read `.github/CODEOWNERS` from the local repo working tree (already synced by the launcher).

Standard CODEOWNERS semantics:

- Each non-comment, non-empty line: `<path-pattern> @owner1 @owner2 ...`
- **Last matching rule wins** (per GitHub's CODEOWNERS spec).
- Inline `#` comments are stripped — `@user1 #@user2` means owner is `@user1` only.

Algorithm:

1. Parse CODEOWNERS into ordered list of `(pattern, owners[])` tuples.
2. For each candidate path from Stage ②b:
   - Walk the rule list **in reverse** and pick the first rule whose pattern matches the path. (= last-match-wins.)
   - Collect the owner set.
3. Combine owner sets across candidate paths; deduplicate; cap at **3 owners** to prevent mass-pinging.
4. **Fallback** — if no rule matched any candidate path, mention `DEFAULT_FALLBACK` (= `@JoonghyunCho`) and note in the comment that auto-routing failed.

---

### Stage ②d: First-Pass Technical Response

The comment is **English** and structured. Default template:

```markdown
🤖 [AI Triage]

**Summary**
{1-2 sentence restatement of the filer's question or reported behaviour. Show that the AI understood the issue.}

**Initial analysis**
{2-6 sentences of substantive technical content:
 - For "how do I" questions → a concrete answer or pointer to an API / sample.
 - For bug reports → a hypothesis about the cause and what the reporter could try
   (logs, repro steps, version checks).
 - For feature requests → acknowledge feasibility constraints if obvious (e.g.,
   "This requires native daemon support and is out of scope for the .NET binding").
 If the issue is too ambiguous to analyse meaningfully, ask **one** specific
 clarifying question instead of guessing.}

**Likely area & reviewer**
- Code area: `{src/Tizen.Foo/}` (or "unable to determine" if unknown)
- Suggested reviewer(s): {@user1 @user2}

---
*This is an automated first-pass triage. The mentioned maintainer(s) have not been
assigned — they will pick up the issue if appropriate. If the routing is wrong,
please re-direct or remove the mention.*
```

If the fallback owner was used:

```markdown
**Likely area & reviewer**
- Code area: unable to determine from issue contents
- @JoonghyunCho — auto-routing via CODEOWNERS could not match a specific area;
  flagging you for manual triage.
```

**Tone constraints:**
- No promises ("This will be fixed in vNN") — AI cannot commit on maintainers' behalf.
- No follow-up reminders or pings to the filer.
- No condescension; assume the filer made a good-faith report.
- Don't speculate beyond the evidence — if uncertain, say "this looks like X but I'm not sure" rather than asserting.

---

### Stage ②e: Post the Comment

```bash
gh issue comment {N} --repo samsung/TizenFX --body-file triage_comment.md
```

After posting, **do nothing else** — no labels, no assignees, no follow-up. Move to the next issue.

---

### Constraints (hard rules)

- **At most `MAX_ISSUES_PER_RUN` (5) issues per run.** Exit unconditionally after that.
- **Never** call `gh issue edit` (no labels, no assignees, no state changes).
- **Never** open or modify code files in the repo. This skill is comment-only.
- **Never** post a second `🤖 [AI Triage]` comment on the same issue.
- If `gh` exits non-zero on any sub-step for an issue, log it, **skip that issue**, and continue with the next survivor — do not retry indefinitely.

### Result Report

At the end of the run, print a short structured report:

```
### Stage ⓪: Candidates discovered
{N issues considered}

### Stage ①: Survivors after filters
{N issues passed: ai-task=excluded, assignee=excluded, already-triaged=excluded, stale=excluded, bot-author=excluded}

### Stage ②: Triage actions
- #{num} → mentioned @{owner}, area `{path}`, status: posted
- #{num} → fallback to @JoonghyunCho (no CODEOWNERS match), status: posted
- #{num} → skipped (gh comment posting failed: {reason})

### Outcome
- Triaged: {N}
- Skipped: {N}
- Failed: {N}
```
