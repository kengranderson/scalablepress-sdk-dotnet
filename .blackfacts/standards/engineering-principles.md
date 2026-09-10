# Global Engineering Principles

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-08-10

These principles apply across languages and frameworks unless a higher-precedence project rule requires otherwise.

## Design

- Keep responsibilities cohesive and boundaries explicit.
- Prefer simple solutions over unnecessary abstraction.
- Avoid meaningful duplication (DRY), while recognizing that premature abstraction can be worse than small duplication.
- Apply SOLID principles where they improve maintainability; do not treat them as mechanical rules.
- Prefer composition over inheritance when practical.
- Design around contracts/interfaces at meaningful boundaries.
- Separate domain/business behavior from infrastructure and presentation concerns where the architecture warrants it.
- Favor testable, deterministic units and explicit dependencies.

## Implementation

- Use meaningful names and small focused functions/classes/modules.
- Prefer established platform/package capabilities over reinventing commodity functionality.
- Avoid hard-coded environment-specific values.
- Fail explicitly and diagnostically; do not silently swallow errors.
- Use structured logging where supported and never log secrets or unnecessary sensitive data.
- Treat warnings, TODOs, temporary workarounds, and disabled checks as intentional technical debt that should be documented.

## Dependencies

- Prefer existing dependencies before adding new ones.
- Add dependencies only when their value outweighs maintenance, security, licensing, performance, and complexity costs.
- Avoid replacing working libraries solely because another library is newer or fashionable.
- Do not introduce a paid SaaS/tool requirement without explicit approval.

## Security

- Validate untrusted input at trust boundaries.
- Apply least privilege.
- Keep credentials/secrets out of repositories, generated artifacts, screenshots, and logs.
- Treat authentication, authorization, cryptography, production infrastructure, DNS, and destructive data operations as elevated-risk areas.

## Maintainability

- Keep source and documentation consistent.
- Prefer reproducible build/test/run commands.
- Modify generated artifacts through their source/generator rather than patching generated output when identifiable.
- Preserve compatibility unless breaking change is intentional and approved.

## Scope

Implement the requested change completely, but resist unrelated "while I am here" refactoring. Improvements outside scope should be recorded separately rather than silently bundled into the task.
