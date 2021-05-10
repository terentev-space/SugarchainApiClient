using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public class FeeOperation : Operation
    {
        public FeeOperation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger = null) : base(httpClient, config, logger)
        {
        }

        /// <summary>
        /// This method return recommended transaction fee.
        /// </summary>
        /// <returns>Transaction fee</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await operation.GetAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"blocks":6,"feerate":1001}}
        /// </example>
        public async Task<Response<FeeResult>> GetAsync() =>
            await this.SendAsync<Response<FeeResult>>(
                method: HttpMethod.Get,
                path: "fee"
            );

        /// <summary>
        /// This method return recommended transaction fee.
        /// </summary>
        /// <returns>Transaction fee</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// operation.Get();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"blocks":6,"feerate":1001}}
        /// </example>
        public Response<FeeResult> Get() => this.GetAsync().Result;
    }
}