# Claude Code — BlackFacts Project Instructions

This project uses the BlackFacts AI-Assisted Development Framework.

Treat `AGENTS.md` as the common agent entry point and read it first. Then read `.blackfacts/project.yml`, `.blackfacts/CURRENT.md`, `.blackfacts/AGENT-CONTRACT.md`, `.blackfacts/SESSION-CONTEXT-MANAGEMENT.md`, `.blackfacts/PRECEDENCE.md`, and applicable `.blackfacts/standards/` before substantial changes. If `.blackfacts/application-link.yml` exists, follow it when cross-repository context matters.

Use Claude Code capabilities to inspect and execute the project rather than guessing. Keep work bounded to one coherent work unit, verify with the component's declared verification profile, and provide evidence for completion claims.

## Claude Session Discipline

- Inspect `git status` before editing and preserve pre-existing/uncommitted work.
- Use `.blackfacts/CURRENT.md` as the concise resume point; reconcile it with the actual repository state.
- Do not use a long Claude conversation as the project's durable memory.
- Prefer focused reads/searches and narrow tests over loading large portions of the repository unnecessarily.
- Use bounded subagents for noisy reconnaissance, large log/test analysis, repository-wide comparisons, or other work that would otherwise consume substantial main-session context; ask them to return concise findings and evidence.
- Keep routine command output concise. When practical, write noisy output to a file and inspect only the relevant failures/results.
- Do not carry a materially different task into the same long session. At a work-unit boundary, update `.blackfacts/CURRENT.md` and other authoritative breadcrumbs first, then explicitly tell the user: **Work unit checkpointed; safe to `/clear`.**
- If the same work unit must continue but accumulated context is excessive, checkpoint durable state first and recommend `/compact` rather than silently retaining irrelevant history.
- When helpful, recommend `/context` so the user can inspect context pressure. Do not pretend to invoke user slash commands yourself.

Do not create a Claude-specific engineering methodology here. Project-specific additions may be recorded below only when they truly apply specifically to Claude Code.

## Claude-Specific Project Notes

_None by default._
