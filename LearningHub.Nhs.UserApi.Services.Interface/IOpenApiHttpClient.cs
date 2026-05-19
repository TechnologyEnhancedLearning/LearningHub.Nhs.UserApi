namespace LearningHub.Nhs.UserApi.Services.Interface
{
    using System.Net.Http;

    /// <summary>
    /// The IOpenApiHttpClient.
    /// </summary>
    public interface IOpenApiHttpClient
    {
        /// <summary>
        /// The get client.
        /// </summary>
        /// <returns>
        /// The <see cref="HttpClient"/>.
        /// </returns>
        HttpClient GetClient();
    }
}
