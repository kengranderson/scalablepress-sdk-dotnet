# Verification Profiles

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-08-11

Verification is selected by component type. Playwright is a web-UI tool, not a universal project requirement.

## Common Baseline

For every changed component where applicable:

- dependencies restore/install successfully;
- compile/build/type-check succeeds;
- existing relevant automated tests pass;
- lint/static analysis passes when configured;
- runtime/startup behavior is verified when practical;
- new runtime warnings/errors are investigated;
- completion report states exactly what was and was not verified.

## `web-ui`

Use the project's existing browser/E2E tooling when adequate. Playwright is the preferred default when browser automation is needed and no established equivalent exists.

When a web UI depends on an application API, establish and verify the required API/services first rather than starting the UI against an unknown backend state.

Verify as applicable:

- application starts and target pages load;
- the real running application is rendered and visually inspected, preferably in the development environment's embedded/integrated browser when available;
- critical user flows function;
- browser console contains no new unexplained errors;
- relevant network/API calls succeed;
- desktop and responsive/mobile layouts are exercised;
- screenshots are captured for material visual changes;
- accessibility baseline is checked;
- reference/current/updated screenshots are compared for visual redesign work.

Before introducing Playwright or another browser automation dependency, inspect the repository/workspace and development environment to determine whether a suitable browser-control, screenshot, or E2E capability is already present. If installation is required, use the smallest project-appropriate setup and document it.

## `api`

Do not install Playwright solely to test an API.

For maintained application APIs, a lightweight health/readiness endpoint should normally exist unless the project documents a reason not to. The endpoint should be appropriate for local verification and operational health checking without exposing sensitive implementation detail.

A running process alone is not sufficient evidence that an API is correct. Run the appropriate existing unit/integration/contract tests before relying on the running service. When meaningful automated coverage is absent, document the gap and establish a minimal test foundation around critical startup/core behavior where practical; initialization should not expand into an exhaustive test retrofit.

Verify as applicable:

- relevant unit/integration/contract tests pass before startup verification;
- service builds and starts;
- health/readiness endpoint behaves correctly;
- changed or representative endpoints are exercised directly;
- status codes, response contracts, validation, authorization, and error behavior are checked;
- OpenAPI/API documentation remains consistent when present;
- startup/runtime logs contain no new unexplained errors.

## `cli`

Verify commands through process execution: arguments, stdin where applicable, stdout/stderr, exit codes, failure cases, and side effects. Prefer automated command-level tests.

## `library`

Verify compilation/package creation, unit tests, public API compatibility, and a consumer/test harness when useful. Do not introduce UI automation.

## `worker` / `service`

Verify startup, representative jobs/messages/events, retry/error behavior, logs, and resulting state/side effects. Use test doubles or isolated infrastructure where appropriate.

## `desktop-ui`

Use UI automation appropriate to the desktop technology. Playwright may apply to Electron or another explicitly supported web-based shell, but should not be assumed for native desktop applications.

## `mobile-ui`

Use platform/framework-specific mobile automation. Verify supported devices/viewports, lifecycle behavior, permissions, and platform-specific interactions as appropriate.

## `database`

Verify migrations/schema changes against an appropriate non-production database, including forward migration and rollback/recovery expectations where supported. Validate compatibility with affected application code.

## `infrastructure`

Prefer validation/plan/dry-run modes. Verify syntax and intended changes before applying. Production-facing mutations require the approval rules in `risk-and-approval.md`.

## Visual Iteration Loop

For material UI design work:

1. Establish reference screenshots/video/design intent.
2. Run and verify required APIs/services.
3. Run the real web application.
4. Open/render it in the available integrated browser or browser automation environment.
5. Capture baseline screenshots at agreed viewports.
6. Make one coherent visual/interaction change.
7. Re-run and capture updated screenshots.
8. Compare layout, typography, spacing, states, responsiveness, accessibility, console errors, and broken network requests.
9. Iterate until the requested result and verification profile are satisfied.

Agents must not describe a visual result as verified if they did not actually render and inspect it.
