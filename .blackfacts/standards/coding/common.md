# Common Coding Standards

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-08-10

These rules sit between global engineering principles and language/framework-specific standards.

- Follow the repository's established naming/style when it does not conflict with an explicit higher-precedence standard.
- Keep modules/files focused and discoverable.
- Prefer explicit contracts at system/module boundaries.
- Avoid duplicated business rules; establish a single authoritative implementation when behavior must remain consistent.
- Prefer dependency injection or explicit dependency passing over hidden global dependencies where supported and useful.
- Keep configuration external to code; never hard-code credentials.
- Validate external/untrusted input.
- Handle errors at the layer capable of adding context or recovery; do not silently consume failures.
- Use structured, actionable logs and appropriate severity levels.
- Write tests at the cheapest level that proves the behavior, adding broader integration/E2E coverage where boundaries or user flows require it.
- Keep tests deterministic and independent where practical.
- Prefer supported packages/platform features over custom implementations of commodity functionality.
- Treat package additions and upgrades as engineering changes requiring justification and verification.
- Preserve public contracts unless breaking change is intentional and approved.
- Mark generated code clearly and modify its source/template rather than generated output.
- Use the canonical BlackFacts source-file headers defined in `docs/file-headers.md` when applicable.

## Standards Inheritance

The intended hierarchy is:

`global engineering principles -> common coding -> language -> framework -> project-specific rules/exceptions`

Language/framework standards should refine these rules rather than duplicate them wholesale.
