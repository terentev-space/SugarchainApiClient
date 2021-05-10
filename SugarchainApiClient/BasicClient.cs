using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient
{
    public abstract class BasicClient
    {
        private readonly HttpClient httpClient;
        private readonly IClientConfig config;

        protected BasicClient(HttpClient httpClient, IClientConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        private IServiceProvider serviceProvider;
        protected IServiceProvider ServiceProvider => serviceProvider ??= this.AddBasicServices(this.InitServices()).BuildServiceProvider();

        protected virtual IServiceCollection InitServices() => new ServiceCollection();

        private IServiceCollection AddBasicServices(IServiceCollection operations) => operations
            // Basic
            .AddSingleton<HttpClient>(this.httpClient)
            .AddSingleton<IClientConfig>(this.config);
    }
}