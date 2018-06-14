using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testwebapi.Infrastructure
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Error = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
            case 404:
                return "Resource not found";
            case 500:
                return "An unhandled error occurred";
            case 401:
                return "Unauthorized: Invalid/Missing apiKey";
                default:
                return null;
        }
    }
}
}
