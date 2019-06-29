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
    public class EfMonitorDal : EfEntityRepositoryBase<Monitor, EczaneNobetContext>, IMonitorDal
    {
        public MonitorDetay GetDetay(Expression<Func<MonitorDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.Monitorler
                    .Select(s => new MonitorDetay
                    {
                        Aciklama = s.Aciklama,
                        AlimTarihi = s.AlimTarihi,
                        Adi = s.Adi,
                        BoyutuInc = s.BoyutuInc,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        CozunurlukAdi = s.Cozunurluk.Adi,
                        CozunurlukId = s.CozunurlukId,
                        Id = s.Id,
                        Marka = s.Marka,
                        SeriNu = s.SeriNu,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi

                    }).SingleOrDefault(filter);
            }
        }
        public List<MonitorDetay> GetDetayList(Expression<Func<MonitorDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.Monitorler
                    .Select(s => new MonitorDetay
                    {
                        Aciklama = s.Aciklama,
                        AlimTarihi = s.AlimTarihi,
                        Adi = s.Adi,
                        BoyutuInc = s.BoyutuInc,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        CozunurlukAdi = s.Cozunurluk.Adi,
                        CozunurlukId = s.CozunurlukId,
                        Id = s.Id,
                        Marka = s.Marka,
                        SeriNu = s.SeriNu,
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