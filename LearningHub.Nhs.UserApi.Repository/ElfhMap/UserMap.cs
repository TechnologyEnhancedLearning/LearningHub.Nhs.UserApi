﻿namespace LearningHub.Nhs.UserApi.Repository.ElfhMap
{
    using elfhHub.Nhs.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The user map.
    /// </summary>
    public class UserMap : BaseEntityMap<User>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void InternalMap(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("user", "hub");

            modelBuilder.Property(e => e.Id).HasColumnName("Id");

            modelBuilder.Property(e => e.ActiveFromDate).HasColumnName("activeFromDate");

            modelBuilder.Property(e => e.ActiveToDate).HasColumnName("activeToDate");

            modelBuilder.Property(e => e.AdminRequestUserLogout).HasColumnName("adminRequestUserLogout");

            modelBuilder.Property(e => e.AmendDate).HasColumnName("amendDate");

            modelBuilder.Property(e => e.AmendUserId).HasColumnName("amendUserId");

            modelBuilder.Property(e => e.CountryId).HasColumnName("countryId");

            modelBuilder.Property(e => e.CreatedDate).HasColumnName("createdDate");

            modelBuilder.Property(e => e.Deleted);

            modelBuilder.Property(e => e.LastLoginWizardCompleted).HasColumnName("lastLoginWizardCompleted");

            modelBuilder.Property(e => e.LoginTimes).HasColumnName("loginTimes");

            modelBuilder.Property(e => e.LoginWizardInProgress).HasColumnName("loginWizardInProgress");

            modelBuilder.Property(e => e.MustChangeNextLogin).HasColumnName("mustChangeNextLogin");

            modelBuilder.Property(e => e.PasswordHash)
                .HasColumnName("passwordHash")
                .HasMaxLength(255);

            modelBuilder.Property(e => e.PasswordLifeCounter).HasColumnName("passwordLifeCounter");

            modelBuilder.Property(e => e.PreferredName)
                .HasColumnName("preferredName")
                .HasMaxLength(50);

            modelBuilder.Property(e => e.PreferredTenantId)
                .HasColumnName("preferredTenantId")
                .HasDefaultValueSql("((1))");

            modelBuilder.Property(e => e.PrimaryUserEmploymentId).HasColumnName("primaryUserEmploymentId");

            modelBuilder.Property(e => e.RegionId).HasColumnName("regionId");

            modelBuilder.Property(e => e.RegistrationCode)
                .HasColumnName("registrationCode")
                .HasMaxLength(50);

            modelBuilder.Property(e => e.RemoteLoginKey).HasMaxLength(50);

            modelBuilder.Property(e => e.RestrictToSso).HasColumnName("RestrictToSSO");

            modelBuilder.Property(e => e.SecurityLifeCounter).HasColumnName("securityLifeCounter");

            modelBuilder.Property(e => e.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasMaxLength(50);
        }
    }
}