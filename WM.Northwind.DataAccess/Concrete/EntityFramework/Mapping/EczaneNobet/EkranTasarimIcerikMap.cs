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
    public class EkranTasarimIcerikMap : EntityTypeConfiguration<EkranTasarimIcerik>
    {
        public EkranTasarimIcerikMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("EkranTasarimIcerikler");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EkranTasarimId).HasColumnName("EkranTasarimId");
            this.Property(t => t.EkranIcerikId).HasColumnName("EkranIcerikId");
            this.Property(t => t.BoyutX).HasColumnName("BoyutX");
            this.Property(t => t.BoyutY).HasColumnName("BoyutY");
            this.Property(t => t.KoordinatX).HasColumnName("KoordinatX");
            this.Property(t => t.KoordinatY).HasColumnName("KoordinatY");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.EkranTasarimId).IsRequired();
            this.Property(t => t.EkranIcerikId).IsRequired();
            this.Property(t => t.BoyutX).IsRequired();
            this.Property(t => t.BoyutY).IsRequired();
            this.Property(t => t.KoordinatX).IsRequired();
            this.Property(t => t.KoordinatY).IsRequired();
            #endregion

            #region relationship
            this.HasRequired(t => t.EkranIcerik)
                        .WithMany(et => et.EkranTasarimIcerikler)
                        .HasForeignKey(t =>t.EkranIcerikId)
                        .WillCascadeOnDelete(false);
            this.HasRequired(t => t.EkranTasarim)
                        .WithMany(et => et.EkranTasarimIcerikler)
                        .HasForeignKey(t =>t.EkranTasarimId)
                        .WillCascadeOnDelete(false);
            #endregion
        }
    }
}