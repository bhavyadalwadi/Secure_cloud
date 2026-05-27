# Secure_cloud Workflows

## Local Development
- Inspect `README.md` and repo-local scripts before running.

## Testing
- No standardized automated test command is visible.

## Deployment
- No standardized deployment command is documented; treat this as a local/manual project.

## Migrations
- Not present.

## Feature Rollout
- Keep rollout incremental and local-first
- For smaller repos, treat release as manual verification plus commit hygiene

## Incident Response
- start from the documented entrypoints and current runtime env
- verify recent schema/config drift before assuming logic bugs
- for infrastructure repos, validate container/network state before editing config

## Debugging
- read Graphify summary first when available
- reproduce from the smallest affected entrypoint
- check env variables, schema state, and local generated artifacts before deeper rewrites

## Rollback
- prefer reverting the smallest safe change
- restore previous schema or env assumptions if a stateful flow regressed
- no automated rollback system is visible unless the runtime platform provides one

## Observability Investigation
- use local logs, UI symptoms, and test output as the primary signal path
