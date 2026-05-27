# Secure_cloud Graph Relationships

       ## Service Dependency Graph
       Secure_cloud
-> primary application under `graphify-out`
-> Database: MySQL
-> Queues/Events: not present
-> Deployment: No standardized deployment command is documented; treat this as a local/manual project.

       ## Runtime Dependency Graph
       Secure_cloud
-> Runtime: C#
-> Runtime: .NET
-> Runtime: PHP
-> Runtime: MySQL
-> Runtime: SQL

       ## Database Relationship Graph
       Secure_cloud
-> MySQL

       ## API Consumer / Provider Graph
       Secure_cloud
-> no formal API contract visible

       ## Queue Publisher / Consumer Graph
       Secure_cloud
-> no broker or queue layer visible

       ## Shared Package Dependency Graph
       Secure_cloud
-> no notable shared package layer beyond app-local dependencies

       ## Deployment Relationship Graph
       Secure_cloud
       - No standardized deployment command is documented; treat this as a local/manual project.

       ## Cross-Repo Relationship Graph
       Secure_cloud
-> no runtime dependency on sibling repos by default
