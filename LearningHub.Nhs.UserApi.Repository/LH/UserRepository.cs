namespace LearningHub.Nhs.UserApi.Repository.LH
{
    using System.Linq;
    using System.Threading.Tasks;
    using LearningHub.Nhs.Models.Entities;
    using LearningHub.Nhs.UserApi.Repository;
    using LearningHub.Nhs.UserApi.Repository.Interface.LH;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : GenericLHRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="tzOffsetManager">The Timezone offset manager.</param>
        public UserRepository(LearningHubDbContext dbContext, ITimezoneOffsetManager tzOffsetManager)
            : base(dbContext, tzOffsetManager)
        {
        }

        /// <inheritdoc/>
        public async Task<User> GetByIdAsync(int id)
        {
            return await this.DbContext.User.FirstOrDefaultWithNoLockAsync(n => n.Id == id);
        }

        /// <inheritdoc/>
        public async Task<(int Id, string UserName)?> GetByIdSnapshotAsync(int id)
        {
            var user = await this.DbContext.User
                                 .AsNoTracking()
                                 .Where(n => n.Id == id)
                                 .Select(u => new
                                 {
                                     u.Id,
                                     u.UserName,
                                 })
                                 .FirstOrDefaultAsync();
            return user == null ? null : (user.Id, user.UserName);
        }

        /// <inheritdoc/>
        public async Task<int> UpdateUserNameAsync(int userId, string userName)
        {
            var amendDate = this.GetAmendDate();
            return await this.DbContext.User.Where(u => u.Id == userId)
                                             .ExecuteUpdateAsync(s => s
                                                    .SetProperty(u => u.UserName, userName)
                                                    .SetProperty(u => u.AmendDate, amendDate)
                                                    .SetProperty(u => u.AmendUserId, userId));
        }
    }
}