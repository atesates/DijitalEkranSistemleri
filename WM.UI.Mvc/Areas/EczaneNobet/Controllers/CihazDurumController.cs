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
using WM.UI.Mvc.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [HandleError]
    [Authorize]
    public class CihazDurumController : Controller
    {
        #region ctor
        private ICihazService _cihazService;
        private IUserService _userService;
        private ICihazDurumService _cihazDurumService;
        private IMonitorService _monitorService;
        private IKonumService _konumService;

        public CihazDurumController(ICihazService cihazService,
                                IUserService userService,
                                ICihazDurumService cihazDurumService,
                                IKonumService konumService,
                                IMonitorService monitorService)
        {
            _cihazService = cihazService;
            _userService = userService;
            _monitorService = monitorService;
            _konumService = konumService;
            _cihazDurumService = cihazDurumService;
        }
        #endregion
        // GET: EczaneNobet/CihazDurum        
        public ActionResult Index()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var model = _cihazDurumService.GetList();

            return View(model);
        }

        // GET: EczaneNobet/CihazDurum/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CihazDurum = _cihazDurumService.GetById(id);
            if (CihazDurum == null)
            {
                return HttpNotFound();
            }
            return View(CihazDurum);
        }

        // GET: EczaneNobet/CihazDurum/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EczaneNobet/CihazDurum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Adi, Deger, Aciklama")] CihazDurum CihazDurum)
        {
            if (ModelState.IsValid)
            {
                _cihazDurumService.Insert(CihazDurum);
                TempData["EklenenCihazDurum"] = CihazDurum.Adi;

                var cihazler = new int[1]
                {
                    CihazDurum.Id
                };

                return RedirectToAction("Index");
            }
            

            return View(CihazDurum);
        }

        // GET: EczaneNobet/CihazDurum/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CihazDurum CihazDurum = _cihazDurumService.GetById(id);
            if (CihazDurum == null)
            {
                return HttpNotFound();
            }
            
            return View(CihazDurum);
        }

        // POST: EczaneNobet/CihazDurum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include = "Id, Adi, Deger, Aciklama")] CihazDurum CihazDurum)
        {
            if (ModelState.IsValid)
            {
                _cihazDurumService.Update(CihazDurum);
                return RedirectToAction("Index");
            }

            var CihazDurumler = _cihazDurumService.GetList();
            ViewBag.NobetUstGrupId = new SelectList(CihazDurumler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            return View(CihazDurum);
        }

        // GET: EczaneNobet/CihazDurum/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CihazDurum CihazDurum = _cihazDurumService.GetById(id);
            if (CihazDurum == null)
            {
                return HttpNotFound();
            }
            return View(CihazDurum);
        }

        // POST: EczaneNobet/CihazDurum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CihazDurum CihazDurum = _cihazDurumService.GetById(id);
            _cihazService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
