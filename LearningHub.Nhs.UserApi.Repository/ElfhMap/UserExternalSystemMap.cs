namespace LearningHub.Nhs.UserApi.Repository.ElfhMap
{
    using elfhHub.Nhs.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// UserExternalSystemMap.
    /// </summary>
    public class UserExternalSystemMap : BaseEntityMap<UserExternalSystem>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void InternalMap(EntityTypeBuilder<UserExternalSystem> modelBuilder)
        {
            modelBuilder.ToTable("ExternalSystemUser", "external");

            modelBuilder.Property(e => e.Id).HasColumnName("Id");

            modelBuilder.Property(e => e.UserId);

            modelBuilder.Property(e => e.Deleted);

            modelBuilder.Property(e => e.ExternalSystemId);

            modelBuilder.HasOne(d => d.ExternalSystem)
                .WithMany()
                .HasForeignKey(d => d.ExternalSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}