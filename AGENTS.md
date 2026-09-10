# BlackFacts Project Agent Instructions

This repository follows the BlackFacts AI-Assisted Development Framework.

Before modifying code:

1. Read `.blackfacts/project.yml` for repository/component identity, stack, commands, verification profiles, and approved exceptions.
2. Read `.blackfacts/CURRENT.md` when present. Treat it as the concise resume point, then reconcile it with the actual working tree and repository state.
3. If `.blackfacts/application-link.yml` exists, read it. The current repository is part of a larger logical application; use the referenced canonical `.blackfacts/application.yml` when cross-repository behavior, architecture, startup, verification, database snapshots, or dependencies matter.
4. Read `.blackfacts/AGENT-CONTRACT.md`, `.blackfacts/SESSION-CONTEXT-MANAGEMENT.md`, and `.blackfacts/PRECEDENCE.md`.
5. Read applicable standards under `.blackfacts/standards/`.
6. Inspect project README, architecture documentation, ADRs, manifests/project files, tests, and existing conventions relevant to the requested work.
7. Inspect `git status` before editing so existing/uncommitted work is preserved.

Do not assume a single repository contains the complete application. A web repo may depend on an API repo, database/schema repo, worker, infrastructure repo, or shared libraries documented by the application manifest.

Work only within the requested scope. Prefer existing project tooling and dependencies. Do not introduce paid services or material dependencies without approval. Do not claim success without actual verification evidence.

Treat each AI session as temporary working memory for one coherent work unit. Keep durable current state in `.blackfacts/CURRENT.md`; prefer focused reads, concise command output, and bounded subagents/reconnaissance over unnecessarily loading large amounts of context.

For user-facing web work, follow the declared `web-ui` verification profile and render/inspect the real application; use Playwright when it is the selected browser automation tool, not as a universal requirement.

For high-risk changes, follow `.blackfacts/RISK-AND-APPROVAL.md` and stop for explicit approval before unapproved production/destructive/high-impact actions.

At handoff/completion, update `.blackfacts/CURRENT.md` when present and report what changed, what commands/checks actually ran, their results, remaining unverified areas, cross-repository impacts discovered, and the recommended next step.
