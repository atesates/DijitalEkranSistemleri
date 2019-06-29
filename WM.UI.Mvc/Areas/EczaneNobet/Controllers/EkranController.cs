using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class EkranController : Controller
    {
        #region ctor
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IGrupService _grupService;
        private IEkranIcerikService _ekranIcerikService;
        private IEkranTasarimIcerikService _ekranTasarimIcerikService;
        private IEkranTasarimService _ekranTasarimService;
        private IMonitorService _monitorService;
        private ICihazService _cihazService;
        private ICihazDurumService _cihazDurumService;
        private IKonumService _konumService;


        public EkranController(IUserService userService,
                                      IUserRoleService userRoleService,
                                      IEkranService ekranService,
                                      IEkranIcerikService ekranIcerikService,
                                      IEkranTasarimIcerikService ekranTasarimIcerikService,
                                      IEkranTasarimService ekranTasarimService,
                                      IMonitorService monitorService,
                                      ICihazService cihazService,
                                      ICihazDurumService cihazDurumService,
                                      IKonumService konumService,
                                      IGrupService grupService,
                                      IYayinEkranService yayinEkranService
        )
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _ekranService = ekranService;
            _ekranIcerikService = ekranIcerikService;
            _ekranTasarimService = ekranTasarimService;
            _monitorService = monitorService;
            _cihazService = cihazService;
            _cihazDurumService = cihazDurumService;
            _konumService = konumService;
            _grupService = grupService;
            _ekranTasarimIcerikService = ekranTasarimIcerikService;
            _yayinEkranService = yayinEkranService;
        }
        #endregion
        // GET: EczaneNobet/Ekran
        public ActionResult Index()
        {
            var model = getEkranDetayTasarimDetaylarIcerikDetaylarViewModel();

            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            var CihazDurumlar = _cihazDurumService.GetListByRoleId(rolId);
            ViewBag.CihazDurumId = new SelectList(CihazDurumlar, "Id", "Adi");
            return View(model);
        }
        private List<EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel> getEkranDetayTasarimDetaylarIcerikDetaylarViewModel()
        {
            List<EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel> yayinEkranDetayTasarimDetaylarIcerikDetaylarViewModel = new List<EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel>();

            var user = _userService.GetByUserName(User.Identity.Name);

            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            //var yayinEkranDetaylar = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).ToList();

            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            if(simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            List<UserRoleDetay> userRoleDetay = _userRoleService.GetDetaylarByUserId(user.Id).ToList();
            var ekranIdlerForEkranDetaylar = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).Select(s => s.EkranId).Distinct().ToList();
            var ekranDetaylar = _ekranService.GetDetaylar().Where(w => ekranIdlerForEkranDetaylar.Contains(w.Id)).ToList();
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            if (rolId == 2)
            {
                ekranDetaylar = _ekranService.GetDetaylar();
            }
            foreach (var ekranDetay in ekranDetaylar)
            {
                List<YayinEkranDetayEkranTasarimIcerikDetaylarViewModel> yayinEkranDetayEkranTasarimIcerikDetaylarViewModel = new List<YayinEkranDetayEkranTasarimIcerikDetaylarViewModel>();
                var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranDetay.Id).ToList();
                var ekranIcerikDetays = _ekranIcerikService.GetDetaylarById(ekranTasarimIcerikDetaylar.Select(s => s.EkranIcerikId).ToList()).ToList();
                var yayinEkranDetaylar = _yayinEkranService.GetDetaylarByEkranId(ekranDetay.Id).ToList();

                foreach (var yayinEkranDetay in yayinEkranDetaylar)
                {
                    List<EkranTasarimIcerikDetaylarViewModel> ekranTasarimIcerikDetaylarViewModeller = new List<EkranTasarimIcerikDetaylarViewModel>();
                    var ekranTasarimIdler = _yayinEkranService.GetDetaylarByEkranId(yayinEkranDetay.EkranId).Select(s => s.EkranTasarimId).Distinct().ToList();
                    var ekranTasarimDetaylar = _ekranTasarimService.GetDetaylar().Where(w => ekranTasarimIdler.Contains(w.Id)).ToList();
                    foreach (var ekranTasarimDetay in ekranTasarimDetaylar)
                    {
                        var ekranIcerikIdler = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimDetay.Id).Select(s => s.EkranIcerikId).ToList();
                        var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranIcerikIdler).ToList();

                        ekranTasarimIcerikDetaylarViewModeller.Add(new EkranTasarimIcerikDetaylarViewModel
                        {
                            EkranTasarimDetay = ekranTasarimDetay,
                            EkranIcerikDetaylar = ekranIcerikDetaylar,
                        });
                    }
                    yayinEkranDetayEkranTasarimIcerikDetaylarViewModel.Add(new YayinEkranDetayEkranTasarimIcerikDetaylarViewModel
                    {
                        YayinEkranDetay = yayinEkranDetay,
                        EkranTasarimIcerikDetaylarViewModeller = ekranTasarimIcerikDetaylarViewModeller,
                    });
                }
                yayinEkranDetayTasarimDetaylarIcerikDetaylarViewModel.Add(new EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel
                {
                    EkranDetay = ekranDetay,
                    YayinEkranDetayEkranTasarimIcerikDetaylarViewModeller = yayinEkranDetayEkranTasarimIcerikDetaylarViewModel,
                    UserRoleDetay = userRoleDetay,
                });

            }

            return yayinEkranDetayTasarimDetaylarIcerikDetaylarViewModel;
        }

        private EkranDetayViewModel getEkranDetayViewModel()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();
            List<UserRoleDetay> userRoleDetay = _userRoleService.GetDetaylarByUserId(user.Id).ToList();

            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s=>s.Id).ToList();
            var yayinEkranlar = _yayinEkranService.GetDetaylar();
            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o=>o.BaslamaZamani).FirstOrDefault();
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            var ekranTasarimDataylar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            var ekranTasarimIdler = ekranTasarimDataylar.Where(w => w.Id == aktifEkranTasarimId).Select(s => s.Id).FirstOrDefault();
            int ekranTasarimId = Convert.ToInt32(ekranTasarimIdler);
            var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimId).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranTasarimIcerikDetaylar.Select(s => s.EkranIcerikId).ToList());
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            var cihazDetaylar = _cihazService.GetDetaylarListByEkranDetaylar(ekranDetaylar);
            var konumlar = _konumService.GetDetaylarListByUser(user).ToList();

            if (rolId == 2)
            {
                cihazDetaylar = _cihazService.GetDetaylar();
                ekranDetaylar = _ekranService.GetDetaylar();
                //ekranTasarimDataylar = _ekranTasarimService.GetDetaylar();
                ekranIcerikDetaylar = _ekranIcerikService.GetDetaylar();
                 
            }

            var model = new EkranDetayViewModel()
            {
                CihazDetaylar = cihazDetaylar,
                EkranDetaylar = ekranDetaylar,
                EkranIcerikDetaylar = ekranIcerikDetaylar,
                EkranTasarimDetaylar = ekranTasarimDataylar,
                UserRoleDetaylar = userRoleDetay,
                Konumlar = konumlar,
                YayinEkranDetaylar = yayinEkranlar,
            };
            return model;
        }
        private List<EkranTasarimIcerikDetaylarViewModel> getEkranTasarimlarim(List<EkranTasarimIcerikDetaylarViewModel> EkranTasarimIcerikDetaylarViewModel)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();
            var ekranTasarimlar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            //int aktifEkranTasarimId = ekranDetaylar.Where(w => w.AktifMi == true).Select(s => s.EkranTasarimId).FirstOrDefault();
            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault(); ;
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;

            var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(aktifEkranTasarimId).ToList();
           
            foreach (var item in ekranTasarimlar)
            {
                var ekranTasarimcerikDetays = ekranTasarimIcerikDetaylar.Where(w => w.EkranTasarimId == item.Id).ToList();
                var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranTasarimcerikDetays.Select(s => s.EkranIcerikId).ToList());

                EkranTasarimIcerikDetaylarViewModel.Add(new EkranTasarimIcerikDetaylarViewModel
                {
                    EkranTasarimDetay = item,
                    EkranIcerikDetaylar = ekranIcerikDetaylar

                });
            }
            return EkranTasarimIcerikDetaylarViewModel;

        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult GetEkranTasarimlarim()
        {
            List<EkranTasarimIcerikDetaylarViewModel> EkranTasarimIcerikDetaylarViewModel = new List<EkranTasarimIcerikDetaylarViewModel>();
            EkranTasarimIcerikDetaylarViewModel = getEkranTasarimlarim(EkranTasarimIcerikDetaylarViewModel);
            return PartialView("EkranPartialView", EkranTasarimIcerikDetaylarViewModel);         
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SetEkranEkranTasarim(string ekranId,
                                            string ekranTasarimId)
        {
            int id = Convert.ToInt32(ekranId);
            // int id = EkranTasarimId;

            Ekran ekran = new Ekran();
            ekran = _ekranService.GetById(id);
            //ekran.EkranTasarimId = Convert.ToInt32(ekranTasarimId);
            
            try
            {
                _ekranService.Update(ekran);
                TempData["MessageSuccess"] = "Ekran Tasarımı başarıyla değiştirildi.";
                // return PartialView("TeklifimPartialView", teklifDetayEkranTasarimDetaylarViewModel);
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR: Ekran Tasarımı değiştirilemedi. " + ex.InnerException.InnerException.Message.ToString();
            }
            var model = new EkranDetayViewModel();
            model = getEkranDetayViewModel();
            return View(model);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SetCihazDurum(string ekranId,
                                          string cihazDurumId)
        {
            int id = Convert.ToInt32(ekranId);
            // int id = EkranTasarimId;
            var user = _userService.GetByUserName(User.Identity.Name);

            Ekran ekran = new Ekran();
            ekran = _ekranService.GetById(id);
            Cihaz cihaz = _cihazService.GetById(ekran.CihazId);
            cihaz.CihazDurumId = Convert.ToInt32(cihazDurumId);
            cihaz.SonGuncelleyenUserId = user.Id;
            cihaz.SonGuncellenmeTarihi = System.DateTime.Now;

            try
            {
                _cihazService.Update(cihaz);
                TempData["MessageSuccess"] = "Cihaz Durumu başarıyla değiştirildi.";
                // return PartialView("TeklifimPartialView", teklifDetayEkranTasarimDetaylarViewModel);
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR: Cihaz Durumu  değiştirilemedi. " + ex.InnerException.InnerException.Message.ToString();
            }
            var model = new EkranDetayViewModel();
            model = getEkranDetayViewModel();
            return View(model);
        }
        //[ValidateAntiForgeryToken]
        public ActionResult SetCihazDurumTumunuYenile()
        {
            
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            if (rolId == 2)
            {
                ekranDetaylar = _ekranService.GetDetaylar();
            }
            foreach (var item in ekranDetaylar)
            {
                try
                {
                    Cihaz cihaz = _cihazService.GetById(item.CihazId);
                    cihaz.CihazDurumId = 2;
                    cihaz.SonGuncelleyenUserId = user.Id;
                    cihaz.SonGuncellenmeTarihi = System.DateTime.Now;
                    _cihazService.Update(cihaz);
                    TempData["MessageSuccess"] = "Cihaz Durumu başarıyla değiştirildi.";
                    // return PartialView("TeklifimPartialView", teklifDetayEkranTasarimDetaylarViewModel);
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR: Cihaz Durumu  değiştirilemedi. " + ex.InnerException.InnerException.Message.ToString();
                }
            }
            var model = new EkranDetayViewModel();
            model = getEkranDetayViewModel();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {         
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(id);
            }
            catch
            {
                return RedirectToAction( "Index",  "Ekran");

            }
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekran Ekran = _ekranService.GetById(Id);

            var user = _userService.GetByUserName(User.Identity.Name);
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi", Ekran.GrupId);
            var monitorler = _monitorService.GetList();
            ViewBag.MonitorId = new SelectList(monitorler, "Id", "SeriNu", Ekran.MonitorId);
            var cihazlar = _cihazService.GetList();
            ViewBag.CihazId = new SelectList(cihazlar, "Id", "SeriNu", Ekran.CihazId);
           // var ekranTasarimlar = _ekranTasarimService.GetDetaylarListByUser(user);
           // ViewBag.EkranTasarimId = new SelectList(ekranTasarimlar, "Id", "Adi", Ekran.EkranTasarimId);
            var konumlar = _konumService.GetList();
            ViewBag.KonumId = new SelectList(konumlar, "Id", "Adi" , Ekran.KonumId);

            if (Ekran == null)
            {
                return HttpNotFound();
            }
            return View(Ekran);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MonitorId,KonumId,CihazId,GrupId,BaslamaTarihi,BitisTarihi,Aciklama,AktifMi,EkranUrl")] Ekran Ekran)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ekranService.Update(Ekran);
                    TempData["MessageSuccess"] = "Ekran başarıyla düzenlenmiştir";
                    return RedirectToAction( "Index",  "Ekran");
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
                }
            }
            
            return View(Ekran);
        }
        // GET: AlimNobet/EkranTasarim/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {//bu metod teklif sayfasından çağırılır. teklife alım yapmak için
            var user = _userService.GetByUserName(User.Identity.Name);
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var ekranDetaylar = _ekranService.GetDetaylar();
            var monitorler = _monitorService.GetList().Where(w => !ekranDetaylar.Select(s => s.MonitorId).Contains(w.Id)).ToList(); ;
            ViewBag.MonitorId = new SelectList(monitorler, "Id", "SeriNu");
            var cihazlar = _cihazService.GetList().Where(w =>!ekranDetaylar.Select(s=>s.CihazId).Contains(w.Id)).ToList();
            ViewBag.CihazId = new SelectList(cihazlar, "Id", "SeriNu");
        
            var konumlar = _konumService.GetList();
            ViewBag.KonumId = new SelectList(konumlar, "Id", "Adi");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MonitorId,KonumId,CihazId,GrupId,BaslamaTarihi,BitisTarihi,Aciklama,AktifMi,EkranUrl")] Ekran Ekran)
        {

            Ekran.BaslamaTarihi = DateTime.Now;
            var user = _userService.GetByUserName(User.Identity.Name);
            //Ekran.UserId = user.Id;
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                try
                {
                    _ekranService.Insert(Ekran);
                    TempData["MessageSuccess"] = "Ekran Tasarımı başarıyla değiştirilmiştir.";
                    return RedirectToAction( "Index",  "Ekran");
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
                }
            }
            else
            {
                var errorText = "";
                foreach (var item in errors)
                {
                    errorText = errorText + " " + item;
                }
                TempData["MessageDanger"] = "ERROR: Modelstate is invalid, " + errorText.ToString();

            }
            var users = _userService.GetList();
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var monitorler = _monitorService.GetList();
            ViewBag.MonitorId = new SelectList(monitorler, "Id", "SeriNu");
            var cihazlar = _cihazService.GetList();
            ViewBag.CihazId = new SelectList(cihazlar, "Id", "SeriNu");
          
            var konumlar = _konumService.GetList();
            ViewBag.KonumId = new SelectList(konumlar, "Id", "Aciklama");

            return View(Ekran);
        }
        // GET: EczaneNobet/Eczane/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekran ekran = _ekranService.GetById(id);
            if (ekran == null)
            {
                return HttpNotFound();
            }
            return View(ekran);
        }
        // POST: EczaneNobet/Eczane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Ekran ekran = _ekranService.GetById(id);
                _ekranService.Delete(id);
                TempData["MessageSuccess"] = "Ekran Tasarımı başarıyla silinmiştir.";
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
            }
            return RedirectToAction( "Index",  "Ekran");
        }
        // GET: EczaneNobet/Cihaz/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ekran = _ekranService.GetDetayById(id);
            if (ekran == null)
            {
                return HttpNotFound();
            }
            return View(ekran);
        }
    }
}