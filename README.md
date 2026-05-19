# Secure_cloud

Secure_cloud is a multi-part secure file-sharing project that combines a Windows desktop client, TCP listener services, a PHP/MySQL backend, and RSA-backed user key storage. It appears to be a capstone-style academic project focused on adding security layers around login and file exchange.

## What this repo does

- Provides a desktop client for browsing and sending files over TCP
- Includes a socket-based login server that validates users against MySQL
- Exposes PHP endpoints for login, registration, password change, and password recovery
- Stores user profile data, salted passwords, and RSA public keys in MySQL
- Separates responsibilities across client, server, public-key, and PHP web components

## Main files

- `PCapplication/PCapplication/filesharingclient.cs` - desktop file-sending client
- `server/tcpserver/tcpserver/logserver.cs` - TCP login server with password verification
- `www/project_php/index.php` - PHP API entrypoint
- `project_database.sql` - MySQL schema and sample data

## Status

- Status confidence: medium
- Pending work: unknown from current repo docs
- Current state: the repo contains the main system pieces, but it still needs cleaner public documentation and architecture notes before publishing broadly

## Start here

1. Read `www/project_php/index.php`
2. Read `PCapplication/PCapplication/filesharingclient.cs`
3. Read `server/tcpserver/tcpserver/logserver.cs`
4. Inspect `project_database.sql`
5. Read `graphify-out/repo-semantic-summary.md` for the low-token repo summary
