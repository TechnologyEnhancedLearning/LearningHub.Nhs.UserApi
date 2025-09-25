﻿namespace LearningHub.Nhs.UserApi.Repository.ElfhMap
{
    using elfhHub.Nhs.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The tenant user group map.
    /// </summary>
    public class TenantUserGroupMap : BaseEntityMap<TenantUserGroup>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void InternalMap(EntityTypeBuilder<TenantUserGroup> modelBuilder)
        {
            modelBuilder.ToTable("tenantUserGroupTBL", "elfh");

            modelBuilder.Property(e => e.Id).HasColumnName("tenantUserGroupId");
            modelBuilder.Property(e => e.UserGroupId).HasColumnName("userGroupId");
            modelBuilder.Property(e => e.Deleted).HasColumnName("deleted");
        }
    }
}
