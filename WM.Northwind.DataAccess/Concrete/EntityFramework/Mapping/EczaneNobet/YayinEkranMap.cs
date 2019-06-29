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
    public class YayinEkranMap : EntityTypeConfiguration<YayinEkran>
    {
        public YayinEkranMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("YayinEkranlar");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EkranId).HasColumnName("EkranId");
            this.Property(t => t.EkranTasarimId).HasColumnName("EkranTasarimId");
            this.Property(t => t.BaslamaZamani).HasColumnName("BaslamaZamani");
            this.Property(t => t.BitisZamani).HasColumnName("BitisZamani");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.EkranId).IsRequired();
            this.Property(t => t.EkranTasarimId).IsRequired();
            this.Property(t => t.BaslamaZamani).IsRequired();
            this.Property(t => t.BitisZamani).IsOptional();
            #endregion

            #region relationship
            this.HasRequired(t => t.Ekran)
                        .WithMany(et => et.YayinEkranlar)
                        .HasForeignKey(t =>t.EkranId)
                        .WillCascadeOnDelete(false);

            this.HasRequired(t => t.EkranTasarim)
             .WithMany(et => et.YayinEkranlar)
             .HasForeignKey(t => t.EkranTasarimId)
             .WillCascadeOnDelete(false);
            #endregion
        }
    }
}