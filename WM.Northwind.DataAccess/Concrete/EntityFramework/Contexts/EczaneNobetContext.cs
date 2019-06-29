using System.Data.Entity;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Initializers;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Mapping.EczaneNobet;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Mapping.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using System.Collections.Generic;
using WM.Northwind.DataAccess.Migrations;

namespace WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts
{
    public class EczaneNobetContext : DbContext
    {
        static EczaneNobetContext()
        {
            //Database.SetInitializer(new EczaneNobetInitializer());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EczaneNobetContext>());

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EczaneNobetContext, Configuration>("EczaneNobetContext"));
        }

        public EczaneNobetContext() : base("Name=EczaneNobetContext")
        {
        }

        #region Yetki
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<MenuRole> MenuRoles { get; set; }
        public DbSet<MenuAltRole> MenuAltRoles { get; set; }

        public DbSet<Menu> Menuler { get; set; }
        public DbSet<MenuAlt> MenuAltlar { get; set; }
        #endregion
        
        
        public DbSet<Log> Logs { get; set; }
       

        #region Eczane Nöbet
        
        public DbSet<Ekran> Ekranlar { get; set; }
        public DbSet<EkranIcerik> EkranIcerikler { get; set; }
        public DbSet<EkranTasarim> EkranTasarimlar { get; set; }
        public DbSet<Konum> Konumlar { get; set; }
        public DbSet<Cozunurluk> Cozunurlukler { get; set; }
        public DbSet<Cihaz> Cihazlar { get; set; }
        public DbSet<Monitor> Monitorler { get; set; }
        public DbSet<CihazDurum> CihazDurumlar { get; set; }
        public DbSet<Grup> Gruplar { get; set; }
        public DbSet<GrupUser> GrupUserlar { get; set; }
        public DbSet<YayinEkran> YayinEkranlar { get; set; }
        public DbSet<YayinEkranIcerik> YayinEkranIcerikler { get; set; }
        public DbSet<EkranTasarimIcerik> EkranTasarimIcerikler { get; set; }

        #endregion

        #region Mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("EczaneNobet");

            #region Yetki
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserRoleMap());

            modelBuilder.Configurations.Add(new MenuRoleMap());
            modelBuilder.Configurations.Add(new MenuAltRoleMap());

            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new MenuAltMap());
            #endregion
            

            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new EkranMap());
            modelBuilder.Configurations.Add(new EkranIcerikMap());
            modelBuilder.Configurations.Add(new EkranTasarimMap());
            modelBuilder.Configurations.Add(new KonumMap());
            modelBuilder.Configurations.Add(new CozunurlukMap());
            modelBuilder.Configurations.Add(new CihazMap());
            modelBuilder.Configurations.Add(new MonitorMap());
            modelBuilder.Configurations.Add(new CihazDurumMap());
            modelBuilder.Configurations.Add(new GrupMap());
            modelBuilder.Configurations.Add(new GrupUserMap());
            modelBuilder.Configurations.Add(new YayinEkranMap());
            modelBuilder.Configurations.Add(new YayinEkranIcerikMap());
            modelBuilder.Configurations.Add(new EkranTasarimIcerikMap());

            #endregion

        }
    }
}