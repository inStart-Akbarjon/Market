using Market.Contracts.Interfaces.GrpcServices;
using Market.Contracts.Models.Product.Request;
using Market.Contracts.Models.Product.Response;
using Market.Tests.Base;
using Market.Tests.Fixtures;

namespace Market.Tests.Services.ProductServiceTests.GetProductTest;

[Collection("GetAllProductsIntegration")]
public class GetAllProductsTest(IntegrationTestWebAppFactory factory) : BaseGrpcTest<IProductServiceGrpc>(factory)
{
    [Fact]
    public async Task GetProduct_ReturnsCorrectResult()
    {
        // Arrange
        var request = new GetAllProductRequest()
        {
            PageNumber = 1,
            PageSize = 10,
        };

        // Act
        var result = await Client.GetAllProducts(request);
        
        // Assert
        Assert.True(result.Items.Count <= 10);
        Assert.True(result.PageNumber > 0);
        Assert.True(result.PageSize > 0);
        Assert.IsType<bool>(result.HasNextPage);
        Assert.IsType<List<GetAllProductsResponse>>(result.Items);
        Assert.IsType<PaginatedList<GetAllProductsResponse>>(result);
    }
}