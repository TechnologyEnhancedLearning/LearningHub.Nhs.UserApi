namespace LearningHub.Nhs.UserApi.Repository.ElfhMap
{
    using elfhHub.Nhs.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The ExternalSystem map.
    /// </summary>
    public partial class ExternalSystemMap : BaseEntityMap<ExternalSystem>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void InternalMap(EntityTypeBuilder<ExternalSystem> modelBuilder)
        {
            modelBuilder.ToTable("ExternalSystem", "external");

            modelBuilder.Property(e => e.Id).HasColumnName("Id");

            modelBuilder.Property(e => e.Name).HasColumnName("Name");

            modelBuilder.Property(e => e.Code);
        }
    }
}