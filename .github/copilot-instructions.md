# BlackFacts Project Instructions for GitHub Copilot and Coding Agents

Follow the repository's `AGENTS.md` as the common agent entry point.

Before substantial changes, inspect `git status` and read `.blackfacts/project.yml`, `.blackfacts/CURRENT.md`, `.blackfacts/AGENT-CONTRACT.md`, `.blackfacts/SESSION-CONTEXT-MANAGEMENT.md`, `.blackfacts/PRECEDENCE.md`, applicable `.blackfacts/standards/`, project documentation, ADRs, and relevant tests/project manifests.

Use the declared component type and verification profiles to decide how to validate changes. Playwright/browser automation applies to web UI components when selected; APIs, CLIs, libraries, workers, desktop applications, databases, and infrastructure have different verification expectations.

Treat the AI session as temporary working memory for one coherent work unit. Keep durable current state in `.blackfacts/CURRENT.md`, keep searches/test output focused, and use bounded secondary-agent/reconnaissance work when it prevents unnecessary context growth.

Keep changes scoped and reviewable. Prefer existing packages and conventions. Never represent unexecuted tests/checks as passing. Observe the project's human-approval boundaries for high-risk changes. At handoff, update `.blackfacts/CURRENT.md` with verified current state and the exact next action.
