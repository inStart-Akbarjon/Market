using FluentAssertions;
using Grpc.Core;
using Market.Contracts.Interfaces.GrpcServices;
using Market.Contracts.Models.Product.Request;
using Market.Tests.Base;
using Market.Tests.Fixtures;

namespace Market.Tests.Services.ProductServiceTests.CreateProductTest;

[Collection("CreateProductIntegration")]
public class CreateProductValidationTest(IntegrationTestWebAppFactory factory) : BaseGrpcTest<IProductServiceGrpc>(factory)
{
    [Fact]
    public async Task CreateProduct_ReturnsValidationErrorForTitleNullOrEmpty()
    {
        // Arrange
        var request = new CreateProductRequest()
        {
            Title = "", // <-- Title has no value here which is not valid
            Description = "Test",
            Price = 100,
            Quantity = 10,
        };
         
        // Act
        var ex = await Assert.ThrowsAsync<RpcException>(async () => 
            await Client.CreateProduct(request)
        );
         
        // Assert
        ex.StatusCode.Should().Be(StatusCode.InvalidArgument);
        ex.Status.Detail.Should().Contain("Validation error: Property Title must have value");
    }
    
     [Fact]
     public async Task CreateProduct_ReturnsValidationErrorForTitleUniqueness()
     {
         // Arrange
         var request1 = new CreateProductRequest()
         {
             Title = "Test",
             Description = "Test",
             Price = 100,
             Quantity = 10,
         };
         var request2 = new CreateProductRequest()
         {
             Title = "Test", // <-- Property Title is being duplicated here which is not valid
             Description = "Test",
             Price = 100,
             Quantity = 10,
         };
         
         // Act
         await Client.CreateProduct(request1);
         
         var ex = await Assert.ThrowsAsync<RpcException>(async () => 
             await Client.CreateProduct(request2)
         );
         
         // Assert
         ex.StatusCode.Should().Be(StatusCode.InvalidArgument);
         ex.Status.Detail.Should().Contain("Validation error: Product with Title Test already exists!");
     }

     [Fact]
     public async Task CreateProduct_ReturnsValidationErrorForQuantityNullOrEmpty()
     {
         // Arrange
         var request = new CreateProductRequest()
         {
             Title = "ReturnsValidationErrorForQuantity",
             Description = "Test",
             Price = 100,
             Quantity = 0, // <-- Property Quantity equal to 0 here which is not valid
         };
         
         // Act
         var ex = await Assert.ThrowsAsync<RpcException>(async () =>
             await Client.CreateProduct(request)
         );
         
         // Assert
         ex.StatusCode.Should().Be(StatusCode.InvalidArgument);
         ex.Status.Detail.Should().Contain("Validation error: Property Quantity should not be null or 0");
     }
     
     [Fact]
     public async Task CreateProduct_ReturnsValidationErrorForQuantityNegativeValue()
     {
         // Arrange
         var request = new CreateProductRequest()
         {
             Title = "ReturnsValidationErrorForQuantityNegativeValue",
             Description = "Test",
             Price = 100,
             Quantity = -1, // <-- Property Quantity has negative value here which is not valid
         };
         
         // Act
         var ex = await Assert.ThrowsAsync<RpcException>(async () =>
             await Client.CreateProduct(request)
         );
         
         // Assert
         ex.StatusCode.Should().Be(StatusCode.InvalidArgument);
         ex.Status.Detail.Should().Contain("Validation error: Property Quantity should not be negative");
     }
     
     [Fact]
     public async Task CreateProduct_ReturnsValidationErrorForPriceNullOrEmpty()
     {
         // Arrange
         var request = new CreateProductRequest()
         {
             Title = "ReturnsValidationErrorForPriceNullOrEmpty",
             Description = "Test",
             Price = 0, // Property Price equal to 0 here which is not valid
             Quantity = 10,
         };
         
         // Act
         var ex = await Assert.ThrowsAsync<RpcException>(async () =>
             await Client.CreateProduct(request)
         );
         
         // Assert
         ex.StatusCode.Should().Be(StatusCode.InvalidArgument);
         ex.Status.Detail.Should().Contain("Validation error: Property Price should not be null or 0");
     }
     
     [Fact]
     public async Task CreateProduct_ReturnsValidationErrorForPriceNegativeValue()
     {
         // Arrange
         var request = new CreateProductRequest()
         {
             Title = "ReturnsValidationErrorForPriceNegativeValue",
             Description = "Test",
             Price = -1, // Property Price has negative value here which is not valid
             Quantity = 10,
         };
         
         // Act
         var ex = await Assert.ThrowsAsync<RpcException>(async () =>
             await Client.CreateProduct(request)
         );
         
         // Assert
         ex.StatusCode.Should().Be(StatusCode.InvalidArgument);
         ex.Status.Detail.Should().Contain("Validation error: Property Price should not be negative");
     }
}
