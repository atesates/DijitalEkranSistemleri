using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WM.Core.DAL.EntityFramework;
using WM.Northwind.DataAccess.Abstract.EczaneNobet;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.DataAccess.Concrete.EntityFramework.EczaneNobet
{
    public class EfGrupUserDal : EfEntityRepositoryBase<GrupUser, EczaneNobetContext>, IGrupUserDal
    {
        public GrupUserDetay GetDetay(Expression<Func<GrupUserDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.GrupUserlar
                    .Select(s => new GrupUserDetay
                    {
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi,
                        UserId = s.UserId,
                        UserAdi = s.User.UserName,
                        
                    }).SingleOrDefault(filter);
            }
        }
        public List<GrupUserDetay> GetDetayList(Expression<Func<GrupUserDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.GrupUserlar
                    .Select(s => new GrupUserDetay
                    {
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi,
                        UserId = s.UserId,
                        UserAdi = s.User.UserName,

                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}