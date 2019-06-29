using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WM.Core.Aspects.PostSharp.TranstionAspects;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Areas.EczaneNobet.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [HandleError]
    public class EkranDigitalYonetimController : Controller
    {
        #region ctor
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private ICihazService _cihazService;
        private IEkranIcerikService _ekranIcerikService;
        private IEkranTasarimIcerikService _ekranTasarimIcerikService;
        private IEkranTasarimService _ekranTasarimService;


        public EkranDigitalYonetimController(IUserService userService,
                                        ICihazService cihazService,
                                        IUserRoleService userRoleService,
                                        IYayinEkranService yayinEkranService,
                                      IEkranService ekranService,
                                      IEkranTasarimIcerikService ekranTasarimIcerikService,
                                      IEkranIcerikService ekranIcerikService,
                                      IEkranTasarimService ekranTasarimService
        )
        {
            _userService = userService;
            _cihazService = cihazService;
            _ekranService = ekranService;
            _userRoleService = userRoleService;
            _ekranIcerikService = ekranIcerikService;
            _ekranTasarimIcerikService = ekranTasarimIcerikService;
            _ekranTasarimService = ekranTasarimService;
            _yayinEkranService = yayinEkranService;
        }
        #endregion
        // GET: EczaneNobet/Ekran
        public ActionResult Index(int ekranTasarimId)
        {
            EkranTasarimIcerikDetaylarViewModel EkranTasarimIcerikDetaylarViewModel = new EkranTasarimIcerikDetaylarViewModel();
            try
            {
                return View(getEkranTasarimlarim(ekranTasarimId));
            }
            catch
            {
                return View("Inex", "Ekran");

            }
        }

        [HttpGet]
        public ActionResult GetEkranTasarimlar(int ekranTasarimId)
        {
            EkranTasarimIcerikDetaylarViewModel EkranTasarimIcerikDetaylarViewModel = new EkranTasarimIcerikDetaylarViewModel();
            EkranTasarimIcerikDetaylarViewModel = getEkranTasarimlarim(ekranTasarimId);
            return PartialView("EkranDigitalYonetimPartialView", EkranTasarimIcerikDetaylarViewModel);
        }

        private EkranTasarimIcerikDetaylarViewModel getEkranTasarimlarim(int ekranTasarimId)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();
            var ekranTasarimDetay = _ekranTasarimService.GetDetayById(ekranTasarimId);
            List<UserRoleDetay> userRoleDetay = _userRoleService.GetDetaylarByUserId(user.Id).ToList();

            var ekranIcerikIdler = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimId).Select(s => s.EkranIcerikId).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranIcerikIdler);

            var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimId);
            var model = new EkranTasarimIcerikDetaylarViewModel()
            {
                EkranIcerikDetaylar = ekranIcerikDetaylar,
                UserRoleDetay = userRoleDetay,
                EkranTasarimDetay = ekranTasarimDetay,
                EkranTasarimIcerikDetaylar = ekranTasarimIcerikDetaylar
            };

            return model;
        }
        private int convertToIntFromString(string str)
        {
            int result;
            try
            {
                str = str.Substring(0, str.IndexOf("."));
            }
            catch { }
            result = Convert.ToInt32(str);
            return result;
        }
        [HttpPost]
        [TransactionScopeAspect]
        //[ValidateAntiForgeryToken]
        public ActionResult SetEkranIcerik(string pr_ekranIcerik, string pr_ekranTasarimId)
        {
            //int id = Convert.ToInt32(ekranIcerikId);
            int ekranTasarimId = Convert.ToInt32(pr_ekranTasarimId);
            int ilkVirgul = pr_ekranIcerik.IndexOf(',');
            string ekranIcerikid = pr_ekranIcerik.Substring(1, ilkVirgul - 1);
            var user = _userService.GetByUserName(User.Identity.Name);
            var int_ekranIcerikId = Convert.ToInt32(ekranIcerikid);
            EkranIcerik ekranIcerikTemp = _ekranIcerikService.GetById(Convert.ToInt32(ekranIcerikid));
            var ekranTasarimDetayIdler = _ekranTasarimIcerikService.GetDetaylarListByEkranIcerikId(int_ekranIcerikId).Select(s => s.EkranTasarimId).ToList();

            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;

            EkranDetay ekranDetay = _ekranService.GetDetayById(simdikiEkran.EkranId);
            var ekranTasarimDetaylar = _ekranTasarimService.GetDetaylarById(ekranTasarimDetayIdler).ToList();

            // List<CihazDetay> cihazDetaylar = _cihazService.GetDetaylarListByEkranDetaylar(ekranDetay);

            // foreach (var cihazDetay in cihazDetaylar)
            // {
            var cihazId = ekranDetay.CihazId;
            Cihaz cihaz = _cihazService.GetById(cihazId);
            cihaz.CihazDurumId = 2;//sayfa f5 yapılmalı
            _cihazService.Update(cihaz);
            //}

            var ekranIcerikler = pr_ekranIcerik.Split(';');
            EkranTasarimIcerik ekranTasarimIcerik = new EkranTasarimIcerik();

            foreach (var item in ekranIcerikler)
            {
                var ekranIceriklers = item.Split(',');
                var ekranTasarimIcerikId = 0;
                var ekranIcerikId = 0;
                if (item.Length > 1)
                {//eleman varsa
                    try
                    {
                        if (ekranIceriklers[0].ToString().IndexOf(".") != -1)
                            ekranIcerikId = Convert.ToInt32(ekranIceriklers[0].ToString().Substring(1));
                        else
                            ekranIcerikId = Convert.ToInt32(ekranIceriklers[0].ToString());

                        ekranTasarimIcerikId = _ekranTasarimIcerikService.GetDetaylarListByEkranIcerikIdEkranTasarimId(ekranIcerikId, ekranTasarimId).FirstOrDefault().Id;
                        ekranTasarimIcerik = _ekranTasarimIcerikService.GetById(ekranTasarimIcerikId);
                        ekranTasarimIcerik.BoyutX = convertToIntFromString(ekranIceriklers[3].ToString());
                        ekranTasarimIcerik.BoyutY = convertToIntFromString(ekranIceriklers[4].ToString());
                        ekranTasarimIcerik.KoordinatX = convertToIntFromString(ekranIceriklers[1].ToString());
                        ekranTasarimIcerik.KoordinatY = convertToIntFromString(ekranIceriklers[2].ToString());

                        _ekranTasarimIcerikService.Update(ekranTasarimIcerik);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            foreach (var item in ekranTasarimDetaylar)
            {
                EkranTasarim ekranTasarim = new EkranTasarim();
                ekranTasarim = _ekranTasarimService.GetById(item.Id);
                ekranTasarim.SonDegisiklikTarihi = System.DateTime.Now;
                _ekranTasarimService.Update(ekranTasarim);

            }
            EkranTasarimIcerikDetaylarViewModel ekranTasarimIcerikDetaylarViewModel = new EkranTasarimIcerikDetaylarViewModel();
            ekranTasarimIcerikDetaylarViewModel = getEkranTasarimlarim(ekranTasarimId);
            //return PartialView("EkranDigitalYonetimPartialView", ekranTasarimIcerikDetaylarViewModel);

            return View("Index", ekranTasarimIcerikDetaylarViewModel);
        }
    }
}