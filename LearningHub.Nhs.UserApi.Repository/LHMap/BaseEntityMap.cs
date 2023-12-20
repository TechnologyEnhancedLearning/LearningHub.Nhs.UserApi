﻿// <copyright file="BaseEntityMap.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.UserApi.Repository.LHMap
{
    using LearningHub.Nhs.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The base entity map.
    /// </summary>
    /// <typeparam name="TEntityType">Input type.</typeparam>
    public abstract class BaseEntityMap<TEntityType> : IEntityTypeMap
       where TEntityType : EntityBase
    {
        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Map(ModelBuilder builder)
        {
            builder.Entity<TEntityType>().Property(e => e.Id).HasColumnName("Id");

            builder.Entity<TEntityType>().Property(e => e.AmendDate).HasColumnName("CreateDate");

            builder.Entity<TEntityType>().Property(e => e.AmendUserId).HasColumnName("CreateUserId");

            builder.Entity<TEntityType>().Property(e => e.AmendDate).HasColumnName("AmendDate");

            builder.Entity<TEntityType>().Property(e => e.AmendUserId).HasColumnName("AmendUserId");

            builder.Entity<TEntityType>().Property(e => e.Deleted).HasColumnName("Deleted");

            builder.Entity<TEntityType>().HasQueryFilter(e => !e.Deleted);

            this.InternalMap(builder.Entity<TEntityType>());
        }

        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected abstract void InternalMap(EntityTypeBuilder<TEntityType> builder);
    }
}