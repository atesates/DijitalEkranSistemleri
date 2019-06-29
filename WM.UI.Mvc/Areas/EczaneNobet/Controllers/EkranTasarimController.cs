using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Areas.EczaneNobet.Models;
using WM.Core.Aspects.PostSharp.TranstionAspects;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [HandleError]
    public class EkranTasarimController : Controller
    {
        #region ctor
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IGrupService _grupService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IEkranIcerikService _ekranIcerikService;
        private IEkranTasarimService _ekranTasarimService;
        private IEkranTasarimIcerikService _ekranTasarimIcerikService;
        private IKonumService _konumService;


        public EkranTasarimController(IUserService userService,
                                      IUserRoleService userRoleService,
                                      IGrupService grupService,
                                      IEkranService ekranService,
                                      IYayinEkranService yayinEkranService,
                                      IEkranIcerikService ekranIcerikService,
                                      IEkranTasarimService ekranTasarimService,
                                      IEkranTasarimIcerikService ekranTasarimIcerikService,
                                      IKonumService konumService
        )
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _ekranService = ekranService;
            _ekranIcerikService = ekranIcerikService;
            _ekranTasarimService = ekranTasarimService;
            _ekranTasarimIcerikService = ekranTasarimIcerikService;
            _konumService = konumService;
            _yayinEkranService = yayinEkranService;
            _grupService = grupService;
        }
        #endregion
        public ActionResult Index()
        {
            // var model = new EkranDetayViewModel();
            var model2 = new List<EkranTasarimIcerikDetaylarViewModel>();
            model2 = getEkranTasarimlarim();
            //model = getEkranlarim();
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
            var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimId).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarById(ekranTasarimIcerikDetaylar.Select(s=>s.EkranTasarimId).ToList()).ToList();


            var model = new EkranDetayViewModel()
            {
                EkranDetaylar = ekranDetaylar,
                EkranIcerikDetaylar = ekranIcerikDetaylar,
                EkranTasarimDetaylar = ekranTasarimDataylar,
            };
            return model;
        }

        [HttpGet]
        private ActionResult GetEkranTasarimlarim()
        {
            List<EkranTasarimIcerikDetaylarViewModel> ekranTasarimIcerikDetaylarViewModel = new List<EkranTasarimIcerikDetaylarViewModel>();
            ekranTasarimIcerikDetaylarViewModel = getEkranTasarimlarim();
            return PartialView("EkranTasarimPartialView", ekranTasarimIcerikDetaylarViewModel);
        }

        public List<EkranTasarimIcerikDetaylarViewModel> getEkranTasarimlarim()
        {
            List<EkranTasarimIcerikDetaylarViewModel> ekranTasarimIcerikDetaylarViewModel = new List<EkranTasarimIcerikDetaylarViewModel>();
            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            List<UserRoleDetay> userRoleDetay = _userRoleService.GetDetaylarByUserId(user.Id).ToList();
            var ekranDetaylar = _ekranService.GetDetaylarListByUser(user).ToList();       
            var ekranTasarimDataylar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            var ekranIcerikDetaylar = _ekranIcerikService.GetDetaylarListByUser(user).ToList();
            if (rolId == 2)
            {
                ekranDetaylar = _ekranService.GetDetaylar();
                ekranTasarimDataylar = _ekranTasarimService.GetDetaylar();
                ekranIcerikDetaylar = _ekranIcerikService.GetDetaylar();
            }
            foreach (var ekranTasarimDetay in ekranTasarimDataylar)
            {
                var ekranTasarimIcerikDetaylar = _ekranTasarimIcerikService.GetDetaylarListByEkranTasarimId(ekranTasarimDetay.Id).ToList();
                var ekranIcerikDetays = _ekranIcerikService.GetDetaylarById(ekranTasarimIcerikDetaylar.Select(s => s.EkranIcerikId).ToList()).ToList();
                var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
                var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault(); ;
                if (simdikiEkran == null)
                {
                    simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
                }
                var ekranDetay = _ekranService.GetDetayById(simdikiEkran.EkranId);

                ekranTasarimIcerikDetaylarViewModel.Add(new EkranTasarimIcerikDetaylarViewModel
                {
                    EkranDetay = ekranDetay,
                    EkranTasarimDetay = ekranTasarimDetay,
                    EkranIcerikDetaylar = ekranIcerikDetays,
                    UserRoleDetay = userRoleDetay,
                    EkranTasarimIcerikDetaylar = ekranTasarimIcerikDetaylar
                });

            }
            var EkranDetaylar = ekranDetaylar;
            ViewBag.EkranLsitesi = new SelectList(EkranDetaylar, "Id", "MonitorAdi");
            //foreach (var ekranDetay in ekranDetaylar)
            //{
            //    var ekranTasarimDetay = ekranTasarimDataylar.Where(w => w.Id == ekranDetay.EkranTasarimId).FirstOrDefault();
            //    var ekranIcerikDetays = ekranIcerikDetaylar.Where(w => w.EkranTasarimId == ekranDetay.EkranTasarimId).ToList();

            //    ekranTasarimIcerikDetaylarViewModel.Add(new EkranTasarimIcerikDetaylarViewModel
            //    {
            //        EkranDetay = ekranDetay,
            //        EkranTasarimDetay = ekranTasarimDetay,
            //        EkranIcerikDetaylar = ekranIcerikDetays
            //    });

            //}


            return ekranTasarimIcerikDetaylarViewModel;
        }

        [HttpPost]
        [TransactionScopeAspect]
        [ValidateAntiForgeryToken]
        public ActionResult SetEkranIcerik(string boyutX, string boyutY,
                                         string koordinatX, string koordinatY,
                                         string ekranIcerikId)
        {
            int id = Convert.ToInt32(ekranIcerikId);
            // int id = EkranTasarimId;

            EkranIcerik ekranIcerik = new EkranIcerik();
            EkranTasarimIcerik ekranTasarimIcerik = new EkranTasarimIcerik();
            ekranIcerik = _ekranIcerikService.GetById(id);

            ekranTasarimIcerik.KoordinatX = Convert.ToInt32(koordinatX);
            ekranTasarimIcerik.KoordinatY = Convert.ToInt32(koordinatY);
            ekranTasarimIcerik.BoyutX = Convert.ToInt32(boyutX);
            ekranTasarimIcerik.BoyutY = Convert.ToInt32(boyutY);

            var ekranTasarimIdlar = _ekranTasarimIcerikService.GetDetaylarListByEkranIcerikId(ekranIcerik.Id).Select(s=>s.EkranTasarimId).ToList();
            var ekranTasarimDetaylarlar = _ekranTasarimService.GetDetaylarById(ekranTasarimIdlar).ToList();
            foreach (var ekranTasarimDetay in ekranTasarimDetaylarlar)
            {
                EkranTasarim ekranTasarim = _ekranTasarimService.GetById(ekranTasarimDetay.Id);
                ekranTasarim.SonDegisiklikTarihi = System.DateTime.Now;
                try
                {
                    _ekranIcerikService.Update(ekranIcerik);
                    _ekranTasarimService.Update(ekranTasarim);
                    TempData["MessageSuccess"] = "Alım durum başarıyla Değiştirildi";
                    // return PartialView("TeklifimPartialView", teklifDetayEkranTasarimDetaylarViewModel);
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR: Alım Durum değiştirilemedi. " + ex.InnerException.InnerException.Message.ToString();

                }
            }
            List<EkranTasarimIcerikDetaylarViewModel> ekranTasarimIcerikDetaylarViewModel = new List<EkranTasarimIcerikDetaylarViewModel>();
            ekranTasarimIcerikDetaylarViewModel = getEkranTasarimlarim();
            return PartialView("EkranTasarimPartialView", ekranTasarimIcerikDetaylarViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SecilenleriSil(string eklenecekIcerikler, string ExpandedForSil, string pageForCokluSil, string teklifDurumIdForCokluSil, string EkranDurumIdForCokluSil)
        {
            List<EkranTasarimIcerikDetaylarViewModel> ekranTasarimIcerikDetaylarViewModel = new List<EkranTasarimIcerikDetaylarViewModel>();

            List<int> ekranIdler = new List<int>();
            var uyariMesaji = "Seçim Yapmadınız!";

            if (eklenecekIcerikler == null || eklenecekIcerikler == "")
            {
                return Json(uyariMesaji, JsonRequestBehavior.AllowGet);
            }

            Int32 basamak = eklenecekIcerikler.IndexOf(';');
            Int32 toplam = eklenecekIcerikler.Length;

            var Ekranlar = eklenecekIcerikler.Substring(0, basamak);
            var liste = Ekranlar.Split(',');

            //Ekranlar update 
            if (liste[0].Length > 0)
            {
                foreach (string item in liste)
                {
                    var ekran = new Ekran();
                    ekran = _ekranService.GetById(Convert.ToInt32(item));
                    try
                    {
                        _ekranService.Delete(ekran.Id);
                    }
                    catch (Exception ex)
                    {
                        string hataMesaji = ex.InnerException.InnerException.Message;
                        TempData["MessageDanger"] = "Seçilen Ekranlar silinemedi." + hataMesaji;
                        return Json(new HttpResponseMessage(HttpStatusCode.BadRequest), JsonRequestBehavior.AllowGet);
                    }
                    ekranIdler.Add(Convert.ToInt32(item));
                }
            }
            ekranTasarimIcerikDetaylarViewModel = getEkranTasarimlarim();
            TempData["MessageSuccess"] = "Seçilen Ekranlar silinmiştir.";
            return PartialView("EkranTasarimPartialView", ekranTasarimIcerikDetaylarViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EkranIcerikEkle(string eklenecekIcerikler, string ekranTasarimId)
        {
            List<int> ekranIdler = new List<int>();
            var uyariMesaji = "Seçim Yapmadınız!";

            if (eklenecekIcerikler == null || eklenecekIcerikler == "")
            {
                return Json(uyariMesaji, JsonRequestBehavior.AllowGet);
            }

            Int32 basamak = eklenecekIcerikler.IndexOf(';');
            Int32 toplam = eklenecekIcerikler.Length;

            var ekranIcerikler = eklenecekIcerikler.Substring(0, basamak);
            var liste = ekranIcerikler.Split(',');

            //Ekranlar update 
            if (liste[0].Length > 0)
            {
                foreach (string item in liste)
                {
                    var ekranIcerik = new EkranIcerik();
                    
                    ekranIcerik = _ekranIcerikService.GetById(Convert.ToInt32(item));
                    try
                    {
                        _ekranIcerikService.Insert(ekranIcerik);
                        TempData["MessageSuccess"] = "Seçilen İçerikler eklenmiştir.";

                    }
                    catch (Exception ex)
                    {
                        string hataMesaji = ex.InnerException.InnerException.Message;
                        TempData["MessageDanger"] = "Seçilen İçerikler eklenemedi." + hataMesaji;
                        return Json(new HttpResponseMessage(HttpStatusCode.BadRequest), JsonRequestBehavior.AllowGet);
                    }
                    ekranIdler.Add(Convert.ToInt32(item));
                }
            }
            TempData["MessageDanger"] = "Seçilen İçerikler eklenemedi.";

            return RedirectToAction("Index", "EkranTasarim");
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
                return RedirectToAction("Index", "EkranTasarim");

            }
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkranTasarim EkranTasarim = _ekranTasarimService.GetById(Id);
            var users = _userService.GetList();
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi", EkranTasarim.GrupId);

            if (EkranTasarim == null)
            {
                return HttpNotFound();
            }
            return View(EkranTasarim);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,SektorId,GrupId,BaslamaTarihi,BitisTarihi,SonDegisiklikTarihi,Aciklama")] EkranTasarim EkranTasarim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ekranTasarimService.Update(EkranTasarim);
                    TempData["MessageSuccess"] = "EkranTasarim başarıyla düzenlenmiştir";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
                }
            }

            var users = _userService.GetList();
            ViewBag.UserId = new SelectList(users, "Id", "UserName");

            return View(EkranTasarim);
        }
        // GET: AlimNobet/EkranTasarim/Create
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Create()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            if (rolId == 2)
            {
                var gruplar = _grupService.GetList();
                ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            }
            else
            {
                var gruplar = _grupService.GetListByUser(user);
                ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EkranTasarim EkranTasarim)
        {

            EkranTasarim.BaslamaTarihi = DateTime.Now;
            EkranTasarim.SonDegisiklikTarihi = DateTime.Now;
            var user = _userService.GetByUserName(User.Identity.Name);
            //
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            if (rolId == 2)
            {
                var users = _userService.GetList();
                var gruplar = _grupService.GetList();
                ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            }
            else
            {
                var gruplar = _grupService.GetListByUser(user).ToList();
                ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
                EkranTasarim.GrupId = user.Id;
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    _ekranTasarimService.Insert(EkranTasarim);
                    TempData["MessageSuccess"] = "Ekran Tasarımı başarıyla değiştirilmiştir.";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
                }
            }
            else
            {
                var errorText ="";
                foreach (var item in errors)
                {
                    errorText = errorText + " " + item;
                }
                TempData["MessageDanger"] = "ERROR: Modelstate is invalid, " + errorText.ToString();

            }

            return View(EkranTasarim);
        }
        // GET: EczaneNobet/Eczane/Delete/5
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkranTasarim ekranTasarim = _ekranTasarimService.GetById(id);
            if (ekranTasarim == null)
            {
                return HttpNotFound();
            }
            return View(ekranTasarim);
        }
        // POST: EczaneNobet/Eczane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EkranTasarim ekranTasarim = _ekranTasarimService.GetById(id);
                _ekranTasarimService.Delete(id);
                TempData["MessageSuccess"] = "Ekran Tasarımı başarıyla silinmiştir.";
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ResimEdit(HttpPostedFileBase file, int EkranIcerikid)
        {
            int ekranIcerikid = EkranIcerikid;
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
            return RedirectToAction("Index", "EkranTasarim");
        }
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ekranTasarim= _ekranTasarimService.GetDetayById(id);
            if (ekranTasarim == null)
            {
                return HttpNotFound();
            }
            return View(ekranTasarim);
        }
    }
}