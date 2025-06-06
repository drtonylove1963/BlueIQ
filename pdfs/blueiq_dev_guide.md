# BlueIQ Plugin Architecture - Developer's Guide

## Table of Contents

1. [Introduction](#introduction)
2. [Plugin Architecture](#plugin-architecture)
3. [Development Requirements](#development-requirements)
4. [Creating Plugins](#creating-plugins)
5. [Plugin Management](#plugin-management)
6. [Configuration](#configuration)
7. [Testing](#testing)
8. [Deployment](#deployment)
9. [Best Practices](#best-practices)
10. [API Reference](#api-reference)
11. [Troubleshooting](#troubleshooting)

## Introduction

BlueIQ is a multi-provider, scalable online architecture system implementation for enterprise-grade solutions. This developer's guide provides comprehensive documentation for developing plugins within the BlueIQ ecosystem.

### Key Features

- **Multi-runtime providers** with hot data updates and messaging
- **PostgreSQL, MongoDB, PostgreSQL Server, Mongo DB, RabbitMQ, Kafka, Neo4j**
- **Complete separation of read/write modules**
- **Distributed transaction management**

## Plugin Architecture

### Core Components

The BlueIQ plugin architecture consists of several core components:

#### 1. Plugin Manager
- Handles plugin lifecycle management
- Manages plugin dependencies
- Provides plugin discovery and loading

#### 2. Event System
- Asynchronous event handling
- Plugin-to-plugin communication
- System-wide event broadcasting

#### 3. Data Layer
- Database abstraction
- Connection pooling
- Transaction management

#### 4. Configuration Manager
- Plugin-specific configuration
- Environment-based settings
- Runtime configuration updates

### Plugin Types

BlueIQ supports several plugin types:

- **Data Providers**: Database connectivity and data management
- **Message Handlers**: Event processing and messaging
- **UI Components**: Frontend interface elements
- **Business Logic**: Core application functionality
- **Integration**: External system connectivity

## Development Requirements

### Prerequisites

- **Node.js** 16.x or higher
- **TypeScript** 4.5+
- **Docker** for containerization
- **Git** for version control

### Development Environment Setup

```bash
# Clone the BlueIQ development template
git clone https://github.com/blueiq/plugin-template.git
cd plugin-template

# Install dependencies
npm install

# Setup development environment
npm run setup:dev
```

### Project Structure

```
my-plugin/
├── src/
│   ├── index.ts
│   ├── plugin.ts
│   ├── handlers/
│   ├── models/
│   └── services/
├── tests/
├── config/
├── package.json
└── plugin.manifest.json
```

## Creating Plugins

### Plugin Manifest

Every plugin requires a `plugin.manifest.json` file:

```json
{
  "name": "my-plugin",
  "version": "1.0.0",
  "description": "Plugin description",
  "author": "Developer Name",
  "main": "dist/index.js",
  "dependencies": [],
  "permissions": [],
  "configuration": {
    "schema": "./config/schema.json"
  }
}
```

### Basic Plugin Structure

```typescript
import { Plugin, PluginContext, EventHandler } from '@blueiq/plugin-sdk';

export class MyPlugin extends Plugin {
  constructor(context: PluginContext) {
    super(context);
  }

  async onLoad(): Promise<void> {
    this.logger.info('Plugin loaded successfully');
    await this.registerEventHandlers();
  }

  async onUnload(): Promise<void> {
    this.logger.info('Plugin unloaded');
    await this.cleanup();
  }

  @EventHandler('data.updated')
  async handleDataUpdate(event: any): Promise<void> {
    // Handle data update events
    this.logger.debug('Processing data update', event);
  }

  private async registerEventHandlers(): Promise<void> {
    // Register additional event handlers
  }

  private async cleanup(): Promise<void> {
    // Cleanup resources
  }
}
```

### Data Provider Plugin Example

```typescript
import { DataProvider, DatabaseConnection } from '@blueiq/plugin-sdk';

export class PostgreSQLProvider extends DataProvider {
  private connection: DatabaseConnection;

  async initialize(config: any): Promise<void> {
    this.connection = await this.createConnection({
      host: config.host,
      port: config.port,
      database: config.database,
      username: config.username,
      password: config.password
    });
  }

  async query(sql: string, params?: any[]): Promise<any[]> {
    return await this.connection.query(sql, params);
  }

  async transaction(callback: Function): Promise<any> {
    return await this.connection.transaction(callback);
  }
}
```

## Plugin Management

### Plugin Lifecycle

1. **Discovery**: Plugin manifest scanning
2. **Validation**: Dependency and permission checks
3. **Loading**: Plugin instantiation and initialization
4. **Registration**: Event handler and service registration
5. **Execution**: Runtime plugin operation
6. **Unloading**: Cleanup and resource deallocation

### Plugin Dependencies

```json
{
  "dependencies": [
    {
      "name": "@blueiq/core",
      "version": "^2.0.0"
    },
    {
      "name": "another-plugin",
      "version": "1.5.x"
    }
  ]
}
```

### Plugin Permissions

```json
{
  "permissions": [
    "database.read",
    "database.write",
    "events.publish",
    "events.subscribe",
    "configuration.read"
  ]
}
```

## Configuration

### Environment Configuration

```yaml
# config/development.yml
database:
  postgresql:
    host: localhost
    port: 5432
    database: blueiq_dev
  mongodb:
    url: mongodb://localhost:27017/blueiq

messaging:
  rabbitmq:
    url: amqp://localhost:5672
  kafka:
    brokers: ["localhost:9092"]

plugins:
  enabled: true
  autoload: true
  directory: "./plugins"
```

### Runtime Configuration

```typescript
export interface PluginConfig {
  enabled: boolean;
  settings: {
    [key: string]: any;
  };
  connections: {
    database?: DatabaseConfig;
    messaging?: MessagingConfig;
  };
}
```

## Testing

### Unit Testing

```typescript
import { TestFramework } from '@blueiq/testing';
import { MyPlugin } from '../src/plugin';

describe('MyPlugin', () => {
  let plugin: MyPlugin;
  let testContext: TestContext;

  beforeEach(async () => {
    testContext = TestFramework.createContext();
    plugin = new MyPlugin(testContext);
    await plugin.onLoad();
  });

  afterEach(async () => {
    await plugin.onUnload();
  });

  test('should handle data update events', async () => {
    const event = { type: 'data.updated', data: { id: 1 } };
    await plugin.handleDataUpdate(event);
    expect(testContext.logger.info).toHaveBeenCalled();
  });
});
```

### Integration Testing

```typescript
import { IntegrationTestSuite } from '@blueiq/testing';

describe('Plugin Integration', () => {
  let testSuite: IntegrationTestSuite;

  beforeAll(async () => {
    testSuite = new IntegrationTestSuite();
    await testSuite.setup();
  });

  test('should integrate with database provider', async () => {
    const result = await testSuite.executeQuery('SELECT 1 as test');
    expect(result).toEqual([{ test: 1 }]);
  });
});
```

## Deployment

### Docker Deployment

```dockerfile
FROM node:16-alpine

WORKDIR /app

COPY package*.json ./
RUN npm ci --only=production

COPY dist/ ./dist/
COPY plugin.manifest.json ./

EXPOSE 3000

CMD ["node", "dist/index.js"]
```

### Kubernetes Configuration

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: blueiq-plugin
spec:
  replicas: 3
  selector:
    matchLabels:
      app: blueiq-plugin
  template:
    metadata:
      labels:
        app: blueiq-plugin
    spec:
      containers:
      - name: plugin
        image: blueiq/my-plugin:latest
        ports:
        - containerPort: 3000
        env:
        - name: NODE_ENV
          value: "production"
```

## Best Practices

### 1. Error Handling

```typescript
try {
  await this.processData(data);
} catch (error) {
  this.logger.error('Data processing failed', error);
  await this.handleError(error);
  throw new PluginError('Processing failed', error);
}
```

### 2. Resource Management

```typescript
export class ResourceAwarePlugin extends Plugin {
  private resources: Resource[] = [];

  async onUnload(): Promise<void> {
    // Clean up all resources
    await Promise.all(
      this.resources.map(resource => resource.dispose())
    );
    this.resources = [];
  }

  private addResource(resource: Resource): void {
    this.resources.push(resource);
  }
}
```

### 3. Configuration Validation

```typescript
import Joi from 'joi';

const configSchema = Joi.object({
  database: Joi.object({
    host: Joi.string().required(),
    port: Joi.number().port().required(),
    username: Joi.string().required(),
    password: Joi.string().required()
  }).required(),
  options: Joi.object({
    timeout: Joi.number().default(5000),
    retries: Joi.number().default(3)
  })
});

export function validateConfig(config: any): any {
  const { error, value } = configSchema.validate(config);
  if (error) {
    throw new ConfigurationError(error.message);
  }
  return value;
}
```

### 4. Logging Standards

```typescript
export class LoggingBestPractices {
  private logger = this.context.getLogger();

  async processRequest(request: any): Promise<any> {
    const correlationId = request.correlationId;
    
    this.logger.info('Processing request', {
      correlationId,
      requestType: request.type,
      timestamp: new Date().toISOString()
    });

    try {
      const result = await this.handleRequest(request);
      
      this.logger.info('Request processed successfully', {
        correlationId,
        resultSize: result.length
      });
      
      return result;
    } catch (error) {
      this.logger.error('Request processing failed', {
        correlationId,
        error: error.message,
        stack: error.stack
      });
      throw error;
    }
  }
}
```

## API Reference

### Core Plugin API

#### Plugin Base Class

```typescript
abstract class Plugin {
  protected context: PluginContext;
  protected logger: Logger;
  protected config: PluginConfig;

  constructor(context: PluginContext);
  
  abstract onLoad(): Promise<void>;
  abstract onUnload(): Promise<void>;
  
  protected emit(event: string, data?: any): void;
  protected on(event: string, handler: Function): void;
  protected off(event: string, handler: Function): void;
}
```

#### Event System

```typescript
interface EventManager {
  subscribe(eventType: string, handler: EventHandler): void;
  unsubscribe(eventType: string, handler: EventHandler): void;
  publish(event: Event): Promise<void>;
  publishAsync(event: Event): void;
}

interface Event {
  type: string;
  data: any;
  timestamp: Date;
  source: string;
  correlationId?: string;
}
```

#### Data Access

```typescript
interface DataProvider {
  connect(): Promise<void>;
  disconnect(): Promise<void>;
  query(query: string, params?: any[]): Promise<any[]>;
  execute(command: string, params?: any[]): Promise<number>;
  transaction<T>(callback: (tx: Transaction) => Promise<T>): Promise<T>;
}
```

### HTTP Client

```typescript
interface HttpClient {
  get<T>(url: string, options?: RequestOptions): Promise<T>;
  post<T>(url: string, data: any, options?: RequestOptions): Promise<T>;
  put<T>(url: string, data: any, options?: RequestOptions): Promise<T>;
  delete<T>(url: string, options?: RequestOptions): Promise<T>;
}
```

## Troubleshooting

### Common Issues

#### Plugin Loading Failures

**Problem**: Plugin fails to load with dependency errors.

**Solution**:
1. Check plugin manifest dependencies
2. Verify all required plugins are installed
3. Check version compatibility

```bash
# Check plugin dependencies
npm run plugin:check-deps my-plugin

# Verify plugin manifest
npm run plugin:validate my-plugin
```

#### Database Connection Issues

**Problem**: Database connections fail or timeout.

**Solution**:
1. Verify connection configuration
2. Check network connectivity
3. Validate credentials

```typescript
// Connection health check
async function checkDatabaseHealth(): Promise<boolean> {
  try {
    await this.dataProvider.query('SELECT 1');
    return true;
  } catch (error) {
    this.logger.error('Database health check failed', error);
    return false;
  }
}
```

#### Memory Leaks

**Problem**: Plugin memory usage grows over time.

**Solution**:
1. Implement proper resource cleanup
2. Use weak references where appropriate
3. Monitor event listener registration

```typescript
// Proper cleanup pattern
export class MemoryEfficientPlugin extends Plugin {
  private intervalId?: NodeJS.Timeout;
  private eventHandlers: Map<string, Function> = new Map();

  async onLoad(): Promise<void> {
    this.intervalId = setInterval(() => {
      this.performPeriodicCleanup();
    }, 60000);
  }

  async onUnload(): Promise<void> {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
    
    // Cleanup event handlers
    this.eventHandlers.forEach((handler, event) => {
      this.off(event, handler);
    });
    this.eventHandlers.clear();
  }
}
```

### Performance Optimization

#### Database Query Optimization

```typescript
// Use connection pooling
const poolConfig = {
  min: 2,
  max: 10,
  acquireTimeoutMillis: 30000,
  idleTimeoutMillis: 30000
};

// Batch operations
async function batchInsert(records: any[]): Promise<void> {
  const batchSize = 100;
  for (let i = 0; i < records.length; i += batchSize) {
    const batch = records.slice(i, i + batchSize);
    await this.dataProvider.batchInsert(batch);
  }
}
```

#### Event Processing Optimization

```typescript
// Use event queuing for high-volume events
export class OptimizedEventHandler {
  private eventQueue: Queue<Event> = new Queue();
  private processing = false;

  async handleEvent(event: Event): Promise<void> {
    this.eventQueue.enqueue(event);
    
    if (!this.processing) {
      this.processQueue();
    }
  }

  private async processQueue(): Promise<void> {
    this.processing = true;
    
    while (!this.eventQueue.isEmpty()) {
      const event = this.eventQueue.dequeue();
      await this.processEvent(event);
    }
    
    this.processing = false;
  }
}
```

### Debugging Tools

#### Plugin Inspector

```bash
# Inspect running plugins
npm run plugin:inspect

# View plugin logs
npm run plugin:logs my-plugin

# Monitor plugin performance
npm run plugin:monitor my-plugin
```

#### Debug Configuration

```json
{
  "debug": {
    "enabled": true,
    "level": "debug",
    "includeStack": true,
    "plugins": ["my-plugin"]
  }
}
```

---

## Additional Resources

- [BlueIQ Core Documentation](https://docs.blueiq.io)
- [Plugin SDK Reference](https://sdk.blueiq.io)
- [Community Forum](https://community.blueiq.io)
- [GitHub Repository](https://github.com/blueiq/plugins)

## Support

For technical support and questions:
- Email: support@blueiq.io
- Documentation: https://docs.blueiq.io
- GitHub Issues: https://github.com/blueiq/plugins/issues

---

*Last updated: December 2024*
*Version: 2.1.0*