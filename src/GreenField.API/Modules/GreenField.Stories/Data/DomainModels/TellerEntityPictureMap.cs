﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class TellerEntityPictureMap : EntityTypeConfiguration<TellerEntityPicture>
    {
        public TellerEntityPictureMap()
        {
            // Primary Key
            HasKey(t => new { t.EntityId, t.EntityPictureId });

            // Properties
            Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.EntityPictureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("TellerEntityPicture");
            Property(t => t.EntityId).HasColumnName("TellerId");
            Property(t => t.EntityPictureId).HasColumnName("EntityPictureId");
            Property(t => t.Primary).HasColumnName("Primary");
            Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            HasRequired(t => t.Entity)
                .WithMany(t => t.EntityEntityPictures)
                .HasForeignKey(d => d.EntityId);
            HasRequired(t => t.EntityPicture)
                .WithMany()
                .HasForeignKey(d => d.EntityPictureId);
        }
    }
}
