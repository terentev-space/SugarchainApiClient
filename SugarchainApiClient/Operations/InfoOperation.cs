using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public class InfoOperation : Operation
    {
        public InfoOperation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger = null) : base(httpClient, config, logger)
        {
        }

        /// <summary>
        /// This method return current info about Sugarchain network.
        /// </summary>
        /// <returns>Information about network</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await operation.GetAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"bestblockhash":"6d5fbd34eff050c1a33465fe103079b55830b5de10e9e342921f34e5898e8ff3","blocks":10753040,"chain":"main","chainwork":"0000000000000000000000000000000000000000000000000000d377d8cd0444","difficulty":0.007871215456912438,"headers":10753040,"mediantime":1620380807,"nethash":6702169,"reward":4294967296,"supply":46183959427547136}}
        /// </example>
        public async Task<Response<InfoResult>> GetAsync() =>
            await this.SendAsync<Response<InfoResult>>(
                method: HttpMethod.Get,
                path: "info"
            );

        /// <summary>
        /// This method return current info about Sugarchain network.
        /// </summary>
        /// <returns>Information about network</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// operation.Get();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"bestblockhash":"6d5fbd34eff050c1a33465fe103079b55830b5de10e9e342921f34e5898e8ff3","blocks":10753040,"chain":"main","chainwork":"0000000000000000000000000000000000000000000000000000d377d8cd0444","difficulty":0.007871215456912438,"headers":10753040,"mediantime":1620380807,"nethash":6702169,"reward":4294967296,"supply":46183959427547136}}
        /// </example>
        public Response<InfoResult> Get() => this.GetAsync().Result;
    }
}