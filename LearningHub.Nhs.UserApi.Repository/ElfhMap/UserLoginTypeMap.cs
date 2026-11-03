namespace LearningHub.Nhs.UserApi.Repository.ElfhMap
{
    using elfhHub.Nhs.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The user user group map.
    /// </summary>
    public class UserLoginTypeMap : BaseEntityMap<UserLoginType>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void InternalMap(EntityTypeBuilder<UserLoginType> modelBuilder)
        {
            modelBuilder.ToTable("UserLoginTypeTBL", "dbo");

            modelBuilder.Property(e => e.Id).HasColumnName("userLoginTypeId");

            modelBuilder.Property(e => e.UserId).HasColumnName("userId");

            modelBuilder.Property(e => e.LoginInfo).HasColumnName("loginInfo");
            modelBuilder.Property(e => e.CreateUserId).HasColumnName("createUserId");
            modelBuilder.Property(e => e.CreateDate).HasColumnName("createDate");
            modelBuilder.Property(e => e.UserHistoryTypeId).HasColumnName("userHistoryTypeId");

            modelBuilder.HasOne(d => d.User)
           .WithMany(p => p.UserLoginType)
           .HasForeignKey(d => d.UserId)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_UserLoginType_user");

            modelBuilder.Property(e => e.Deleted).HasColumnName("deleted");
        }
    }
}