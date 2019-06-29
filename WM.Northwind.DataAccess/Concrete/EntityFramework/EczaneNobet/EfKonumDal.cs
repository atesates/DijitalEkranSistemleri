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
    public class EfKonumDal : EfEntityRepositoryBase<Konum, EczaneNobetContext>, IKonumDal
    {
        public KonumDetay GetDetay(Expression<Func<KonumDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.Konumlar
                    .Select(s => new KonumDetay
                    {
                        Aciklama = s.Aciklama,
                        Adi = s.Adi,
                        Id = s.Id,
                        Enlem = s.Enlem,
                        Boylam = s.Boylam,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi


                    }).SingleOrDefault(filter);
            }
        }
        public List<KonumDetay> GetDetayList(Expression<Func<KonumDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.Konumlar
                    .Select(s => new KonumDetay
                    {
                        Aciklama = s.Aciklama,
                        Id = s.Id,
                        Adi = s.Adi,
                        Enlem = s.Enlem,
                        Boylam = s.Boylam,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi

                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}