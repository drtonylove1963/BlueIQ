# Clean Architecture with BlueIQ Libraries

## Table of Contents
1. [Project Structure](#project-structure)
2. [Dependency Injection Setup](#dependency-injection-setup)
3. [Domain Layer (DDD)](#domain-layer-ddd)
4. [CQRS Implementation](#cqrs-implementation)
5. [Error Handling](#error-handling)
6. [Testing Strategy](#testing-strategy)
7. [Event Processing](#event-processing)
8. [Troubleshooting](#troubleshooting)

## Project Structure

### Recommended Solution Structure

```
OnlineStore.Solution/
├── src/
│   ├── OnlineStore.Domain/
│   │   ├── Entities/
│   │   │   ├── Product/
│   │   │   │   ├── Product.cs
│   │   │   │   ├── ProductId.cs
│   │   │   │   └── Events/
│   │   │   │       ├── ProductCreatedEvent.cs
│   │   │   │       └── ProductPriceChangedEvent.cs
│   │   │   ├── Order/
│   │   │   │   ├── Order.cs
│   │   │   │   ├── OrderId.cs
│   │   │   │   ├── OrderItem.cs
│   │   │   │   ├── OrderItemId.cs
│   │   │   │   └── Events/
│   │   │   │       ├── OrderCreatedEvent.cs
│   │   │   │       ├── OrderConfirmEvent.cs
│   │   │   │       └── OrderCancelledEvent.cs
│   │   │   └── Customer/
│   │   │       ├── Customer.cs
│   │   │       ├── CustomerId.cs
│   │   │       └── Events/
│   │   │           ├── CustomerCreatedEvent.cs
│   │   │           └── CustomerEmailChangedEvent.cs
│   │   ├── ValueObjects/
│   │   │   ├── Money.cs
│   │   │   ├── Email.cs
│   │   │   ├── Address.cs
│   │   │   ├── ProductName.cs
│   │   │   └── CustomerName.cs
│   │   ├── Rules/
│   │   │   ├── Product/
│   │   │   │   ├── ProductPriceMustBePositiveRule.cs
│   │   │   │   └── ProductNameMustNotBeEmptyRule.cs
│   │   │   ├── Order/
│   │   │   │   ├── OrderMustHaveItemsRule.cs
│   │   │   │   └── OrderTotalCannotExceedLimitRule.cs
│   │   │   └── Customer/
│   │   │       ├── CustomerEmailMustBeValidRule.cs
│   │   │       └── CustomerMustBeAdultRule.cs
│   │   └── Services/
│   │       └── IPricingService.cs
│   ├── OnlineStore.Application/
│   │   ├── Commands/
│   │   │   ├── Products/
│   │   │   │   ├── CreateProductCommand.cs
│   │   │   │   ├── UpdateProductPriceCommand.cs
│   │   │   │   └── DeleteProductCommand.cs
│   │   │   ├── Orders/
│   │   │   │   ├── CreateOrderCommand.cs
│   │   │   │   ├── AddOrderItemCommand.cs
│   │   │   │   ├── ConfirmOrderCommand.cs
│   │   │   │   └── CancelOrderCommand.cs
│   │   │   └── Customers/
│   │   │       ├── CreateCustomerCommand.cs
│   │   │       └── UpdateCustomerEmailCommand.cs
│   │   ├── Queries/
│   │   │   ├── Products/
│   │   │   │   ├── GetProductByIdQuery.cs
│   │   │   │   ├── SearchProductsQuery.cs
│   │   │   │   └── GetProductCatalogQuery.cs
│   │   │   ├── Orders/
│   │   │   │   ├── GetOrderByIdQuery.cs
│   │   │   │   ├── GetOrdersByCustomerQuery.cs
│   │   │   │   └── GetOrderSummaryQuery.cs
│   │   │   └── Customers/
│   │   │       ├── GetCustomerByIdQuery.cs
│   │   │       └── GetCustomerByEmailQuery.cs
│   │   ├── Handlers/
│   │   │   ├── Commands/
│   │   │   │   ├── Products/
│   │   │   │   ├── Orders/
│   │   │   │   └── Customers/
│   │   │   └── Queries/
│   │   │       ├── Products/
│   │   │       ├── Orders/
│   │   │       └── Customers/
│   │   └── DTOs/
│   │       ├── ProductDto.cs
│   │       └── OrderDto.cs
│   └── OnlineStore.Infrastructure/
│       ├── Persistence/
│       │   ├── Configurations/
│       │   ├── Repositories/
│       │   └── DbContext/
│       ├── Services/
│       │   └── PricingService.cs
│       └── External/
└── tests/
    ├── OnlineStore.Domain.Tests/
    ├── OnlineStore.Application.Tests/
    └── OnlineStore.Infrastructure.Tests/
```

## Dependency Injection Setup

### Domain Project Configuration

```xml
<!-- OnlineStore.Domain/OnlineStore.Domain.csproj -->
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="BlueIQ.DDD.Core" Version="1.0.0" />
  </ItemGroup>
</Project>

<!-- OnlineStore.Application/OnlineStore.Application.csproj -->
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="BlueIQ.CQRS.Core" Version="1.0.0" />
    <ProjectReference Include="..\OnlineStore.Domain\OnlineStore.Domain.csproj" />
  </ItemGroup>
</Project>
```

### Program.cs Configuration

```csharp
// Program.cs
using BlueIQ.CQRS.Core.Abstractions;
using BlueIQ.CQRS.Core.Infrastructure;
using OnlineStore.Application.Handlers.Commands.Products;
using OnlineStore.Application.Commands.Products;

var builder = WebApplication.CreateBuilder(args);

// Register CQRS components
builder.Services.AddScoped<IServiceLocator, DIServiceLocatorAdapter>();
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IQueryBus, QueryBus>();

// Register command handlers
builder.Services.AddScoped<ICommandHandler<CreateProductCommand, Guid>, CreateProductHandler>();

// Register query handlers
builder.Services.AddScoped<IQueryHandler<GetProductByIdQuery, ProductDto>, GetProductByIdHandler>();

// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
```

## Domain Layer (DDD)

### Strongly Typed IDs

#### Base Entity

```csharp
// OnlineStore.Domain/Entities/Product/ProductId.cs
using BlueIQ.DDD.Core.ValueObjects;

namespace OnlineStore.Domain.Entities.Product;

public class ProductId : GuidId
{
    public ProductId(Guid value) : base(value) { }
    public ProductId() : base() { }

    public static ProductId New() => new();
    public static ProductId From(Guid value) => new(value);
}
```

#### Product Entity

```csharp
// OnlineStore.Domain/Entities/Product/Product.cs
using BlueIQ.DDD.Core.ValueObjects;

namespace OnlineStore.Domain.Entities.Product;

public class ProductId : GuidId
{
    public ProductId(Guid value) : base(value) { }
    public ProductId() : base() { }

    public static ProductId New() => new();
    public static ProductId From(Guid value) => new(value);
}

public class Product : AggregateRoot<ProductId>
{
    public ProductName Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int StockQuantity { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastModifiedAt { get; private set; }

    private Product() : base() { } // For ORM

    public Product(ProductId id, ProductName name, string description, Money price, int stockQuantity)
        : base(id)
    {
        ValidateCreationRules(name, price, stockQuantity);

        Name = name;
        Description = description ?? string.Empty;
        Price = price;
        StockQuantity = stockQuantity;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductCreatedEvent(Id, Name, Price));
    }

    public void UpdatePrice(Money newPrice)
    {
        CheckRule(new ProductPriceMustBePositiveRule(newPrice.Amount));

        var oldPrice = Price;
        Price = newPrice;
        LastModifiedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductPriceChangedEvent(Id, oldPrice, newPrice));
    }

    public void UpdateStock(int newQuantity)
    {
        CheckRule(new ProductStockMustBeNonNegativeRule(newQuantity));

        StockQuantity = newQuantity;
        LastModifiedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductStockUpdatedEvent(Id, newQuantity));
    }

    public void Deactivate()
    {
        if (!IsActive)
            return;

        IsActive = false;
        LastModifiedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductDeactivatedEvent(Id));
    }

    public bool HasSufficientStock(int requestedQuantity)
    {
        return StockQuantity >= requestedQuantity;
    }

    private void ValidateCreationRules(ProductName name, Money price, int stockQuantity)
    {
        CheckRule(new ProductNameMustNotBeEmptyRule(name));
        CheckRule(new ProductPriceMustBePositiveRule(price.Amount));
        CheckRule(new ProductStockMustBeNonNegativeRule(stockQuantity));
    }
}
```

### Value Objects

#### Money Value Object

```csharp
// OnlineStore.Domain/ValueObjects/Money.cs
using BlueIQ.DDD.Core.ValueObjects;
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.ValueObjects;

public class Money : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public Money(decimal amount, string currency = "USD")
    {
        CheckRule(new MoneyAmountMustBeNonNegativeRule(amount));
        CheckRule(new CurrencyMustBeValidRule(currency));

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot add money with different currencies");

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot subtract money with different currencies");

        return new Money(Amount - other.Amount, Currency);
    }

    public Money Multiply(decimal factor)
    {
        return new Money(Amount * factor, Currency);
    }

    public static Money operator +(Money left, Money right) => left.Add(right);
    public static Money operator -(Money left, Money right) => left.Subtract(right);
    public static Money operator *(Money money, decimal factor) => money.Multiply(factor);

    public override string ToString() => $"{Amount:C} {Currency}";

    public static Money Zero(string currency = "USD") => new(0, currency);
}
```

#### Email Value Object

```csharp
// OnlineStore.Domain/ValueObjects/Email.cs
using BlueIQ.DDD.Core.ValueObjects;
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        CheckRule(new EmailMustBeValidRule(value));

        Value = value.ToLowerInvariant().Trim();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Email email) => email.Value;
    public static explicit operator Email(string email) => new(email);

    public override string ToString() => Value;
}
```

#### Address Value Object

```csharp
// OnlineStore.Domain/ValueObjects/Address.cs
using BlueIQ.DDD.Core.ValueObjects;

namespace OnlineStore.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string postalCode, string country)
    {
        CheckRule(new AddressFieldMustNotBeEmptyRule(street, nameof(Street)));
        CheckRule(new AddressFieldMustNotBeEmptyRule(city, nameof(City)));
        CheckRule(new AddressFieldMustNotBeEmptyRule(state, nameof(State)));
        CheckRule(new AddressFieldMustNotBeEmptyRule(postalCode, nameof(PostalCode)));
        CheckRule(new AddressFieldMustNotBeEmptyRule(country, nameof(Country)));

        Street = street.Trim();
        City = city.Trim();
        State = state.Trim();
        PostalCode = postalCode.Trim();
        Country = country.Trim();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {PostalCode}, {Country}";
    }
}
```

#### ProductName Value Object

```csharp
// OnlineStore.Domain/ValueObjects/ProductName.cs
using BlueIQ.DDD.Core.ValueObjects;

namespace OnlineStore.Domain.ValueObjects;

public class ProductName : ValueObject
{
    public string Value { get; private set; }

    public ProductName(string value)
    {
        CheckRule(new ProductNameMustNotBeEmptyRule(value));

        Value = value.Trim();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(ProductName productName) => productName.Value;
    public static explicit operator ProductName(string productName) => new(productName);

    public override string ToString() => Value;
}
```

#### CustomerName Value Object

```csharp
// OnlineStore.Domain/ValueObjects/CustomerName.cs
using BlueIQ.DDD.Core.ValueObjects;

namespace OnlineStore.Domain.ValueObjects;

public class CustomerName : ValueObject
{
    public string Value { get; private set; }

    public CustomerName(string value)
    {
        CheckRule(new CustomerNameMustNotBeEmptyRule(value));

        Value = value.Trim();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(CustomerName customerName) => customerName.Value;
    public static explicit operator CustomerName(string customerName) => new(customerName);

    public override string ToString() => Value;
}
```

### Business Rules

#### Product Rules

```csharp
// OnlineStore.Domain/Rules/Product/ProductPriceMustBePositiveRule.cs
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.Rules.Product;

public class ProductPriceMustBePositiveRule : IBusinessRule
{
    private readonly decimal _price;

    public ProductPriceMustBePositiveRule(decimal price)
    {
        _price = price;
    }

    public string Message => "Product price must be greater than zero";

    public bool IsBroken() => _price <= 0;
}
```

```csharp
// OnlineStore.Domain/Rules/Product/ProductNameMustNotBeEmptyRule.cs
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.Rules.Product;

public class ProductNameMustNotBeEmptyRule : IBusinessRule
{
    private readonly string _name;

    public ProductNameMustNotBeEmptyRule(string name)
    {
        _name = name;
    }

    public string Message => "Product name cannot be empty";

    public bool IsBroken() => string.IsNullOrWhiteSpace(_name);
}
```

#### Order Rules

```csharp
// OnlineStore.Domain/Rules/Order/OrderMustHaveItemsRule.cs
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.Rules.Order;

public class OrderMustHaveItemsRule : IBusinessRule
{
    private readonly int _itemCount;

    public OrderMustHaveItemsRule(int itemCount)
    {
        _itemCount = itemCount;
    }

    public string Message => "Order must contain at least one item";

    public bool IsBroken() => _itemCount <= 0;
}
```

```csharp
// OnlineStore.Domain/Rules/Order/OrderTotalCannotExceedLimitRule.cs
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.Rules.Order;

public class OrderTotalCannotExceedLimitRule : IBusinessRule
{
    private readonly decimal _total;
    private readonly decimal _limit;

    public OrderTotalCannotExceedLimitRule(decimal total, decimal limit)
    {
        _total = total;
        _limit = limit;
    }

    public string Message => $"Order total cannot exceed limit of {_limit:C}";

    public bool IsBroken() => _total > _limit;
}
```

#### Customer Rules

```csharp
// OnlineStore.Domain/Rules/Customer/CustomerEmailMustBeValidRule.cs
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.Rules.Customer;

public class CustomerEmailMustBeValidRule : IBusinessRule
{
    private readonly string _email;

    public CustomerEmailMustBeValidRule(string email)
    {
        _email = email;
    }

    public string Message => "Customer email must be valid";

    public bool IsBroken() => string.IsNullOrWhiteSpace(_email) || !IsValidEmail(_email);

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
```

```csharp
// OnlineStore.Domain/Rules/Customer/CustomerMustBeAdultRule.cs
using BlueIQ.DDD.Core.Rules;

namespace OnlineStore.Domain.Rules.Customer;

public class CustomerMustBeAdultRule : IBusinessRule
{
    private readonly DateTime _birthDate;

    public CustomerMustBeAdultRule(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public string Message => "Customer must be at least 18 years old";

    public bool IsBroken() => DateTime.Today.Year - _birthDate.Year < 18;
}
```

## CQRS Implementation

### Commands

#### Create Product Command

```csharp
// OnlineStore.Application/Commands/Products/CreateProductCommand.cs
using BlueIQ.CQRS.Core.Commands;

namespace OnlineStore.Application.Commands.Products;

public class CreateProductCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public int StockQuantity { get; set; }
}
```

#### Update Product Price Command

```csharp
// OnlineStore.Application/Commands/Products/UpdateProductPriceCommand.cs
using BlueIQ.CQRS.Core.Commands;

namespace OnlineStore.Application.Commands.Products;

public class UpdateProductPriceCommand : ICommand
{
    public Guid ProductId { get; set; }
    public decimal NewPrice { get; set; }
    public string Currency { get; set; }
}
```

#### Delete Product Command

```csharp
// OnlineStore.Application/Commands/Products/DeleteProductCommand.cs
using BlueIQ.CQRS.Core.Commands;

namespace OnlineStore.Application.Commands.Products;

public class DeleteProductCommand : ICommand
{
    public Guid ProductId { get; set; }
}
```

### Queries

#### Get Product By ID Query

```csharp
// OnlineStore.Application/Queries/Products/GetProductByIdQuery.cs
using BlueIQ.CQRS.Core.Queries;

namespace OnlineStore.Application.Queries.Products;

public class GetProductByIdQuery : IQuery<ProductDto>
{
    public Guid ProductId { get; set; }
}
```

#### Search Products Query

```csharp
// OnlineStore.Application/Queries/Products/SearchProductsQuery.cs
using BlueIQ.CQRS.Core.Queries;

namespace OnlineStore.Application.Queries.Products;

public class SearchProductsQuery : IQuery<PagedResult<ProductDto>>
{
    public string SearchTerm { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool ActiveOnly { get; set; }
}
```

#### Get Product Catalog Query

```csharp
// OnlineStore.Application/Queries/Products/GetProductCatalogQuery.cs
using BlueIQ.CQRS.Core.Queries;

namespace OnlineStore.Application.Queries.Products;

public class GetProductCatalogQuery : IQuery<PagedResult<ProductDto>>
{
    public string Category { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
```

### Command Handlers

#### Create Product Handler

```csharp
// OnlineStore.Application/Handlers/Commands/Products/CreateProductHandler.cs
using BlueIQ.CQRS.Core.Abstractions;
using BlueIQ.CQRS.Core.Commands;
using OnlineStore.Application.Commands.Products;
using OnlineStore.Domain.Entities.Product;
using OnlineStore.Domain.Repositories;

namespace OnlineStore.Application.Handlers.Commands.Products;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand command)
    {
        var productId = ProductId.New();
        var product = new Product(
            productId,
            new ProductName(command.Name),
            command.Description,
            new Money(command.Price, command.Currency),
            command.StockQuantity
        );

        await _productRepository.AddAsync(product);
        
        return productId.Value;
    }
}
```

#### Update Product Price Handler

```csharp
// OnlineStore.Application/Handlers/Commands/Products/UpdateProductPriceHandler.cs
using BlueIQ.CQRS.Core.Commands;
using OnlineStore.Application.Commands.Products;

namespace OnlineStore.Application.Handlers.Commands.Products;

public class UpdateProductPriceHandler : ICommandHandler<UpdateProductPriceCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductPriceHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProductPriceCommand command)
    {
        var product = await _productRepository.GetByIdAsync(ProductId.From(command.ProductId));
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        product.UpdatePrice(new Money(command.NewPrice, command.Currency));
        
        await _productRepository.UpdateAsync(product);
    }
}
```

### Query Handlers

#### Get Product By ID Handler

```csharp
// OnlineStore.Application/Handlers/Queries/Products/GetProductByIdHandler.cs
using BlueIQ.CQRS.Core.Queries;
using OnlineStore.Application.Queries.Products;

namespace OnlineStore.Application.Handlers.Queries.Products;

public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery query)
    {
        var product = await _productRepository.GetByIdAsync(ProductId.From(query.ProductId));
        
        return product == null 
            ? null 
            : new ProductDto
            {
                Id = product.Id.Value,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.Amount,
                Currency = product.Price.Currency,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                LastModifiedAt = product.LastModifiedAt
            };
    }
}
```

#### Search Products Handler

```csharp
// OnlineStore.Application/Handlers/Queries/Products/SearchProductsHandler.cs
using BlueIQ.CQRS.Core.Queries;
using OnlineStore.Application.Queries.Products;

namespace OnlineStore.Application.Handlers.Queries.Products;

public class SearchProductsHandler : IQueryHandler<SearchProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public SearchProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedResult<ProductDto>> Handle(SearchProductsQuery query)
    {
        var products = await _productRepository.SearchAsync(
            query.SearchTerm,
            query.ActiveOnly,
            query.PageNumber,
            query.PageSize
        );

        var productDtos = products.Items.Select(p => new ProductDto
        {
            Id = p.Id.Value,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price.Amount,
            Currency = p.Price.Currency,
            StockQuantity = p.StockQuantity,
            IsActive = p.IsActive,
            CreatedAt = p.CreatedAt,
            LastModifiedAt = p.LastModifiedAt
        }).ToList();

        return new PagedResult<ProductDto>
        {
            Items = productDtos,
            TotalCount = products.TotalCount,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        };
    }
}
```

## Error Handling

### Do's:
- Provide meaningful error messages
- Log errors appropriately  
- Validate input at boundaries
- Implement retry policies and dead letter queues
- Make entities immutable after creation when possible

### Don'ts:
- Use exceptions for business rule violations
- Return null from methods
- Ignore errors or fail silently
- Expose internal error details to clients

### Testing Strategy

### Do's:
- Unit test domain entities and business rules
- Integration test command and query handlers
- Test business scenarios end-to-end
- Use test doubles for external dependencies
- Test both happy path and error scenarios

### Don'ts:
- Test implementation details
- Mock value objects
- Skip testing error conditions
- Write tests that depend on external systems

## Event Processing

### Immediate Events:
- Process critical business events synchronously
- Use domain events for same-aggregate updates
- Implement business rules and dead letter queues

### Background Events:
- Queue non-critical events for asynchronous processing
- Use reliable message queues for integration events
- Implement retry policies and dead letter queues

## Testing Strategies

### Unit Testing Domain Entities

```csharp
[Fact]
public void Product_Creation_Should_Succeed_With_Valid_Data()
{
    // Arrange
    var productId = ProductId.New();
    var name = new ProductName("Test Product");
    var price = new Money(99.99m, "USD");
    const int stock = 10;

    // Act
    var product = new Product(productId, name, "Test Description", price, stock);

    // Assert
    Assert.Equal(productId, product.Id);
    Assert.Equal(name, product.Name);
    Assert.Equal(price, product.Price);
    Assert.Equal(stock, product.StockQuantity);
}
```

### Integration Testing Command Handlers

```csharp
public class CreateProductHandlerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CreateProductHandlerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Handle_Should_Create_Product_Successfully()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Name = "Integration Test Product",
            Description = "A product for testing",
            Price = 99.99m,
            Currency = "USD",
            StockQuantity = 10
        };

        var handler = _factory.Services.GetRequiredService<ICommandHandler<CreateProductCommand, Guid>>();

        // Act
        var result = await handler.Handle(command);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }
}
```

## Troubleshooting

### Common Issues

#### 1. "Result is inaccessible due to its protection level"
- Ensure BlueIQ.DDD.Core package is correctly referenced
- Check that Result class is public in the DDD package
- Verify using statements are correct

#### 2. "BusinessRule constructor errors"  
- Use explicit constructor overloads instead of default ones
- Check that base class constructors are properly called

#### 3. "Handler not found" errors
- Verify handler registration in DI container
- Check that command/query types match exactly
- Ensure proper assembly scanning for handlers

#### 4. Domain event not firing
- Check that AddDomainEvent is called in aggregate
- Verify event publisher is configured
- Ensure events are cleared after publishing

### Debug Tips

#### Enable Detailed Logging:

```csharp
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);
```

#### Add Pipeline Behavior for Debugging:

```csharp
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
```

## Key Takeaways

1. **Separation of Concerns**: Domain logic stays in the domain layer, application logic in the application layer
2. **Type Safety**: Use strongly typed IDs and value objects for better model integrity  
3. **Business Rules**: Implement and test business rules as separate, reusable components
4. **Event-Driven**: Use domain events for decoupled, reactive architecture
5. **Testing**: Focus on testing behavior and business scenarios, not implementation details

---

*This guide provides a comprehensive foundation for building maintainable applications using Clean Architecture patterns with BlueIQ libraries. The online store example demonstrates practical implementation of DDD concepts, CQRS patterns, and proper testing strategies.*