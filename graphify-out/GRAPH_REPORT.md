# Graph Report - Secure_cloud  (2026-05-26)

## Corpus Check
- 75 files · ~47,403 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 310 nodes · 297 edges · 55 communities (37 shown, 18 thin omitted)
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `f4096ac5`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- [[_COMMUNITY_Community 0|Community 0]]
- [[_COMMUNITY_Community 1|Community 1]]
- [[_COMMUNITY_Community 2|Community 2]]
- [[_COMMUNITY_Community 3|Community 3]]
- [[_COMMUNITY_Community 4|Community 4]]
- [[_COMMUNITY_Community 5|Community 5]]
- [[_COMMUNITY_Community 6|Community 6]]
- [[_COMMUNITY_Community 7|Community 7]]
- [[_COMMUNITY_Community 8|Community 8]]
- [[_COMMUNITY_Community 9|Community 9]]
- [[_COMMUNITY_Community 10|Community 10]]
- [[_COMMUNITY_Community 11|Community 11]]
- [[_COMMUNITY_Community 12|Community 12]]
- [[_COMMUNITY_Community 13|Community 13]]
- [[_COMMUNITY_Community 14|Community 14]]
- [[_COMMUNITY_Community 15|Community 15]]
- [[_COMMUNITY_Community 16|Community 16]]
- [[_COMMUNITY_Community 37|Community 37]]
- [[_COMMUNITY_Community 38|Community 38]]
- [[_COMMUNITY_Community 39|Community 39]]
- [[_COMMUNITY_Community 40|Community 40]]
- [[_COMMUNITY_Community 41|Community 41]]
- [[_COMMUNITY_Community 42|Community 42]]
- [[_COMMUNITY_Community 43|Community 43]]
- [[_COMMUNITY_Community 44|Community 44]]
- [[_COMMUNITY_Community 45|Community 45]]
- [[_COMMUNITY_Community 46|Community 46]]
- [[_COMMUNITY_Community 47|Community 47]]
- [[_COMMUNITY_Community 48|Community 48]]
- [[_COMMUNITY_Community 49|Community 49]]
- [[_COMMUNITY_Community 50|Community 50]]
- [[_COMMUNITY_Community 51|Community 51]]
- [[_COMMUNITY_Community 52|Community 52]]
- [[_COMMUNITY_Community 53|Community 53]]
- [[_COMMUNITY_Community 54|Community 54]]

## God Nodes (most connected - your core abstractions)
1. `Form2` - 16 edges
2. `Secure_cloud Project Context` - 16 edges
3. `Primary App` - 15 edges
4. `Secure_cloud Architecture` - 14 edges
5. `Form2` - 12 edges
6. `logserver` - 11 edges
7. `DB_Functions` - 11 edges
8. `DB_Functions` - 11 edges
9. `filereceiver` - 10 edges
10. `Secure_cloud Workflows` - 10 edges

## Surprising Connections (you probably didn't know these)
- `Form2` --references--> `IContainer`  [EXTRACTED]
  PCapplication/PCapplication/Form2.Designer.cs → server/pubkey/pubkey/publistener.Designer.cs
- `Form2` --references--> `Button`  [EXTRACTED]
  PCapplication/PCapplication/Form2.Designer.cs → server/pubkey/pubkey/publistener.Designer.cs
- `Form2` --references--> `Label`  [EXTRACTED]
  PCapplication/PCapplication/Form2.Designer.cs → server/pubkey/pubkey/publistener.Designer.cs
- `Form2` --references--> `string`  [EXTRACTED]
  PCapplication/PCapplication/Form2.cs → server/pubkey/pubkey/publistener.cs
- `tcpclient` --references--> `IContainer`  [EXTRACTED]
  PCapplication/PCapplication/tcpclient.Designer.cs → server/pubkey/pubkey/publistener.Designer.cs

## Communities (55 total, 18 thin omitted)

### Community 0 - "Community 0"
Cohesion: 0.07
Nodes (16): Button, file_receiver, filereceiver, IContainer, Label, filesharingclient, PCapplication, Form1 (+8 more)

### Community 1 - "Community 1"
Cohesion: 0.11
Nodes (11): bool, Form, filesharingclient, PCapplication, Form1, PCapplication, PCapplication, tcpclient (+3 more)

### Community 2 - "Community 2"
Cohesion: 0.19
Nodes (3): Form2, PCapplication, RSAParameters

### Community 5 - "Community 5"
Cohesion: 0.18
Nodes (7): CultureInfo, file_receiver.Properties, PCapplication.Properties, pubkey.Properties, Resources, tcpserver.Properties, ResourceManager

### Community 6 - "Community 6"
Cohesion: 0.18
Nodes (8): BindingSource, DataColumn, DataGridView, DataSet, DataTable, OpenFileDialog, Form2, PCapplication

### Community 7 - "Community 7"
Cohesion: 0.27
Nodes (3): int, logserver, tcpserver

### Community 8 - "Community 8"
Cohesion: 0.24
Nodes (4): file_receiver, filereceiver, MySqlCommand, MySqlConnection

### Community 9 - "Community 9"
Cohesion: 0.25
Nodes (5): file_receiver.Properties, PCapplication.Properties, pubkey.Properties, Settings, tcpserver.Properties

### Community 37 - "Community 37"
Cohesion: 0.12
Nodes (16): Business Purpose, Critical Dependencies, Current Architecture Themes, Deployment Model, Environments, Important APIs, Important Databases, Important Queues / Events (+8 more)

### Community 38 - "Community 38"
Cohesion: 0.12
Nodes (15): Critical Workflows, Dangerous Code Paths, Databases Used, Dependencies, Failure Modes, Important Source Files, Inbound APIs, Known Technical Debt (+7 more)

### Community 39 - "Community 39"
Cohesion: 0.13
Nodes (14): Auth Flow, Caching Layers, Deployment Topology, End-to-End Request Flows, Event-Driven Architecture, Failover Behavior, Frontend / Backend Interaction, Observability Architecture (+6 more)

### Community 40 - "Community 40"
Cohesion: 0.18
Nodes (10): Debugging, Deployment, Feature Rollout, Incident Response, Local Development, Migrations, Observability Investigation, Rollback (+2 more)

### Community 41 - "Community 41"
Cohesion: 0.2
Nodes (9): API Conventions, Architecture Patterns, Database / Migration Patterns, Error Handling / Logging, Naming / Structure, Secure_cloud Coding Rules, State Management, Testing Conventions (+1 more)

### Community 42 - "Community 42"
Cohesion: 0.29
Nodes (6): Critical Entrypoints, First Read, How To Start Reasoning, Local Run Baseline, Module Map, Secure_cloud Onboarding

### Community 43 - "Community 43"
Cohesion: 0.33
Nodes (5): Main files, Secure_cloud, Start here, Status, What this repo does

### Community 44 - "Community 44"
Cohesion: 0.5
Nodes (3): Graphify-first repo discovery, Preserve repo separation, Secure_cloud Decision Log

### Community 45 - "Community 45"
Cohesion: 0.5
Nodes (3): Critical Entrypoints, Read First, Top-Level Modules

## Knowledge Gaps
- **121 isolated node(s):** `PCapplication`, `OpenFileDialog`, `DataGridView`, `BindingSource`, `DataSet` (+116 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **18 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Form2` connect `Community 2` to `Community 1`?**
  _High betweenness centrality (0.016) - this node is a cross-community bridge._
- **Why does `string` connect `Community 1` to `Community 8`, `Community 2`, `Community 7`?**
  _High betweenness centrality (0.012) - this node is a cross-community bridge._
- **Why does `logserver` connect `Community 7` to `Community 1`?**
  _High betweenness centrality (0.011) - this node is a cross-community bridge._
- **What connects `PCapplication`, `OpenFileDialog`, `DataGridView` to the rest of the system?**
  _121 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Community 0` be split into smaller, more focused modules?**
  _Cohesion score 0.07 - nodes in this community are weakly interconnected._
- **Should `Community 1` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Should `Community 37` be split into smaller, more focused modules?**
  _Cohesion score 0.12 - nodes in this community are weakly interconnected._