namespace LearningHub.Nhs.UserApi.Repository.Interface
{
    using System.Linq;
    using System.Threading.Tasks;
    using elfhHub.Nhs.Models.Entities;

    /// <summary>
    /// The User login type interface.
    /// </summary>
    public interface IUserLoginTypeRepository : IGenericElfhRepository<UserLoginType>
    {
        /// <summary>
        /// The get by user id async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<UserLoginType> GetByUserIdAsync(int userId);

        /// <summary>
        /// The get by User Id and email Address async.
        /// </summary>
        /// <param name="emailAddress">
        /// The email Address.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<UserLoginType> GetByEmailAddressAsync(string emailAddress, int userId);

        /// <summary>
        /// The create async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="userLoginType">
        /// The email change validation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> CreateAsync(int userId, UserLoginType userLoginType);
    }
}
