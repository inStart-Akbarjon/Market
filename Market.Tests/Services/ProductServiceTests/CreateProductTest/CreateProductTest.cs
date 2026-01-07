using Market.Contracts.Interfaces.GrpcServices;
using Market.Contracts.Models.Product.Request;
using Market.Tests.Base;
using Market.Tests.Fixtures;

namespace Market.Tests.Services.ProductServiceTests.CreateProductTest;

[Collection("CreateProductIntegration")]
public class CreateProductTest(IntegrationTestWebAppFactory factory) : BaseGrpcTest<IProductServiceGrpc>(factory)
{
    [Fact]
    public async Task CreateProduct_ReturnsCorrectResult()
    {
        // Arrange
        var requestContainsUnRequiredProperties = new CreateProductRequest()
        {
            Title = "ReturnsCorrectResult1",
            Description = "Test",
            Price = 100,
            Quantity = 10,
            OpenedAt = 50,
            ClosedAt = 150,
        };
        
        var requestDoNotContainsUnRequiredProperties = new CreateProductRequest()
        {
            Title = "ReturnsCorrectResult2",
            Description = "Test",
            Price = 100,
            Quantity = 10,
        };
        
        // Act
        var result1 = await Client.CreateProduct(requestDoNotContainsUnRequiredProperties);
        var result2 = await Client.CreateProduct(requestContainsUnRequiredProperties);

        // Assert requestDoNotContainsUnRequiredProperties
        Assert.NotNull(result1);
        Assert.True(result1.Id > 0);
        Assert.True(result1.Title.Length > 0);
        Assert.True(result1.Quantity > 0);
        Assert.True(result1.Price > 0);
        
        // Assert requestContainsUnRequiredProperties
        Assert.NotNull(result2);
        Assert.True(result2.Id > 0);
        Assert.True(result2.Title.Length > 0);
        Assert.True(result2.Quantity > 0);
        Assert.True(result2.Price > 0);
        Assert.True(result2.OpenedAt > 0);
        Assert.True(result2.ClosedAt > 0);
        Assert.True(result2.OpenedAt < result2.ClosedAt);
    }
}
