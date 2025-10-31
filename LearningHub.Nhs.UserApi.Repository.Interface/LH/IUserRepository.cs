namespace LearningHub.Nhs.UserApi.Repository.Interface.LH
{
    using System.Threading.Tasks;
    using elfhHub.Nhs.Models.Common;
    using elfhHub.Nhs.Models.Dto;
    using LearningHub.Nhs.Models.Entities;

    /// <summary>
    /// The Learning Hub User Repository interface.
    /// </summary>
    public interface IUserRepository : IGenericLHRepository<User>
    {
        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<User> GetByIdAsync(int id);

        /// <summary>
        /// The get user id by username async.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> GetUserIdByUsernameAsync(string username);

        /// <summary>
        /// The get by open athens id.
        /// </summary>
        /// <param name="openAthensId">
        /// The open athens id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<UserBasic> GetByOpenAthensIdAsync(string openAthensId);

        /// <summary>
        /// The get user detail for the authentication.
        /// </summary>
        /// <param name = "username">
        /// username.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<UserAuthenticateDto> GetUserDetailForAuthentication(string username);
    }
}