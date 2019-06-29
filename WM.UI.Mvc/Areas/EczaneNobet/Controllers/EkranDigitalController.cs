using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Areas.EczaneNobet.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [HandleError]
    public class EkranDigitalController : Controller
    {
        #region ctor
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IYayinEkranIcerikService _yayinEkranIcerikService;
        private IEkranIcerikService _ekranIcerikService;
        private IEkranTasarimService _ekranTasarimService;
        private IEkranTasarimIcerikService _ekranTasarimIcerikService;


        public EkranDigitalController(IUserService userService,
                                      IEkranService ekranService,
                                      IUserRoleService userRoleService,
                                      IYayinEkranService yayinEkranService,
                                      IEkranIcerikService ekranIcerikService,
                                      IEkranTasarimService ekranTasarimService,
                                      IYayinEkranIcerikService yayinEkranIcerikService,
                                      IEkranTasarimIcerikService ekranTasarimIcerikService
        )
        {
            _userService = userService;
            _ekranService = ekranService;
            _ekranIcerikService = ekranIcerikService;
            _ekranTasarimService = ekranTasarimService;
            _userRoleService = userRoleService;
            _ekranTasarimIcerikService = ekranTasarimIcerikService;
            _yayinEkranService = yayinEkranService;
            _yayinEkranIcerikService = yayinEkranIcerikService;
        }
        #endregion
        // GET: EczaneNobet/Ekran
        public ActionResult Index()
        {
            int cihazId = 0;
            int ekranId = 0;
            try
            {
                cihazId = Convert.ToInt32(RouteData.Values["cihazId"].ToString());
                ekranId = _ekranService.GetDetayByCihazId(cihazId).Id;
                var simdikiEkran = _yayinEkranService.GetDetayByIdByDate(ekranId, DateTime.Now);
                List<int> ekranIdler = new List<int>();
                ekranIdler.Add(ekranId);
                if (simdikiEkran == null)
                {
                    simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
                }
                int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;


                EkranTasarimIcerikDetaylarViewModel EkranTasarimIcerikDetaylarViewModel = new EkranTasarimIcerikDetaylarViewModel();
                return View(getEkranTasarimlarim(ekranId));
            }
            catch
            {
                return View("~/Views/Home/HataEkrani.cshtml");
            }

        }

        //[HttpGet]
        //private ActionResult GetEkranTasarimlarim(int ekranTasarimId)
        //{
        //    return View(getEkranTasarimlarim(ekranTasarimId));
        //}

        public EkranTasarimIcerikDetaylarViewModel getEkranTasarimlarim(int ekranId)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetay = _ekranService.GetDetayById(ekranId);
            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            var simdikiEkran = _yayinEkranService.GetDetayByIdByDate(ekranId, DateTime.Now);
            if(simdikiEkran == null)
            {
                //en son görünen devam edecek şekilde ekran getirilecek
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranId(ekranId).Where(w => w.BaslamaZamani < DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
                
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            var ekranTasarimDetay = _ekranTasarimService.GetDetayById(aktifEkranTasarimId);
            var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimDetay.Id).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranTasarimIcerikDetaylar.Select(s => s.EkranIcerikId).ToList()).ToList();
            var yayinEkranDetaylar = _yayinEkranService.GetDetaylarByEkranId(ekranId);

            var model = new EkranTasarimIcerikDetaylarViewModel()
            {
                EkranDetay = ekranDetay,
                EkranIcerikDetaylar = ekranIcerikDetaylar,
                EkranTasarimDetay = ekranTasarimDetay,
                EkranTasarimIcerikDetaylar = ekranTasarimIcerikDetaylar,
                TasarimBaslamaZamani = simdikiEkran.BaslamaZamani,
                TasarimBitisZamani = simdikiEkran.BitisZamani,
                YayinEkranDetaylar = yayinEkranDetaylar,
                //UserRoleDetay = userRoleDetay,
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
        //[ValidateAntiForgeryToken]
        public ActionResult SetYayinEkranIcerik(string pr_ekranIcerik, string pr_ekranId, string pr_ekranTasarimId)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranId = Convert.ToInt32(pr_ekranId);
            var ekranTasarimId = Convert.ToInt32(pr_ekranTasarimId);
            var yayinEkranId = _yayinEkranService.GetDetaylarByEkranIdByEkranTasarimId(ekranId, ekranTasarimId).OrderByDescending(o => o.BaslamaZamani).FirstOrDefault().Id;
            //DateTime baslamaZamani = Convert.ToDateTime(pr_baslamaZamani);
            // int id = EkranTasarimId;

            YayinEkranIcerik yayinEkranIcerik = new YayinEkranIcerik();

            var ekranIcerikler = pr_ekranIcerik.Split(';');

            foreach (var item in ekranIcerikler)
            {
                var ekranIceriklers = item.Split(',');
                var yayinEkranIcerikId = 0;
                var ekranIcerikId = 0;
                if (item.Length > 1)
                {//eleman varsa
                    try
                    {
                        if (ekranIceriklers[0].ToString().IndexOf(".") != -1)
                            ekranIcerikId = Convert.ToInt32(ekranIceriklers[0].ToString().Substring(1));
                        else
                            ekranIcerikId = Convert.ToInt32(ekranIceriklers[0].ToString());

                        var yayinEkranIcerikList = _yayinEkranIcerikService.GetDetaylarByEkranIdByEkranIcerikId(yayinEkranId, ekranIcerikId);

                        yayinEkranIcerikId = yayinEkranIcerikList.LastOrDefault().Id;
                        yayinEkranIcerik = _yayinEkranIcerikService.GetById(yayinEkranIcerikId);
                        yayinEkranIcerik.Alan = Convert.ToInt32(ekranIceriklers[1]) * Convert.ToInt32(ekranIceriklers[2]);
                        yayinEkranIcerik.BitisZamani = DateTime.Now;
                        _yayinEkranIcerikService.Update(yayinEkranIcerik);

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            var model = new List<EkranIcerikTasarimDetaylarViewModel>();
            return View("Index", getEkranTasarimlarim(Convert.ToInt32(pr_ekranId)));
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SetYayinEkranIcerikInsert(string pr_ekranIcerik,  string pr_ekranId, string pr_ekranTasarimId)
        {

            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranId = Convert.ToInt32(pr_ekranId);
            var ekranTasarimId = Convert.ToInt32(pr_ekranTasarimId);
            var yayinEkranId = _yayinEkranService.GetDetaylarByEkranIdByEkranTasarimId(ekranId, ekranTasarimId).OrderByDescending(o => o.BaslamaZamani).FirstOrDefault().Id;
            //DateTime baslamaZamani = Convert.ToDateTime(pr_baslamaZamani);
            // int id = EkranTasarimId;

            YayinEkranIcerik yayinEkranIcerik = new YayinEkranIcerik();

            var ekranIcerikler = pr_ekranIcerik.Split(';');
            foreach (var item in ekranIcerikler)
            {
                var ekranIceriklers = item.Split(',');
                var ekranIcerikId = 0;
                if (item.Length > 1)
                {//eleman varsa
                    try
                    {
                        if (ekranIceriklers[0].ToString().IndexOf(".") != -1)
                            ekranIcerikId = Convert.ToInt32(ekranIceriklers[0].ToString().Substring(1));
                        else
                            ekranIcerikId = Convert.ToInt32(ekranIceriklers[0].ToString());

                        yayinEkranIcerik.Alan = yayinEkranIcerik.Alan = Convert.ToInt32(ekranIceriklers[1]) * Convert.ToInt32(ekranIceriklers[2]);
                        yayinEkranIcerik.BaslamaZamani = DateTime.Now;
                        yayinEkranIcerik.EkranIcerikId = ekranIcerikId;
                        yayinEkranIcerik.YayinEkranId = yayinEkranId;
                        _yayinEkranIcerikService.Insert(yayinEkranIcerik);

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            var model = new List<EkranIcerikTasarimDetaylarViewModel>();
            return View("Index", getEkranTasarimlarim(Convert.ToInt32(pr_ekranId)));
        }

    }
}