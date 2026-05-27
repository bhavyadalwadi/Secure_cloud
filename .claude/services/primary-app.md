# Primary App

## Responsibility
Main runtime for `Secure_cloud`.

## Dependencies
- C#
- .NET
- PHP
- MySQL
- SQL

## Inbound APIs
- No formal inbound API is visible.

## Outbound APIs
- No confirmed external provider or downstream API.

## Databases Used
- MySQL

## Queues / Topics
- No queue/topic layer visible.

## Critical Workflows
- Desktop client for browsing a local file and sending it to a remote TCP file receiver
- Socket-based login server that validates user credentials against MySQL
- PHP API endpoints for login, registration, password reset, and password change flows
- User database schema that stores salted passwords, profile fields, and RSA public keys
- Separate server components for login handling, file receiving, and public-key distribution

## Failure Modes
- Project maturity is uneven; expect weaker docs, less automation, and more manual assumptions than the active product repos.

## Scaling Concerns
- current implementation appears intentionally lightweight
- there is no evidence of multi-service scaling machinery unless repo docs add it

## Operational Concerns
- start from repo-local `.claude/` docs and Graphify summary before code changes
- validate environment assumptions before debugging logic

## Important Source Files
- `PCapplication/PCapplication/filesharingclient.cs`
- `server/tcpserver/tcpserver/logserver.cs`
- `www/project_php/index.php`
- `project_database.sql`
- `README.md`
- `README.MD`

## Dangerous Code Paths
- Project maturity is uneven; expect weaker docs, less automation, and more manual assumptions than the active product repos.

## Testing Strategy
- No standardized automated test command is visible.

## Known Technical Debt
- Pending work is unknown from current repo docs.
