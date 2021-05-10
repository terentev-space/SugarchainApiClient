using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public class UnspentOperation : Operation
    {
        public UnspentOperation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger = null) : base(httpClient, config, logger)
        {
        }

        /// <summary>
        /// This method return address unspent outputs.
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <param name="amount">Unspent amount</param>
        /// <returns>Unspent outputs</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await operation.GetAsync(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// await operation.GetAsync(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5", amount: 99999);
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":[{"height":10733044,"index":0,"script":"0014d81961ce827299a7afef8113b338761e6b6ea03d","txid":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18","value":100000000}]}
        /// </example>
        public async Task<Response<IReadOnlyList<UnspentResult>>> GetAsync(
            [NotNull] string address,
            [AllowNull] BigInteger? amount = null
        ) =>
            await this.SendAsync<Response<IReadOnlyList<UnspentResult>>>(
                method: HttpMethod.Get,
                path: $"unspent/{address}",
                queryParams: new Dictionary<string, string>
                {
                    {"amount", amount.ToString()}
                }
            );

        /// <summary>
        /// This method return address unspent outputs.
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <param name="amount">Unspent amount</param>
        /// <returns>Unspent outputs</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// operation.Get(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// operation.Get(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5", amount: 99999);
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":[{"height":10733044,"index":0,"script":"0014d81961ce827299a7afef8113b338761e6b6ea03d","txid":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18","value":100000000}]}
        /// </example>
        public Response<IReadOnlyList<UnspentResult>> Get([NotNull] string address, [AllowNull] BigInteger? amount = null) => this.GetAsync(address, amount).Result;
    }
}