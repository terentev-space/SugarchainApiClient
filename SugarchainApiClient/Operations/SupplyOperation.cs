using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public class SupplyOperation : Operation
    {
        public SupplyOperation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger = null) : base(httpClient, config, logger)
        {
        }

        /// <summary>
        /// This method return info about current coins supply.
        /// </summary>
        /// <returns>Information about coins supply</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await operation.GetAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"halvings":0,"height":10753102,"supply":46184225715519488}}
        /// </example>
        public async Task<Response<SupplyResult>> GetAsync() =>
            await this.SendAsync<Response<SupplyResult>>(
                method: HttpMethod.Get,
                path: "supply"
            );

        /// <summary>
        /// This method return info about current coins supply.
        /// </summary>
        /// <returns>Information about coins supply</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// operation.Get();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"halvings":0,"height":10753102,"supply":46184225715519488}}
        /// </example>
        public Response<SupplyResult> Get() => this.GetAsync().Result;
    }
}