using System;
using Newtonsoft.Json;
using RestSharp;

namespace Api.Client
{
    public class ApiClient
    {
        protected ApiSettings _settings;

        public ApiClient(ApiSettings settings)
        {
            _settings = settings;
        }

        public object Get(string lookup, Type responseType = null)
        {
            return ExecuteRequest(CreateRequestor(lookup), CreateGetRequest(), responseType);
        }


        protected object ExecuteRequest(RestClient requestor, RestRequest request, Type responseType = null)
        {
            var response = requestor.Execute(request);

            var content = response.Content;
            if (content == null) throw new ApplicationException(string.Format("ERROR: No response received from call to web API: {0}", 
                requestor.BaseUrl));

            return responseType != null ? JsonConvert.DeserializeObject(content, responseType) : content;
        }

        protected RestClient CreateRequestor(string lookup = "")
        {
            return new RestClient()
            {
                BaseUrl = new Uri(string.Format("{0}{1}{2}", _settings.BaseUrl, _settings.Route, lookup)),
                Timeout = _settings.GetTimeoutValue()
            };
        }

        protected RestRequest CreateGetRequest()
        {
            return CreateRequest(Method.GET);
        }

        protected RestRequest CreateRequest(Method requestMethod)
        {
            var request = new RestRequest(requestMethod);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            return request;
        }
    }
}
