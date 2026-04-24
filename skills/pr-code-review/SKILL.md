---
name: pr-code-review
description: Performs code review on every open PR of TizenFX and replies with technical responses to new comments left by other reviewers. Never asks the author/reviewers for action and never leaves follow-up reminders.
---

## TizenFX PR Code Review Pipeline

### Overview
For every open PR in the samsung/TizenFX repository:
1. Perform a code review and leave improvement suggestions as comments.
2. Respond, from a technical perspective, to **new questions/requests left by other reviewers**.

All comments are written in **English**.

**Role boundaries (important):**
- We provide **technical feedback and responses** on the code.
- **Do not ask the author or other reviewers for answers/actions.**
- **Never leave follow-up / reminder / status-check comments on our own previous reviews.**
  - ❌ Forbidden examples: `Follow-up on @X review (unanswered)`, `@author Could you please address...`, "please confirm", "checking review status" style
  - Reason: such comments are merely pings that pressure people and add no value to the code
 
### Repository
- **Repo**: samsung/TizenFX (GitHub)
- **CLI**: `gh` CLI (authenticated)

---

### Stage ①: List Open PRs

```bash
gh pr list --repo samsung/TizenFX --state open \
  --json number,title,author,updatedAt,isDraft,labels \
  --jq '[.[] | select(.isDraft | not)]
         | sort_by(.updatedAt) | reverse
         | .[] | "\(.number)\t\(.title)\t\(.author.login)\t\(.updatedAt)"'
```

- `draft` PRs are **skipped**
- `ai-task` labeled PRs are reviewed on the same basis (serves as an objective second-pass review of AI-authored PRs)
- Sort by most recently updated, **max 5 PRs per run**

---

### Stage ②: Delta Judgment — Skip / Proceed

**Core rule: if no new commits or human comments have appeared since the last AI activity, skip immediately.**
(This rule fundamentally blocks the "leave follow-up on a PR where nothing changed" pattern.)

For each PR:

1. Look up the most recent AI activity timestamp (both review and issue comments):
   ```bash
   LAST_AI_AT=$(
     {
       gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
         --jq '.[] | select(.body | startswith("🤖 [AI Review]")) | .created_at'
       gh api repos/samsung/TizenFX/issues/{NUMBER}/comments \
         --jq '.[] | select(.body | startswith("🤖 [AI Review]")) | .created_at'
     } | sort | tail -1
   )
   ```

2. Check for **new commits** and **new human comments** after that timestamp:
   ```bash
   NEW_COMMITS=$(gh api repos/samsung/TizenFX/pulls/{NUMBER}/commits \
     --jq ".[] | select(.commit.committer.date > \"$LAST_AI_AT\") | .sha" | wc -l)

   NEW_HUMAN_COMMENTS=$(
     {
       gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
         --jq ".[] | select(.created_at > \"$LAST_AI_AT\")
                    | select(.body | startswith(\"🤖 [AI Review]\") | not) | .id"
       gh api repos/samsung/TizenFX/issues/{NUMBER}/comments \
         --jq ".[] | select(.created_at > \"$LAST_AI_AT\")
                    | select(.body | startswith(\"🤖 [AI Review]\") | not) | .id"
     } | wc -l
   )
   ```

3. **Decision**:
   - `LAST_AI_AT` is empty → **new PR**. Proceed to Stage ③ (full-diff review). Stage ④ not needed.
   - `NEW_COMMITS == 0 && NEW_HUMAN_COMMENTS == 0` → **skip**. Reason: `no-delta`.
   - `NEW_COMMITS > 0` → proceed to Stage ③ (delta-range review).
   - `NEW_HUMAN_COMMENTS > 0` → proceed to Stage ④ (respond only to new human comments).
   - If both, run Stage ③ and Stage ④.

---

### Stage ③: Write Code Review Comments

Review from the perspective of a .NET / C# / Tizen expert developer.

**Review priorities:**
- 🔴 **Critical** (must flag): bugs, broken builds, public API compatibility issues, null safety, memory leaks, **missing public API XML documentation**
- 🟡 **Suggestion**: readability, modern C# 12 syntax, duplicate removal, obvious performance issues (e.g., heavy allocation inside loops)
- **No nitpicks**: whitespace/style/naming preferences that do not affect behavior are not mentioned

**Public API documentation check (🔴 Critical):**
- In the PR diff, identify **newly added or signature-changed public/protected members** (class, struct, interface, enum, method, property, event, field, delegate).
- If the member is **missing an XML doc comment (`///`)** or is missing required tags, always flag it.
- Required tags:
  - `<summary>` — all public/protected members
  - `<param name="...">` — every parameter
  - `<returns>` — non-void methods, property getters
  - `<exception cref="...">` — explicitly thrown exceptions
  - `<typeparam name="...">` — generic types/methods
  - `<since_tizen>` — TizenFX public API version info (TizenFX convention)
- Judgment guide:
  - `internal`, `private`, `file`-scoped members are out of scope (not flagged)
  - If only the **body of an existing public member** changes (signature unchanged), skip
  - If the `partial` class has documentation on the other side, it is OK
  - **Public APIs annotated with `[EditorBrowsable(EditorBrowsableState.Never)]` are excluded** — by TizenFX convention, IntelliSense-hidden APIs are not part of the official documentation surface

**Full-file fetch required before flagging missing docs (to prevent false positives):**

A raw `diff` can clip attributes or existing XML doc out of context. Before flagging missing documentation, **always fetch the file at the PR branch** and verify:

```bash
# Get the PR head SHA
HEAD_SHA=$(gh api repos/samsung/TizenFX/pulls/{NUMBER} --jq '.head.sha')

# Fetch full file content (base64 → decode)
gh api repos/samsung/TizenFX/contents/{FILE_PATH}?ref=$HEAD_SHA \
  --jq '.content' | base64 -d
```

Checkpoints:
1. Is `[EditorBrowsable(EditorBrowsableState.Never)]` / `[Obsolete]` placed right above the member?
2. Is the containing class/type declared with `[EditorBrowsable(...Never)]`? (if yes, skip all its members)
3. Does another file of the `partial` class already contain XML doc? (check via `grep -l` or repeated `gh api .../contents`)
4. Is the `///` doc already present but only missing a few tags, vs. completely missing?

If **any one** of the four applies, do not flag. Prioritize accuracy over diff-browsing convenience.

**Comment style rules (concise + diff-centric):**

1. **Write in English**, always start with `🤖 [AI Review]`
2. **Explanation within 1–2 sentences**. Only the "why" in one line.
3. **Always include a ```` ```suggestion ```` block when proposing a fix.** Avoid prose-only feedback with no diff.
4. Use only two severity levels: 🔴 / 🟡
5. Max 5 comments per PR. Essentials only.
6. No "looks good" filler. Praise is limited to a single line only for **design choices with clearly surfaced intent**.
7. **No follow-up / reminder / status-check / @-mention action-request comments** (e.g., `@author please address...` ❌)

**Standard template (inline comment):**

~~~
🤖 [AI Review]
🟡 **Suggestion**: {one-line reason}

```suggestion
{corrected code — in a form directly applicable from GitHub}
```
~~~

**Critical exception** (structural issues that cannot be expressed as a suggestion block — class split, signature change, etc.): prose allowed but keep it **within 3 sentences**; attach a Before/After code snippet whenever possible.

**Public API missing-docs template example:**

~~~
🤖 [AI Review]
🔴 **Critical**: Public API missing XML documentation. TizenFX public APIs require `<summary>`, `<param>`, `<returns>`, and `<since_tizen>` tags.

```suggestion
/// <summary>
/// {Brief description of what this member does}.
/// </summary>
/// <param name="value">{Description of parameter}.</param>
/// <returns>{Description of return value}.</returns>
/// <since_tizen> {API level} </since_tizen>
public int DoSomething(int value)
```
~~~

**Line-level inline comment call:**
```bash
gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
  -f body="🤖 [AI Review]
🟡 **Suggestion**: Use FrozenDictionary for this read-only mapping.

\`\`\`suggestion
private static readonly FrozenDictionary<string, int> _mapping = new Dictionary<string, int>
{
    ...
}.ToFrozenDictionary();
\`\`\`" \
  -f commit_id="{COMMIT_SHA}" \
  -f path="{FILE_PATH}" \
  -F line={LINE_NUMBER}
```

**Overall summary comment (optional, concise variant):**
```bash
gh pr comment {NUMBER} --repo samsung/TizenFX --body "🤖 [AI Review]
Left {N} inline comments (🔴 {critical}, 🟡 {suggestion}). See inline for details.

---
*Automated review by AI assistant*"
```

---

### Stage ④: Respond to New Comments from Other Reviewers

**Target**: new human comments after `LAST_AI_AT` that are **not replies to a previous AI comment**.

**Response principles (strict):**

- ✅ Allowed:
  - **Technical answers** to their questions (factual statements grounded in the code context and .NET/Tizen behavior)
  - **Validity analysis** of their change request, with a specific rationale and a ```` ```suggestion ```` block when possible
  - One-line agreement when their approval/critique is valid

- ❌ Forbidden:
  - Phrasing that **asks the author/reviewer for an answer or action** (`Could you please...`, `Please confirm...`, "please check")
  - **@-mention patterns** that call someone out to demand action
  - Titles/phrases like "Follow-up", "unanswered", "status check", "reminder"
  - Ceremonial agreements without code context (`Thanks!`, `Agreed.` alone)

**Comment format:**
- Must start with `🤖 [AI Review]`
- **English**, 1–3 sentences, with a ```` ```suggestion ```` block when helpful
- End with an answer/opinion, **not a question**

**Reply call (preserving reply-to relationship):**
```bash
gh api repos/samsung/TizenFX/pulls/{NUMBER}/comments \
  -f body="🤖 [AI Review]
{technical response — 1–3 sentences, with suggestion block when possible}" \
  -F in_reply_to={COMMENT_ID}
```

**Judgment guide**: when unsure whether to respond, **choose not to**. A comment that doesn't add value to the code is noise.

---

### Constraints
- **Max 5 PRs per run**
- Comments must be written in **English**
- **Skip if no new commits/human comments** after the last AI activity (Stage ②)
- **No follow-up / reminder / status-check comments on our own previous reviews**
- **No asking for answers/actions** from the author or reviewers (including pings via `@-mention`)
- No formal reviews such as `approve` / `request changes` (inline comments only)
- No PR `merge` / `close`
- Draft PRs are skipped (`ai-task` PRs are not skipped)

### Reporting
- **Review performed**: PR number, link, number of comments left, severity distribution (🔴 / 🟡)
- **Responses performed**: PR number, number of comments answered
- **Skipped**: PR number and reason (`no-delta` / `draft` / `quota-5`)
- **Errors**: PR number and error summary, if any
