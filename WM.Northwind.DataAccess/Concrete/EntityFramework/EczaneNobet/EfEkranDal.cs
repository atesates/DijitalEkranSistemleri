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
    public class EfEkranDal : EfEntityRepositoryBase<Ekran, EczaneNobetContext>, IEkranDal
    {
        public EkranDetay GetDetay(Expression<Func<EkranDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.Ekranlar
                    .Select(s => new EkranDetay
                    {
                        AktifMi = s.AktifMi,
                        Aciklama = s.Aciklama,
                        EkranUrl = s.EkranUrl,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        Boylam = s.Konum.Boylam,
                        CihazId = s.CihazId,
                        CihazDurumId = s.Cihaz.CihazDurumId,
                        CihazDurumAdi = s.Cihaz.CihazDurum.Adi,
                        CihazSeriNu = s.Cihaz.SeriNu,
                        CihazSonDegisiklikTarihi = s.Cihaz.SonGuncellenmeTarihi,
                       // EkranTasarimBaslamaTarihi = s.EkranTasarim.BaslamaTarihi,
                       // EkranTasarimBitisTarihi = s.EkranTasarim.BitisTarihi,
                      //  EkranTasarimSonDegisiklikTarihi = s.EkranTasarim.SonDegisiklikTarihi,
                        //EkranTasarimAdi = s.EkranTasarim.Adi,
                        Enlem = s.Konum.Enlem,
                        Id = s.Id,
                        KonumId = s.KonumId,
                        KonumAdi = s.Konum.Adi,
                        MonitorSeriNu = s.Monitor.SeriNu,
                        MonitorId = s.MonitorId,
                        MonitorAdi = s.Monitor.Adi,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi,
                        CihaziSonGuncelleyenUserId = s.Cihaz.SonGuncelleyenUserId,
                        PingPeriyodu = s.Cihaz.PingPeriyodu,


                    }).SingleOrDefault(filter);
            }
        }
        public List<EkranDetay> GetDetayList(Expression<Func<EkranDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.Ekranlar
                    .Select(s => new EkranDetay
                    {
                        AktifMi = s.AktifMi,
                        Aciklama = s.Aciklama,
                        EkranUrl = s.EkranUrl,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        Boylam = s.Konum.Boylam,
                        CihazId = s.CihazId,
                        CihazDurumId = s.Cihaz.CihazDurumId,
                        CihazDurumAdi = s.Cihaz.CihazDurum.Adi,
                        CihazSeriNu = s.Cihaz.SeriNu,
                        CihazSonDegisiklikTarihi = s.Cihaz.SonGuncellenmeTarihi,
                       // EkranTasarimBaslamaTarihi = s.EkranTasarim.BaslamaTarihi,
                       // EkranTasarimBitisTarihi = s.EkranTasarim.BitisTarihi,
                       // EkranTasarimSonDegisiklikTarihi = s.EkranTasarim.SonDegisiklikTarihi,
                       // EkranTasarimAdi = s.EkranTasarim.Adi,
                        Enlem = s.Konum.Enlem,
                        Id = s.Id,
                        KonumId = s.KonumId,
                        KonumAdi = s.Konum.Adi,
                        MonitorSeriNu = s.Monitor.SeriNu,
                        MonitorId = s.MonitorId,
                        MonitorAdi = s.Monitor.Adi,
                        GrupId = s.GrupId,
                        GrupAdi = s.Grup.Adi,
                        CihaziSonGuncelleyenUserId = s.Cihaz.SonGuncelleyenUserId,
                        PingPeriyodu = s.Cihaz.PingPeriyodu
                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}