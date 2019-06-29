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
    public class CihazMap : EntityTypeConfiguration<Cihaz>
    {
        public CihazMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("Cihazlar");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GrupId).HasColumnName("GrupId");
            this.Property(t => t.CozunurlukId).HasColumnName("CozunurlukId");
            this.Property(t => t.CihazDurumId).HasColumnName("CihazDurumId");
            this.Property(t => t.Marka).HasColumnName("Marka");
            this.Property(t => t.ApiUrl).HasColumnName("ApiUrl");
            this.Property(t => t.Model).HasColumnName("Model");
            this.Property(t => t.SeriNu).HasColumnName("SeriNu");
            this.Property(t => t.AlimTarihi).HasColumnName("AlimTarihi");
            this.Property(t => t.BaslamaTarihi).HasColumnName("BaslamaTarihi");
            this.Property(t => t.SonGuncellenmeTarihi).HasColumnName("SonGuncellenmeTarihi");
            this.Property(t => t.SonGuncelleyenUserId).HasColumnName("SonGuncelleyenUserId");
            this.Property(t => t.BitisTarihi).HasColumnName("BitisTarihi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.WiFiKullaniciAdi).HasColumnName("WiFiKullaniciAdi");
            this.Property(t => t.WiFiParola).HasColumnName("WiFiParola");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.Marka).IsRequired()
                        .HasMaxLength(50);
            this.Property(t => t.Model).IsRequired()
                        .HasMaxLength(50);
            this.Property(t => t.ApiUrl).IsRequired()
                        .HasMaxLength(100);
            this.Property(t => t.SeriNu).IsRequired()
                        .HasMaxLength(50);
            this.Property(t => t.AlimTarihi).IsRequired();
            this.Property(t => t.GrupId).IsRequired();
            this.Property(t => t.SonGuncelleyenUserId).IsRequired();
            this.Property(t => t.CozunurlukId).IsRequired();
            this.Property(t => t.CihazDurumId).IsRequired();
            this.Property(t => t.BaslamaTarihi).IsRequired();
            this.Property(t => t.SonGuncellenmeTarihi).IsRequired();
            this.Property(t => t.BitisTarihi).IsOptional();
            this.Property(t => t.Aciklama).IsOptional()
                        .HasMaxLength(100);
            this.Property(t => t.WiFiKullaniciAdi).IsOptional()
                       .HasMaxLength(50);
            this.Property(t => t.WiFiParola).IsOptional()
                       .HasMaxLength(50);
            #endregion

            #region relationship
            this.HasRequired(t => t.Cozunurluk)
                   .WithMany(et => et.Cihazlar)
                   .HasForeignKey(t => t.CozunurlukId)
                   .WillCascadeOnDelete(false);

            this.HasRequired(t => t.CihazDurum)
                  .WithMany(et => et.Cihazlar)
                  .HasForeignKey(t => t.CihazDurumId)
                  .WillCascadeOnDelete(false);

            this.HasRequired(t => t.Grup)
                       .WithMany(et => et.Cihazlar)
                       .HasForeignKey(t => t.GrupId)
                       .WillCascadeOnDelete(false);

            this.HasRequired(t => t.User)
                       .WithMany(et => et.Cihazlar)
                       .HasForeignKey(t => t.SonGuncelleyenUserId)
                       .WillCascadeOnDelete(false);
            #endregion
        }
    }
}