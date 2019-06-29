using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.EczaneNobet.WebApi.Controllers
{
    public class EkranTakipController : ApiController
    {
        #region ctor
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IEkranTasarimService _ekranTasarimService;
        private ICihazService _cihazService;
        private IUserRoleService _userRoleService;

        public EkranTakipController(IEkranService ekranService,
                                    IEkranTasarimService ekranTasarimService,
                                    ICihazService cihazService,
                                    IYayinEkranService yayinEkranService,
                                    IUserRoleService userRoleService

            )
        {
            _ekranService = ekranService;
            _cihazService = cihazService;
            _ekranTasarimService = ekranTasarimService;
            _userRoleService = userRoleService;
            _yayinEkranService = yayinEkranService;
        }
        #endregion

        public EkranTakipDetay Ekran(int cihazId)
        {
            CihazDetay cihazDetay = _cihazService.GetDetayById(cihazId);
            EkranDetay ekranDetay = _ekranService.GetDetayByCihazId(cihazDetay.Id);
            Ekran ekran = _ekranService.GetById(ekranDetay.Id);
            EkranTakipDetay ekranTakipDetay = new EkranTakipDetay();

            var simdikiEkran = _yayinEkranService.GetDetayByIdByDate(ekran.Id, DateTime.Now);

            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            EkranTasarimDetay ekranTasarimDetay = _ekranTasarimService.GetDetayById(aktifEkranTasarimId);
            EkranTasarim ekranTasarim = _ekranTasarimService.GetById(ekranTasarimDetay.Id);
            ekranTakipDetay.SonDegisiklilkTarihi = ekranTasarim.SonDegisiklikTarihi;
            ekranTakipDetay.CihazDurumId = cihazDetay.CihazDurumId;
            ekranTakipDetay.CihazDurumAdi = cihazDetay.CihazDurumAdi;
            ekranTakipDetay.CihazId = cihazId;
            ekranTakipDetay.CihazUrl = ekran.EkranUrl;
            ekranTakipDetay.DomainUrl = cihazDetay.ApiUrl;
            ekranTakipDetay.PingPeriyodu = cihazDetay.PingPeriyodu;
            ekranTakipDetay.WifiKullaniciAdi = cihazDetay.WiFiKullaniciAdi;
            ekranTakipDetay.WifiParola = cihazDetay.WiFiParola;
            ekranTakipDetay.CihazDurumAciklama = cihazDetay.CihazDurumAciklama;

            return ekranTakipDetay;
        }

        [Route("ekranlar/{cihazId:int:min(1)}")]
        [HttpGet]
        public EkranTakipDetay Get(int cihazId)
        {
            return Ekran(cihazId);
        }


        [Route("cihaz-durum-guncelle/{cihazId:int:min(1)}/{cihazDurumId:int:min(0)}")]
        [HttpPost]
        public void CihazDurumGuncelle(int cihazId, int cihazDurumId)
        {
            Cihaz cihaz = _cihazService.GetById(cihazId);
            cihaz.CihazDurumId = cihazDurumId;
            cihaz.SonGuncellenmeTarihi = System.DateTime.Now;
            cihaz.SonGuncelleyenUserId = 1;//cihaz güncelledi demek
            _cihazService.Update(cihaz);

        }
    }


}
