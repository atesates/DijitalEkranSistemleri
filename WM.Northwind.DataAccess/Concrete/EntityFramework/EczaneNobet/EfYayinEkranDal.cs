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
    public class EfYayinEkranDal : EfEntityRepositoryBase<YayinEkran, EczaneNobetContext>, IYayinEkranDal
    {
        public YayinEkranDetay GetDetay(Expression<Func<YayinEkranDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.YayinEkranlar
                    .Select(s => new YayinEkranDetay
                    {
                        BaslamaZamani = s.BaslamaZamani,
                        BitisZamani = s.BitisZamani,
                        Boylam = s.Ekran.Konum.Boylam,
                        CihazSeriNu = s.Ekran.Cihaz.SeriNu,
                        CihazDurumAdi = s.Ekran.Cihaz.CihazDurum.Adi,
                        CihaziSonGuncelleyenUserAdi = s.Ekran.Cihaz.User.UserName,
                        CihaziSonGuncelleyenUserId = s.Ekran.Cihaz.SonGuncelleyenUserId,
                        CihazDurumId = s.Ekran.Cihaz.CihazDurumId,
                        CihazId = s.Ekran.CihazId,
                        CihazSonDegisiklikTarihi = s.Ekran.Cihaz.SonGuncellenmeTarihi,
                        EkranTasarimBaslamaTarihi = s.EkranTasarim.BaslamaTarihi,
                        EkranTasarimBitisTarihi = s.EkranTasarim.BitisTarihi,
                        EkranTasarimSonDegisiklikTarihi = s.EkranTasarim.SonDegisiklikTarihi,
                        Enlem = s.Ekran.Konum.Enlem,
                        EkranTasarimAdi = s.EkranTasarim.Adi,
                        EkranId = s.EkranId,
                        EkranUrl = s.Ekran.EkranUrl,
                        EkranTasarimId = s.EkranTasarimId,
                        GrupAdi = s.Ekran.Grup.Adi,
                        GrupId = s.Ekran.Grup.Id,
                        Id = s.Id,
                        KonumAdi = s.Ekran.Konum.Adi,
                        KonumId = s.Ekran.Konum.Id,
                        MonitorAdi = s.Ekran.Monitor.Adi,
                        MonitorId = s.Ekran.Monitor.Id,
                        PingPeriyodu = s.Ekran.Cihaz.PingPeriyodu,

                    }).SingleOrDefault(filter);
            }
        }
        public List<YayinEkranDetay> GetDetayList(Expression<Func<YayinEkranDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.YayinEkranlar
                    .Select(s => new YayinEkranDetay
                    {
                        BaslamaZamani = s.BaslamaZamani,
                        BitisZamani = s.BitisZamani,
                        Boylam = s.Ekran.Konum.Boylam,
                        CihazSeriNu = s.Ekran.Cihaz.SeriNu,
                        CihazDurumAdi = s.Ekran.Cihaz.CihazDurum.Adi,
                        CihaziSonGuncelleyenUserAdi = s.Ekran.Cihaz.User.UserName,
                        CihaziSonGuncelleyenUserId = s.Ekran.Cihaz.SonGuncelleyenUserId,
                        CihazDurumId = s.Ekran.Cihaz.CihazDurumId,
                        CihazId = s.Ekran.CihazId,
                        CihazSonDegisiklikTarihi = s.Ekran.Cihaz.SonGuncellenmeTarihi,
                        EkranTasarimBaslamaTarihi = s.EkranTasarim.BaslamaTarihi,
                        EkranTasarimBitisTarihi = s.EkranTasarim.BitisTarihi,
                        EkranTasarimSonDegisiklikTarihi = s.EkranTasarim.SonDegisiklikTarihi,
                        Enlem = s.Ekran.Konum.Enlem,
                        EkranTasarimAdi = s.EkranTasarim.Adi,
                        EkranId = s.EkranId,
                        EkranUrl = s.Ekran.EkranUrl,
                        EkranTasarimId = s.EkranTasarimId,
                        GrupAdi = s.Ekran.Grup.Adi,
                        GrupId = s.Ekran.Grup.Id,
                        Id = s.Id,
                        KonumAdi = s.Ekran.Konum.Adi,
                        KonumId = s.Ekran.Konum.Id,
                        MonitorAdi = s.Ekran.Monitor.Adi,
                        MonitorId = s.Ekran.Monitor.Id,
                        PingPeriyodu = s.Ekran.Cihaz.PingPeriyodu,                        

                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}