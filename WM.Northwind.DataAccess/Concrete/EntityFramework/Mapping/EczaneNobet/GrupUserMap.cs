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
    public class GrupUserMap : EntityTypeConfiguration<GrupUser>
    {
        public GrupUserMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("GrupUserlar");

            #region columns
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GrupId).HasColumnName("GrupId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            #endregion

            #region properties
            this.Property(t => t.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.GrupId).IsRequired();
            this.Property(t => t.UserId).IsRequired();
            #endregion

            #region relationship
            this.HasRequired(t => t.Grup)
                        .WithMany(et => et.GrupUserlar)
                        .HasForeignKey(t =>t.GrupId)
                        .WillCascadeOnDelete(false);
            this.HasRequired(t => t.User)
                        .WithMany(et => et.GrupUserlar)
                        .HasForeignKey(t =>t.UserId)
                        .WillCascadeOnDelete(false);
            #endregion
        }
    }
}