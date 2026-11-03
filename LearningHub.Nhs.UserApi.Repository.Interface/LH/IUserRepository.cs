namespace LearningHub.Nhs.UserApi.Repository.Interface.LH
{
    using System.Threading.Tasks;
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
        /// The get by Id async snapshot.
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<(int Id, string UserName)?> GetByIdSnapshotAsync(int id);

        /// <summary>
        /// The update username method.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <param name="userName">The username.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<int> UpdateUserNameAsync(int userId, string userName);
    }
}