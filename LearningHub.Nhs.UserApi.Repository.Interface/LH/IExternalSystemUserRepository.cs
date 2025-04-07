﻿namespace LearningHub.Nhs.UserApi.Repository.Interface.LH
{
    using System.Threading.Tasks;
    using elfhHub.Nhs.Models.Entities;
    using LearningHub.Nhs.Models.Entities.External;

    /// <summary>
    /// The External System User Repository interface.
    /// </summary>
    public interface IExternalSystemUserRepository : IGenericLHRepository<ExternalSystemUser>
    {
        /// <summary>
        /// Get external system user entity by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="externalSystemId">The external system id.</param>
        /// <returns>The <see cref="ExternalSystemUser"/>.</returns>
        Task<ExternalSystemUser> GetByIdAsync(int userId, int externalSystemId);

        /// <summary>
        /// Create External system user.
        /// </summary>
        /// <param name="userExternalSystem">The userExternalSystem.</param>
        /// <returns>The <see cref="ExternalSystemUser"/>.</returns>
        Task CreateExternalSystemUserAsync(ExternalSystemUser userExternalSystem);
    }
}
