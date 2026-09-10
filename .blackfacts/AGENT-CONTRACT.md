# BlackFacts Agent Contract

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-09-10

This contract applies to AI coding agents regardless of product or model.

## Before Changing Code

- Read `.blackfacts/project.yml` when present.
- Read `.blackfacts/CURRENT.md` when present; treat it as the concise resume point, then reconcile it with the actual working tree and repository state.
- Read `.blackfacts/SESSION-CONTEXT-MANAGEMENT.md` when present and follow its work-unit/context discipline.
- Inspect applicable README, architecture documents, ADRs, project files, package manifests, tests, and existing conventions relevant to the requested work.
- Inspect `git status` before editing so pre-existing/uncommitted work is not overwritten or misattributed.
- Classify the affected component(s) and choose appropriate verification profiles.
- Prefer existing project tooling and dependencies before introducing new ones.
- Identify the requested scope and avoid unrelated cleanup.
- For medium/high-risk work, state the intended plan and rollback path before destructive or difficult-to-reverse changes.

## While Working

- Make small, coherent, reviewable changes.
- Do not perform unrelated refactors, formatting churn, framework migrations, or dependency upgrades.
- Follow BlackFacts standards according to the documented precedence hierarchy.
- Design around clear contracts and boundaries; use interfaces/abstractions when they provide meaningful substitution, isolation, testability, or architectural separation. Do not create abstractions solely for ceremony.
- Keep secrets and credentials out of source control and logs.
- Preserve backward compatibility unless a breaking change is explicitly authorized.
- Update authoritative documentation when behavior or architecture changes.

## Session and Context Discipline

- Treat the repository as durable project memory and the current AI session as temporary working memory for one coherent assignment.
- Do not carry unrelated work into the same session merely because it belongs to the same repository or application.
- Prefer focused searches, relevant file sections, narrow tests, quiet command output, and bounded subagent work over indiscriminate repository loading or large transcript dumps.
- Keep `.blackfacts/CURRENT.md` concise and current so a fresh session can resume without depending on chat history.
- At a natural work-unit boundary, checkpoint durable state before recommending a fresh session. Claude Code should explicitly tell the user when it is safe to use `/clear`; if the same work unit must continue with excessive accumulated context, checkpoint first and recommend `/compact` where appropriate.

## Shared Toolkit Boundary

Pilot projects may drive improvements to `blackfacts/tools`, but application-specific facts must not leak into the shared toolkit.

- Keep project-specific names, repository identities, URLs, ports, database names, credentials, topology, business rules, environment quirks, and one-off workflow assumptions in the application repositories/manifests.
- Promote a pilot-driven change into `blackfacts/tools` only when it has been generalized into a reusable abstraction, rule, template, detection capability, or test scenario that remains valid for unrelated projects.
- Before committing a toolkit change prompted by a pilot, ask: **Would this still belong in the toolkit if the current pilot project had a completely different name, stack, and topology?** If not, keep it in the project.
- Keep toolkit changes and application-specific changes in separate commits/change sets whenever practical.
- Shared repositories used by multiple applications have a broader blast radius. Scope edits to the declared paths/resources and apply stronger verification/risk discipline.

## Verification

- Never claim an action succeeded unless it was actually executed or directly verified.
- Use the verification profile appropriate to each affected component.
- Capture evidence: commands executed, build/test results, relevant HTTP/status results, screenshots where applicable, console/runtime errors, and known unverified areas.
- Do not weaken, delete, or bypass failing tests merely to obtain a green result.
- When verification cannot be completed, clearly report why and what remains unverified.
- Keep routine command/test output as concise as practical; retain detailed logs in files when needed and surface only the evidence required to diagnose or prove the result.

## Failure Behavior

When blocked by missing credentials, unavailable services, environment failures, unclear destructive operations, or contradictory requirements:

1. Preserve the current working state.
2. Capture the relevant failure evidence.
3. Avoid speculative/destructive workarounds.
4. Report the blocker and the smallest decision/action needed to continue.

## Handoffs

When another agent or developer may continue the work, update `.blackfacts/CURRENT.md` when present and leave a concise durable record containing:

- goal and scope;
- current state;
- decisions made and relevant ADRs;
- files/areas changed;
- verification performed and results;
- blockers/known issues;
- recommended next step.

Do not turn `CURRENT.md` into an append-only activity log. Replace stale state; use Git history and changelogs for history.

## Completion

"Done" means the requested behavior is implemented, appropriate verification has passed (or exceptions are explicitly reported), authoritative documentation is current, durable current-state breadcrumbs are updated, and evidence is available for the completion claim.
