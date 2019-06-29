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
    public class EfCihazDal : EfEntityRepositoryBase<Cihaz, EczaneNobetContext>, ICihazDal
    {
        public CihazDetay GetDetay(Expression<Func<CihazDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.Cihazlar
                    .Select(s => new CihazDetay
                    {                      
                        Aciklama = s.Aciklama,
                        AlimTarihi = s.AlimTarihi,
                        ApiUrl = s.ApiUrl,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        CozunurlukAdi = s.Cozunurluk.Adi,
                        CozunurlukId = s.CozunurlukId,
                        CihazDurumAciklama = s.CihazDurum.Aciklama,
                        CihazDurumAdi = s.CihazDurum.Adi,
                        CihazDurumId = s.CihazDurumId,
                        Id = s.Id,
                        Marka = s.Marka,
                        Model = s.Model,
                        SeriNu = s.SeriNu,
                        PingPeriyodu = s.PingPeriyodu,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi,
                        SonGuncellenmeTarihi = s.SonGuncellenmeTarihi,
                        SonGuncelleyenUserId = s.SonGuncelleyenUserId,
                        SonGuncelleyenUserAdi = s.User.UserName,
                        WiFiKullaniciAdi = s.WiFiKullaniciAdi,
                        WiFiParola = s.WiFiParola

                    }).SingleOrDefault(filter);
            }
        }
        public List<CihazDetay> GetDetayList(Expression<Func<CihazDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.Cihazlar
                    .Select(s => new CihazDetay
                    {
                        Aciklama = s.Aciklama,
                        AlimTarihi = s.AlimTarihi,
                        ApiUrl = s.ApiUrl,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        CozunurlukAdi = s.Cozunurluk.Adi,
                        CihazDurumAdi = s.CihazDurum.Adi,
                        CihazDurumAciklama = s.CihazDurum.Aciklama,
                        CihazDurumId = s.CihazDurumId,
                        CozunurlukId = s.CozunurlukId,               
                        Id = s.Id,
                        Marka = s.Marka,
                        Model = s.Model,
                        PingPeriyodu = s.PingPeriyodu,
                        SeriNu = s.SeriNu,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi,
                        SonGuncelleyenUserId = s.SonGuncelleyenUserId,
                        SonGuncelleyenUserAdi = s.User.UserName,
                        SonGuncellenmeTarihi = s.SonGuncellenmeTarihi,
                        WiFiKullaniciAdi = s.WiFiKullaniciAdi,
                        WiFiParola = s.WiFiParola
                        
                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}