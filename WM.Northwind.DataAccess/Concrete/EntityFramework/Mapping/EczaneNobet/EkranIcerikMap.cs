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
    public class EkranIcerikMap : EntityTypeConfiguration<EkranIcerik>
    {
        public EkranIcerikMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("EkranIcerikler");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GrupId).HasColumnName("GrupId");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Uzanti).HasColumnName("Uzanti");           
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.GrupId).IsRequired();
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.Adi).IsRequired()
                        .HasMaxLength(50);
            this.Property(t => t.Uzanti).IsRequired()
                        .HasMaxLength(50);
           
            this.Property(t => t.Url).IsRequired()
                        .HasMaxLength(100);
            #endregion

            #region relationship

            this.HasRequired(t => t.Grup)
                       .WithMany(et => et.EkranIcerikler)
                       .HasForeignKey(t => t.GrupId)
                       .WillCascadeOnDelete(false);
            #endregion
        }
    }
}