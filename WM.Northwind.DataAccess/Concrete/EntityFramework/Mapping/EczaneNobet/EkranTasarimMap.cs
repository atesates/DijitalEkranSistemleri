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
    public class EkranTasarimMap : EntityTypeConfiguration<EkranTasarim>
    {
        public EkranTasarimMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("EkranTasarimlar");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.BaslamaTarihi).HasColumnName("BaslamaTarihi");
            this.Property(t => t.BitisTarihi).HasColumnName("BitisTarihi");
            this.Property(t => t.SonDegisiklikTarihi).HasColumnName("SonDegisiklikTarihi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.GrupId).HasColumnName("GrupId");

            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.Adi).IsRequired()
                        .HasMaxLength(50);
            this.Property(t => t.GrupId).IsRequired();
            this.Property(t => t.BaslamaTarihi).IsRequired();
            this.Property(t => t.BitisTarihi).IsOptional();
            this.Property(t => t.SonDegisiklikTarihi).IsRequired();
            this.Property(t => t.Aciklama).IsOptional()
                        .HasMaxLength(100);
            #endregion

            #region relationship
            this.HasRequired(t => t.Grup)
                               .WithMany(et => et.EkranTasarimlar)
                               .HasForeignKey(t => t.GrupId)
                               .WillCascadeOnDelete(false);
            #endregion
        }
    }
}