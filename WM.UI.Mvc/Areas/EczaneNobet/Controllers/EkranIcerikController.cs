using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
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
    public class EkranIcerikController : Controller
    {
        #region ctor
        private IUserService _userService;
        private IGrupUserService _grupUserService;
        private ICihazService _cihazService;
        private IUserRoleService _userRoleService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IEkranIcerikService _ekranIcerikService;
        private IEkranTasarimIcerikService _ekranTasarimIcerikService;
        private IEkranTasarimService _ekranTasarimService;
        private IKonumService _konumService;


        public EkranIcerikController(IUserService userService,
                                     IUserRoleService userRoleService,
                                      ICihazService cihazService,
                                      IGrupUserService grupUserService,
                                      IEkranService ekranService,
                                      IYayinEkranService yayinEkranService,
                                      IEkranIcerikService ekranIcerikService,
                                      IEkranTasarimService ekranTasarimService,
                                      IEkranTasarimIcerikService ekranTasarimIcerikService,
                                      IKonumService konumService
        )
        {
            _userService = userService;
            _ekranService = ekranService;
            _userRoleService = userRoleService;
            _cihazService = cihazService;
            _ekranIcerikService = ekranIcerikService;
            _ekranTasarimService = ekranTasarimService;
            _konumService = konumService;
            _grupUserService = grupUserService;
            _ekranTasarimIcerikService = ekranTasarimIcerikService;
            _yayinEkranService = yayinEkranService;
        }
        #endregion
        public ActionResult Index()
        {
            // var model = new EkranDetayViewModel();
            var model2 = new List<EkranIcerikTasarimDetaylarViewModel>();
            model2 = getEkranIceriklerim();
            //model = getEkranlarim();
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranTasarimlar = _ekranTasarimService.GetDetaylarListByUser(user);
            ViewBag.EkranTasarimId = new SelectList(ekranTasarimlar, "Id", "Adi");
            return View(model2);
        }
        public EkranDetayViewModel getEkranlarim()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();
            var ekranTasarimlar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();

            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault(); ;
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            var ekranTasarimDataylar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            var ekranTasarimIdler = ekranTasarimDataylar.Where(w => w.Id == aktifEkranTasarimId).Select(s => s.Id).FirstOrDefault();
            int ekranTasarimId = Convert.ToInt32(ekranTasarimIdler);
            var ekranIcerikIdler = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimId).Select(s=>s.EkranIcerikId).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranIcerikIdler);

            var model = new EkranDetayViewModel()
            {
                EkranDetaylar = ekranDetaylar,
                EkranIcerikDetaylar = ekranIcerikDetaylar,
                EkranTasarimDetaylar = ekranTasarimDataylar,
            };
            return model;
        }

        [HttpGet]
        private ActionResult GetEkranIceriklerim()
        {
            List<EkranIcerikTasarimDetaylarViewModel> ekranIcerikTasarimDetaylarViewModel = new List<EkranIcerikTasarimDetaylarViewModel>();
            ekranIcerikTasarimDetaylarViewModel = getEkranIceriklerim();
            return PartialView("EkranIcerikPartialView", ekranIcerikTasarimDetaylarViewModel);
        }

        public List<EkranIcerikTasarimDetaylarViewModel> getEkranIceriklerim()
        {
            List<EkranIcerikTasarimDetaylarViewModel> ekranIcerikTasarimDetaylarViewModel = new List<EkranIcerikTasarimDetaylarViewModel>();
            var user = _userService.GetByUserName(User.Identity.Name);
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarListByUser(user).ToList();
            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault(); ;
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            List<UserRoleDetay> userRoleDetay = _userRoleService.GetDetaylarByUserId(user.Id).ToList();
            if (rolId == 2)
            {
                ekranDetaylar = _ekranService.GetDetaylar();
                ekranIcerikDetaylar = _ekranIcerikService.GetDetaylar();
            }


            foreach (var ekranIcerikDetay in ekranIcerikDetaylar)
            {
                //var ekranIcerikDetays = ekranIcerikDetaylar.Where(w => w.EkranTasarimId == ekranTasarimDetay.Id).ToList();
                //var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimDetay.Id).ToList();

                var ekranIcerikTasarimDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranIcerikId(ekranIcerikDetay.Id);
                var ekraTasarimIdler = ekranIcerikTasarimDetaylar.Select(s => s.EkranTasarimId).ToList();
                var ekranTasarimDetays = _ekranTasarimService.GetDetaylarById(ekraTasarimIdler);

                ekranIcerikTasarimDetaylarViewModel.Add(new EkranIcerikTasarimDetaylarViewModel
                {

                    EkranIcerikDetay = ekranIcerikDetay,
                    EkranTasarimDetaylar = ekranTasarimDetays,
                    UserRoleDetay = userRoleDetay,
                    EkranTasarimIcerikDetaylar = ekranIcerikTasarimDetaylar

                });

            }


            return ekranIcerikTasarimDetaylarViewModel;
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SetEkranEkranTasarim(string ekranIcerikId,
                                           string ekranTasarimId)
        {
            int int_ekranIcerikId = Convert.ToInt32(ekranIcerikId);
            int int_ekranTasarimId = Convert.ToInt32(ekranTasarimId);
            // int id = EkranTasarimId;

            EkranTasarimIcerik ekranTasarimIcerik = new EkranTasarimIcerik();
            ekranTasarimIcerik.EkranIcerikId = int_ekranIcerikId;
            ekranTasarimIcerik.EkranTasarimId = int_ekranTasarimId;

            try
            {
                _ekranTasarimIcerikService.Insert(ekranTasarimIcerik);
                TempData["MessageSuccess"] = "Ekran İçerik Ekran Tasarıma başarıyla eklendi.";
                // return PartialView("TeklifimPartialView", teklifDetayEkranTasarimDetaylarViewModel);
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR: Ekran Tasarımı değiştirilemedi. " + ex.InnerException.InnerException.Message.ToString();
            }
            var model = new List<EkranIcerikTasarimDetaylarViewModel>();
            model = getEkranIceriklerim();
            return View(model);
        }

        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Edit(int? id)
        {
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(id);
            }
            catch
            {
                return RedirectToAction("Index", "EkranIcerik");

            }
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkranIcerik EkranIcerik = _ekranIcerikService.GetById(Id);

            if (EkranIcerik == null)
            {
                return HttpNotFound();
            }
            return View(EkranIcerik);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,GrupId,Uzanti,Agirlik,BoyutX,BoyutY,Url,EkranTasarimId,KoordinatX,KoordinatY")] EkranIcerik EkranIcerik)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ekranIcerikService.Update(EkranIcerik);
                    TempData["MessageSuccess"] = "Ekran içeriği başarıyla düzenlenmiştir";
                    return RedirectToAction("Index", "EkranIcerik");
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
                }
            }
            
            return View(EkranIcerik);
        }
        // GET: AlimNobet/EkranIcerik/Create
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Create(HttpPostedFileBase file, int? ekranTasarimId)
        {//bu metod teklif sayfasından çağırılır. teklife alım yapmak için
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(ekranTasarimId);
            }
            catch
            {
                return RedirectToAction("Index", "EkranTasarim");

            }
            EkranIcerik EkranIcerik = new EkranIcerik();
            //EkranIcerik.EkranTasarimId = Id;
            //ViewBag.EkranTasarimId = ekranTasarimId;
            return View(EkranIcerik);
        }
        [HttpPost]
        [TransactionScopeAspect]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EkranIcerik EkranIcerik)
        {
            if (ModelState.IsValid)
            {
                EkranTasarimIcerik ekranTasarimIcerik = new EkranTasarimIcerik();
                try
                {
                    if (EkranIcerik.Uzanti == "png" || EkranIcerik.Uzanti == "jpg" || EkranIcerik.Uzanti == "jpeg")
                        EkranIcerik.Url = " ";
                    //http://www.youtube.com/embed/GRonxog5mbw?autoplay=1&loop=1&playlist=GRonxog5mbw
                    //https://www.youtube.com/embed/jbNPeYrGhi0 ?autoplay=1&loop=1&playlist=GRonxog5mbw
                    //https://www.youtube.com/watch?v=jbNPeYrGhi0
                    //EkranIcerik.BoyutX = 50;
                    //EkranIcerik.BoyutY = 50;
                    var user = _userService.GetByUserName(User.Identity.Name);
                    var grupId = _grupUserService.GetDetaylarListByUser(user).Select(s=>s.GrupId).FirstOrDefault();
                    EkranIcerik.GrupId = grupId;
                    
                    _ekranIcerikService.Insert(EkranIcerik);
                    //ekranTasarimIcerik.EkranTasarimId = ViewBag.EkranTasarimId;
                    //ekranTasarimIcerik.BoyutX = 1;
                    //ekranTasarimIcerik.BoyutY = 1;
                    //ekranTasarimIcerik.KoordinatX = 1;
                    //ekranTasarimIcerik.KoordinatY = 1;

                    //var ekranIcerik = _ekranIcerikService.GetList().OrderByDescending(w => w.Id).Select(s=>s.Id).FirstOrDefault();
                    //ekranTasarimIcerik.EkranIcerikId = ekranIcerik;
                  
                    //_ekranTasarimIcerikService.Insert(ekranTasarimIcerik);
                    TempData["MessageSuccess"] = "Ekran içeriği başarıyla değiştirilmiştir.";
                    return RedirectToAction("Index", "EkranIcerik");

                }
                catch (Exception ex)
                {
                    TempData["Message"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
                }
            }
            return View(EkranIcerik);
        }
        // GET: EczaneNobet/Eczane/Delete/5
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkranIcerik ekranIcerik = _ekranIcerikService.GetById(id);
            if (ekranIcerik == null)
            {
                return HttpNotFound(); 
            }
            return View(ekranIcerik);
        }
        // POST: EczaneNobet/Eczane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            { 
                EkranIcerik ekranIcerik = _ekranIcerikService.GetById(id);
                _ekranIcerikService.Delete(id);
                TempData["MessageSuccess"] = "Ekran iceriği başarıyla silinmiştir.";
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
            }
            return RedirectToAction("Index", "EkranIcerik");
        }
        public ActionResult ResimEdit(int Id)
        {
            EkranIcerik EkranIcerik = _ekranIcerikService.GetById(Id);
            return View(EkranIcerik);
        }
        [HttpPost]
        public ActionResult ResimEdit(HttpPostedFileBase file, int EkranIcerikid)
        {
         
            EkranIcerik ekranIcerikTemp = _ekranIcerikService.GetById(EkranIcerikid);
            var ekranTasarimIdler = _ekranTasarimIcerikService.GetDetaylarListByEkranIcerikId(EkranIcerikid).Select(s=>s.EkranTasarimId).ToList();
            // EkranTasarim ekranTasarim = _ekranTasarimService.GetById(ekranIcerikTemp.EkranTasarimId);
            var user = _userService.GetByUserName(User.Identity.Name);

            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault(); ;
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            // ekranTasarim.SonDegisiklikTarihi = System.DateTime.Now;

            EkranDetay ekranDetay = _ekranService.GetDetayById(simdikiEkran.EkranId);

            var cihazId = ekranDetay.CihazId;
            Cihaz cihaz = _cihazService.GetById(cihazId);
            cihaz.CihazDurumId = 3;//sayfa kapatılıp açılmalı
            _cihazService.Update(cihaz);
           
            EkranIcerik EkranIcerik = _ekranIcerikService.GetById(EkranIcerikid);
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/images/EkranIcerik/"),
                                               Path.GetFileName(EkranIcerikid.ToString()));
                    WebImage img = new WebImage(file.InputStream);

                    img.Save(path);
                    EkranIcerik.Url = "~/Content/images/EkranIcerik/" + EkranIcerikid.ToString();
                    _ekranIcerikService.Update(EkranIcerik);

                    TempData["MessageSuccess"] = "Dosya başarıyla yüklendi.";
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "HATA:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Dosya seçmediniz.";
            }
            return RedirectToAction("Index", "EkranIcerik");
        }
        public ActionResult ResimCreate(int Id)
        {
            EkranIcerik EkranIcerik = _ekranIcerikService.GetById(Id);
            return View("ResimEdit", EkranIcerik);
        }
        [HttpPost]
        public ActionResult ResimCreate(HttpPostedFileBase file, EkranIcerik Model)
        {
            int ekranIcerikid = Model.Id;
            EkranIcerik EkranIcerik = _ekranIcerikService.GetById(ekranIcerikid);
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/images/EkranIcerik/"),
                                               Path.GetFileName(ekranIcerikid.ToString()));
                    WebImage img = new WebImage(file.InputStream);

                    img.Save(path);
                    EkranIcerik.Url = "~/Content/images/EkranIcerik/" + ekranIcerikid.ToString();
                    _ekranIcerikService.Update(EkranIcerik);

                    TempData["MessageSuccess"] = "Dosya başarıyla yüklendi.";
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "HATA:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Dosya seçmediniz.";
            }
            return RedirectToAction("Create", "EkranIcerik");
        }

    }
}