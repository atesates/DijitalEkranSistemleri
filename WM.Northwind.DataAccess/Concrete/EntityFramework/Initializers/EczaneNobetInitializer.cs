using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using System.Data.Entity.Migrations;

namespace WM.Northwind.DataAccess.Concrete.EntityFramework.Initializers
{
    //DropCreateDatabaseIfModelChanges
    public class EczaneNobetInitializer : DropCreateDatabaseIfModelChanges<EczaneNobetContext>
    {
        protected override void Seed(EczaneNobetContext context)
        {
          

        }
    }
}
