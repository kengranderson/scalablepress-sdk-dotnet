# BlackFacts AI Session and Context Management

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-09-10  
**Status:** Active / Living Standard

## Purpose

Keep AI-assisted development productive without making a single chat/session carry the lifetime of a project. The repository is durable project memory; an AI session is temporary working memory for one coherent work unit.

## Core Operating Model

**One repository/application = durable project knowledge. One AI session = one coherent work assignment.**

Project history, decisions, current state, verification evidence, and next actions belong in version-controlled files. Chat history should not be required to resume work correctly.

## Start of a Work Unit

Before substantial changes:

1. Inspect `git status` and preserve existing/uncommitted work.
2. Read the project agent entry point plus `.blackfacts/project.yml` and, when present, `.blackfacts/application-link.yml`.
3. Read `.blackfacts/CURRENT.md` before broad repository exploration.
4. Read only the architecture, ADRs, standards, source files, and tests relevant to the requested work; do not preload the repository indiscriminately.
5. Establish the objective, boundaries, verification profile, and smallest sensible next step.

## Context Discipline

- Do not use the conversation as a project archive.
- Avoid sustained sessions above roughly 150k tokens when a clean work-unit boundary is available. Prefer checkpointing earlier, especially after a major phase or when context is dominated by old investigation.
- Do not carry unrelated work into the same session merely because the project is the same.
- Re-read large files only when necessary; prefer targeted searches and relevant sections.
- Keep command output concise. Run the narrowest useful build/test first and use quiet/summary reporters where practical.
- Send very noisy output to a file when possible, then inspect/summarize the relevant failures rather than flooding the main session.
- Use subagents for bounded reconnaissance, repository-wide searches, log analysis, large test traces, dependency audits, or comparisons that would otherwise consume substantial main-session context. Ask subagents to return concise findings and evidence, not full transcripts.
- When a tool can perform a focused search or fetch, prefer it over loading large directories or documents wholesale.

## Claude Code Session Boundaries

Claude Code should treat the following as natural checkpoint points:

- the requested work unit is complete;
- the objective materially changes;
- a major implementation phase ends and a different kind of work begins;
- the session has accumulated large amounts of obsolete investigation/debug output;
- context has become large enough that continuing would mostly pay to retain old work rather than solve the next step.

At a checkpoint, Claude must first leave durable breadcrumbs, then explicitly tell the user that the work is checkpointed and it is safe to use `/clear` before the next work unit. Claude should not pretend it can invoke `/clear` itself.

If the same coherent work unit must continue but context is already large, first update durable state and then recommend `/compact` rather than silently carrying unnecessary history forward.

`/context` may be used when helpful to inspect current context pressure. Slash commands are user-facing controls; the agent should recommend them at appropriate boundaries rather than depending on the user to remember.

## Durable Current State

Each participating project should maintain `.blackfacts/CURRENT.md` as the concise resume point for the next human or agent.

Keep it current, short, and operational. It is not a diary or changelog. Replace stale details instead of endlessly appending history. Git history and `CHANGELOG.md` are the appropriate places for historical detail.

At minimum, `CURRENT.md` should identify:

- current objective/status;
- relevant branch/commit or working-state note when useful;
- completed work that affects the next step;
- verification actually performed and results;
- unresolved blockers or unverified areas;
- important current decisions/constraints;
- exact recommended next action;
- key files/documents the next session should read first.

## End of a Work Unit

Before declaring a work unit complete:

1. Run the appropriate verification profile and capture evidence.
2. Update authoritative documentation affected by the change.
3. Update `.blackfacts/CURRENT.md` so a fresh session can resume without relying on chat history.
4. Commit coherent changes when committing is within the requested scope; otherwise clearly identify uncommitted changes.
5. Report what changed, what was verified, what remains, and the exact next action.
6. If the next action is a distinct work unit, explicitly say: **Work unit checkpointed; safe to `/clear`.**

## Principle

**Repository memory should get stronger as chat memory gets shorter.**
