using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public class BroadcastOperation : Operation
    {
        public BroadcastOperation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger = null) : base(httpClient, config, logger)
        {
        }

        /// <summary>
        /// This method broadcast raw signed transaction to Sugarchain network.
        /// </summary>
        /// <param name="raw">Encoded raw signed transaction</param>
        /// <returns>TxId</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await operation.SendAsync(raw: "020000000001021786bf75007d1d94b4ce3b94e885690c1dfb9299bcd97e92f7f1b0a80526f6000100000000ffffffff5adfd951b1c065a46dddb0bd0df8b652165e492cb6e5857048ddea365261d0840100000000ffffffff0200e1f50500000000160014d81961ce827299a7afef8113b338761e6b6ea03d605af405000000001600145af91e8c58fccd17682b1bc41a5df595181dc4b402483045022100bcc87972c6389c6b610bb5089a549bea2f92c67f01a3c7516223e3731f155c8b022038fa950f872310b2a576206cd0ce2980592a714ca571a4427774af7f2b68035e012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b0247304402204e9eee008c4fdd9205a3af9eb47c3c393d0ed35f29be8d670ac48edd468647890220583053b7e77e22e631a29360bca44339c5dc6f1aefd0069008097e9a564b8a0f012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b00000000");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18"}
        /// </example>
        public async Task<Response<string>> SendAsync([NotNull] string raw) =>
            await this.SendAsync<Response<string>>(
                method: HttpMethod.Post,
                path: "broadcast",
                formParams: new Dictionary<string, string>
                {
                    {"raw", raw},
                }
            );

        /// <summary>
        /// This method broadcast raw signed transaction to Sugarchain network.
        /// </summary>
        /// <param name="raw">Encoded raw signed transaction</param>
        /// <returns>TxId</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// operation.Send(raw: "020000000001021786bf75007d1d94b4ce3b94e885690c1dfb9299bcd97e92f7f1b0a80526f6000100000000ffffffff5adfd951b1c065a46dddb0bd0df8b652165e492cb6e5857048ddea365261d0840100000000ffffffff0200e1f50500000000160014d81961ce827299a7afef8113b338761e6b6ea03d605af405000000001600145af91e8c58fccd17682b1bc41a5df595181dc4b402483045022100bcc87972c6389c6b610bb5089a549bea2f92c67f01a3c7516223e3731f155c8b022038fa950f872310b2a576206cd0ce2980592a714ca571a4427774af7f2b68035e012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b0247304402204e9eee008c4fdd9205a3af9eb47c3c393d0ed35f29be8d670ac48edd468647890220583053b7e77e22e631a29360bca44339c5dc6f1aefd0069008097e9a564b8a0f012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b00000000");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18"}
        /// </example>
        public Response<string> Send([NotNull] string raw) => this.SendAsync(raw).Result;
    }
}