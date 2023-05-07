using System;
using Novu.Interfaces;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace Novu.Clients
{
    /// <summary>
    /// Base class for an API client.
    /// </summary>
    public abstract class ApiClient
    {
        protected readonly RestClient Client;
    
        protected ApiClient(INovuClientConfiguration apiConfiguration)
        {
            Client = new RestClient(new RestClientOptions
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                    apiConfiguration.ApiKey, 
                    "ApiKey"),
                BaseUrl = new Uri(apiConfiguration.Url)
            });
        }
    }
}