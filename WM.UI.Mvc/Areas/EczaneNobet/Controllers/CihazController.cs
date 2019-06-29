using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Areas.EczaneNobet.Models;
using WM.UI.Mvc.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [HandleError]
    [Authorize]
    public class CihazController : Controller
    {
        #region ctor
        private ICihazService _cihazService;
        private IGrupService _grupService;
        private IUserRoleService _userRoleService;
        private ICihazDurumService _cihazDurumService;
        private IUserService _userService;
        private ICozunurlukService _cozunurlukService;
        private IMonitorService _monitorService;
        private IKonumService _konumService;

        public CihazController(ICihazService cihazService,
                                ICihazDurumService cihazDurumService,
                                IGrupService grupService,
                                IUserService userService,
                                IUserRoleService userRoleService,
                                ICozunurlukService cozunurlukService,
                                IKonumService konumService,
                                IMonitorService monitorService)
        {
            _cihazService = cihazService;
            _userRoleService = userRoleService;
            _cihazDurumService = cihazDurumService;
            _userService = userService;
            _monitorService = monitorService;
            _konumService = konumService;
            _cozunurlukService = cozunurlukService;
            _grupService = grupService;
        }
        #endregion
        // GET: EczaneNobet/Cihaz        
        public ActionResult Index()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var cihazDetaylar = _cihazService.GetDetaylarListByUser(user);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            List<UserRoleDetay> userRoleDetaylar = _userRoleService.GetDetaylarByUserId(user.Id).ToList();

            if (rolId == 2)
            {
                cihazDetaylar = _cihazService.GetDetaylar();
            }

            var model = new CihazDetayViewModel()
            {
                CihazDetaylar = cihazDetaylar,
                UserRoleDetaylar = userRoleDetaylar
            };
            return View(model);
        }

        // GET: EczaneNobet/Cihaz/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cihaz = _cihazService.GetDetayById(id);
            if (cihaz == null)
            {
                return HttpNotFound();
            }
            return View(cihaz);
        }

        // GET: EczaneNobet/Cihaz/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            //var cihaz = new Cihaz { AlimTarihi = DateTime.Today, Enlem = 0, Boylam = 0 };
            var user = _userService.GetByUserName(User.Identity.Name);
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            var cihazDurumlar = _cihazDurumService.GetList();
            ViewBag.CihazDurumId = new SelectList(cihazDurumlar.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            return View();
        }

        // POST: EczaneNobet/Cihaz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GrupId,ApiUrl,CozunurlukId,PingPeriyodu,CihazDurumId,Marka,Model,SeriNu,AlimTarihi,BaslamaTarihi,SonGuncellenmeTarihi,Aciklama,WiFiKullaniciAdi,WiFiParola")] Cihaz cihaz)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            cihaz.SonGuncelleyenUserId = user.Id;
            cihaz.SonGuncellenmeTarihi = DateTime.Now;
            if (ModelState.IsValid)
            {
                _cihazService.Insert(cihaz);
                TempData["EklenenCihaz"] = cihaz.SeriNu;

                var cihazler = new int[1]
                {
                    cihaz.Id
                };

                return RedirectToAction("Index");
            }

            var cihazDurumlar = _cihazDurumService.GetList();
            ViewBag.CihazDurumId = new SelectList(cihazDurumlar.Select(s => new { s.Id, s.Adi }), "Id", "Adi", cihaz.CihazDurumId);
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler, "Id", "Adi", cihaz.CozunurlukId);

            return View(cihaz);
        }

        // GET: EczaneNobet/Cihaz/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetByUserName(User.Identity.Name);

            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cihaz cihaz = _cihazService.GetById(id);
            if (cihaz == null)
            {
                return HttpNotFound();
            }
            var users = _userService.GetList();
            var gruplar = _grupService.GetListByUser(user);
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi", cihaz.GrupId);
            var cihazDurumlar = _cihazDurumService.GetList();
            ViewBag.CihazDurumId = new SelectList(cihazDurumlar.Select(s => new { s.Id, s.Adi }), "Id", "Adi", cihaz.CihazDurumId);
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi", cihaz.CozunurlukId);
            return View(cihaz);
        }

        // POST: EczaneNobet/Cihaz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include = "Id,GrupId,ApiUrl,PingPeriyodu,CozunurlukId,CihazDurumId,Marka,Model,SeriNu,AlimTarihi,BaslamaTarihi,BitisTarihi,SonGuncellenmeTarihi,Aciklama,WiFiKullaniciAdi,WiFiParola")] Cihaz cihaz)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            cihaz.SonGuncelleyenUserId = user.Id;
            if (ModelState.IsValid)
            {
                _cihazService.Update(cihaz);
                return RedirectToAction("Index");
            }
            var users = _userService.GetList();
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var cihazDurumlar = _cihazDurumService.GetList();
            ViewBag.CihazDurumId = new SelectList(cihazDurumlar.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            return View(cihaz);
        }

        // GET: EczaneNobet/Cihaz/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cihaz cihaz = _cihazService.GetById(id);
            if (cihaz == null)
            {
                return HttpNotFound();
            }
            return View(cihaz);
        }

        // POST: EczaneNobet/Cihaz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cihaz cihaz = _cihazService.GetById(id);
            _cihazService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
