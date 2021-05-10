using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace SugarchainApiClient.Interfaces
{
    public interface IOperationLogger
    {
        public void LogSend(HttpMethod method, string path, [AllowNull] Dictionary<string, string> queryParams = null, [AllowNull] Dictionary<string, string> formParams = null);
        public void LogRequest(HttpRequestMessage request);
        public void LogResponse(HttpResponseMessage response);
        public void LogException(Exception ex);

        public void LogResult<T>(T result) where T : class;
    }
}