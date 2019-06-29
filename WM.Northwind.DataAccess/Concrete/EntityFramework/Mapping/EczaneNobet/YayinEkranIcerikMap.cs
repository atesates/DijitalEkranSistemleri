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
    public class YayinEkranIcerikMap : EntityTypeConfiguration<YayinEkranIcerik>
    {
        public YayinEkranIcerikMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("YayinEkranIcerikler");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EkranIcerikId).HasColumnName("EkranIcerikId");
            this.Property(t => t.Alan).HasColumnName("Alan");
            this.Property(t => t.YayinEkranId).HasColumnName("YayinEkranId");
            this.Property(t => t.BaslamaZamani).HasColumnName("BaslamaZamani");
            this.Property(t => t.BitisZamani).HasColumnName("BitisZamani");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.EkranIcerikId).IsRequired();
            this.Property(t => t.Alan).IsRequired();
            this.Property(t => t.YayinEkranId).IsRequired();
            this.Property(t => t.BaslamaZamani).IsRequired();
            this.Property(t => t.BitisZamani).IsOptional();
            #endregion

            #region relationship

            this.HasRequired(t => t.EkranIcerik)
                        .WithMany(et => et.YayinEkranIcerikler)
                        .HasForeignKey(t =>t.EkranIcerikId)
                        .WillCascadeOnDelete(false);

            this.HasRequired(t => t.YayinEkran)
                    .WithMany(et => et.YayinEkranIcerikler)
                    .HasForeignKey(t => t.YayinEkranId)
                    .WillCascadeOnDelete(false);
            #endregion
        }
    }
}