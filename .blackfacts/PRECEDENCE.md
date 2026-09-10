# Standards Precedence

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-08-10

When instructions conflict, agents must use this order of authority, highest first:

1. Explicit current human instruction, subject to safety/security constraints.
2. Documented project-specific rules and approved exceptions.
3. Architecture decisions (ADRs) applicable to the affected area.
4. Framework/framework-specific standards (React, ASP.NET Core, etc.).
5. Language-specific standards.
6. BlackFacts common coding standards.
7. BlackFacts global engineering principles and agent contract.
8. Existing local conventions inferred from code when no explicit rule exists.
9. Tool defaults or model preferences.

Agents must not silently resolve material conflicts. If a higher-precedence instruction appears unsafe, contradictory, destructive, or ambiguous, stop and surface the conflict.

Existing mature code should not be mechanically rewritten merely to conform to a newer global convention. Apply standards to new/changed code and document intentional exceptions where broad migration would create unnecessary risk or scope.
