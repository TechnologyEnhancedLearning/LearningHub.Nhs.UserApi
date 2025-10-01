namespace LearningHub.Nhs.UserApi.Repository.Extentions
{
    using System;
    using System.Linq;
    using elfhHub.Nhs.Models.Entities;
    using LearningHub.Nhs.UserApi.Shared;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user extension methods.
    /// </summary>
    public static class UserExtensionMethods
    {
        /// <summary>
        /// The include collections.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The included column is not in the internal list.
        /// </exception>
        public static IQueryable<User> IncludeCollections(this IQueryable<User> query, UserIncludeCollectionsEnum[] includes)
        {
            if (includes == null)
            {
                return query;
            }

            for (var i = 0; i < includes.Length; i++)
            {
                query = includes[i] switch
                {
                    UserIncludeCollectionsEnum.UserUserGroup => query.Include(x => x.UserUserGroup),
                    UserIncludeCollectionsEnum.UserPasswordValidationToken => query.Include(x => x.UserPasswordValidationToken),
                    UserIncludeCollectionsEnum.UserEmployment => query.Include(x => x.UserEmployment),
                    UserIncludeCollectionsEnum.EmailLog => query.Include(x => x.EmailLog),
                    UserIncludeCollectionsEnum.LoginWizardStageActivity => query.Include(x => x.LoginWizardStageActivity),
                    UserIncludeCollectionsEnum.UserTermsAndConditions => query.Include(x => x.UserTermsAndConditions),
                    UserIncludeCollectionsEnum.UserSecurityQuestion => query.Include(x => x.UserSecurityQuestion),
                    UserIncludeCollectionsEnum.UserAttributes => query.Include(x => x.UserAttributes).ThenInclude(x => x.Attribute),
                    UserIncludeCollectionsEnum.UserRoleUpgrade => query.Include(x => x.UserRoleUpgrade),
                    _ => throw new ArgumentOutOfRangeException(includes[i].ToString()),
                };
            }

            return query;
        }

        /// <summary>
        /// The user update ions.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="profile">The profile.</param>
        public static void ApplyUserProfile(this User user, Models.Entities.UserProfile profile)
        {
            if (profile == null)
            {
                return;
            }

            user.EmailAddress = profile.EmailAddress;
            user.AltEmailAddress = profile.AltEmailAddress;
            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            user.PreferredName = profile.PreferredName;
            user.Active = profile.Active;
        }

        /// <summary>
        /// The user update query.
        /// </summary>
        /// <param name="users">The user.</param>
        /// <param name="profiles">The profile.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public static IQueryable<User> WithProfile(this IQueryable<User> users, IQueryable<Models.Entities.UserProfile> profiles)
        {
            return from u in users
                   join p in profiles on u.Id equals p.Id
                   select new User
                   {
                       Id = u.Id,
                       UserName = u.UserName,
                       EmailAddress = p.EmailAddress,
                       FirstName = p.FirstName,
                       LastName = p.LastName,
                       Active = p.Active,
                       AltEmailAddress = p.AltEmailAddress,
                       PreferredName = p.PreferredName,
                       CountryId = u.CountryId,
                       RegistrationCode = u.RegistrationCode,
                       ActiveFromDate = u.ActiveFromDate,
                       ActiveToDate = u.ActiveToDate,
                       PasswordHash = u.PasswordHash,
                       MustChangeNextLogin = u.MustChangeNextLogin,
                       PasswordLifeCounter = u.PasswordLifeCounter,
                       SecurityLifeCounter = u.SecurityLifeCounter,
                       RemoteLoginKey = u.RemoteLoginKey,
                       RemoteLoginGuid = u.RemoteLoginGuid,
                       RemoteLoginStart = u.RemoteLoginStart,
                       RestrictToSso = u.RestrictToSso,
                       ActiveComponentHierarchyId = u.ActiveComponentHierarchyId,
                       ActiveComponentHierarchyDate = u.ActiveComponentHierarchyDate,
                       CreatedDate = u.CreatedDate,
                       LoginTimes = u.LoginTimes,
                       LoginWizardInProgress = u.LoginWizardInProgress,
                       LastLoginWizardCompleted = u.LastLoginWizardCompleted,
                       PrimaryUserEmploymentId = u.PrimaryUserEmploymentId,
                       RegionId = u.RegionId,
                       PreferredTenantId = u.PreferredTenantId,
                   };
        }
    }
}