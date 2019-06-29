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
    public class MonitorController : Controller
    {
        #region ctor
        private ICihazService _cihazService;
        private IGrupService _grupService;
        private IUserRoleService _userRoleService;
        private IUserService _userService;
        private ICozunurlukService _cozunurlukService;
        private IMonitorService _monitorService;
        private IKonumService _konumService;

        public MonitorController(ICihazService cihazService,
                                IUserRoleService userRoleService,
                                IUserService userService,
                                IGrupService grupService,
                                ICozunurlukService cozunurlukService,
                                IKonumService konumService,
                                IMonitorService monitorService)
        {
            _cihazService = cihazService;
            _userRoleService = userRoleService;
            _userService = userService;
            _monitorService = monitorService;
            _konumService = konumService;
            _cozunurlukService = cozunurlukService;
            _grupService = grupService;
        }
        #endregion
        // GET: EczaneNobet/Monitor        
        public ActionResult Index()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var monitorDetaylar = _monitorService.GetDetaylarListByUser(user);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            List<UserRoleDetay> userRoleDetaylar = _userRoleService.GetDetaylarByUserId(user.Id).ToList();

            if (rolId == 2)
            {
                monitorDetaylar = _monitorService.GetDetaylar();
            }

            var model = new MonitorDetayViewModel()
            {
                MonitorDetaylar = monitorDetaylar,
                UserRoleDetaylar = userRoleDetaylar
            };
            return View(model);
        }

        // GET: EczaneNobet/Monitor/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var monitor = _monitorService.GetDetayById(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        // GET: EczaneNobet/Monitor/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            //var monitor = new Monitor { AlimTarihi = DateTime.Today, Enlem = 0, Boylam = 0 };
            var user = _userService.GetByUserName(User.Identity.Name);
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");

            return View();
        }

        // POST: EczaneNobet/Monitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adi,GrupId,CozunurlukId,Marka,BoyutuInc,AlimTarihi,BaslamaTarihi,SeriNu,Aciklama")] Monitor monitor)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            var user = _userService.GetByUserName(User.Identity.Name);

            //monitor.UserId = user.Id;
            if (ModelState.IsValid)
            {
                _monitorService.Insert(monitor);
                TempData["EklenenCihaz"] = monitor.SeriNu;

                var cihazler = new int[1]
                {
                    monitor.Id
                };

                return RedirectToAction("Index");
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
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler, "Id", "Adi");

            return View(monitor);
        }

        // GET: EczaneNobet/Monitor/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitor monitor = _monitorService.GetById(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            var users = _userService.GetList();
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi",monitor.GrupId);
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi", monitor.CozunurlukId);
            return View(monitor);
        }

        // POST: EczaneNobet/Monitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include = "Id,GrupId,Adi,CozunurlukId,Marka,BoyutuInc,AlimTarihi,BaslamaTarihi,BitisTarihi,SeriNu,Aciklama")] Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                _monitorService.Update(monitor);
                return RedirectToAction("Index");
            }
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.CozunurlukId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi", monitor.CozunurlukId);
            return View(monitor);
        }

        // GET: EczaneNobet/Monitor/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitor monitor = _monitorService.GetById(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        // POST: EczaneNobet/Monitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monitor monitor = _monitorService.GetById(id);
            _monitorService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
