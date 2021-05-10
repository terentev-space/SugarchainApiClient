using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Interfaces;
using SugarchainApiClient.Operations;

namespace SugarchainApiClient.Services
{
    public class ApiService
    {
        protected readonly ISugarchainClient client;

        public ApiService(ISugarchainClient client) => this.client = client;
        
        #region ApiAsync
        
        /// <summary>
        /// This method return address balance.
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>Balance</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await api.BalanceAsync(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"balance":100000000,"received":300000000}}
        /// </example>
        public async Task<Response<BalanceResult>> BalanceAsync([NotNull] string address) => await this.client.UseOperation<BalanceOperation>().GetAsync(address);
        
        /// <summary>
        /// This method broadcast raw signed transaction to Sugarchain network.
        /// </summary>
        /// <param name="raw">Encoded raw signed transaction</param>
        /// <returns>TxId</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await api.BroadcastAsync(raw: "020000000001021786bf75007d1d94b4ce3b94e885690c1dfb9299bcd97e92f7f1b0a80526f6000100000000ffffffff5adfd951b1c065a46dddb0bd0df8b652165e492cb6e5857048ddea365261d0840100000000ffffffff0200e1f50500000000160014d81961ce827299a7afef8113b338761e6b6ea03d605af405000000001600145af91e8c58fccd17682b1bc41a5df595181dc4b402483045022100bcc87972c6389c6b610bb5089a549bea2f92c67f01a3c7516223e3731f155c8b022038fa950f872310b2a576206cd0ce2980592a714ca571a4427774af7f2b68035e012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b0247304402204e9eee008c4fdd9205a3af9eb47c3c393d0ed35f29be8d670ac48edd468647890220583053b7e77e22e631a29360bca44339c5dc6f1aefd0069008097e9a564b8a0f012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b00000000");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18"}
        /// </example>
        public async Task<Response<string>> BroadcastAsync([NotNull] string raw) => await this.client.UseOperation<BroadcastOperation>().SendAsync(raw);
        
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
        /// await api.UnspentAsync(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// await api.UnspentAsync(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5", amount: 99999);
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":[{"height":10733044,"index":0,"script":"0014d81961ce827299a7afef8113b338761e6b6ea03d","txid":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18","value":100000000}]}
        /// </example>
        public async Task<Response<IReadOnlyList<UnspentResult>>> UnspentAsync(
            [NotNull] string address,
            [AllowNull] BigInteger? amount = null
        ) => await this.client.UseOperation<UnspentOperation>().GetAsync(address, amount);

        /// <summary>
        /// This method return recommended transaction fee.
        /// </summary>
        /// <returns>Transaction fee</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await api.FeeAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"blocks":6,"feerate":1001}}
        /// </example>
        public async Task<Response<FeeResult>> FeeAsync() => await this.client.UseOperation<FeeOperation>().GetAsync();
        
        /// <summary>
        /// This method return current info about Sugarchain network.
        /// </summary>
        /// <returns>Information about network</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await api.InfoAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"bestblockhash":"6d5fbd34eff050c1a33465fe103079b55830b5de10e9e342921f34e5898e8ff3","blocks":10753040,"chain":"main","chainwork":"0000000000000000000000000000000000000000000000000000d377d8cd0444","difficulty":0.007871215456912438,"headers":10753040,"mediantime":1620380807,"nethash":6702169,"reward":4294967296,"supply":46183959427547136}}
        /// </example>
        public async Task<Response<InfoResult>> InfoAsync() => await this.client.UseOperation<InfoOperation>().GetAsync();
        
        /// <summary>
        /// This method return info about current coins supply.
        /// </summary>
        /// <returns>Information about coins supply</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// await api.SupplyAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"halvings":0,"height":10753102,"supply":46184225715519488}}
        /// </example>
        public async Task<Response<SupplyResult>> SupplyAsync() => await this.client.UseOperation<SupplyOperation>().GetAsync();
        
        #endregion

        #region Api

        /// <summary>
        /// This method return address balance.
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>Balance</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// api.Balance(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"balance":100000000,"received":300000000}}
        /// </example>
        public Response<BalanceResult> Balance([NotNull] string address) => this.client.UseOperation<BalanceOperation>().Get(address);
        
        /// <summary>
        /// This method broadcast raw signed transaction to Sugarchain network.
        /// </summary>
        /// <param name="raw">Encoded raw signed transaction</param>
        /// <returns>TxId</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// api.Broadcast(raw: "020000000001021786bf75007d1d94b4ce3b94e885690c1dfb9299bcd97e92f7f1b0a80526f6000100000000ffffffff5adfd951b1c065a46dddb0bd0df8b652165e492cb6e5857048ddea365261d0840100000000ffffffff0200e1f50500000000160014d81961ce827299a7afef8113b338761e6b6ea03d605af405000000001600145af91e8c58fccd17682b1bc41a5df595181dc4b402483045022100bcc87972c6389c6b610bb5089a549bea2f92c67f01a3c7516223e3731f155c8b022038fa950f872310b2a576206cd0ce2980592a714ca571a4427774af7f2b68035e012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b0247304402204e9eee008c4fdd9205a3af9eb47c3c393d0ed35f29be8d670ac48edd468647890220583053b7e77e22e631a29360bca44339c5dc6f1aefd0069008097e9a564b8a0f012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b00000000");
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18"}
        /// </example>
        public Response<string> Broadcast([NotNull] string raw) => this.client.UseOperation<BroadcastOperation>().Send(raw);
        
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
        /// api.Unspent(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");
        /// api.Unspent(address: "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5", amount: 99999);
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":[{"height":10733044,"index":0,"script":"0014d81961ce827299a7afef8113b338761e6b6ea03d","txid":"5e1f2c078f598fb3ca42c1f6dc2e4a19420ac4d64ea87500c1d08fd4fcad9b18","value":100000000}]}
        /// </example>
        public Response<IReadOnlyList<UnspentResult>> Unspent(
            [NotNull] string address,
            [AllowNull] BigInteger? amount = null
        ) => this.client.UseOperation<UnspentOperation>().Get(address, amount);

        /// <summary>
        /// This method return recommended transaction fee.
        /// </summary>
        /// <returns>Transaction fee</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// api.Fee();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"blocks":6,"feerate":1001}}
        /// </example>
        public Response<FeeResult> Fee() => this.client.UseOperation<FeeOperation>().Get();
        
        /// <summary>
        /// This method return current info about Sugarchain network.
        /// </summary>
        /// <returns>Information about network</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// api.InfoAsync();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"bestblockhash":"6d5fbd34eff050c1a33465fe103079b55830b5de10e9e342921f34e5898e8ff3","blocks":10753040,"chain":"main","chainwork":"0000000000000000000000000000000000000000000000000000d377d8cd0444","difficulty":0.007871215456912438,"headers":10753040,"mediantime":1620380807,"nethash":6702169,"reward":4294967296,"supply":46183959427547136}}
        /// </example>
        public Response<InfoResult> Info() => this.client.UseOperation<InfoOperation>().Get();
        
        /// <summary>
        /// This method return info about current coins supply.
        /// </summary>
        /// <returns>Information about coins supply</returns>
        /// 
        /// <example>
        /// For example:
        /// <code>
        /// api.Supply();
        /// </code>
        /// JsonResponse: {"error":null,"id":"sugar-api","result":{"halvings":0,"height":10753102,"supply":46184225715519488}}
        /// </example>
        public Response<SupplyResult> Supply() => this.client.UseOperation<SupplyOperation>().Get();

        #endregion
    }
}