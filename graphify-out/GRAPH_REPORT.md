# Graph Report - Secure_cloud  (2026-05-19)

## Corpus Check
- 57 files · ~45,291 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 202 nodes · 207 edges · 37 communities (28 shown, 9 thin omitted)
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS
- Token cost: 0 input · 0 output

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

## God Nodes (most connected - your core abstractions)
1. `Form2` - 16 edges
2. `Form2` - 12 edges
3. `logserver` - 11 edges
4. `DB_Functions` - 11 edges
5. `DB_Functions` - 11 edges
6. `filereceiver` - 10 edges
7. `IContainer` - 7 edges
8. `Form1` - 7 edges
9. `filesharingclient` - 7 edges
10. `Label` - 6 edges

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

## Communities (37 total, 9 thin omitted)

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

## Knowledge Gaps
- **39 isolated node(s):** `PCapplication`, `OpenFileDialog`, `DataGridView`, `BindingSource`, `DataSet` (+34 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **9 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Form2` connect `Community 2` to `Community 1`?**
  _High betweenness centrality (0.037) - this node is a cross-community bridge._
- **Why does `string` connect `Community 1` to `Community 8`, `Community 2`, `Community 7`?**
  _High betweenness centrality (0.029) - this node is a cross-community bridge._
- **Why does `logserver` connect `Community 7` to `Community 1`?**
  _High betweenness centrality (0.026) - this node is a cross-community bridge._
- **What connects `PCapplication`, `OpenFileDialog`, `DataGridView` to the rest of the system?**
  _39 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Community 0` be split into smaller, more focused modules?**
  _Cohesion score 0.07 - nodes in this community are weakly interconnected._
- **Should `Community 1` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._