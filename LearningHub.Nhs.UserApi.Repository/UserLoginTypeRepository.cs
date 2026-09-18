namespace LearningHub.Nhs.UserApi.Repository
{
    using System.Linq;
    using elfhHub.Nhs.Models.Entities;
    using LearningHub.Nhs.UserApi.Repository.Interface;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The user login typep repository.
    /// </summary>
    public class UserLoginTypeRepository : GenericElfhRepository<UserLoginType>, IUserLoginTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginTypeRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public UserLoginTypeRepository(ElfhHubDbContext dbContext, ILogger<UserLoginType> logger)
            : base(dbContext, logger)
        {
        }

        /// <inheritdoc/>
        public IQueryable<UserLoginType> GetByUserIdAsync(int userId)
        {
            return this.DbContext.Set<UserLoginType>()
                .Where(n => n.UserId == userId && n.Deleted == false)
                .AsNoTracking();
        }

        /// <inheritdoc/>
        public IQueryable<UserLoginType> GetByEmailAddressAsync(string emailAddress, int userId)
        {
            return this.DbContext.Set<UserLoginType>()
                .Where(n => n.UserId == userId && n.LoginInfo.ToLower() == emailAddress.ToLower() && n.Deleted == false)
              .AsNoTracking();
        }
  }
}
