using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Areas.EczaneNobet.Models;
using WM.UI.Mvc.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [Authorize]
    public class YayinEkranController : Controller
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


        public YayinEkranController(IUserService userService,
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


        // GET: EczaneNobet/YayinEkran
        public ActionResult Index()
        {//YayinEkranDetayTasarimDetaylarIcerikDetaylarViewModel
            var user = _userService.GetByUserName(User.Identity.Name);
            var model = _yayinEkranService.GetDetaylarByUser(user);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;

            if (rolId == 2)
            {
                model = _yayinEkranService.GetDetaylar();
            }

            return View(model);
        }
        private List<EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel> getEkranDetayTasarimDetaylarIcerikDetaylarViewModel()
        {
            List<EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel> yayinEkranDetayTasarimDetaylarIcerikDetaylarViewModel = new List<EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel>();

            var user = _userService.GetByUserName(User.Identity.Name);

            var ekranIdler = _ekranService.GetDetaylarListByUser(user).Select(s => s.Id).ToList();
            //var yayinEkranDetaylar = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).ToList();

            var simdikiEkran = _yayinEkranService.GetDetaylarByIdlerByDate(ekranIdler, DateTime.Now).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            if (simdikiEkran == null)
            {
                simdikiEkran = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).OrderBy(o => o.BaslamaZamani).FirstOrDefault();
            }
            int aktifEkranTasarimId = simdikiEkran.EkranTasarimId;
            List<UserRoleDetay> userRoleDetay = _userRoleService.GetDetaylarByUserId(user.Id).ToList();
            var ekranIdlerForEkranDetaylar = _yayinEkranService.GetDetaylarByEkranIdler(ekranIdler).Select(s=>s.EkranId).Distinct().ToList();
            var ekranDetaylar = _ekranService.GetDetaylar().Where(w => ekranIdlerForEkranDetaylar.Contains(w.Id)).ToList();

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

        // GET: EczaneNobet/YayinEkran/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var yayinEkran = _yayinEkranService.GetDetayById(id);
            if (yayinEkran == null)
            {
                return HttpNotFound();
            }
            return View(yayinEkran);
        }

        // GET: EczaneNobet/YayinEkran/Create
        public ActionResult Create()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            var ekranTasarimlar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            var ekranlar = _ekranService.GetDetaylarListByUser(user).ToList();
            if (rolId == 2)
            {
                ekranlar = _ekranService.GetDetaylar();
                ekranTasarimlar = _ekranTasarimService.GetDetaylar();
            }
            ViewBag.EkranTasarimId = new SelectList(ekranTasarimlar.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            ViewBag.EkranId = new SelectList(ekranlar.Select(s => new { s.Id, s.KonumAdi }), "Id" , "KonumAdi");
            return View();
        }

        // POST: EczaneNobet/YayinEkran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EkranTasarimId,EkranId,BaslamaZamani,BitisZamani")] YayinEkran yayinEkran)
        {//,BaslamaSaati, BaslamaDakikasi, BitisSaati, BitisDakikasi
            var yayinEkranlar = _yayinEkranService.GetDetaylarByEkranId(yayinEkran.EkranId)
                                .Where(w=>w.BaslamaZamani < yayinEkran.BaslamaZamani 
                                        && w.BitisZamani > yayinEkran.BaslamaZamani
                                        || w.BaslamaZamani < yayinEkran.BitisZamani
                                        && w.BitisZamani > yayinEkran.BitisZamani).ToList();
            if (yayinEkranlar.Count > 0)
            {
                TempData["MessageDanger"] = "Çakışan tasarım var. Öncelikle çakışan tasarım değiştirmelisiniz.";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _yayinEkranService.Insert(yayinEkran);
                    TempData["MessageSuccess"] = "Başarıyla kaydedildi.";
                    return RedirectToAction("Index");
                }
            }
            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            var ekranTasarimlar = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            var ekranlar = _ekranService.GetDetaylarListByUser(user).ToList();
            if (rolId == 2)
            {
                ekranlar = _ekranService.GetDetaylar();
                ekranTasarimlar = _ekranTasarimService.GetDetaylar();
            }
            ViewBag.EkranTasarimId = new SelectList(ekranTasarimlar.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            ViewBag.EkranId = new SelectList(ekranlar.Select(s => new { s.Id, s.KonumAdi }), "Id", "KonumAdi");
            //ViewBag.EkranId = new SelectList(_ekranService.GetList().Select(s => new { s.Id, s.Konum.Adi }), "Id", "Adi", yayinEkran.Ekran.Konum.Adi);
            return View(yayinEkran);
        }

        // GET: EczaneNobet/YayinEkran/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var yayinEkran = _yayinEkranService.GetById(id);
            if (yayinEkran == null)
            {
                return HttpNotFound();
            }
           
           // ViewBag.EkranId = new SelectList(_ekranService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", yayinEkran.Ekran.Konum.Adi);
            return View(yayinEkran);
        }

        // POST: EczaneNobet/YayinEkran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EkranTasarimId,EkranId,BaslamaZamani,BitisZamani")] YayinEkran yayinEkran)
        {
            if (ModelState.IsValid)
            {
                _yayinEkranService.Update(yayinEkran);
                return RedirectToAction("Index");
            }
            //ViewBag.EkranId = new SelectList(_ekranService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", yayinEkran.Ekran.Konum.Adi);
            return View(yayinEkran);
        }
  

        // GET: EczaneNobet/YayinEkran/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var yayinEkran = _yayinEkranService.GetDetayById(id);
            if (yayinEkran == null)
            {
                return HttpNotFound();
            }
            return View(yayinEkran);
        }

        // POST: EczaneNobet/YayinEkran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var yayinEkran = _yayinEkranService.GetDetayById(id);
            _yayinEkranService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
