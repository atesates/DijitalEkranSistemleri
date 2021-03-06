﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Entities.Concrete;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.DataAccess.Concrete.EntityFramework.Mapping.EczaneNobet
{
    public class KonumMap : EntityTypeConfiguration<Konum>
    {
        public KonumMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("Konumlar");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GrupId).HasColumnName("GrupId");
            this.Property(t => t.Enlem).HasColumnName("Enlem");
            this.Property(t => t.Boylam).HasColumnName("Boylam");
            this.Property(t => t.BaslamaTarihi).HasColumnName("BaslamaTarihi");
            this.Property(t => t.BitisTarihi).HasColumnName("BitisTarihi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.Adi).HasColumnName("Adi");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.Enlem).IsRequired();
            this.Property(t => t.GrupId).IsRequired();
            this.Property(t => t.Boylam).IsRequired();
            this.Property(t => t.BaslamaTarihi).IsRequired();
            this.Property(t => t.BitisTarihi).IsOptional();
            this.Property(t => t.Aciklama).IsOptional()
                        .HasMaxLength(100);
            this.Property(t => t.Adi).IsOptional()
                      .HasMaxLength(50);
            #endregion

            #region relationship
            this.HasRequired(t => t.Grup)
                       .WithMany(et => et.Konumlar)
                       .HasForeignKey(t => t.GrupId)
                       .WillCascadeOnDelete(false);
            #endregion
        }
    }
}