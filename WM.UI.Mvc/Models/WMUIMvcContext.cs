using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Models
{
    public class WMUIMvcContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public WMUIMvcContext() : base("name=WMUIMvcContext")
        {
        }         

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuAlt> MenuAlts { get; set; }
        
        public DbSet<MenuAltRole> MenuAltRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<MenuRole> MenuRoles { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        
    }
}
