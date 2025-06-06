# BlueIQ Framework - Technical Architecture Document (MVP)

*   **Version:** 1.0
*   **Date:** 2025-06-05
*   **Status:** Initial Draft

---

# Table of Contents
1.  [Introduction](#1-introduction)
    1.1. [Purpose](#11-purpose)
    1.2. [Scope](#12-scope)
    1.3. [Audience](#13-audience)
    1.4. [Document Version](#14-document-version)
2.  [Architectural Goals and Constraints](#2-architectural-goals-and-constraints)
    2.1. [Architectural Goals](#21-architectural-goals)
    2.2. [Key Constraints & Considerations](#22-key-constraints--considerations)
3.  [System Overview](#3-system-overview)
4.  [Detailed Architecture](#4-detailed-architecture)
    4.1. [Microservice Architecture](#41-microservice-architecture)
    4.2. [Polyrepo Structure and Strategy](#42-polyrepo-structure-and-strategy)
    4.3. [Data Architecture](#43-data-architecture)
    4.4. [Frontend Architecture (Blazor)](#44-frontend-architecture-blazor)
    4.5. [Core Components and Shared Libraries](#45-core-components-and-shared-libraries)
    4.6. [Security Architecture](#46-security-architecture)
    4.7. [Logging and Monitoring](#47-logging-and-monitoring)
    4.8. [Technology Stack Summary](#48-technology-stack-summary)
5.  [Non-Functional Requirements (NFRs) Realization](#5-non-functional-requirements-nfrs-realization)
    5.1. [Performance & Responsiveness](#51-performance--responsiveness)
    5.2. [Scalability & Elasticity](#52-scalability--elasticity)
    5.3. [Reliability & Availability](#53-reliability--availability)
    5.4. [Maintainability & Extensibility](#54-maintainability--extensibility)
    5.5. [Security](#55-security)
    5.6. [Testability](#56-testability)
    5.7. [Deployability](#57-deployability)
6.  [Testing Strategy](#6-testing-strategy)
    6.1. [Guiding Principles](#61-guiding-principles)
    6.2. [Levels of Testing](#62-levels-of-testing)
    6.3. [Specialized Testing Areas](#63-specialized-testing-areas)
    6.4. [Test Data Management](#64-test-data-management)
7.  [Deployment Strategy](#7-deployment-strategy)
    7.1. [Deployment Environments](#71-deployment-environments)
    7.2. [Packaging: Containerization with Docker](#72-packaging-containerization-with-docker)
    7.3. [Local Development Environment Setup](#73-local-development-environment-setup)
    7.4. [Deployment to Staging & Production](#74-deployment-to-staging--production)
    7.5. [Configuration Management](#75-configuration-management)
    7.6. [Zero-Downtime Deployments (Goal for Post-MVP)](#76-zero-downtime-deployments-goal-for-post-mvp)
8.  [Future Considerations and Scalability](#8-future-considerations-and-scalability)
    8.1. [Enhanced Scalability & Performance](#81-enhanced-scalability--performance)
    8.2. [Feature Enhancements](#82-feature-enhancements)
    8.3. [Operational Excellence](#83-operational-excellence)
    8.4. [Evolving Security Posture](#84-evolving-security-posture)
    8.5. [Data & Analytics](#85-data--analytics)
    8.6. [Broader Technology Adoption](#86-broader-technology-adoption)
9.  [Appendices](#9-appendices)
    9.1. [Appendix A: High-Level Architecture Diagram](#91-appendix-a-high-level-architecture-diagram)
    9.2. [Appendix B: Glossary](#92-appendix-b-glossary)
    9.3. [Appendix C: Architectural Decision Log (ADL)](#93-appendix-c-architectural-decision-log-adl)

---

# 1. Introduction

## 1.1. Purpose
This Technical Architecture Document (TAD) outlines the comprehensive architectural design for the Minimum Viable Product (MVP) of the BlueIQ Framework. It serves as a blueprint for the development team, detailing the system's structure, components, technologies, and design principles. The goal is to ensure a shared understanding and guide the implementation towards a robust, scalable, and maintainable platform.

## 1.2. Scope
The scope of this document is limited to the MVP of the BlueIQ Framework. It covers the core microservices, data architecture, frontend UIs (Admin Panel and Workflow Designer), shared libraries, security considerations, testing, and deployment strategies. Future enhancements beyond the MVP are discussed but not detailed for implementation at this stage.

## 1.3. Audience
This document is intended for software architects, developers, QA engineers, DevOps engineers, and project stakeholders involved in the design, development, and deployment of the BlueIQ Framework.

## 1.4. Document Version
*   **Version:** 1.0
*   **Date:** 2025-06-05
*   **Status:** Initial Draft

---

# 2. Architectural Goals and Constraints

## 2.1. Architectural Goals
The primary architectural goals for the BlueIQ Framework MVP are:
*   **Modularity & Maintainability:** Design a system composed of loosely coupled, independent components that are easy to understand, develop, test, and maintain.
*   **Scalability & Performance:** Ensure the system can handle a growing number of users, workflows, and data, while maintaining responsive performance.
*   **Reliability & Availability:** Build a resilient system that minimizes downtime and can gracefully handle failures.
*   **Security:** Implement robust security measures to protect data and system integrity.
*   **Extensibility:** Design the framework to be easily extendable with new features, plugins, and integrations in the future.
*   **Developer Productivity:** Choose technologies and patterns that enhance developer productivity and enable rapid iteration.

## 2.2. Key Constraints & Considerations
*   **Technology Ecosystem:** Primarily leverage the .NET 8 ecosystem.
*   **Database Technology:** Microsoft SQL Server 2022 is the chosen RDBMS for core framework data.
*   **Messaging System:** RabbitMQ for asynchronous communication.
*   **Frontend Technology:** Blazor Server for the Admin Panel and Workflow Designer UIs.
*   **MVP Focus:** Prioritize core functionality essential for the MVP, deferring non-critical features.
*   **Existing User Preferences:** Incorporate specific user preferences regarding data patterns (CQRS, CDC, Temporal Tables, Dual Key, Outbox, Saga), private NuGet feeds, MudBlazor, etc., as detailed throughout this document.

---

# 3. System Overview

The BlueIQ Framework is a comprehensive platform designed to facilitate the creation, management, and execution of automated workflows. It empowers users to connect various systems and services through a flexible plugin architecture, enabling complex business processes to be orchestrated with ease.

The MVP focuses on delivering the core engine for workflow definition and execution, user and plugin management, event handling, and essential administrative and design interfaces.

At a high level, the system comprises:
*   **User Interfaces:** Web-based applications (Admin Panel, Workflow Designer) for system administration, workflow design, and monitoring.
*   **API Gateway:** A single entry point for all client requests, handling routing, authentication, and other cross-cutting concerns.
*   **Backend For Frontend (BFF) Services:** Tailored backend services that aggregate and adapt data from core microservices specifically for the UIs.
*   **Core Microservices:** A set of specialized, independently deployable services responsible for distinct business capabilities such as authentication, user management, workflow processing, plugin management, eventing, and configuration.
*   **Data Stores:** Relational databases (SQL Server 2022) employing advanced patterns like CQRS, with separate stores for transactional writes and optimized reads, along with mechanisms like CDC and Temporal Tables for data integrity and history.
*   **Messaging Infrastructure:** A message broker (RabbitMQ) to enable asynchronous communication and event-driven interactions between services.
*   **Shared Libraries:** Common code modules for DTOs, core utilities, and SDKs, distributed via a private NuGet feed.

This distributed architecture is designed to be scalable, resilient, and maintainable, leveraging containerization (Docker) and orchestration (Kubernetes) for deployment and management.

---

# 4. Detailed Architecture

This section provides a detailed breakdown of the various architectural components of the BlueIQ Framework.

## 4.1. Microservice Architecture
The BlueIQ Framework adopts a microservice architecture to promote modularity, scalability, and independent development and deployment of its components. Each microservice is responsible for a specific set of business capabilities.

*   **4.1.1. Service Identification and Decomposition**
    The following core microservices and BFFs have been identified for the MVP:
    *   **API Gateway (`blueiq-api-gateway`):** Single entry point for all external requests.
    *   **Authentication Service (`blueiq-auth-service`):** Handles user authentication and JWT issuance.
    *   **User Management Service (`blueiq-user-management-service`):** Manages user profiles, roles, and permissions. Secure storage of user credentials (e.g., hashed passwords).
    *   **Workflow Service (`blueiq-workflow-service`):** Core engine for defining, executing, and managing workflows.
    *   **Plugin Service (`blueiq-plugin-service`):** Manages plugin discovery, registration, configuration, and lifecycle.
    *   **Event Service (`blueiq-event-service`):** Abstracted interface for publishing and subscribing to system events via RabbitMQ.
    *   **Configuration Service (`blueiq-config-service`):** Provides centralized configuration management for other services (lightweight for MVP).
    *   **Admin BFF Service (`blueiq-admin-bff`):** Backend for the Admin Panel UI.
    *   **Designer BFF Service (`blueiq-designer-bff`):** Backend for the Workflow Designer UI.

*   **4.1.2. Microservice Details**
    *   **A. API Gateway (`blueiq-api-gateway`)**
        *   **Responsibilities:** Request routing, SSL termination, authentication/authorization (JWT validation), rate limiting (future), request aggregation (minimal), response transformation (minimal).
        *   **Key API Contracts:** Exposes all public-facing endpoints for UIs and external clients.
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** N/A (acts as a pass-through/router).
        *   **Technology:** Ocelot or YARP.
    *   **B. Authentication Service (`blueiq-auth-service`)**
        *   **Responsibilities:** Authenticate users (e.g., username/password), issue JWTs, validate JWTs (can be offloaded to API Gateway post-issuance), token revocation (future).
        *   **Key API Contracts:** `/login`, `/token/refresh` (future), `/token/validate`.
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** `UserCredentials` (internal, interacts with User Management Service for credential validation).
        *   **Technology:** ASP.NET Core, JWT generation libraries.
    *   **C. User Management Service (`blueiq-user-management-service`)**
        *   **Responsibilities:** CRUD operations for users, roles, and permissions. Secure storage of user credentials (e.g., hashed passwords).
        *   **Key API Contracts:** `/users`, `/roles`, `/permissions`.
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** `User`, `Role`, `Permission`, `UserRoleMapping`.
        *   **Technology:** ASP.NET Core, EF Core, SQL Server.
    *   **D. Workflow Service (`blueiq-workflow-service`)**
        *   **Responsibilities:** Workflow definition storage and retrieval (using a structured JSON format, schema to be finalized during detailed design), workflow instance creation and execution, state management for active workflows, coordination with Plugin Service for step execution, publishing workflow-related events.
        *   **Key API Contracts:** `/workflows/definitions`, `/workflows/instances`, `/workflows/instances/{id}/execute`.
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** `WorkflowDefinition`, `WorkflowInstance`, `WorkflowStep`, `WorkflowState`.
        *   **Technology:** ASP.NET Core, EF Core, SQL Server, RabbitMQ (via Event Service).
    *   **E. Plugin Service (`blueiq-plugin-service`)**
        *   **Responsibilities:** Plugin discovery (e.g., from a known directory or registry), plugin registration, managing plugin configurations, plugin lifecycle (loading/unloading - simplified for MVP), exposing plugin capabilities to the Workflow Service.
        *   **Key API Contracts:** `/plugins`, `/plugins/{id}/config`, `/plugins/execute-step` (internal, called by Workflow Service).
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** `PluginMetadata`, `PluginConfiguration`, `PluginExecutionContract`.
        *   **Technology:** ASP.NET Core, EF Core, SQL Server.
    *   **F. Event Service (`blueiq-event-service`)**
        *   **Responsibilities:** Provides a common abstraction for publishing events to RabbitMQ and for services to subscribe to events. Manages connection to RabbitMQ, exchange/queue declarations (convention-based).
        *   **Key API Contracts (Internal Library/SDK):** `PublishAsync(eventData)`, `SubscribeAsync(handler)`.
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** `EventEnvelope`, specific event DTOs (defined in `blueiq-messaging-contracts`).
        *   **Technology:** .NET library, RabbitMQ client.
    *   **G. Configuration Service (`blueiq-config-service`)**
        *   **Responsibilities (MVP - Lightweight):** Provides a simple API for other services to fetch shared or dynamic configuration values. For MVP, this might be backed by environment variables or a simple JSON file, exposed via an API.
        *   **Key API Contracts:** `/config/{serviceName}/{key}`.
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** `ConfigurationItem`.
        *   **Technology:** ASP.NET Core.
    *   **H. Admin BFF Service (`blueiq-admin-bff`)**
        *   **Responsibilities:** Aggregates data from various core services (User Management, Workflow, Plugin, Configuration) specifically for the Admin Panel UI. Tailors responses to UI needs, reducing chattiness.
        *   **Key API Contracts:** Exposes endpoints consumed by the Admin Panel UI (e.g., `/admin/dashboard-data`, `/admin/users`, `/admin/workflow-instances`).
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** UI-specific view models.
        *   **Technology:** ASP.NET Core.
    *   **I. Designer BFF Service (`blueiq-designer-bff`)**
        *   **Responsibilities:** Aggregates data and provides backend support for the Workflow Designer UI (e.g., fetching plugin metadata for toolbox, saving workflow definitions).
        *   **Key API Contracts:** Exposes endpoints consumed by the Workflow Designer UI (e.g., `/designer/plugins/available`, `/designer/workflows/save-definition`).
        *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository.
        *   **Primary Data Models:** UI-specific view models.
        *   **Technology:** ASP.NET Core.

*   **4.1.3. Inter-Service Communication**
    *   **Synchronous Communication:** Direct HTTP/REST calls between services for request/response interactions. Used when an immediate response is required.
        *   **Examples:** BFFs calling core services, Auth Service calling User Management Service.
        *   **Resilience:** Implemented using policies like retries, timeouts (e.g., with Polly).
    *   **Asynchronous Communication:** Event-driven communication via RabbitMQ, facilitated by the Event Service and Outbox Pattern.
        *   **Examples:** Workflow Service publishing `WorkflowStartedEvent`, Plugin Service publishing `PluginRegisteredEvent`.
        *   **Benefits:** Decoupling, improved resilience to temporary unavailability of services, better scalability.
    *   **Service Discovery:** For MVP, service addresses can be managed via configuration (environment variables, Configuration Service). In containerized environments (e.g., Kubernetes), built-in DNS-based service discovery will be used.

*   **4.1.4. API Gateway Strategy**
    *   A dedicated API Gateway (Ocelot or YARP) serves as the single entry point for all external traffic (from UIs or future third-party clients).
    *   **Responsibilities:**
        *   **Routing:** Directs incoming requests to the appropriate BFF or core service.
        *   **Authentication & Authorization:** Validates JWTs on incoming requests. Can enforce coarse-grained authorization rules.
        *   **SSL Termination:** Handles HTTPS, offloading SSL processing from backend services.
        *   **Rate Limiting & Throttling (Future):** Protect backend services from abuse or overload.
        *   **Request/Response Transformation (Minimal):** Avoid complex transformations; prefer BFFs for this.
    *   **Configuration:** Routes, authentication policies, and other settings will be configured in the API Gateway's configuration file(s).

## 4.2. Polyrepo Structure and Strategy
A polyrepo (multiple repositories) strategy will be adopted for managing the source code of the BlueIQ Framework. Each microservice, UI application, shared library, and potentially the API Gateway will reside in its own dedicated Git repository.

*   **4.2.1. Repository Breakdown (Examples)**
    *   `blueiq-api-gateway`
    *   `blueiq-auth-service`
    *   `blueiq-user-management-service`
    *   `blueiq-workflow-service`
    *   `blueiq-plugin-service`
    *   `blueiq-event-service`
    *   `blueiq-config-service`
    *   `blueiq-admin-bff`
    *   `blueiq-designer-bff`
    *   `blueiq-admin-ui` (Blazor Admin Panel)
    *   `blueiq-designer-ui` (Blazor Workflow Designer)
    *   `blueiq-framework-core` (Shared Core Library)
    *   `blueiq-plugin-sdk` (Plugin SDK Library)
    *   `blueiq-messaging-contracts` (Shared Event DTOs)
    *   `blueiq-ui-shared-components` (Shared Blazor Components)
    *   `blueiq-infrastructure` (Future: for K8s manifests, IaC scripts)

*   **4.2.2. Versioning**
    *   Each repository will be versioned independently using Semantic Versioning (SemVer - `MAJOR.MINOR.PATCH`).
    *   Shared libraries (NuGet packages) will follow SemVer strictly to manage dependencies.

*   **4.2.3. Dependency Management**
    *   Dependencies between services (e.g., on shared libraries) will be managed via NuGet packages published to a **private NuGet feed** (e.g., Azure Artifacts, GitHub Packages, MyGet).

*   **4.2.4. CI/CD Pipelines**
    *   Each repository will have its own independent CI/CD pipeline.
    *   CI pipelines will build the code, run unit and integration tests, and publish artifacts (Docker images to a container registry, NuGet packages to the private feed).
    *   CD pipelines will deploy services/applications to various environments (Testing, Staging, Production).

*   **4.2.5. Developer Experience**
    *   Clear `README.md` files in each repository will provide setup and build instructions.
    *   Docker Compose will be used to orchestrate local development environments, simplifying the setup of multiple services.

## 4.3. Data Architecture
The data architecture for the BlueIQ Framework is designed for scalability, performance, and data integrity, employing several advanced patterns.

*   **4.3.1. Database Technology**
    *   **Primary RDBMS:** Microsoft SQL Server 2022 for core framework data (Write and Read stores).
    *   **Plugin Data Stores:** Plugins are encouraged to manage their own data. While they can use various technologies, if relational storage is needed, they should use separate SQL Server instances/databases to ensure data isolation from the core framework and other plugins.

*   **4.3.2. CQRS (Command Query Responsibility Segregation)**
    *   The system will implement CQRS by logically (and potentially physically) separating the data models and stores for write operations (Commands) and read operations (Queries).
    *   **Write Database (Command Store):**
        *   Optimized for transactional consistency and write performance.
        *   Normalized schema design.
        *   Used for all CUD (Create, Update, Delete) operations.
        *   Primary source of truth.
        *   Accessed via EF Core, with entities designed for transactional operations.
    *   **Read Database (Query Store):**
        *   Optimized for query performance and read efficiency.
        *   Denormalized or specifically structured views/tables to support UI and query needs.
        *   Can be a separate database or a set of optimized read replicas of the Write DB, kept in sync.
        *   Accessed via EF Core or Dapper for optimized queries.

*   **4.3.3. Data Synchronization (Write to Read Store): Change Data Capture (CDC)**
    *   SQL Server's built-in Change Data Capture (CDC) feature will be enabled on relevant tables in the Write Database.
    *   A dedicated process (e.g., a separate microservice or a background worker within a service) will monitor CDC tables and propagate changes to the Read Database in near real-time. This process will transform data as needed for the denormalized read models.

*   **4.3.4. Temporal Tables**
    *   Key entities in the Write Database (e.g., `WorkflowDefinition`, `WorkflowInstance`, `User`, `PluginConfiguration`) will be configured as SQL Server Temporal Tables.
    *   This provides built-in support for tracking historical changes to data, enabling auditing, point-in-time data retrieval, and easier data recovery scenarios without custom audit logging code.

*   **4.3.5. Dual Key Strategy**
    *   Each primary entity table in the Write Database will use two keys:
        *   **`Id` (Primary Key):** An auto-incrementing integer (`int` or `bigint`). This is the clustered primary key, optimal for internal joins and performance.
        *   **`PublicId` (Alternate Key/Index):** A Globally Unique Identifier (GUID/UUID). This key will be non-clustered, indexed, and used for external references (e.g., in API responses, event messages, URLs). This avoids exposing internal integer IDs and provides stable identifiers across distributed systems.

*   **4.3.6. Outbox Pattern**
    *   Each microservice performing business transactions that also need to publish events will implement the Outbox pattern.
    *   **Mechanism:**
        1.  Within the same database transaction as the business data change, an event message is written to an `Outbox` table in that service's Write Database.
        2.  A separate background process (Relay/Publisher) monitors the `Outbox` table.
        3.  The Relay reads unprocessed messages from the `Outbox` and publishes them to RabbitMQ (via the Event Service).
        4.  Once successfully published, the message is marked as processed in the `Outbox` table (or deleted).
    *   **Benefit:** Ensures atomicity between database state changes and event publishing, preventing data inconsistencies if event publishing fails after the DB commit or vice-versa.

*   **4.3.7. Saga Pattern**
    *   For managing distributed transactions that span multiple microservices, the Saga pattern will be implemented.
    *   **Type:** Choreography-based sagas are preferred for MVP due to their decentralized nature, aligning well with event-driven architecture. Orchestration-based sagas (with a central coordinator) can be considered if choreography becomes too complex for certain scenarios.
    *   **Mechanism (Choreography Example - Workflow Creation & User Assignment):
        1.  `WorkflowService` creates a workflow (local transaction) and publishes `WorkflowCreatedEvent` (via Outbox).
        2.  `UserManagementService` subscribes to `WorkflowCreatedEvent`, assigns a default user/role (local transaction), and publishes `UserAssignedToWorkflowEvent` (via Outbox).
        3.  If `UserManagementService` fails, it might publish a `UserAssignmentFailedEvent`. `WorkflowService` could subscribe to this to trigger a compensating transaction (e.g., mark workflow as needing attention or delete it).
    *   **Compensating Transactions:** Each step in a saga must have a corresponding compensating transaction to undo its action if a subsequent step fails.

*   **4.3.8. Data Migrations**
    *   EF Core Migrations will be used to manage and apply schema changes to both Write and Read databases in a version-controlled manner.

## 4.4. Frontend Architecture (Blazor)
The BlueIQ Framework will feature two primary web-based user interfaces for the MVP, both built using Blazor Server.

*   **4.4.1. UI Applications**
    *   **Admin Panel UI (`blueiq-admin-ui`):** For system administrators to manage users, roles, monitor workflow instances, view system logs (basic), manage plugin configurations, and perform other administrative tasks.
    *   **Workflow Designer UI (`blueiq-designer-ui`):** For workflow designers to create, configure, and manage workflow definitions using a visual interface.

*   **4.4.2. Technology Choice: Blazor Server**
    *   **Rationale for MVP:**
        *   **Productivity:** Allows full-stack .NET development with C# for UI logic.
        *   **Performance:** UI rendering and event handling occur on the server, minimizing client-side load. Suitable for intranet/low-latency environments.
        *   **Security:** UI logic is not exposed to the client browser. Easier to secure access to backend resources.
        *   **Simpler Deployment:** Compared to Blazor WebAssembly for MVP, as it doesn't require separate static file hosting and complex client-side API authentication handling (though JWTs will still be used for API calls from the server-side Blazor app to BFFs).
    *   **Future Consideration:** Blazor WebAssembly could be explored post-MVP if offline capabilities or reduced server load become critical.

*   **4.4.3. Architectural Considerations**
    *   **Component-Based Design:** UIs will be built using reusable Blazor components.
    *   **UI Component Library:** **MudBlazor** will be used as the primary component library to accelerate UI development and ensure a consistent look and feel.
    *   **State Management:**
        *   For MVP, Blazor Server's built-in component state and scoped dependency injection will be primarily used.
        *   Global client-side state stores (like Fluxor or Redux-style patterns) are not planned for MVP but can be introduced if state management complexity grows significantly.
    *   **Routing:** Blazor's built-in routing system (`@page` directive) will be used for navigation.
    *   **API Communication:**
        *   Blazor Server applications will communicate with their respective BFF services (`Admin BFF`, `Designer BFF`).
        *   Typed `HttpClient` instances, configured via `IHttpClientFactory`, will be used for making API calls.
        *   Authentication with BFFs will utilize JWTs obtained during user login, attached to outgoing HTTP requests from the Blazor server-side code.
    *   **UI Notifications:** Toaster-style (Snackbar) notifications will be implemented using MudBlazor's `ISnackbar` service for user feedback (e.g., success messages, errors).
    *   **Error Handling:** Graceful error handling within components and global error boundaries to display user-friendly error messages.
    *   **Accessibility:** Adherence to web accessibility best practices (WCAG) will be a design consideration.

## 4.5. Core Components and Shared Libraries
To promote code reuse, consistency, and maintainability, several shared libraries will be developed. These libraries will be packaged as NuGet packages and distributed via a private NuGet feed.

*   **4.5.1. Key Shared Libraries**
    *   **`blueiq-framework-core`**
        *   **Contents:** Common Data Transfer Objects (DTOs) used across services (excluding event-specific DTOs), base classes for services or repositories, common utility functions, enums, constants, helper classes for patterns like Outbox or Saga (if generic enough).
        *   **Consumers:** Most backend microservices and BFFs.
    *   **`blueiq-plugin-sdk`**
        *   **Contents:** Interfaces, base classes, and helper utilities that plugin developers will use to create plugins compatible with the BlueIQ Framework. Defines contracts for plugin execution, configuration, and lifecycle.
        *   **Consumers:** Plugin Service, individual plugin projects.
    *   **`blueiq-messaging-contracts`**
        *   **Contents:** DTOs specifically for event messages exchanged via RabbitMQ. Defines the schema for all system events.
        *   **Consumers:** Event Service, any service publishing or consuming events.
    *   **`blueiq-ui-shared-components` (Future/Optional for MVP)**
        *   **Contents:** Reusable Blazor UI components that can be shared between the Admin Panel UI and the Workflow Designer UI (e.g., custom input controls, common layout elements).
        *   **Consumers:** `blueiq-admin-ui`, `blueiq-designer-ui`.

*   **4.5.2. Versioning and Distribution**
    *   Shared libraries will be independently versioned using SemVer.
    *   Published to a private NuGet feed (e.g., Azure Artifacts, GitHub Packages).
    *   CI/CD pipelines for shared libraries will automatically build, test, and publish new package versions.

## 4.6. Security Architecture
Security is a critical aspect of the BlueIQ Framework. The architecture incorporates multiple layers of security controls.

*   **4.6.1. Authentication**
    *   **Mechanism:** JSON Web Tokens (JWT).
    *   **Issuing Authority:** The `Authentication Service` is responsible for validating user credentials and issuing JWTs (access tokens, and potentially refresh tokens post-MVP).
    *   **Token Validation:** The API Gateway will be primarily responsible for validating JWTs on all incoming requests. Services behind the gateway can trust that the request has been authenticated if this validation is enforced at the gateway.

*   **4.6.2. Authorization**
    *   **Coarse-Grained (API Gateway):** The API Gateway can enforce basic authorization rules, e.g., ensuring only authenticated users can access certain routes.
    *   **Fine-Grained (Services/BFFs):** Role-Based Access Control (RBAC) will be implemented within individual services and BFFs.
        *   The `User Management Service` will manage users, roles, and permissions.
        *   Services will use attributes (e.g., `[Authorize(Roles = "Admin")]`) or custom authorization policies to protect endpoints and features.

*   **4.6.3. Data Security**
    *   **Data in Transit:** HTTPS/TLS will be enforced for all external communication (UIs to API Gateway, API Gateway to services if over public networks). Internal service-to-service communication within a trusted network (e.g., Kubernetes cluster) may use HTTP for performance, but TLS is preferred if feasible.
    *   **Data at Rest:**
        *   **Password Hashing:** User passwords will be securely hashed (e.g., using ASP.NET Core Identity's default hashing mechanism, which is PBKDF2).
        *   **Database Encryption (Optional):** SQL Server Transparent Data Encryption (TDE) can be considered for encrypting the entire database at rest if required by compliance or security policies.
        *   **Secrets Management:** Connection strings, API keys, JWT signing keys, and other secrets will be managed securely using environment variables, Kubernetes Secrets, or dedicated secret management solutions (e.g., Azure Key Vault, HashiCorp Vault) – not hardcoded in configuration files or source code.

*   **4.6.4. Input Validation**
    *   All services will perform rigorous input validation on data received from external sources (APIs, messages) to prevent common vulnerabilities like injection attacks (SQL injection, XSS – though Blazor Server helps mitigate XSS on the server side).
    *   Use of DTOs and model validation attributes (e.g., DataAnnotations).

*   **4.6.5. Secure Coding Practices**
    *   Development teams will follow secure coding guidelines (e.g., OWASP recommendations).
    *   Regular code reviews will include a security focus.

*   **4.6.6. Logging and Monitoring for Security**
    *   Audit trails for significant security events (e.g., logins, role changes, access denials) will be logged.
    *   Monitoring for suspicious activities or security breaches.

*   **4.6.7. Plugin Security**
    *   Plugins execute code within the system, posing a potential security risk. For MVP:
        *   Plugins will be sourced from trusted locations.
        *   The `Plugin SDK` will guide developers on secure practices.
    *   **Future:** Plugin sandboxing, permission models for plugins.

*   **4.6.8. Outbox and Saga Security**
    *   Ensure that event messages handled by the Outbox and Saga patterns do not inadvertently expose sensitive data if they are logged or transit less secure channels. Sensitive data within events should be minimized or encrypted if necessary.

## 4.7. Logging and Monitoring
A comprehensive logging and monitoring strategy is essential for understanding system behavior, diagnosing issues, and ensuring the reliability and performance of the BlueIQ Framework. Given the distributed nature of the microservice architecture, robust observability is critical.

*   **4.7.1. Logging Strategy**
    *   **A. Logging Framework:**
        *   All .NET services and applications (including Blazor UIs for client-side relevant logs) will use the `Microsoft.Extensions.Logging` abstractions.
        *   **Recommendation:** Serilog will be implemented as the concrete logging provider, configured to integrate with `Microsoft.Extensions.Logging`. Serilog offers rich features for structured logging, flexible sink configuration, and log enrichment.
    *   **B. Log Levels and Conventions:**
        *   Standard log levels will be utilized: `Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical`.
        *   Log levels will be configurable per service (via Configuration Service) to allow dynamic adjustment in different environments (e.g., `Information` in production, `Debug` in development or during troubleshooting).
    *   **C. Structured Logging:**
        *   Logs MUST be written in a structured format, preferably JSON. This allows for easier parsing, querying, and analysis by log aggregation tools.
        *   Serilog's capabilities for structured logging will be fully leveraged.
    *   **D. Key Log Information (Log Context):**
        *   All log entries SHOULD include, at a minimum:
            *   `Timestamp` (UTC)
            *   `LogLevel`
            *   `ServiceName` (identifying the source microservice/application)
            *   `MachineName` / `InstanceId` (to identify the specific instance generating the log)
            *   `CorrelationId` (see below)
            *   `UserId` / `ClientId` (if available in the context, for user-specific actions)
            *   `RequestId` (if applicable to a specific HTTP request)
            *   Log `Message` (human-readable)
            *   `ExceptionDetails` (full exception information, including stack trace, for error logs)
            *   Custom properties relevant to the specific log entry (e.g., `WorkflowId`, `PluginName`, `EventTypeName`).
    *   **E. Log Storage and Aggregation:**
        *   **Local Development:** Logs will be written to the console and/or local files for ease of development and debugging (e.g., using Serilog sinks for Console and File).
        *   **Staging/Production:** Logs from all services and applications MUST be aggregated into a centralized logging system.
            *   **Recommended Tools (MVP):**
                *   **Seq:** Excellent for structured .NET logs, easy to set up and use.
                *   **ELK Stack (Elasticsearch, Logstash, Kibana):** Powerful and scalable, but more complex to set up and manage.
                *   **Cloud Provider Solutions:** Azure Monitor Logs (Application Insights), AWS CloudWatch Logs, Google Cloud Logging. The choice may depend on the target deployment environment.
            *   Services will be configured with appropriate Serilog sinks to ship logs to the chosen centralized system.
    *   **F. Correlation IDs:**
        *   To trace a single logical operation across multiple microservices and events:
            *   A unique `CorrelationId` (Guid) MUST be generated at the entry point of a request (e.g., API Gateway or BFF when a request first enters the system).
            *   This `CorrelationId` MUST be propagated through:
                *   HTTP headers in inter-service calls.
                *   Message headers in RabbitMQ events (and included in the Outbox message).
            *   All log entries related to that logical operation, across all services, MUST include this `CorrelationId`. This is crucial for distributed tracing and debugging.

*   **4.7.2. Monitoring Strategy**
    *   **A. Application Performance Monitoring (APM) & Distributed Tracing:**
        *   **Standard:** OpenTelemetry (OTel) will be adopted as the standard for collecting traces, metrics, and logs.
        *   **Traces:**
            *   Services will be instrumented (using OTel SDKs and auto-instrumentation where possible for ASP.NET Core) to generate distributed traces.
            *   Traces will capture the flow of requests across service boundaries, including timing for each operation.
            *   The `CorrelationId` will be part of the trace context.
        *   **Metrics:**
            *   Key performance indicators (KPIs) will be collected from each service:
                *   Request rates, error rates, and latencies (e.g., ASP.NET Core metrics).
                *   Resource utilization (CPU, memory, network I/O).
                *   Queue lengths and processing times (for RabbitMQ via Event Service).
                *   Database call latencies and error rates.
                *   Outbox processing rates and backlogs.
        *   **APM Backend:** Collected telemetry data (traces, metrics) will be sent to an APM backend compatible with OpenTelemetry.
            *   **Candidates:** Jaeger or Zipkin (for tracing), Prometheus (for metrics) + Grafana (for visualization), or integrated solutions like Datadog, Dynatrace, Azure Monitor (Application Insights). The choice depends on budget and operational preference. For MVP, Application Insights (if on Azure) or a self-hosted Jaeger/Prometheus/Grafana setup could be considered.

    *   **B. Health Checks:**
        *   Each microservice and UI application (Blazor Server apps) MUST expose an ASP.NET Core health check endpoint (e.g., `/health`).
        *   Health checks should verify:
            *   The service's own internal status.
            *   Connectivity to critical dependencies:
                *   Database(s) (Write DB, Read DB if applicable).
                *   RabbitMQ (via Event Service).
                *   Dependent microservices (lightweight check, e.g., can it reach the service discovery endpoint for them).
                *   Configuration Service (if applicable).
        *   The API Gateway can use these health checks for load balancing or service discovery purposes.
        *   Container orchestration platforms (like Kubernetes) will use these health checks for liveness and readiness probes.

    *   **C. Alerting:**
        *   Alerts will be configured based on:
            *   Critical errors logged (e.g., high rate of `Error` or `Critical` logs).
            *   Metric thresholds being breached (e.g., high request latency, high error rate, low disk space, high CPU/memory).
            *   Health check failures.
            *   Dead-letter queue (DLQ) message counts in RabbitMQ.
            *   Outbox processing delays.
        *   **MVP:** Basic alerting via email notifications triggered by the centralized logging/monitoring system.
        *   **Future:** Integration with on-call management tools (e.g., PagerDuty, Opsgenie).

*   **4.7.3. Tooling Summary (MVP Focus)**
    *   **Logging:** `Microsoft.Extensions.Logging` with Serilog. Centralized logging to Seq or ELK (if team has expertise/resources) or cloud provider's solution.
    *   **Tracing & Metrics:** OpenTelemetry SDKs. APM backend like Jaeger/Prometheus/Grafana or Application Insights.
    *   **Health Checks:** ASP.NET Core Health Checks.
    *   **Visualization:** Kibana (if ELK), Grafana (if Prometheus), Seq UI, APM tool's UI.

## 4.8. Technology Stack Summary
This section summarizes the key technologies, frameworks, and tools that will be utilized to build and operate the BlueIQ Framework MVP. The choices aim for a modern, robust, and scalable .NET-centric ecosystem.

*   **4.8.1. Backend Development**
    *   **Language:** C#
    *   **Framework:** .NET 8 (ASP.NET Core for web services/APIs)
    *   **Microservice Architecture:** As detailed in Section 4.1.
    *   **API Gateway:** Ocelot (or YARP as an alternative).
    *   **Database (Core Framework):**
        *   **Write Store:** Microsoft SQL Server 2022.
        *   **Read Store:** Microsoft SQL Server 2022.
        *   **ORM:** Entity Framework (EF) Core.
        *   **Data Features:** SQL Server Temporal Tables, Change Data Capture (CDC).
    *   **Messaging (Asynchronous Communication):**
        *   RabbitMQ (AMQP).
    *   **Distributed Consistency Patterns:**
        *   Outbox Pattern (for reliable event publishing).
        *   Saga Pattern (for managing distributed transactions).
    *   **Authentication:** JWT (JSON Web Tokens).
    *   **Shared Libraries:** .NET Standard / .NET 8 class libraries, distributed via a private NuGet feed.

*   **4.8.2. Frontend Development (Admin Panel & Workflow Designer)**
    *   **Framework:** Blazor Server.
    *   **Language:** C#
    *   **UI Component Library:** MudBlazor.
    *   **Notifications:** Toaster notifications (via MudBlazor Snackbar).

*   **4.8.3. Logging & Monitoring**
    *   **Logging Framework:** `Microsoft.Extensions.Logging` with Serilog.
    *   **Log Aggregation (MVP):** Seq (preferred for ease of use with .NET/Serilog), ELK Stack, or cloud provider solution (e.g., Azure Monitor Logs).
    *   **APM & Distributed Tracing:** OpenTelemetry (OTel) SDKs.
    *   **APM Backend (MVP):** Jaeger/Prometheus + Grafana, or cloud provider solution (e.g., Azure Application Insights).
    *   **Health Checks:** ASP.NET Core Health Checks.

*   **4.8.4. Source Control**
    *   Git.
    *   Polyrepo strategy (multiple repositories).
    *   Hosted on a platform like GitHub, Azure Repos, or GitLab.

*   **4.8.5. CI/CD (Build and Deployment)**
    *   **Tooling:** GitHub Actions, Azure DevOps Pipelines, Jenkins (choice depends on hosting platform and team preference).
    *   **Artifacts:** NuGet packages (for shared libraries), Docker images (for services and UI applications).
    *   **Containerization:** Docker.

*   **4.8.6. Development Environment**
    *   **Operating System:** Windows (primary, though .NET 8 is cross-platform).
    *   **IDE:** Visual Studio 2022, Visual Studio Code.
    *   **Local Orchestration:** Docker Compose for running multiple services locally.

*   **4.8.7. Testing**
    *   **Unit Testing:** xUnit, NUnit, or MSTest (xUnit often preferred for new .NET projects).
    *   **Mocking:** Moq, NSubstitute.
    *   **Integration Testing:** ASP.NET Core TestServer, `WebApplicationFactory`.
    *   **End-to-End (E2E) Testing (Future Consideration):** Playwright, Selenium (for Blazor UI testing).

---

# 5. Non-Functional Requirements (NFRs) Realization

The architecture described in Section 4 has been designed to meet the critical non-functional requirements essential for the BlueIQ Framework's success. This section outlines how specific architectural choices address these NFRs.

*   **5.1. Performance & Responsiveness**
    *   **Objective:** Ensure the system responds quickly to user interactions and processes workflows efficiently.
    *   **Architectural Enablers:**
*   **5.2. Scalability & Elasticity**
    *   **Objective:** Enable the system to handle growth in users, data volume, and transaction load by scaling resources efficiently.
    *   **Architectural Enablers:**
        *   **Microservice Architecture:** Individual services can be scaled independently (horizontally by adding more instances) based on their specific load, optimizing resource utilization.
        *   **Containerization (Docker):** Simplifies packaging, deployment, and scaling of service instances in orchestrated environments (e.g., Kubernetes, Docker Swarm).
        *   **Stateless Services (Design Goal):** Services are designed to be as stateless as possible, facilitating horizontal scaling and load balancing. State is managed in dedicated stores (databases, caches).
        *   **Scalable Message Broker (RabbitMQ):** RabbitMQ can be clustered to handle high volumes of messages, supporting the scaling of event-driven parts of the system.
        *   **Scalable Data Stores:**
            *   The Read Database can be scaled out with read replicas to handle increasing query loads.
            *   SQL Server offers various scalability features.
        *   **API Gateway:** Can be scaled to handle increasing ingress traffic.
        *   **Polyrepo Strategy:** Allows independent scaling of development efforts and deployment pipelines for different components.

*   **5.3. Reliability & Availability**
    *   **Objective:** Ensure the system is operational and accessible with minimal downtime, and can tolerate failures gracefully.
    *   **Architectural Enablers:**
        *   **Microservice Architecture:** Fault isolation – a failure in one non-critical service is less likely to bring down the entire system. Critical services can have higher redundancy.
        *   **Redundancy and Failover:** Achieved by running multiple instances of each service and database replicas, managed by container orchestrators and database HA solutions (e.g., SQL Server Always On Availability Groups).
        *   **Outbox Pattern:** Guarantees reliable event publishing even if the message broker is temporarily unavailable or the service crashes after a database commit, preventing data loss or inconsistent states due to missed events.
        *   **Saga Pattern:** Manages consistency across distributed transactions. Compensating transactions ensure that the system can be rolled back to a consistent state if parts of a multi-service operation fail.
        *   **Health Checks:** Allow orchestration platforms to monitor service health and automatically restart or replace unhealthy instances.
        *   **Resilience in Inter-Service Communication:** Timeouts, retries (e.g., with Polly) for transient faults in synchronous HTTP calls.
        *   **Temporal Tables:** Provide point-in-time recovery capabilities for data, enhancing data integrity and recoverability.
        *   **CDC for Data Synchronization:** Provides a reliable mechanism for propagating data changes.
        *   **RabbitMQ Features:** Message persistence, publisher confirms, and dead-letter exchanges (DLQs) contribute to message reliability.

*   **5.4. Maintainability & Extensibility**
    *   **Objective:** Allow the system to be easily updated, modified, and extended with new features over time.
    *   **Architectural Enablers:**
        *   **Microservice Architecture:** Services are smaller, have well-defined responsibilities (bounded contexts), and can be developed, tested, and deployed independently. This reduces complexity and cognitive load for development teams.
        *   **Polyrepo Strategy:** Clear code ownership, independent versioning, and focused CI/CD pipelines per component.
        *   **Well-Defined APIs and Contracts:** RESTful APIs for synchronous communication and clearly defined event schemas (`blueiq-messaging-contracts`) for asynchronous communication ensure stable integration points.
        *   **Shared Libraries (`blueiq-framework-core`, `blueiq-plugin-sdk`):** Promote code reuse, consistency, and reduce boilerplate. The Plugin SDK is key for extensibility.
        *   **Technology Stack (.NET 8):** A modern, well-supported framework with a large ecosystem and community.
        *   **EF Core Migrations:** Systematic and version-controlled database schema evolution.
        *   **Decoupling via Events:** Services are loosely coupled, allowing them to evolve independently.
        *   **Configuration Management:** Centralized or well-defined configuration approaches simplify environment-specific settings.

*   **5.5. Security**
    *   **Objective:** Protect system data and functionality from unauthorized access and threats.
    *   **Architectural Enablers:**
        *   **Dedicated Authentication Service & JWT:** Centralized and standardized authentication.
        *   **API Gateway Security Enforcement:** Acts as a choke point for validating JWTs and potentially applying coarse-grained authorization.
        *   **Role-Based Access Control (RBAC):** Enforces authorization at various levels.
        *   **HTTPS/TLS:** Encrypts data in transit.
            *   **Key Data:** Framework-level configuration settings, tenant-specific configurations.
            *   **API Contract:** Formal API contracts will be defined using OpenAPI 3.x specifications, maintained within this service's repository. Service) to allow dynamic adjustment in different environments (e.g., `Information` in production, `Debug` in development or during troubleshooting).
        *   **Input Validation:** Protects against common injection vulnerabilities.
        *   **Temporal Tables & CDC:** Provide audit trails for data changes.
        *   **Outbox/Saga Patterns:** Contribute to data integrity, which is a facet of security.
        *   **Principle of Least Privilege:** Applied when defining service permissions and user roles.
        *   **Secure Coding Practices & Dependency Scanning:** Proactive measures against vulnerabilities.

*   **5.6. Testability**
    *   **Objective:** Ensure components and the system as a whole can be effectively tested.
    *   **Architectural Enablers:**
        *   **Microservice Architecture:** Smaller, independent services are easier to unit test and integration test in isolation.
        *   **Well-Defined APIs:** Enable contract testing and focused integration tests.
        *   **Dependency Injection:** Used throughout .NET services, facilitating mocking of dependencies for unit testing.
        *   **Separation of Concerns:** BFFs separate UI concerns from core backend logic. CQRS separates read and write concerns.
        *   **Automated Testing Tools:** Support for xUnit, Moq, `WebApplicationFactory` for integration tests.

*   **5.7. Deployability**
    *   **Objective:** Enable frequent, reliable, and automated deployments of system components.
    *   **Architectural Enablers:**
        *   **Containerization (Docker):** Creates consistent and portable deployment units.
        *   **Polyrepo & Independent CI/CD Pipelines:** Allows services and components to be deployed independently without affecting others, enabling faster release cycles.
        *   **Infrastructure as Code (IaC) (Future):** Tools like Terraform or ARM/Bicep templates can automate infrastructure provisioning.
        *   **EF Core Migrations:** Manage database schema changes as part of the deployment process.
        *   **Health Checks:** Used by deployment orchestrators to verify deployment success.

---

# 6. Testing Strategy

A comprehensive testing strategy is crucial for ensuring the quality, reliability, and correctness of the BlueIQ Framework. The strategy will encompass various levels of testing, focusing on automation to enable rapid feedback and continuous delivery.

*   **6.1. Guiding Principles**
    *   **Automation First:** Prioritize automated tests over manual testing wherever feasible.
    *   **Test Pyramid:** Adhere to the testing pyramid concept – a large base of fast unit tests, a smaller layer of integration tests, and an even smaller layer of end-to-end tests.
    *   **Shift Left:** Integrate testing early in the development lifecycle.
    *   **CI/CD Integration:** All automated tests will be integrated into the CI/CD pipelines. Builds will fail if critical tests do not pass.
    *   **Testability by Design:** Services and components will be designed with testability in mind (e.g., using dependency injection, clear interfaces).

*   **6.2. Levels of Testing**

    *   **6.2.1. Unit Tests**
        *   **Scope:** Focus on testing the smallest individual units of code (e.g., methods, classes, components) in isolation from their dependencies.
        *   **Responsibilities:** Verify the correctness of business logic, algorithms, and component behavior.
        *   **Tools:**
            *   **Test Framework:** xUnit (preferred), NUnit, or MSTest.
            *   **Mocking Framework:** Moq (preferred) or NSubstitute to mock dependencies.
        *   **Location:** Within each service/library's repository, typically in a separate test project (e.g., `ServiceName.Tests.Unit`).
        *   **Execution:** Run automatically on every commit/PR as part of the CI pipeline.
        *   **Coverage Goal:** Aim for high unit test coverage for critical business logic.

    *   **6.2.2. Integration Tests**
        *   **Scope:** Verify the interaction between components or services, or between a service and its external dependencies (e.g., database, message broker, other services).
        *   **Types & Responsibilities:**
            *   **Service-Level Integration Tests:** Test a microservice's interaction with its own database (e.g., using EF Core with an in-memory provider for fast tests or a test database instance). Test interaction with the message broker (e.g., publishing to and consuming from RabbitMQ).
            *   **API Contract Tests (Consumer-Driven Contracts - CDC - *not to be confused with Change Data Capture*):**
                *   Ensure that services consuming APIs from other services (or the API Gateway) are compatible with the provider's contract.
                *   Tools like Pact can be considered for this, though for MVP, focused integration tests validating key API interactions might suffice.
            *   **Outbox Processor Tests:** Verify that the Outbox pattern correctly publishes events after database transactions.
            *   **Saga Orchestration/Choreography Tests:** Verify that sagas correctly coordinate steps across services or handle compensating transactions (these can be complex and may border on E2E).
        *   **Tools:**
            *   ASP.NET Core `WebApplicationFactory` and `TestServer` for in-memory testing of service APIs.
            *   Testcontainers for spinning up ephemeral instances of dependencies like SQL Server or RabbitMQ.
            *   xUnit, NUnit, or MSTest.
        *   **Location:** Within each service's repository, in a separate test project (e.g., `ServiceName.Tests.Integration`).
        *   **Execution:** Run automatically on every commit/PR in the CI pipeline, typically after unit tests.

    *   **6.2.3. End-to-End (E2E) Tests**
        *   **Scope:** Test the entire system flow from the user's perspective, typically interacting with the UIs and validating outcomes across multiple services and data stores.
        *   **Responsibilities:** Verify that complete user scenarios and business workflows function correctly.
        *   **Approach for MVP:**
            *   E2E tests are valuable but can be brittle and slow. For MVP, focus will be on a *limited set* of critical "happy path" E2E scenarios.
            *   These tests will primarily target the Blazor UIs (Admin Panel, Workflow Designer).
        *   **Tools:**
            *   **Web UI Automation:** Playwright (preferred for modern web apps and Blazor) or Selenium.
            *   Test framework (e.g., xUnit, NUnit) to structure and run these tests.
        *   **Location:** Potentially in a dedicated E2E test repository or within the UI repositories.
        *   **Execution:** Run less frequently than unit/integration tests, perhaps nightly or before releases, due to their longer execution time.
        *   **Data Management:** E2E tests will require careful test data setup and teardown strategies.

    *   **6.2.4. Component Tests (Blazor UIs)**
        *   **Scope:** Test individual Blazor components or groups of components in isolation from the full application, but with rendering and user interaction.
        *   **Responsibilities:** Verify UI component logic, rendering, event handling, and interaction with services (mocked).
        *   **Tools:**
            *   **bUnit:** A testing library specifically for Blazor components, allowing them to be tested similarly to unit tests.
        *   **Location:** Within the Blazor UI project repositories (e.g., `blueiq-admin-ui.Tests.Components`).
        *   **Execution:** Run as part of the CI pipeline for the UI applications.

*   **6.3. Specialized Testing Areas**

    *   **6.3.1. Security Testing**
        *   **Static Application Security Testing (SAST):** Integrate SAST tools into CI/CD pipelines to scan code for known vulnerabilities.
        *   **Dependency Scanning:** Use tools (e.g., GitHub Dependabot, Snyk, OWASP Dependency-Check) to identify vulnerabilities in third-party libraries.
    *   **6.3.2. Performance Testing**
        *   **Load Testing:** Simulate expected user loads and transaction volumes to identify performance bottlenecks and ensure the system meets performance NFRs under load.
        *   **Stress Testing:** Push the system beyond normal operating conditions to understand its breaking points and recovery behavior.
        *   **Tools:** k6, JMeter, Azure Load Testing, or similar.
        *   **Focus (MVP):** Basic load tests on critical API Gateway endpoints and key workflow execution paths. More extensive performance testing post-MVP.

    *   **6.3.3. Usability Testing (Informal for MVP)**
        *   Gather feedback from early users (internal team, stakeholders) on the usability of the Admin Panel and Workflow Designer.
        *   Formal usability testing with target user groups can be planned post-MVP.

*   **6.4. Test Data Management**
    *   Strategies for generating and managing test data for different testing levels will be required.
    *   For integration and E2E tests, this might involve:
        *   Seed data scripts.
        *   Resetting databases to a known state before test runs.
        *   Using libraries like Bogus for generating realistic fake data.

---

# 7. Deployment Strategy

The deployment strategy for the BlueIQ Framework aims for automation, consistency, and scalability across various environments, from local development to production. Containerization with Docker is a cornerstone of this strategy.

*   **7.1. Deployment Environments**
    *   **Local Development:** Developer machines for coding and initial testing.
    *   **CI/Testing Environment:** An automated environment where CI builds run, and integration/E2E tests are executed.
    *   **Staging Environment:** A pre-production environment that mirrors production as closely as possible, used for final testing, UAT, and demonstrations.
    *   **Production Environment:** The live environment serving end-users and executing real workflows.

*   **7.2. Packaging: Containerization with Docker**
    *   **Docker Images:** Each microservice, BFF service, Blazor Server UI application, and the API Gateway will be packaged as a Docker image.
    *   **Dockerfiles:** Each component's repository will contain a `Dockerfile` defining how to build its image, including:
        *   Base .NET SDK/Runtime images.
        *   Copying application binaries.
        *   Setting environment variables (placeholders).
        *   Exposing necessary ports.
        *   Defining entry points/commands.
    *   **Container Registry:** Docker images will be versioned (matching the component's SemVer) and pushed to a private container registry (e.g., Azure Container Registry (ACR), Docker Hub private repositories, GitHub Container Registry, AWS ECR).

*   **7.3. Local Development Environment Setup**
    *   **Docker Compose:** A `docker-compose.yml` file (or multiple, organized by concern) will be provided to orchestrate the setup of the entire BlueIQ stack locally. This includes:
        *   All microservices and UI applications.
        *   API Gateway.
        *   Databases (SQL Server Write & Read instances).
        *   RabbitMQ.
        *   Centralized logging/monitoring tools (e.g., local Seq, Prometheus/Grafana stack).
    *   **Benefits:** Simplifies onboarding for new developers and ensures a consistent local environment.
    *   **Configuration:** Local Docker Compose will use environment variables or `.env` files to manage service URLs, connection strings, and other configurations.

*   **7.4. Deployment to Staging & Production**
    *   **Orchestration Platform (Recommendation: Kubernetes)**
        *   For Staging and Production environments, a container orchestration platform is highly recommended for managing deployments, scaling, networking, and resilience.
        *   **Kubernetes (K8s)** is the preferred choice due to its widespread adoption, rich feature set, and strong community support.
        *   Alternatives could include Azure Kubernetes Service (AKS), Amazon EKS, Google GKE, or other managed Kubernetes offerings, or simpler platforms like Docker Swarm if K8s complexity is a concern for initial MVP.
    *   **Deployment Manifests (Kubernetes):**
        *   Kubernetes deployment manifests (YAML files) will define:
            *   `Deployments` (for stateless services, managing replicas).
            *   `StatefulSets` (for stateful components like databases if run in K8s, though managed DB services are often preferred).
            *   `Services` (for internal networking and service discovery).
            *   `Ingress` (for exposing services externally, often integrated with the API Gateway's role).
            *   `ConfigMaps` and `Secrets` (for managing application configuration and sensitive data).
            *   Persistent Volume Claims (`PVCs`) for data storage.
        *   These manifests will be version-controlled, potentially in a dedicated `blueiq-infrastructure` repository or alongside each service.
    *   **Deployment Process (CI/CD Integration):**
        1.  CI pipeline builds the Docker image and pushes it to the container registry.
        2.  CD pipeline (triggered by successful CI or manually) applies the Kubernetes manifests (or updates existing deployments) to the target environment (Staging, then Production).
        3.  Strategies like Blue/Green deployments or Canary releases can be adopted post-MVP to minimize downtime and risk during updates. For MVP, rolling updates provided by Kubernetes are standard.
    *   **Database Deployment:**
        *   **Managed Database Services:** For Staging and Production, using managed database services (e.g., Azure SQL Database, AWS RDS for SQL Server) is STRONGLY recommended over self-hosting SQL Server in containers. This offloads management, backup, patching, and HA.
        *   **Schema Migrations (EF Core):** Database schema migrations will be applied as a step in the CD pipeline before the new application version is fully rolled out. This could be via:
            *   A dedicated migration job/container that runs `dotnet ef database update`.
            *   The application itself applying migrations on startup (less ideal for production due to potential for multiple instances trying to migrate simultaneously, but can be managed with leader election or startup probes). A separate migration step is cleaner.
    *   **RabbitMQ Deployment:**
        *   Can be deployed as a cluster in Kubernetes (e.g., using RabbitMQ Cluster Kubernetes Operator) or use a managed RabbitMQ service if available from the cloud provider.

*   **7.5. Configuration Management**
    *   Configuration for different environments (local, staging, production) will be managed externally from the Docker images.
    *   **Methods:**
        *   Environment variables injected into containers by the orchestrator.
        *   Kubernetes `ConfigMaps` and `Secrets`.
        *   Integration with the `Configuration Service` which sources its values from these environment-specific mechanisms.
        *   Azure App Configuration or HashiCorp Consul (post-MVP for more advanced dynamic configuration).

*   **7.6. Zero-Downtime Deployments (Goal for Post-MVP)**
    *   While rolling updates in Kubernetes provide minimal disruption, true zero-downtime deployments require careful handling of:
        *   Database schema compatibility during transitions.
        *   API versioning and backward compatibility.
        *   Connection draining and readiness/liveness probes.
    *   This will be an iterative improvement target.

---

# 8. Future Considerations and Scalability

The BlueIQ Framework MVP architecture is designed not only to meet immediate requirements but also to provide a solid foundation for future growth, new features, and increased scale. This section outlines potential areas for future development and how the chosen architecture supports these evolutions.

*   **8.1. Enhanced Scalability & Performance**
    *   **Advanced Caching Strategies:**
        *   Implement distributed caching (e.g., Redis, Memcached) for frequently accessed, slowly changing data to reduce database load and improve response times for read-heavy operations. This can be applied at the API Gateway, BFF, or core service levels.
    *   **Read Model Optimization:** Further optimize the Read Database schema and query patterns as specific performance bottlenecks are identified. Consider specialized read stores (e.g., NoSQL document databases like MongoDB or Elasticsearch for specific query types) if relational reads become a constraint for certain data.
    *   **gRPC for Inter-Service Communication:** For performance-critical internal service-to-service communication, gRPC could be adopted as an alternative to HTTP/REST due to its efficiency and use of Protocol Buffers.
    *   **Autoscaling Refinements:** Fine-tune autoscaling rules in Kubernetes based on custom metrics for more responsive and cost-effective scaling.

*   **8.2. Feature Enhancements**
    *   **Multi-Tenancy:** Architect the system to support multiple tenants with data isolation and customizable experiences if this becomes a requirement. The current data isolation for plugins provides a conceptual starting point.
    *   **Advanced Workflow Capabilities:**
        *   Human-in-the-loop workflows (requiring manual approval steps).
        *   More complex branching, looping, and error handling logic in workflows.
        *   Workflow versioning with side-by-side execution and migration paths.
    *   **Expanded Plugin Ecosystem:**
        *   A public or marketplace-style plugin discovery mechanism.
        *   More sophisticated plugin lifecycle management (e.g., hot-swapping, versioning).
        *   Plugin sandboxing for enhanced security and resource control.
    *   **Enhanced Configuration Management:** Integrate with advanced configuration management tools like Azure App Configuration or HashiCorp Consul for dynamic, feature-flag driven configuration.
    *   **AI/ML Integration:** Incorporate AI/ML capabilities for predictive workflow execution, anomaly detection, or intelligent task routing.
    *   **Real-time UI Updates:** For highly dynamic UIs, explore technologies like SignalR in conjunction with Blazor Server or WebAssembly for real-time updates pushed from the server.

*   **8.3. Operational Excellence**
    *   **Advanced CI/CD Strategies:** Implement Blue/Green deployments, Canary releases, or A/B testing deployment strategies for safer and more controlled rollouts.
    *   **Infrastructure as Code (IaC):** Fully adopt IaC using tools like Terraform or Bicep/ARM templates to manage all cloud infrastructure components.
    *   **Mature Observability:** Enhance the monitoring stack with more sophisticated dashboards, anomaly detection in metrics, and distributed log correlation across more dimensions. Implement synthetic monitoring.
    *   **Chaos Engineering:** Introduce controlled experiments to test system resilience and identify weaknesses proactively.

*   **8.4. Evolving Security Posture**
    *   **Fine-grained Permissions/Policy-Based Authorization:** Move beyond simple RBAC to more granular permission or attribute-based access control (ABAC) systems if needed.
    *   **Web Application Firewall (WAF):** Implement a WAF at the edge for protection against common web exploits.
    *   **Regular Security Audits & Penetration Testing:** Establish a cadence for formal security assessments.
    *   **Refresh Token Implementation:** Implement refresh tokens for improved user experience without compromising access token security.

*   **8.5. Data & Analytics**
    *   **Data Warehousing/Lake:** For advanced analytics and business intelligence, establish a data pipeline (potentially leveraging CDC data) to a data warehouse or data lake.
    *   **Reporting & Visualization:** Integrate with BI tools for richer reporting on workflow performance, system usage, and other metrics.

*   **8.6. Broader Technology Adoption**
    *   **Alternative Message Brokers:** While RabbitMQ is robust, Kafka could be considered if extremely high-throughput event streaming or log aggregation becomes a primary use case.
    *   **Serverless Functions:** For specific, event-driven, short-lived tasks, serverless functions (e.g., Azure Functions, AWS Lambda) could complement the microservice architecture.

---

# 9. Appendices

This section provides supplementary materials to support the Technical Architecture Document, including diagrams, a glossary of terms, and a log of key architectural decisions.

*   **9.1. Appendix A: High-Level Architecture Diagram**
    Below is the Mermaid.js code for the High-Level Architecture Diagram. This can be rendered using tools like the Mermaid Live Editor or VS Code extensions.

    ```mermaid
graph TD
    %% External Users
    subgraph External Users
        U_Admin[Admin User]
        U_Designer[Workflow Designer User]
    end

    %% User Interfaces (Blazor Server Applications)
    subgraph User Interfaces
        style UI_AdminPanel fill:#D6EAF8,stroke:#2E86C1
        style UI_DesignerPanel fill:#D6EAF8,stroke:#2E86C1
        UI_AdminPanel[Admin Panel UI]
        UI_DesignerPanel[Workflow Designer UI]
    end

    %% API Gateway
    subgraph API Gateway
        style APIGateway fill:#FADBD8,stroke:#C0392B
        APIGateway[blueiq-api-gateway API Gateway]
    end

    %% Backend For Frontend (BFF) Services
    subgraph Backend For Frontend Services
        style BFF_Admin fill:#D5F5E3,stroke:#28B463
        style BFF_Designer fill:#D5F5E3,stroke:#28B463
        BFF_Admin[Admin BFF Service]
        BFF_Designer[Designer BFF Service]
    end

    %% Core Microservices
    subgraph Core Microservices
        style MS_Auth fill:#E8DAEF,stroke:#8E44AD
        style MS_UserMgmt fill:#E8DAEF,stroke:#8E44AD
        style MS_Workflow fill:#E8DAEF,stroke:#8E44AD
        style MS_Plugin fill:#E8DAEF,stroke:#8E44AD
        style MS_Event fill:#E8DAEF,stroke:#8E44AD
        style MS_Config fill:#E8DAEF,stroke:#8E44AD
        MS_Auth[Authentication Service]
        MS_UserMgmt[User Management Service]
        MS_Workflow[Workflow Service]
        MS_Plugin[Plugin Service]
        MS_Event[Event Service]
        MS_Config[Configuration Service]
    end

    %% Messaging System
    subgraph Messaging System
        style RabbitMQ fill:#FCF3CF,stroke:#F39C12
        style OutboxProcessor fill:#FCF3CF,stroke:#F39C12
        RabbitMQ[RabbitMQ Message Broker]
        OutboxProcessor[/Outbox Processor/]
    end

    %% Data Stores (SQL Server 2022)
    subgraph Data Stores
        style DB_Write fill:#FEF9E7,stroke:#F7DC6F,color:#000
        style DB_Read fill:#FEF9E7,stroke:#F7DC6F,color:#000
        style DB_Plugins fill:#FEF9E7,stroke:#F7DC6F,color:#000
        style CDC_Pipeline fill:#FEF9E7,stroke:#F7DC6F,color:#000
        DB_Write["Write Database (SQL Server 2022)<br/>- Temporal Tables<br/>- CDC Source<br/>- Outbox Table"]
        DB_Read["Read Database (SQL Server 2022)<br/>- Query Store"]
        DB_Plugins["Plugin Databases<br/>(Separate SQL Instances)"]
        CDC_Pipeline[CDC Pipeline]
    end

    %% Interactions
    U_Admin --> UI_AdminPanel
    U_Designer --> UI_DesignerPanel

    UI_AdminPanel -- HTTPS --> APIGateway
    UI_DesignerPanel -- HTTPS --> APIGateway

    APIGateway -- Routes to --> BFF_Admin
    APIGateway -- Routes to --> BFF_Designer
    APIGateway -.->|1. Validates JWT with| MS_Auth

    BFF_Admin -- HTTP --> MS_Workflow
    BFF_Admin -- HTTP --> MS_UserMgmt
    BFF_Admin -- HTTP --> MS_Config
    BFF_Admin -- HTTP Queries --> DB_Read

    BFF_Designer -- HTTP --> MS_Workflow
    BFF_Designer -- HTTP --> MS_Plugin
    BFF_Designer -- HTTP --> MS_Config
    BFF_Designer -- HTTP Queries --> DB_Read

    MS_Auth -- HTTP --> MS_UserMgmt
    MS_Auth --> DB_Write

    MS_UserMgmt --> DB_Write

    MS_Workflow -- HTTP --> MS_Plugin
    MS_Workflow -- HTTP --> MS_Event
    MS_Workflow --> DB_Write
    MS_Workflow -- HTTP Queries --> DB_Read

    MS_Plugin --> DB_Write
    MS_Plugin -- HTTP Queries --> DB_Read
    MS_Plugin --> DB_Plugins

    MS_Config --> DB_Write

    MS_Event -- Publishes/Manages --> RabbitMQ
    MS_Workflow -- Subscribes via Event Service/Directly --> RabbitMQ
    MS_Plugin -- Subscribes via Event Service/Directly --> RabbitMQ
    %% Other services might subscribe

    %% Outbox Pattern
    DB_Write -- Outbox Records --> OutboxProcessor
    OutboxProcessor -- Reliably Publishes --> RabbitMQ

    %% CDC
    DB_Write -- CDC --> CDC_Pipeline
    CDC_Pipeline -- Syncs --> DB_Read

    %% General Notes (Conceptual - Not directly drawn as nodes)
    %% Note1[Polyrepo Structure]
    %% Note2[Private NuGet Feed for Shared Libraries]
    %% Note3[Containerization: Docker for all services/UIs]
    %% Note4[Orchestration: Kubernetes for Staging/Prod]
    %% Note5[Centralized Logging & Monitoring]

    classDef default fill:#fff,stroke:#333,stroke-width:1.5px,color:#000;
    ```

    **User Login Flow Sequence Diagram:**

    ```mermaid
sequenceDiagram
    actor User
    participant UI as Admin/Designer UI
    participant APIGateway as API Gateway
    participant AuthService as Authentication Service
    participant UserMgmtService as User Management Service
    participant WriteDB as Write Database

    User->>UI: Enters credentials and clicks Login
    UI->>APIGateway: POST /api/auth/login (credentials)
    APIGateway->>AuthService: POST /login (credentials)

    AuthService->>UserMgmtService: GET /users/validate?username={username} (or similar to fetch user details for password check)
    UserMgmtService->>WriteDB: SELECT User WHERE Username={username}
    WriteDB-->>UserMgmtService: User details (hashed password, salt, status)
    UserMgmtService-->>AuthService: User details

    alt Credentials Valid
        AuthService->>AuthService: Generate JWT
        AuthService->>WriteDB: (Optional) Log successful login attempt
        WriteDB-->>AuthService: Log persisted
        AuthService-->>APIGateway: 200 OK (JWT Token)
        APIGateway-->>UI: 200 OK (JWT Token)
        UI->>User: Login successful, store JWT, redirect to dashboard
    else Credentials Invalid
        AuthService->>WriteDB: (Optional) Log failed login attempt
        WriteDB-->>AuthService: Log persisted
        AuthService-->>APIGateway: 401 Unauthorized
        APIGateway-->>UI: 401 Unauthorized
        UI->>User: Display login error message
    end
    ```

    **Admin Fetching Workflow Instances Sequence Diagram:**

    ```mermaid
sequenceDiagram
    actor Admin
    participant AdminUI as Admin Panel UI
    participant APIGateway as API Gateway
    participant AdminBFF as Admin BFF Service
    participant WorkflowService as Workflow Service
    participant ReadDB as Read Database

    Admin->>AdminUI: Requests list of workflow instances (e.g., clicks "View Workflows")
    AdminUI->>APIGateway: GET /api/admin/workflows?params={filter/paging}
    APIGateway->>AdminBFF: GET /workflows?params={filter/paging}
    
    AdminBFF->>WorkflowService: GET /workflows?params={filter/paging}
    WorkflowService->>ReadDB: SELECT * FROM WorkflowInstancesView WHERE {filter criteria} ORDER BY ... OFFSET ... LIMIT ...
    ReadDB-->>WorkflowService: List of workflow instance data
    WorkflowService-->>AdminBFF: Workflow instance data (DTOs)
    
    AdminBFF-->>APIGateway: 200 OK (Workflow instance data)
    APIGateway-->>AdminUI: 200 OK (Workflow instance data)
    AdminUI->>Admin: Displays list of workflow instances
    end
    ```

    **Workflow Execution Triggering an Event Sequence Diagram:**

    ```mermaid
sequenceDiagram
    participant WorkflowService as Workflow Service
    participant WriteDB as Write Database (with Outbox Table)
    participant OutboxProcessor as Outbox Processor
    participant RabbitMQ as RabbitMQ Message Broker
    participant SubscribingService as Other Subscribing Service(s)

    WorkflowService->>WriteDB: BEGIN TRANSACTION
    WorkflowService->>WriteDB: 1. Perform business logic (e.g., update workflow state)
    WorkflowService->>WriteDB: 2. Insert event message into Outbox Table
    WriteDB-->>WorkflowService: Data & Event persisted
    WorkflowService->>WriteDB: COMMIT TRANSACTION
    WriteDB-->>WorkflowService: Transaction committed

    %% Asynchronous processing by Outbox Processor
    OutboxProcessor->>WriteDB: Periodically polls Outbox Table for new events
    WriteDB-->>OutboxProcessor: New event(s) found
    
    OutboxProcessor->>RabbitMQ: Publish event message
    RabbitMQ-->>OutboxProcessor: Message Acknowledged (if publisher confirms enabled)
    
    OutboxProcessor->>WriteDB: Mark event as processed in Outbox Table (or delete)
    WriteDB-->>OutboxProcessor: Event marked/deleted

    %% Event Consumption
    RabbitMQ-->>SubscribingService: Delivers event message
    SubscribingService->>SubscribingService: Process event (e.g., update its own data, trigger further actions)
    end
    ```

*   **9.2. Appendix B: Glossary**
    *(Placeholder: This section will contain definitions of key terms, acronyms, and concepts used throughout the TAD to ensure common understanding.)*
    *   Examples: BFF, CQRS, CDC (Change Data Capture), JWT, Polyrepo, Saga, Outbox, SemVer, Temporal Tables, etc.

*   **9.3. Appendix C: Architectural Decision Log (ADL)**
    *(Placeholder: This section will document significant architectural decisions made during the design process, including the options considered, rationale for the chosen option, and any trade-offs. This is a living document that would be updated as the system evolves.)*
    *   **Example Entry Format:**
        *   **Decision ID:** ADL-001
        *   **Date:** YYYY-MM-DD
        *   **Status:** Decided/Proposed
        *   **Decision:** Adopt a Polyrepo strategy for source code management.
        *   **Context:** Need to manage multiple independent services, UIs, and shared libraries.
        *   **Options Considered:** Monorepo, Polyrepo.
        *   **Rationale:** Polyrepo chosen for independent versioning, CI/CD pipelines, clear ownership, and alignment with microservice independence.
        *   **Consequences/Trade-offs:** Requires management of dependencies via NuGet; local development setup needs orchestration (e.g., Docker Compose).

---
