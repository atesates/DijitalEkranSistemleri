using System;
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
    public class EkranMap : EntityTypeConfiguration<Ekran>
    {
        public EkranMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("Ekranlar");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MonitorId).HasColumnName("MonitorId");
            this.Property(t => t.KonumId).HasColumnName("KonumId");
            this.Property(t => t.CihazId).HasColumnName("CihazId");
            this.Property(t => t.GrupId).HasColumnName("GrupId");
            this.Property(t => t.BaslamaTarihi).HasColumnName("BaslamaTarihi");
            this.Property(t => t.BitisTarihi).HasColumnName("BitisTarihi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.AktifMi).HasColumnName("AktifMi");
            this.Property(t => t.EkranUrl).HasColumnName("EkranUrl");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.MonitorId).IsRequired();
            this.Property(t => t.KonumId).IsRequired();
            this.Property(t => t.CihazId).IsRequired();
            this.Property(t => t.GrupId).IsRequired();
            this.Property(t => t.BaslamaTarihi).IsRequired();
            this.Property(t => t.BitisTarihi).IsOptional();
            this.Property(t => t.Aciklama).IsOptional()
                        .HasMaxLength(100);
            this.Property(t => t.AktifMi).IsRequired();
            this.Property(t => t.EkranUrl).IsRequired()
                        .HasMaxLength(100);
            #endregion

            #region relationship

            this.HasRequired(t => t.Konum)
                        .WithMany(et => et.Ekranlar)
                        .HasForeignKey(t =>t.KonumId)
                        .WillCascadeOnDelete(false);
            this.HasRequired(t => t.Grup)
                        .WithMany(et => et.Ekranlar)
                        .HasForeignKey(t => t.GrupId)
                        .WillCascadeOnDelete(false);

            this.HasRequired(t => t.Monitor)
                      .WithMany(et => et.Ekranlar)
                      .HasForeignKey(t => t.MonitorId)
                      .WillCascadeOnDelete(false);

            this.HasRequired(t => t.Cihaz)
                     .WithMany(et => et.Ekranlar)
                     .HasForeignKey(t => t.CihazId)
                     .WillCascadeOnDelete(false);
            #endregion
        }
    }
}