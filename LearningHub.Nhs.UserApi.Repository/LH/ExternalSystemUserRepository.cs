﻿namespace LearningHub.Nhs.UserApi.Repository.LH
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using elfhHub.Nhs.Models.Entities;
    using LearningHub.Nhs.Models.Entities.External;
    using LearningHub.Nhs.UserApi.Repository;
    using LearningHub.Nhs.UserApi.Repository.Interface.LH;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The external system user repository.
    /// </summary>
    public class ExternalSystemUserRepository : GenericLHRepository<ExternalSystemUser>, Interface.LH.IExternalSystemUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalSystemUserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="tzOffsetManager">The Timezone offset manager.</param>
        public ExternalSystemUserRepository(LearningHubDbContext dbContext, ITimezoneOffsetManager tzOffsetManager)
            : base(dbContext, tzOffsetManager)
        {
        }

        /// <inheritdoc/>
        public async Task<ExternalSystemUser> GetByIdAsync(int userId, int externalSystemId)
        {
            return await this.DbContext.ExternalSystemUser
                            .Where(t => t.UserId == userId && t.ExternalSystemId == externalSystemId)
                            .AsNoTracking()
                            .FirstOrDefaultWithNoLockAsync();
        }

        /// <inheritdoc/>
        public async Task CreateExternalSystemUserAsync(ExternalSystemUser userExternalSystem)
        {
            try
            {
                var param0 = new SqlParameter("@p0", SqlDbType.Int) { Value = userExternalSystem.UserId };
                var param1 = new SqlParameter("@p1", SqlDbType.Int) { Value = userExternalSystem.ExternalSystemId };
                var param2 = new SqlParameter("@p2", SqlDbType.Int) { Value = userExternalSystem.UserId };
                var param3 = new SqlParameter("@p3", SqlDbType.Int) { Value = this.TimezoneOffsetManager.UserTimezoneOffset ?? (object)DBNull.Value };
                await this.DbContext.Database.ExecuteSqlRawAsync("[external].ExternalSystemUserCreate @p0, @p1, @p2, @p3", param0, param1, param2, param3);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
