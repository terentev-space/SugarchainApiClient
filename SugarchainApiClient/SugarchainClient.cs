using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using SugarchainApiClient.Interfaces;
using SugarchainApiClient.Operations;
using SugarchainApiClient.Services;

namespace SugarchainApiClient
{
    public class SugarchainClient : BasicClient, ISugarchainClient
    {
        public SugarchainClient() : this(new HttpClient(), new ClientConfig())
        {
        }

        public SugarchainClient(HttpClient httpClient) : this(httpClient, new ClientConfig())
        {
        }

        public SugarchainClient(IClientConfig config) : this(new HttpClient(), config)
        {
        }

        public SugarchainClient(HttpClient httpClient, IClientConfig config) : base(httpClient, config)
        {
        }

        protected override IServiceCollection InitServices() => base.InitServices()
            // Client
            .AddSingleton<ISugarchainClient>(this)
            // Api
            .AddSingleton<ApiService>()
            // Operations
            .AddSingleton<BalanceOperation>()
            .AddSingleton<BroadcastOperation>()
            .AddSingleton<UnspentOperation>()
            .AddSingleton<FeeOperation>()
            .AddSingleton<InfoOperation>()
            .AddSingleton<SupplyOperation>()
        ;

        protected T GetService<T>() => this.ServiceProvider.GetService<T>();
        protected T GetRequiredService<T>() => this.ServiceProvider.GetRequiredService<T>();

        public bool IsOperation<T>() where T : Operation => this.GetService<T>() is {};
        public T UseOperation<T>() where T : Operation => this.GetRequiredService<T>();

        public ApiService Api => this.GetRequiredService<ApiService>();
    }
}