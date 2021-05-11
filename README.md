# SugarchainApiClient

[![Latest Version](https://img.shields.io/github/v/tag/terentev-space/SugarchainApiClient)](https://github.com/terentev-space/SugarchainApiClient/releases)
[![Software License](https://img.shields.io/badge/license-Apache_2.0-brightgreen.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/SugarchainApiClient.svg)](https://www.nuget.org/packages/SugarchainApiClient) 
[![downloads](https://img.shields.io/nuget/dt/SugarchainApiClient)](https://www.nuget.org/packages/SugarchainApiClient) 
[![Size](https://img.shields.io/github/repo-size/terentev-space/SugarchainApiClient.svg)]()
#### 🚧 Attention: the project is currently under development! 🚧

<br/>Sugarchain project website: https://sugarchain.org/
<br/>Sugarchain API: https://api.sugarchain.org/

## Install

#### PM
```
Install-Package SugarchainApiClient
```

#### .NET CLI
```
dotnet add package SugarchainApiClient
```

#### NuGet
```
SugarchainApiClient
```

## Usage

#### Interface ISugarchainClient
```c#
ISugarchainClient client = new SugarchainClient();

/* Operation is Abstract */
var operation = client.UseOperation<Operation>();

var @params = GetParams();

/* MethodAsync & Method is nonexistent (example) */
var resultAsync = await operation.MethodAsync(@params);
/* OR */
var result = operation.Method(@params);
```

#### SugarchainClient ApiService
```c#
SugarchainClient client = new SugarchainClient();

var @params = GetParams();

/* MethodAsync & Method is nonexistent (example) */
var resultAsync = await client.Api.MethodAsync(@params);
/* OR */
var result = client.Api.Method(@params);
```

## Api & Operations & Methods

<br/>✅`/info` - `...<InfoOperation>().Get(); /* or GetAsync */`
<br/>❌`/height/{height}`
<br/>❌`/block/{hash}`
<br/>❌`/header/{hash}`
<br/>❌`/range/{height}`
<br/>✅`/balance/{address}` - `...<BalanceOperation>().Get(address); /* or GetAsync */`
<br/>❌`/mempool/{address}`
<br/>✅`/unspent/{address}` - `...<UnspentOperation>().Get(address, amount); /* or GetAsync */`
<br/>❌`/history/{address}`
<br/>❌`/transaction/{hash}`
<br/>❌`/mempool`
<br/>✅`/supply` - `...<SupplyOperation>().Get(); /* or GetAsync */`
<br/>✅`/fee` - `...<FeeOperation>().Get(); /* or GetAsync */`
<br/>❌`/decode/{raw}`
<br/>✅`/broadcast` - `...<BroadcastOperation>().Send(raw); /* or SendAsync */`

## Examples
```c#
SugarchainClient client = new SugarchainClient();
```

#### 🔹 Info
This method return current info about Sugarchain network.

* Info UseOperation
```c#
Response<InfoResult> result = client.UseOperation<InfoOperation>().Get();
```
* Info UseOperation Async
```c#
Response<InfoResult> result = await client.UseOperation<InfoOperation>().GetAsync();
```
* Info Api
```c#
Response<InfoResult> result = client.Api.Info();
```
* Info Api Async
```c#
Response<InfoResult> result = await client.Api.InfoAsync();
```

#### 🔹 Balance
This method return address balance.

* Data
```c#
string address = "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5";
```
* Balance UseOperation
```c#
Response<BalanceResult> result = client.UseOperation<BalanceOperation>().Get(address);
```
* Balance UseOperation Async
```c#
Response<BalanceResult> result = await client.UseOperation<BalanceOperation>().GetAsync(address);
```
* Balance Api
```c#
Response<BalanceResult> result = client.Api.Balance(address);
```
* Balance Api Async
```c#
Response<BalanceResult> result = await client.Api.BalanceAsync(address);
```

#### 🔹 Unspent
This method return address unspent outputs.

* Data
```c#
string address = "sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5";
int amount = 0;
```
* Unspent UseOperation
```c#
Response<UnspentResult> result = client.UseOperation<UnspentOperation>().Get(address, amount);
```
* Unspent UseOperation Async
```c#
Response<UnspentResult> result = await client.UseOperation<UnspentOperation>().GetAsync(address, amount);
```
* Unspent Api
```c#
Response<UnspentResult> result = client.Api.Unspent(address, amount);
```
* Unspent Api Async
```c#
Response<UnspentResult> result = await client.Api.UnspentAsync(address, amount);
```

#### 🔹 Supply
This method return info about current coins supply.

* Supply UseOperation
```c#
Response<SupplyResult> result = client.UseOperation<SupplyOperation>().Get();
```
* Supply UseOperation Async
```c#
Response<SupplyResult> result = await client.UseOperation<SupplyOperation>().GetAsync();
```
* Supply Api
```c#
Response<SupplyResult> result = client.Api.Supply();
```
* Supply Api Async
```c#
Response<SupplyResult> result = await client.Api.SupplyAsync();
```

#### 🔹 Fee
This method return recommended transaction fee.

* Fee UseOperation
```c#
Response<FeeResult> result = client.UseOperation<FeeOperation>().Get();
```
* Fee UseOperation Async
```c#
Response<FeeResult> result = await client.UseOperation<FeeOperation>().GetAsync();
```
* Fee Api
```c#
Response<FeeResult> result = client.Api.Fee();
```
* Fee Api Async
```c#
Response<FeeResult> result = await client.Api.FeeAsync();
```

#### 🔹 Broadcast
This method broadcast raw signed transaction to Sugarchain network.

* Data
```c#
string raw = "020000000001021786bf75007d1d94b4ce3b94e885690c1dfb9299bcd97e92f7f1b0a80526f6000100000000ffffffff5adfd951b1c065a46dddb0bd0df8b652165e492cb6e5857048ddea365261d0840100000000ffffffff0200e1f50500000000160014d81961ce827299a7afef8113b338761e6b6ea03d605af405000000001600145af91e8c58fccd17682b1bc41a5df595181dc4b402483045022100bcc87972c6389c6b610bb5089a549bea2f92c67f01a3c7516223e3731f155c8b022038fa950f872310b2a576206cd0ce2980592a714ca571a4427774af7f2b68035e012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b0247304402204e9eee008c4fdd9205a3af9eb47c3c393d0ed35f29be8d670ac48edd468647890220583053b7e77e22e631a29360bca44339c5dc6f1aefd0069008097e9a564b8a0f012102f415fdf94b01db2fa79792c849d862d4b708ca1770ebdeba004ad4f218c8565b00000000";
```
* Broadcast UseOperation
```c#
Response<string> result = client.UseOperation<BroadcastOperation>().Send(raw);
```
* Broadcast UseOperation Async
```c#
Response<string> result = await client.UseOperation<BroadcastOperation>().SendAsync(raw);
```
* Broadcast Api
```c#
Response<string> result = client.Api.Broadcast(raw);
```
* Broadcast Api Async
```c#
Response<string> result = await client.Api.BroadcastAsync(raw);
```

## Credits

- [Ivan Terentev](https://github.com/terentev-space)
- [All Contributors](https://github.com/terentev-space/SugarchainApiClient/contributors)

## License

The Apache 2.0 License (Apache-2.0). Please see [License File](LICENSE) for more information.
