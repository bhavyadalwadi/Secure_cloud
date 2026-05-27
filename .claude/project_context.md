# Secure_cloud Project Context

Generated: 2026-05-27 01:50 UTC

## Business Purpose
Multi-part secure file-sharing project that combines a Windows client, TCP listener services, a PHP/MySQL backend, and RSA-backed user key storage.

## System Overview
This repo centers on primary application under `graphify-out`.

## Major Applications
- primary application under `graphify-out`

## Environments
- local development

## Tech Stack
- C#
- .NET
- PHP
- MySQL
- SQL

## Critical Dependencies
- No package-manager dependencies were parsed.

## Major Workflows
- Desktop client for browsing a local file and sending it to a remote TCP file receiver
- Socket-based login server that validates user credentials against MySQL
- PHP API endpoints for login, registration, password reset, and password change flows
- User database schema that stores salted passwords, profile fields, and RSA public keys
- Separate server components for login handling, file receiving, and public-key distribution

## Operational Constraints
- Project maturity is uneven; expect weaker docs, less automation, and more manual assumptions than the active product repos.

## Scaling Constraints
- Likely low-scale or instructional usage; do not overdesign scaling layers that the repo does not currently have.

## Deployment Model
No standardized deployment command is documented; treat this as a local/manual project.

## Important APIs
- No formal API surface is visible; this may be a static or local-only project.

## Important Databases
- MySQL

## Important Queues / Events
- No message queue or explicit event bus is visible; async behavior is local/in-process if present at all.

## Known Technical Debt
- Pending work is unknown from current repo docs.

## Current Architecture Themes
- Tier C repo under the `_personal` workspace
- Graphify-first repository discovery
- preserve current architecture instead of speculative rewrites
