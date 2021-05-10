using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public class BalanceOperation : Operation
    {
        public BalanceOperation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger = null) : base(httpClient, config, logger)
        {
        }

        /// <summary>
        /// This method return address balance.
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>Balance</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await operation.GetAsync(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"balance":100000000,"received":300000000}}
        /// </example>
        public async Task<Response<BalanceResult>> GetAsync([NotNull] string address) =>
            await this.SendAsync<Response<BalanceResult>>(
                method: HttpMethod.Get,
                path: $"balance/{address}"
            );

        /// <summary>
        /// This method return address balance.
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>Balance</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// operation.Get(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"balance":100000000,"received":300000000}}
        /// </example>
        public Response<BalanceResult> Get([NotNull] string address) => this.GetAsync(address).Result;
    }
}