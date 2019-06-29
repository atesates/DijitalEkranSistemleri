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
    public class EfYayinEkranIcerikDal : EfEntityRepositoryBase<YayinEkranIcerik, EczaneNobetContext>, IYayinEkranIcerikDal
    {
        public YayinEkranIcerikDetay GetDetay(Expression<Func<YayinEkranIcerikDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.YayinEkranIcerikler
                    .Select(s => new YayinEkranIcerikDetay
                    {
                        Alan = s.Alan,
                        BaslamaZamani = s.BaslamaZamani,
                        BitisZamani = s.BitisZamani,
                        EkranIcerikId = s.EkranIcerikId,
                        EkranIcerikAdi = s.EkranIcerik.Adi,
                        Id = s.Id,
                        YayinEkranId = s.YayinEkranId,

                    }).SingleOrDefault(filter);
            }
        }
        public List<YayinEkranIcerikDetay> GetDetayList(Expression<Func<YayinEkranIcerikDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.YayinEkranIcerikler
                    .Select(s => new YayinEkranIcerikDetay
                    {
                        Alan = s.Alan,
                        BaslamaZamani = s.BaslamaZamani,
                        BitisZamani = s.BitisZamani,
                        EkranIcerikAdi = s.EkranIcerik.Adi,
                        EkranIcerikId = s.EkranIcerikId,
                        Id = s.Id,
                        YayinEkranId = s.YayinEkranId,

                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}