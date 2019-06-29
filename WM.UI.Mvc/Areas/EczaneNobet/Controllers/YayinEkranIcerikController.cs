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
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [Authorize]
    public class YayinEkranIcerikController : Controller
    {
        #region ctor
        private IYayinEkranIcerikService _yayinEkranIcerikService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IEkranIcerikService _ekranIcerikService;

        public YayinEkranIcerikController(IYayinEkranIcerikService yayinEkranIcerikService,
                                    IEkranIcerikService ekranIcerikService,
                                    IYayinEkranService yayinEkranService,
                                    IUserRoleService userRoleService,
                                    IEkranService ekranService,
                                    IUserService userService)
        {
            _yayinEkranIcerikService = yayinEkranIcerikService;
            _ekranService = ekranService;
            _yayinEkranService = yayinEkranService;
            _userRoleService = userRoleService;
            _ekranIcerikService = ekranIcerikService;
            _userService = userService;
        }
        #endregion
        // GET: EczaneNobet/YayinEkranIcerik
        public ActionResult Index()
        {

            var user = _userService.GetByUserName(User.Identity.Name);
            var model = _yayinEkranIcerikService.GetDetaylarByUser(user);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;

            if (rolId == 2)
            {
                model = _yayinEkranIcerikService.GetDetaylar();

            }
            return View(model);
        }

        // GET: EczaneNobet/YayinEkranIcerik/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var yayinEkranIcerik = _yayinEkranIcerikService.GetDetayById(id);
            if (yayinEkranIcerik == null)
            {
                return HttpNotFound();
            }
            return View(yayinEkranIcerik);
        }

        // GET: EczaneNobet/YayinEkranIcerik/Create
        public ActionResult Create()
        {
            ViewBag.EkranIcerikId = new SelectList(_ekranIcerikService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            return View();
        }

        // POST: EczaneNobet/YayinEkranIcerik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EkranIcerikId,EkranId")] YayinEkranIcerik yayinEkranIcerik)
        {
            if (ModelState.IsValid)
            {
                _yayinEkranIcerikService.Insert(yayinEkranIcerik);
                return RedirectToAction("Index");
            }

            ViewBag.EkranIcerikId = new SelectList(_ekranIcerikService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", yayinEkranIcerik.Id);
            return View(yayinEkranIcerik);
        }

        // GET: EczaneNobet/YayinEkranIcerik/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var yayinEkranIcerik = _yayinEkranIcerikService.GetById(id);
            if (yayinEkranIcerik == null)
            {
                return HttpNotFound();
            }
            ViewBag.YayinId = new SelectList(_ekranIcerikService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", yayinEkranIcerik.Id);
            return View(yayinEkranIcerik);
        }

        // POST: EczaneNobet/YayinEkranIcerik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EkranIcerikId,EkranId")] YayinEkranIcerik yayinEkranIcerik)
        {
            if (ModelState.IsValid)
            {
                _yayinEkranIcerikService.Update(yayinEkranIcerik);
                return RedirectToAction("Index");
            }
            ViewBag.YayinId = new SelectList(_ekranIcerikService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", yayinEkranIcerik.Id);
            return View(yayinEkranIcerik);
        }

        // GET: EczaneNobet/YayinEkranIcerik/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var yayinEkranIcerik = _yayinEkranIcerikService.GetDetayById(id);
            if (yayinEkranIcerik == null)
            {
                return HttpNotFound();
            }
            return View(yayinEkranIcerik);
        }

        // POST: EczaneNobet/YayinEkranIcerik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var yayinEkranIcerik = _yayinEkranIcerikService.GetDetayById(id);
            _yayinEkranIcerikService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
