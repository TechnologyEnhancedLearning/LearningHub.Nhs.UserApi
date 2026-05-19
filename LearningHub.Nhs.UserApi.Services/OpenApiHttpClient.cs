namespace LearningHub.Nhs.UserApi.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using LearningHub.Nhs.UserApi.Services.Interface;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// The OpenApiHttpClient.
    /// </summary>
    public class OpenApiHttpClient : IOpenApiHttpClient
    {
        /// <summary>
        /// The Http client.
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiHttpClient"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="client">The client.</param>
        public OpenApiHttpClient(IOptions<OpenApiConfig> config, HttpClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            client.BaseAddress = new Uri(config.Value.OpenApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-API-KEY", config.Value.OpenApiKey.ToString());
            this.client = client;
        }

        /// <summary>
        /// The get client.
        /// </summary>
        /// <returns>
        /// The <see cref="HttpClient"/>.
        /// </returns>
        public HttpClient GetClient()
        {
            return this.client;
        }
    }
}
