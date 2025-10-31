namespace LearningHub.Nhs.UserApi.Repository.LH
{
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using elfhHub.Nhs.Models.Common;
    using elfhHub.Nhs.Models.Dto;
    using LearningHub.Nhs.Models.Entities;
    using LearningHub.Nhs.UserApi.Repository;
    using LearningHub.Nhs.UserApi.Repository.Interface.LH;
    using Microsoft.Data.SqlClient;
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
        public async Task<int> GetUserIdByUsernameAsync(string username)
        {
            return await this.DbContext.User.AsNoTracking().Where(n => n.UserName == username).Select(n => n.Id).FirstOrDefaultWithNoLockAsync();
        }

        /// <inheritdoc/>
        public async Task<UserBasic> GetByOpenAthensIdAsync(string openAthensId)
        {
            var param = new SqlParameter("@OpenAthensId", openAthensId);

            return await this.DbContext.Set<UserBasic>()
                .FromSqlRaw("EXEC elfh.proc_GetUserByOpenAthensId @OpenAthensId", param)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// The get user detail for the authentication.
        /// </summary>
        /// <param name = "username">
        /// username.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<UserAuthenticateDto> GetUserDetailForAuthentication(string username)
        {
                var param0 = new SqlParameter("@userName", SqlDbType.VarChar) { Value = username };

                var userAuthenticateDto = await this.DbContext.UserAuthenticateDto.FromSqlRaw("elfh.proc_UserDetailForAuthenticationByUserName @userName", param0).AsNoTracking().ToListAsync();

                return userAuthenticateDto.FirstOrDefault();
        }
    }
}