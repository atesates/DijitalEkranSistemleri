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
    public class CozunurlukController : Controller
    {
        #region ctor
        private ICihazService _cihazService;
        private IUserService _userService;
        private ICozunurlukService _cozunurlukService;
        private IMonitorService _monitorService;
        private IKonumService _konumService;

        public CozunurlukController(ICihazService cihazService,
                                IUserService userService,
                                ICozunurlukService cozunurlukService,
                                IKonumService konumService,
                                IMonitorService monitorService)
        {
            _cihazService = cihazService;
            _userService = userService;
            _monitorService = monitorService;
            _konumService = konumService;
            _cozunurlukService = cozunurlukService;
        }
        #endregion
        // GET: EczaneNobet/Cozunurluk        
        public ActionResult Index()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var model = _cozunurlukService.GetList();

            return View(model);
        }

        // GET: EczaneNobet/Cozunurluk/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cozunurluk = _cozunurlukService.GetById(id);
            if (cozunurluk == null)
            {
                return HttpNotFound();
            }
            return View(cozunurluk);
        }

        // GET: EczaneNobet/Cozunurluk/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EczaneNobet/Cozunurluk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Adi, Deger, Aciklama")] Cozunurluk cozunurluk)
        {
            if (ModelState.IsValid)
            {
                _cozunurlukService.Insert(cozunurluk);
                TempData["EklenenCozunurluk"] = cozunurluk.Adi;

                var cihazler = new int[1]
                {
                    cozunurluk.Id
                };

                return RedirectToAction("Index");
            }
            

            return View(cozunurluk);
        }

        // GET: EczaneNobet/Cozunurluk/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cozunurluk cozunurluk = _cozunurlukService.GetById(id);
            if (cozunurluk == null)
            {
                return HttpNotFound();
            }
            
            return View(cozunurluk);
        }

        // POST: EczaneNobet/Cozunurluk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include = "Id, Adi, Deger, Aciklama")] Cozunurluk cozunurluk)
        {
            if (ModelState.IsValid)
            {
                _cozunurlukService.Update(cozunurluk);
                return RedirectToAction("Index");
            }

            var cozunurlukler = _cozunurlukService.GetList();
            ViewBag.NobetUstGrupId = new SelectList(cozunurlukler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            return View(cozunurluk);
        }

        // GET: EczaneNobet/Cozunurluk/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cozunurluk cozunurluk = _cozunurlukService.GetById(id);
            if (cozunurluk == null)
            {
                return HttpNotFound();
            }
            return View(cozunurluk);
        }

        // POST: EczaneNobet/Cozunurluk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cozunurluk cozunurluk = _cozunurlukService.GetById(id);
            _cihazService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
