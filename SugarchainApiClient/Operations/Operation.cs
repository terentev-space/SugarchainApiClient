using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient.Operations
{
    public abstract class Operation
    {
        private readonly HttpClient httpClient;
        private readonly IClientConfig config;
        [AllowNull]
        private readonly IOperationLogger logger;

        protected Operation(HttpClient httpClient, IClientConfig config, [AllowNull] IOperationLogger logger)
        {
            this.httpClient = httpClient;
            this.config = config;
            this.logger = logger;
        }

        protected async Task<T> SendAsync<T>(
            HttpMethod method,
            string path,
            [AllowNull] Dictionary<string, string> queryParams = null,
            [AllowNull] Dictionary<string, string> formParams = null
        ) where T : class
        {
            this.logger?.LogSend(method, path, queryParams, formParams);
            
            string query = this.BuildQuery(queryParams);
            HttpContent content = this.BuildContent(formParams);
            
            foreach (string host in config.GetHosts())
            {
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(method, this.BuildUri(host, path, query));
                    if (content is { })
                        request.Content = content;
                    
                    this.logger?.LogRequest(request);
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    this.logger?.LogResponse(response);

                    if (response.IsSuccessStatusCode)
                    {
                        T result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                        this.logger?.LogResult<T>(result);
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    this.logger?.LogException(ex);
                }
            }

            this.logger?.LogResult<T>(default);
            return default;
        }

        private string BuildQuery([AllowNull] Dictionary<string, string> queryParams = null, string queryString = "")
        {
            if (queryParams is null)
                return queryString;

            NameValueCollection query = HttpUtility.ParseQueryString(queryString);
            foreach ((string key, string value) in queryParams)
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    query.Add(key, value);

            return query.ToString();
        }

        private HttpContent BuildContent([AllowNull]Dictionary<string, string> formParams)
        {
            if (formParams is { })
                return new FormUrlEncodedContent(formParams);

            return default;
        }

        private string BuildUri(string host, string path, string query)
        {
            UriBuilder builder = new UriBuilder(host)
            {
                Path = path,
                Query = query,
            };

            return builder.ToString();
        }
    }
}