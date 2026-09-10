# Change Risk and Approval Boundaries

**Author:** Ken Granderson  
**Owner:** Black Facts Educational Foundation  
**Last Updated:** 2026-08-10

Agents should scale planning, verification, rollback preparation, and human approval to the risk of the change.

## Low Risk

Examples: documentation, isolated presentation changes, narrowly scoped bug fixes with good test coverage, non-destructive developer tooling.

Agents may normally implement and verify autonomously within the requested scope.

## Medium Risk

Examples: new dependencies, significant refactors, public behavior changes, new endpoints, cross-component changes, build/deployment configuration changes, performance-sensitive changes.

Agents should document the plan, preserve rollback through coherent commits, and provide stronger verification evidence. Material scope expansion requires approval.

## High Risk

Examples include:

- production database/schema/data mutations;
- destructive operations or irreversible migrations;
- authentication/authorization changes;
- secrets/credential rotation or exposure risk;
- DNS, certificates, networking, production infrastructure, or deployment mutations;
- breaking public API/contract changes;
- billing/payment behavior;
- security/cryptography changes;
- deletion of substantial code/data/resources;
- actions that can materially affect availability or users.

For high-risk work, agents may inspect, analyze, draft, test in safe environments, and prepare a plan, but must obtain explicit human approval before performing the production/destructive/high-impact action unless the current instruction already gives specific, informed authorization for that exact action.

## Always Stop Rather Than Guess

Stop and ask when:

- the target environment is ambiguous and production could be affected;
- required credentials or authorization are missing;
- rollback/recovery is unclear for a destructive operation;
- instructions materially conflict;
- the requested operation would expose secrets or sensitive data;
- the agent cannot distinguish generated output from its authoritative source;
- verification failure suggests continuing could compound damage.

Approval for one high-risk action does not imply standing approval for unrelated future high-risk actions.
