using Grpc.Net.Client;
using MagicOnion.Client;
using Market.Tests.Fixtures;

namespace Market.Tests.Base;

public class BaseGrpcTest<TService> : IAsyncLifetime, IClassFixture<IntegrationTestWebAppFactory>  where TService : MagicOnion.IService<TService>
{
    protected readonly TService Client;
    private readonly GrpcChannel _channel;

    protected BaseGrpcTest(IntegrationTestWebAppFactory factory)
    {
        var httpClient = factory.CreateDefaultClient();
        
        _channel = GrpcChannel.ForAddress(
            httpClient.BaseAddress!,
            new GrpcChannelOptions
            {
                HttpClient = httpClient
            });
        
        Client = MagicOnionClient.Create<TService>(_channel);
    }
    
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await _channel.ShutdownAsync();
    }
}
