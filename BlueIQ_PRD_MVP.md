# BlueIQ Framework - Product Requirements Document (MVP)

**Document Version:** 1.0
**Date:** June 5, 2025
**Status:** Draft Final

## Table of Contents
1.  [Goal, Objective, and Context](#1-goal-objective-and-context)
2.  [Functional Requirements (MVP)](#2-functional-requirements-mvp)
3.  [Non-Functional Requirements (MVP)](#3-non-functional-requirements-mvp)
4.  [User Interaction and Design Goals](#4-user-interaction-and-design-goals)
5.  [Technical Assumptions](#5-technical-assumptions)
6.  [Epic Overview & User Stories (MVP)](#6-epic-overview--user-stories-mvp)
    *   [Epic 1: Core Workflow Orchestration](#epic-1-core-workflow-orchestration)
    *   [Epic 2: Plugin Ecosystem Management](#epic-2-plugin-ecosystem-management)
    *   [Epic 3: Event-Driven Communication Backbone](#epic-3-event-driven-communication-backbone)
    *   [Epic 4: Data Persistence & Abstraction Layer](#epic-4-data-persistence--abstraction-layer)
    *   [Epic 5: Centralized Framework Configuration](#epic-5-centralized-framework-configuration)
    *   [Epic 6: Essential Security & Operational Services](#epic-6-essential-security--operational-services)
    *   [Epic 7: System Administration & Monitoring UI (Admin Panel)](#epic-7-system-administration--monitoring-ui-admin-panel)
    *   [Epic 8: Visual Workflow Design & Management (Workflow Designer)](#epic-8-visual-workflow-design--management-workflow-designer)
7.  [Out of Scope (for MVP)](#7-out-of-scope-for-mvp)
8.  [Core Technical Decisions](#8-core-technical-decisions)
9.  [Checklist Results: PRD Quality Checklist](#9-checklist-results-prd-quality-checklist)
10. [Initial Architect Prompt for BlueIQ Framework MVP](#10-initial-architect-prompt-for-blueiq-framework-mvp)

---

## 1. Goal, Objective, and Context

*   **Goal:**
    To establish BlueIQ as a comprehensive, enterprise-grade, and highly extensible .NET-based framework that empowers organizations to rapidly design, build, deploy, and manage sophisticated, event-driven, and workflow-centric business applications and integration solutions, fostering agility, scalability, and operational excellence.

*   **Objective:**
    *   Provide a robust, pluggable workflow engine inspired by SSIS, enabling visual design, scheduling, and monitoring of complex business processes.
    *   Offer a comprehensive plugin management system for modular development, lifecycle management, and secure integration of custom and third-party functionalities.
    *   Implement a resilient core event system supporting asynchronous communication and diverse messaging providers to facilitate decoupled architectures.
    *   Deliver a flexible data layer abstraction allowing integration with various data storage technologies while promoting clean architecture principles.
    *   Establish a hybrid configuration management system for centralized control and dynamic updates of application settings.
    *   Furnish a suite of essential middleware services (AuthN/AuthZ, Logging/Monitoring, Caching, API Gateway) to accelerate development and ensure operational readiness.
    *   Enable seamless integration with a wide array of enterprise technologies and systems (e.g., databases, message queues, ERPs, CRMs) through a rich connector/adapter ecosystem.
    *   Provide intuitive user interfaces (Admin Panel, Workflow Designer) for efficient system administration, development, and operational oversight.

*   **Context:**
    Modern enterprises face increasing pressure to digitize operations, integrate disparate systems, and respond rapidly to changing market demands. Developing custom solutions that are scalable, maintainable, and secure often involves significant repetitive effort in building foundational components like workflow orchestration, event handling, plugin architectures, and operational tooling. BlueIQ addresses this challenge by providing a standardized, feature-rich framework that abstracts common complexities, allowing development teams to focus on delivering unique business value rather than reinventing core infrastructure. It aims to reduce development time, improve solution quality, and provide a consistent operational model for a wide range of enterprise applications, from internal process automation to complex system integrations.

---

## 2. Functional Requirements (MVP)

The Minimum Viable Product (MVP) for the BlueIQ Framework will deliver the following core functionalities:

*   **2.1 Pluggable Workflow Engine (Core):**
    *   2.1.1 Ability to define workflows consisting of a sequence of executable steps (plugins).
    *   2.1.2 Runtime execution of defined workflows.
    *   2.1.3 Basic scheduling capabilities for initiating workflows (e.g., time-based triggers).
    *   2.1.4 Persistence of workflow instance state to allow for basic monitoring and recovery.
    *   2.1.5 API for programmatic interaction with the workflow engine (e.g., start workflow, query status).
*   **2.2 Plugin Management System (Core):**
    *   2.2.1 Ability to discover and load .NET-based plugins at runtime.
    *   2.2.2 Basic plugin lifecycle management (load, unload - if feasible for MVP, enable, disable).
    *   2.2.3 Secure mechanism for plugins to register their capabilities and be invoked by the workflow engine or event system.
    *   2.2.4 Basic versioning support for plugins.
*   **2.3 Core Event System (Core):**
    *   2.3.1 Ability for components and plugins to publish events.
    *   2.3.2 Ability for components and plugins to subscribe to specific events.
    *   2.3.3 Support for at least one message broker for asynchronous event delivery (e.g., RabbitMQ as a default).
    *   2.3.4 Basic event catalog for discovering available event types.
*   **2.4 Data Layer Abstraction (Core):**
    *   2.4.1 Define core interfaces (e.g., Repository pattern) for data access.
    *   2.4.2 Provide an initial implementation for SQL Server using Entity Framework Core.
    *   2.4.3 Mechanism for plugins to define and manage their own data schemas/models through the abstraction.
*   **2.5 Hybrid Configuration Management (Core):**
    *   2.5.1 Ability to load framework and plugin configurations from local files (e.g., `appsettings.json`) and environment variables.
    *   2.5.2 API for accessing configuration values at runtime.
    *   2.5.3 Support for hierarchical configuration and environment-specific overrides.
*   **2.6 Core Middleware Services (MVP Set):**
    *   2.6.1 **Authentication & Authorization:**
        *   Secure API endpoints using a standard token-based mechanism (e.g., JWT).
        *   Basic RBAC model for controlling access to core framework APIs and Admin Panel functionalities.
    *   2.6.2 **Logging & Basic Monitoring:**
        *   Structured logging for framework core services and plugin activities.
        *   Ability to output logs to console and/or a file.
        *   Basic health check endpoint for core services.
*   **2.7 Admin Panel (MVP UI - Blazor):**
    *   2.7.1 **Operational Dashboard (MVP):**
        *   Display a list of loaded plugins and their status.
        *   Display a list of recent workflow instances and their status.
        *   Basic view of system logs.
    *   2.7.2 **Plugin Management UI (MVP):**
        *   View loaded plugins.
        *   Enable/disable plugins.
    *   2.7.3 **Workflow Management UI (MVP):**
        *   View list of defined workflows.
        *   Manually trigger a workflow.
        *   View status of running/completed workflow instances.
    *   2.7.4 **User Management UI (MVP):**
        *   Basic interface for managing users and assigning roles for Admin Panel access.
*   **2.8 Workflow Designer UI (Visual MVP - Blazor):**
    *   2.8.1 Ability to visually drag-and-drop registered plugins from a palette onto a design canvas to form a workflow sequence.
    *   2.8.2 Ability to visually connect workflow steps (plugins) to define the flow of execution.
    *   2.8.3 Interface for configuring basic properties of each workflow step (plugin) directly on the canvas or via a properties panel.
    *   2.8.4 Ability to save named workflow definitions.
    *   2.8.5 Ability to load existing workflow definitions into the designer for viewing or editing.

---

## 3. Non-Functional Requirements (MVP)

The Minimum Viable Product (MVP) for the BlueIQ Framework will adhere to the following essential Non-Functional Requirements:

*   **3.1 Performance (MVP Focus):**
    *   **3.1.1 Responsiveness:** Core framework APIs should respond within acceptable limits for typical single-user interactions (e.g., P95 under 500ms for core operations, Admin Panel UI basic interactions within 3 seconds).
    *   **3.1.2 Resource Utilization:** The framework should operate with a reasonable memory and CPU footprint for basic scenarios.
*   **3.2 Security (MVP Essentials):**
    *   **3.2.1 Secure API Access:** All framework APIs and Admin Panel access must be authenticated (e.g., via JWT).
    *   **3.2.2 Basic Authorization:** Role-based access control (RBAC) for Admin Panel functionalities.
    *   **3.2.3 Data in Transit:** Communication between the Admin Panel and backend services should use HTTPS.
    *   **3.2.4 Secrets Management (Basic):** Secure handling of sensitive configuration values – avoid hardcoding; support via environment variables or configuration files with appropriate access controls.
*   **3.3 Reliability & Availability (MVP Stability):**
    *   **3.3.1 Stability:** Core framework services should be stable under typical single-user or light load conditions.
    *   **3.3.2 Error Handling:** Graceful error handling and informative logging for common failure scenarios.
    *   **3.3.3 Workflow State Persistence:** Workflow instance states must be reliably persisted.
*   **3.4 Maintainability & Extensibility (MVP Foundation):**
    *   **3.4.1 Modularity:** The plugin architecture must allow for the development and loading of custom plugins as separate .NET assemblies.
    *   **3.4.2 Code Quality (Core):** Core framework code should adhere to .NET best practices.
    *   **3.4.3 Basic Documentation:** Essential developer documentation (plugin creation, setup).
*   **3.5 Usability (MVP Developer & Admin Focus):**
    *   **3.5.1 Developer Experience (Plugin Dev):** Clear, documented process for creating, building, and deploying a simple plugin.
    *   **3.5.2 Admin Panel Usability:** Intuitive for technical users for basic plugin and workflow management.
    *   **3.5.3 Workflow Designer Usability:** Visual designer must allow technical users to create, save, and load simple workflows.

---

## 4. User Interaction and Design Goals

This section outlines the high-level vision and goals for the User Experience (UX) of the BlueIQ Framework's UI components, primarily the Admin Panel and the Workflow Designer. This will serve as a brief for the Design Architect (Jane).

*   **Overall Vision & Experience:**
    *   **Admin Panel:** Professional, clean, and intuitive. Empower administrators and developers with clear insights and efficient control. Data-intensive where necessary but understandable and actionable.
    *   **Workflow Designer:** Highly visual, interactive, and intuitive, mirroring SSIS ease-of-use. Powerful yet approachable. AI-driven BMAD scaffolding mode (for new systems) should feel guided and supportive.
*   **Key Interaction Paradigms:**
    *   **Admin Panel:** Standard dashboard navigation, sortable/filterable tables, clear forms, visual status cues.
    *   **Workflow Designer:** Drag-and-drop, visual connectors, inline/panel-based configuration, real-time validation feedback where possible.
*   **Core Screens/Views (Conceptual MVP):**
    *   **Admin Panel:** Login, Main Dashboard, Plugin Management, Workflow Definitions, Workflow Instance Detail, User Management, System Logs (basic).
    *   **Workflow Designer:** Main design canvas with plugin palette, Properties panel, Workflow save/load dialogs.
*   **Accessibility Aspirations (Initial):**
    *   Aim for WCAG 2.1 Level A as baseline for MVP, Level AA as target for future. Keyboard navigability for core functions.
*   **Branding Considerations (High-Level):**
    *   To be defined. Initially, a clean, professional, neutral theme. Allow for theming/customization later.
*   **Target Devices/Platforms:**
    *   **Admin Panel & Workflow Designer:** Primarily web desktop (modern browsers). Responsive for tablet secondary for MVP.

---

## 5. Technical Assumptions

This section outlines the foundational technical decisions and assumptions for the BlueIQ Framework MVP. These will guide the Architect (Fred) in developing the detailed technical architecture.

*   **5.1 Primary Technology Stack (MVP):**
    *   **Backend Framework:** .NET 8 (ASP.NET Core for APIs and services).
    *   **Frontend UI (Admin Panel & Workflow Designer):** Blazor.
    *   **Database for Core Services (MVP):** SQL Server.
    *   **Message Broker (MVP):** RabbitMQ.
    *   **Initial Development Environment:** Windows with Visual Studio or VS Code.

*   **5.2 Repository Structure (CRITICAL DECISION): Polyrepo**
    *   **Decision:** The BlueIQ Framework will adopt a Polyrepo structure.
    *   **Rationale:** Independent evolution, clear ownership, optimized CI/CD, long-term technology flexibility.
    *   **Implications for MVP:** Setup of distinct repositories, strategy for inter-repo dependencies (e.g., NuGet), Architect to define initial repositories.

*   **5.3 Service Architecture (CRITICAL DECISION - for BlueIQ Core Services): Microservices**
    *   **Decision:** Core backend functionalities will be designed as cooperating Microservices.
    *   **Rationale:** Scalability, resilience, independent deployability, alignment with modern practices.
    *   **Implications for MVP:** Clear API contracts, service discovery, load balancing, inter-service security, Architect to define service breakdown and interactions, higher operational complexity.

*   **5.4 Testing Requirements (MVP):**
    *   **Unit Tests:** Comprehensive for critical business logic.
    *   **Integration Tests:** Basic for key microservice interactions and dependencies.
    *   **End-to-End (E2E) UI Tests:** Automated for critical user flows in Blazor UIs.
    *   **No Manual Test Scripts:** Goal is high test automation.

---

## 6. Epic Overview & User Stories (MVP)

### Epic 1: Core Workflow Orchestration
*Goal: To establish the fundamental capabilities for defining, executing, scheduling, and monitoring workflows within the BlueIQ framework.*

**User Story 1.1: Define a Workflow Structure**
*   **As a** Framework Developer (or a user of the Workflow Designer in later epics),
*   **I want to** be able to define a workflow as a structured sequence of executable steps (plugins), including their configuration,
*   **So that** I can model a specific business process or integration task for the framework to execute.
**Acceptance Criteria:**
1.  A workflow definition must support an ordered list of steps.
2.  Each step must reference a registered plugin.
3.  Each step must allow storing specific configuration parameters for its plugin.
4.  Workflow definition structure must be serializable.
5.  Mechanism (API/service) to CRUD workflow definitions.
**Notes for Architect/Scrum Master:** Consider unique IDs, internal representation (linear for MVP), flexible plugin config handling.

**User Story 1.2: Execute a Defined Workflow**
*   **As a** System Process or an authorized User,
*   **I want to** trigger the execution of a defined workflow,
*   **So that** the sequence of configured plugin steps is performed.
**Acceptance Criteria:**
1.  Engine loads workflow definition.
2.  Engine executes steps in order.
3.  Engine invokes plugin with configuration for each step.
4.  Engine captures execution status of steps and overall instance.
5.  Basic error handling: failed step marks instance as failed, error logged.
6.  API to initiate workflow execution.
**Notes for Architect/Scrum Master:** Inter-step data passing, plugin execution model (sync/async), idempotency, logging.

**User Story 1.3: Schedule Workflow Execution**
*   **As a** System Administrator or an authorized User,
*   **I want to** schedule a workflow to run at specific times/intervals,
*   **So that** routine tasks can be automated.
**Acceptance Criteria:**
1.  System allows associating a schedule (CRON/interval) with a workflow.
2.  Engine/Scheduling Service triggers workflows based on schedules.
3.  API to CRUD workflow schedules.
4.  Scheduled executions logged as distinct instances.
**Notes for Architect/Scrum Master:** Scheduling mechanism (e.g., Quartz.NET), handling missed schedules, scheduler resilience.

**User Story 1.4: Monitor Workflow Instance Status**
*   **As a** System Administrator or an authorized User,
*   **I want to** query status and details of running/completed workflow instances,
*   **So that** I can track progress and identify issues.
**Acceptance Criteria:**
1.  Each execution has a unique instance ID.
2.  System stores/provides status (Pending, Running, Succeeded, Failed, Cancelled) of instances.
3.  System stores/provides start/end time, duration of instances.
4.  API to retrieve list of instances, filterable by status, definition ID, time.
5.  Ability to retrieve status of individual steps for an instance.
**Notes for Architect/Scrum Master:** Level of detail for step execution, data retention for instance history.

**User Story 1.5: Persist Workflow Instance State**
*   **As the** Workflow Engine,
*   **I want to** reliably persist state of instances and steps,
*   **So that** system can recover from shutdowns and provide accurate monitoring.
**Acceptance Criteria:**
1.  Instance creation and status changes persisted to database.
2.  Status of individual steps persisted.
3.  Persistence handles concurrent executions.
4.  On restart, last known state of running instances determinable.
**Notes for Architect/Scrum Master:** Critical for reliability (SQL Server), schema definition, performance of state updates.

### Epic 2: Plugin Ecosystem Management
*Goal: To establish the capabilities for discovering, loading, managing the lifecycle, and securely invoking .NET-based plugins.*

**User Story 2.1: Discover and Load Plugins**
*   **As the** BlueIQ Framework (Plugin Management Service),
*   **I want to** discover and load .NET plugin assemblies from a designated location,
*   **So that** their functionalities become available.
**Acceptance Criteria:**
1.  Framework defines plugin contract/interface.
2.  Service configurable with path(s) to scan for plugins.
3.  Service loads valid plugin assemblies (startup/on-demand).
4.  Info about loaded plugins (name, version, description, capabilities) registered and available.
5.  Errors during discovery/loading logged clearly.
**Notes for Architect/Scrum Master:** AssemblyLoadContext for isolation (future), plugin dependency handling (simple for MVP).

**User Story 2.2: Register Plugin Capabilities**
*   **As a** Plugin Developer,
*   **I want to** declare capabilities, input/output parameters of my plugin,
*   **So that** Framework understands how to use and configure it.
**Acceptance Criteria:**
1.  Plugins expose metadata about executable actions.
2.  Metadata includes input parameter details (name, type, required, description).
3.  Metadata includes output parameter details.
4.  Plugin Management Service reads metadata on load.
**Notes for Architect/Scrum Master:** Attributes-based metadata, crucial for dynamic UI in Workflow Designer.

**User Story 2.3: Manage Plugin Lifecycle (Enable/Disable)**
*   **As a** System Administrator,
*   **I want to** enable or disable loaded plugins,
*   **So that** I can control active functionalities without undeploying files.
**Acceptance Criteria:**
1.  Service maintains active/inactive state for plugins.
2.  Disabled plugins not available for design/execution.
3.  State changes are persistent.
4.  API to manage enabled/disabled state.
**Notes for Architect/Scrum Master:** Dynamic enable/disable vs. restart (MVP: restart acceptable if clear).

**User Story 2.4: Secure Plugin Execution Environment (Basic)**
*   **As the** BlueIQ Framework,
*   **I want to** execute plugin code minimizing risk to core stability,
*   **So that** poorly behaved plugins don't crash the system.
**Acceptance Criteria:**
1.  Engine handles plugin exceptions gracefully (log, fail step/instance, not engine).
2.  Plugins don't have direct access to modify core framework config/state outside contracts.
**Notes for Architect/Scrum Master:** True sandboxing complex (MVP: robust exceptions, clear APIs), secure access to framework services (logging, config).

**User Story 2.5: Basic Plugin Versioning Awareness**
*   **As the** BlueIQ Framework,
*   **I want to** be aware of loaded plugin versions,
*   **So that** admins can identify versions and lay groundwork for dependency management.
**Acceptance Criteria:**
1.  Plugins declare version (e.g., assembly version).
2.  Service records/exposes version of loaded plugins.
3.  Workflow definitions store plugin version used at design time.
**Notes for Architect/Scrum Master:** Handling version mismatches at runtime (MVP: use loaded or fail).

### Epic 3: Event-Driven Communication Backbone
*Goal: To establish the framework's ability to publish and subscribe to events, enabling asynchronous and decoupled interactions using RabbitMQ.*

**User Story 3.1: Publish Events**
*   **As a** Framework Component or a Plugin,
*   **I want to** publish events to a central event bus,
*   **So that** other interested parts can react without direct coupling.
**Acceptance Criteria:**
1.  Framework provides service/API for publishing strongly-typed events.
2.  Published events routed to RabbitMQ.
3.  Publishing resilient to transient broker unavailability (basic retry).
4.  Events have common metadata (ID, timestamp, type).
**Notes for Architect/Scrum Master:** Event serialization (JSON), event naming conventions/base class.

**User Story 3.2: Subscribe to Events**
*   **As a** Framework Component or a Plugin,
*   **I want to** subscribe to specific event types from the event bus,
*   **So that** I can perform actions when those events occur.
**Acceptance Criteria:**
1.  Framework provides mechanism for components/plugins to register handlers for event types.
2.  Framework routes events from broker to subscribed handlers.
3.  Event handlers invoked asynchronously.
4.  Errors in handlers caught/logged without stopping other processing.
**Notes for Architect/Scrum Master:** Subscription management (declarative/programmatic), dead-lettering for failed events.

**User Story 3.3: Integrate with Message Broker (RabbitMQ)**
*   **As the** BlueIQ Event System,
*   **I want to** integrate with RabbitMQ,
*   **So that** events can be reliably and asynchronously exchanged.
**Acceptance Criteria:**
1.  Framework connects to configured RabbitMQ instance.
2.  Events published to appropriate RabbitMQ exchanges/queues.
3.  Framework consumes events from relevant RabbitMQ queues.
4.  Basic RabbitMQ connection management (reconnections).
**Notes for Architect/Scrum Master:** RabbitMQ topology (exchanges, queues, bindings), externalized connection config.

**User Story 3.4: Basic Event Catalog Access**
*   **As a** Developer or System Administrator,
*   **I want to** get a list of known event types,
*   **So that** I can understand available events for integration/debugging.
**Acceptance Criteria:**
1.  API endpoint returns list of discoverable event types.
2.  Basic info (name, description) per event type.
**Notes for Architect/Scrum Master:** Event type discovery mechanism (reflection, manual registration).

### Epic 4: Data Persistence & Abstraction Layer
*Goal: To establish the framework's approach to data access, supporting core services and plugin data needs using SQL Server for the MVP.*

**User Story 4.1: Define Core Data Access Interfaces**
*   **As a** BlueIQ Framework Developer,
*   **I want** standardized data access interfaces (Repository, Unit of Work),
*   **So that** core services can interact with SQL Server consistently and abstractly.
**Acceptance Criteria:**
1.  Generic interfaces for CRUD operations defined.
2.  Interfaces support async operations.
3.  Design allows easy implementation against SQL Server (EF Core).
4.  Core services use these interfaces for persistence.
**Notes for Architect/Scrum Master:** ORM (EF Core), database migration handling for core schemas.

**User Story 4.2: Implement Data Access for SQL Server (Core Services)**
*   **As the** BlueIQ Framework,
*   **I want** an SQL Server implementation of core data access interfaces,
*   **So that** core framework data can be persisted/retrieved from SQL Server.
**Acceptance Criteria:**
1.  Concrete repositories for core entities using EF Core for SQL Server.
2.  SQL Server connection configurable.
3.  Correct mapping of entities to tables.
4.  Basic error handling/logging for DB operations.
**Notes for Architect/Scrum Master:** Connection pooling, performance best practices, initial DB schema for core services.

**User Story 4.3: Enable Plugins to Manage Their Own Data (via Abstraction)**
*   **As a** Plugin Developer,
*   **I want to** leverage framework's data layer to manage my plugin's data in SQL Server,
*   **So that** I don't need to implement DB connectivity from scratch.
**Acceptance Criteria:**
1.  Plugins can define own EF Core DbContexts/entities.
2.  Framework allows plugins to register DbContexts and participate in migrations (if using central DB).
3.  Alternatively, plugins can get configured SQL Server connection string.
4.  Documentation guides plugin devs on data layer usage.
**Notes for Architect/Scrum Master:** Plugin migration management, security (plugins in own schemas/data boundaries).

### Epic 5: Centralized Framework Configuration
*Goal: To establish how the framework and its components (including plugins) are configured and how settings are accessed, supporting local files and environment variables.*

**User Story 5.1: Load Framework and Service Configurations**
*   **As the** BlueIQ Framework (and its Microservices),
*   **I want to** load my configuration from `appsettings.json` and environment variables,
*   **So that** behavior can be customized for different environments.
**Acceptance Criteria:**
1.  Framework uses .NET's `IConfiguration`.
2.  Support for `appsettings.json`, environment-specific files, environment variables by default.
3.  Core services (DB connections, RabbitMQ URLs, log levels) configurable.
4.  Configuration is hierarchical.
**Notes for Architect/Scrum Master:** Config key naming conventions, shared vs. service-specific configs for microservices.

**User Story 5.2: Provide Configuration Access to Plugins**
*   **As a** Plugin Developer,
*   **I want to** access framework config and define my own plugin-specific sections,
*   **So that** my plugin's behavior can be customized.
**Acceptance Criteria:**
1.  Plugins access framework's `IConfiguration`.
2.  Plugins define own config sections (e.g., in `appsettings.json`).
3.  Framework provides way for plugins to bind sections to typed options classes.
4.  Documentation explains plugin config usage.
**Notes for Architect/Scrum Master:** Isolate plugin configs, consider plugin-specific `appsettings.plugin.json`.

**User Story 5.3: Support Basic Dynamic Configuration Updates (for specific settings)**
*   **As a** System Administrator,
*   **I want** some settings (e.g., log levels) to be updatable at runtime without restart,
*   **So that** I can dynamically adjust system behavior.
**Acceptance Criteria:**
1.  Identify critical MVP settings for dynamic updates (e.g., log levels).
2.  Implement `IOptionsMonitor` for these settings.
3.  Provide secured API to trigger refresh of these specific configs.
**Notes for Architect/Scrum Master:** Limit scope for MVP, step towards centralized config stores.

### Epic 6: Essential Security & Operational Services
*Goal: To implement core authentication, authorization, structured logging, and basic monitoring capabilities for the framework's MVP.*

**User Story 6.1: Secure API Endpoints with Authentication**
*   **As the** BlueIQ Framework,
*   **I want all** my exposed APIs to require authentication,
*   **So that** only legitimate users/services can access them.
**Acceptance Criteria:**
1.  Implement token-based authentication (JWT) for all public APIs.
2.  Provide auth service/endpoint for users/clients to obtain tokens.
3.  Authenticated user identity available to API controllers/services.
4.  Unauthenticated requests get 401 Unauthorized.
**Notes for Architect/Scrum Master:** JWT library, token claims, issuer, audience, lifetime, secure key management.

**User Story 6.2: Implement Basic Role-Based Authorization (RBAC)**
*   **As the** BlueIQ Framework,
*   **I want to** control access to APIs/functionalities based on user roles,
*   **So that** users only perform permitted actions.
**Acceptance Criteria:**
1.  Define basic MVP roles (Administrator, WorkflowDesigner, Viewer).
2.  Associate users with roles.
3.  APIs protectable by required roles (e.g., `[Authorize(Roles = "Administrator")]`).
4.  Requests from users without required role get 403 Forbidden.
5.  User/role management via API initially.
**Notes for Architect/Scrum Master:** Secure user credential storage, extensible RBAC model.

**User Story 6.3: Implement Structured Logging**
*   **As a** BlueIQ Framework Developer or Administrator,
*   **I want** all services and plugins to produce structured logs,
*   **So that** activity, errors, diagnostics can be easily queried/analyzed.
**Acceptance Criteria:**
1.  Integrate structured logging library (Serilog or MS.Ext.Logging).
2.  Logs include timestamp, level, message, exception, context (service, workflow ID, correlation ID).
3.  MVP: logs to console and local file.
4.  Plugins access logging infrastructure.
**Notes for Architect/Scrum Master:** Standard log formats, contextual properties, correlation IDs across microservices.

**User Story 6.4: Provide Basic Health Check Endpoints**
*   **As an** Operations Team Member or Monitoring System,
*   **I want to** query health status of each microservice,
*   **So that** I can quickly determine if a service is running and functional.
**Acceptance Criteria:**
1.  Each microservice exposes health check API (e.g., `/health`).
2.  Health check verifies basic dependencies (DB, message broker).
3.  Endpoint returns clear status (Healthy, Unhealthy) and optional details.
4.  Use ASP.NET Core health check features.
**Notes for Architect/Scrum Master:** Differentiate liveness/readiness (future), MVP: basic combined health check.

### Epic 7: System Administration & Monitoring UI (Admin Panel)
*Goal: To provide a Blazor-based user interface for administrators and developers to manage and monitor the BlueIQ framework's MVP functionalities.*

**User Story 7.1: Admin Panel User Authentication**
*   **As an** Administrator or authorized User,
*   **I want to** log in securely to the Admin Panel,
*   **So that** I can access its features.
**Acceptance Criteria:**
1.  Admin Panel has login page.
2.  Users authenticate via framework's auth service.
3.  Admin Panel maintains session/token for API calls.
4.  Access to features restricted by authenticated user's roles.
**Notes for Architect/Scrum Master:** Secure token handling in Blazor.

**User Story 7.2: View and Manage Plugins (Admin Panel)**
*   **As an** Administrator,
*   **I want to** view loaded plugins (name, version, status) and enable/disable them in Admin Panel,
*   **So that** I can control active framework functionalities.
**Acceptance Criteria:**
1.  Admin Panel displays sortable/filterable list of plugins.
2.  UI controls to enable/disable plugins.
3.  UI changes call backend API to persist plugin state.
4.  UI reflects current plugin state.

**User Story 7.3: View and Manage Workflow Definitions (Admin Panel)**
*   **As an** Administrator or Workflow Designer,
*   **I want to** view defined workflows, manually trigger execution, and view basic details in Admin Panel,
*   **So that** I can manage and initiate business processes.
**Acceptance Criteria:**
1.  Admin Panel lists saved workflow definitions.
2.  Users can trigger workflow execution.
3.  Users can view basic, read-only details of a workflow definition.

**User Story 7.4: Monitor Workflow Instances (Admin Panel)**
*   **As an** Administrator or authorized User,
*   **I want to** view running/completed workflow instances, status, and basic details in Admin Panel,
*   **So that** I can monitor activity and troubleshoot.
**Acceptance Criteria:**
1.  Admin Panel displays sortable/filterable list of instances.
2.  Users can drill down to see individual step status.
3.  Basic error messages for failed steps/workflows visible.
4.  UI updates near real-time for running workflows.

**User Story 7.5: Basic User and Role Management (Admin Panel)**
*   **As an** Administrator,
*   **I want to** CRUD users (simplified) and assign roles for Admin Panel access,
*   **So that** I can manage administrative access.
**Acceptance Criteria:**
1.  Admin Panel lists users.
2.  Admins create new users.
3.  Admins assign/unassign MVP roles.
4.  Admins disable/enable user accounts.

**User Story 7.6: View System Logs (Admin Panel - Basic)**
*   **As an** Administrator,
*   **I want to** view a basic stream/list of recent system logs in Admin Panel,
*   **So that** I can perform quick diagnostics.
**Acceptance Criteria:**
1.  Admin Panel displays recent log entries.
2.  Logs filterable by level, date, service name (if feasible).
3.  For quick viewing; advanced analysis via external tools.

### Epic 8: Visual Workflow Design & Management (Workflow Designer)
*Goal: To provide a Blazor-based user interface for visually creating, configuring, saving, and loading workflow definitions.*

**User Story 8.1: Design Workflow Visually (Drag & Drop)**
*   **As a** Workflow Designer user,
*   **I want to** drag/drop plugin representations onto a canvas and visually connect them,
*   **So that** I can intuitively model business processes.
**Acceptance Criteria:**
1.  Designer UI displays palette of available/enabled plugins.
2.  Users drag plugins to canvas.
3.  Users draw connections between steps (linear for MVP).
4.  Canvas supports basic step arrangement.
**Notes for Architect/Scrum Master:** Blazor diagramming/canvas library, visual to storable definition translation.

**User Story 8.2: Configure Workflow Steps (Plugins) Visually**
*   **As a** Workflow Designer user,
*   **I want to** select a step on canvas and configure its parameters via UI,
*   **So that** I can customize step behavior.
**Acceptance Criteria:**
1.  Selecting step shows properties panel/modal with configurable parameters.
2.  UI adapts to parameter types (basic types for MVP).
3.  Configured values stored in workflow definition.
4.  Basic validation for required parameters in UI.

**User Story 8.3: Save and Load Workflow Definitions (Workflow Designer)**
*   **As a** Workflow Designer user,
*   **I want to** save my visual workflow and load previously saved ones,
*   **So that** I can manage and iterate on designs.
**Acceptance Criteria:**
1.  Designer UI has Save/Load options.
2.  Saving persists visual layout and logical structure via backend API.
3.  Loading retrieves definition and renders accurately on canvas.
4.  Prompt to save unsaved changes.

**User Story 8.4: Basic Workflow Validation in Designer**
*   **As a** Workflow Designer user,
*   **I want** designer to provide basic validation feedback as I build,
*   **So that** I can correct common errors before save/run.
**Acceptance Criteria:**
1.  Designer indicates missing required plugin parameters.
2.  Designer indicates unconnected steps.
3.  Validation errors/warnings clearly displayed, linked to step.
**Notes for Architect/Scrum Master:** Client-side validation; server-side also important.

---

## 7. Out of Scope (for MVP)

The following features, functionalities, and non-functional requirement levels, while potentially part of the broader vision for BlueIQ, are explicitly **NOT** part of the MVP scope. They may be considered for future releases.

*   **7.1 Advanced Workflow Engine Capabilities:** Complex control flows, dynamic modification of in-flight instances, sophisticated transaction management (Sagas), full long-running workflow support, workflow versioning/migration for running instances.
*   **7.2 Advanced Plugin Management:** Full plugin sandboxing, dynamic loading/unloading/updating without restarts, plugin marketplace, complex inter-plugin dependency resolution.
*   **7.3 Expanded Event System Capabilities:** Native support for brokers beyond RabbitMQ (Kafka, Azure SB, etc.) for MVP, event schema registry, Complex Event Processing, guaranteed exactly-once processing.
*   **7.4 Broader Data Layer Support:** Native NoSQL support (MongoDB, Neo4j) for MVP, distributed caching, data virtualization.
*   **7.5 Advanced Configuration Management:** Full UI-driven config management, out-of-the-box integration with centralized config systems (Azure App Config, Consul, Vault).
*   **7.6 Advanced Middleware Services:** API Gateway advanced features, full IAM (OIDC/OAuth2 provider, federation, MFA, SSO), deep Secrets Management integration.
*   **7.7 Extensive Pre-built Plugin/Adapter Library:** Comprehensive library for specific enterprise systems/protocols for MVP.
*   **7.8 Advanced UI/UX Features:** Admin Panel (advanced analytics, graphical audit trails, i18n/l10n, theming), Workflow Designer (AI assistance, real-time collaboration, Git integration, advanced visual debugging), End-User Application Shell.
*   **7.9 Sophisticated Deployment & Operations Tooling:** Official Docker images/Helm charts for BlueIQ itself, turnkey installers, built-in support for advanced deployment patterns for BlueIQ-built apps, advanced monitoring integration, automated scalability, automated backup/recovery for framework.
*   **7.10 Highest Tiers of Non-Functional Requirements:** Extremely high performance targets, specific security certifications (HIPAA, PCI-DSS), "five nines" availability, comprehensive user guides for all roles.
*   **7.11 All items listed in "Section 7: Future Considerations / Roadmap" of `BlueIQ_Consolidated_Features.md` document.**

---

## 8. Core Technical Decisions

N/A - The "Outcome Focused" project workflow context has been selected. Detailed core technical decisions will be defined by the Architect (Fred) as part of the Technical Architecture Document. The "Technical Assumptions" section (Section 5) provides the high-level technical direction agreed upon with the Product Manager.

---

## 9. Checklist Results: PRD Quality Checklist

**Instructions for Product Manager Agent (John):**
Before finalizing the PRD and handing it off, please review the PRD against each item in this checklist. Report the status (Pass, Fail, N/A) and provide brief comments if an item is not 'Pass'.

**Checklist Items:**

**1. Completeness & Clarity:**
    *   1.1 **Project Goal & Objectives:** Pass (Section 1 clearly outlines Goal, Objective, and Context.)
    *   1.2 **Target Users/Personas:** Pass (Implicitly Framework Developers, System Administrators, Workflow Designers; clear from user stories and UI sections.)
    *   1.3 **Functional Requirements (MVP):** Pass (Section 2 details MVP functional requirements, refined with user input.)
    *   1.4 **Non-Functional Requirements (MVP):** Pass (Section 3 details MVP NFRs.)
    *   1.5 **User Interaction & Design Goals (if UI exists):** Pass (Section 4 covers this for Admin Panel and Workflow Designer.)
    *   1.6 **Out of Scope (MVP):** Pass (Section 7 comprehensively lists out-of-scope items.)
    *   1.7 **Assumptions:** Pass (Section 5 (Technical Assumptions) covers critical technical decisions. Business assumptions are implicitly covered by the feature set.)

**2. Prioritization & Scope:**
    *   2.1 **MVP Focus:** Pass (Functional requirements and out-of-scope sections clearly define MVP boundaries.)
    *   2.2 **Justification for Features:** Pass ("So that..." part of user stories and overall goals provide justification.)

**3. User Stories (if applicable):**
    *   3.1 **Clarity (As a... I want... So that...):** Pass (User stories follow the standard format.)
    *   3.2 **Acceptance Criteria:** Pass (Each user story has a list of acceptance criteria.)
    *   3.3 **Completeness for MVP:** Pass (Epics and user stories map to MVP functional requirements.)

**4. Technical Considerations (Guidance for Architect):**
    *   4.1 **Technical Assumptions Stated:** Pass (Section 5 details .NET 8, Blazor, SQL Server, RabbitMQ, Polyrepo, Microservices.)
    *   4.2 **Key Decisions Highlighted:** Pass (Section 5 explicitly calls out and provides rationale for Polyrepo and Microservices.)
    *   4.3 **Integration Points:** Pass (SQL Server and RabbitMQ are key integration points for the framework itself. Plugin nature implies future external integrations.)

**5. Readability & Maintainability:**
    *   5.1 **Clear Language:** Pass
    *   5.2 **Organization:** Pass
    *   5.3 **Version Control:** N/A (Document generated interactively. Will be saved as a single file.)
    *   5.4 **Change Log (if applicable):** N/A (This is the first version.)

---

## 10. Initial Architect Prompt for BlueIQ Framework MVP

**To:** Fred (Architect Agent)
**From:** John (Product Manager Agent)
**Date:** June 5, 2025
**Subject:** Request for Technical Architecture Document - BlueIQ Framework MVP

**1. Introduction & Product Vision:**

Fred, we have completed the Product Requirements Document (PRD) for the Minimum Viable Product (MVP) of the BlueIQ Framework. This document outlines the product's goals, functional and non-functional requirements, user interaction design goals, key technical assumptions, and MVP scope.

*   **Core Goal:** BlueIQ aims to be a comprehensive, enterprise-grade, .NET-based framework empowering organizations to rapidly design, build, deploy, and manage sophisticated, event-driven, workflow-centric business applications and integration solutions.
*   **Key Value Proposition:** Reduce development time, improve solution quality, and provide a consistent operational model by abstracting common complexities in enterprise application development.

**2. Key Sections of the PRD for Your Review:**

Please thoroughly review the full PRD. Pay special attention to:

*   **Section 1: Goal, Objective, and Context**
*   **Section 2: Functional Requirements (MVP)** (Visual Workflow Designer is key)
*   **Section 3: Non-Functional Requirements (MVP)**
*   **Section 4: User Interaction and Design Goals** (Blazor UIs)
*   **Section 5: Technical Assumptions** (CRITICAL: .NET 8, Blazor, SQL Server, RabbitMQ, Polyrepo, Microservices)
*   **Section 6: Epic Overview & User Stories (MVP)**
*   **Section 7: Out of Scope (for MVP)**

**3. Architect's Mandate & Key Deliverables:**

Your primary task is to produce a comprehensive **Technical Architecture Document (TAD)** for the BlueIQ Framework MVP. This document should:

*   **Define the overall system architecture (Microservices):** Detail each microservice (responsibilities, API contracts, data models, tech), inter-service communication, service discovery, load balancing, configuration.
*   **Detail the Polyrepo structure:** Propose initial repositories, contents, inter-repo dependency strategy.
*   **Specify the database design (SQL Server):** Schema for core needs, migration strategy, plugin data management.
*   **Elaborate on the frontend architecture (Blazor):** Structure for Admin Panel & Workflow Designer, backend interaction, state management.
*   **Detail core component implementation:** Workflow Engine, Plugin Management, Event System.
*   **Address NFRs:** How architecture meets performance, security, reliability NFRs.
*   **Define testing strategy further:** Unit, integration, E2E test implementation.
*   **Deployment Strategy (Conceptual MVP):** Basic deployment approach for dev/test.
*   **Provide clear diagrams:** Component, sequence, deployment.

**4. Key Questions to Address in the TAD:**

*   How will Polyrepo be managed for build, versioning, deployment?
*   Specific microservices, boundaries, APIs?
*   Secure inter-service communication?
*   Blazor frontend interaction with backend microservices?
*   Visual workflow design translation, storage, execution?
*   Plugin data and migration handling?
*   Data consistency across microservices?

We look forward to your detailed Technical Architecture Document. Please raise any questions or ambiguities you find in the PRD.

