# Secure_cloud Coding Rules

## Naming / Structure
- Use repo-local naming patterns from the existing modules and manifests
- Keep top-level boundaries stable: `PCapplication`, `server`, `www`, `graphify-out`

## Architecture Patterns
- Read Graphify semantic artifacts before broad source searching when `graphify-out/` exists.
- Preserve existing architecture and make the smallest safe change.
- Legacy/tutorial repos may not have uniform conventions; preserve the local style instead of normalizing the whole repo.

## State Management
- Prisma or SQLite-backed persistence is the source of truth
- No complex shared state layer is visible

## Error Handling / Logging
- Prefer explicit local validation and user-visible failure messages
- Console logging and focused route-level guardrails are the common default
- No centralized observability SDK is visible unless the repo docs say otherwise

## API Conventions
- Preserve current request and response shapes on existing routes
- Do not widen state-changing payloads when the repo is moving toward stronger authority or validation

## Testing Conventions
- No standardized automated test command is visible.

## Typing / Abstractions
- Follow existing typed request/data models where present
- Prefer thin adapters over broad rewrites when integrating providers or services

## Database / Migration Patterns
- Keep schema changes aligned with the repo's chosen persistence layer
- Call out migration or seed prerequisites explicitly when touching stateful flows
