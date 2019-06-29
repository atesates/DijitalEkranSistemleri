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
    public class GrupUserController : Controller
    {
        private IGrupUserService _grupUserService;
        private IUserService _userService;
        private IGrupService _grupService;

        public GrupUserController(IGrupUserService grupUserService,
                                  IUserService userService,
                                  IGrupService grupService
            )
        {
            _grupUserService = grupUserService;
            _userService = userService;
            _grupService = grupService;
        }

        // GET: EczaneNobet/GrupUser
        public ActionResult Index()
        {
            var model = _grupUserService.GetDetaylar();
            return View(model);
        }

        // GET: EczaneNobet/GrupUser/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var grupUser = _grupUserService.GetDetayById(id);
            if (grupUser == null)
            {
                return HttpNotFound();
            }
            return View(grupUser);
        }

        // GET: EczaneNobet/GrupUser/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(_grupService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName");
            return View();
        }

        // POST: EczaneNobet/GrupUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,UserId")] GrupUser grupUser)
        {
            if (ModelState.IsValid)
            {
                _grupUserService.Insert(grupUser);
                return RedirectToAction("Index");
            }

            ViewBag.GrupId = new SelectList(_grupService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", grupUser.GrupId);
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName", grupUser.UserId);
            return View(grupUser);
        }

        // GET: EczaneNobet/GrupUser/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var grupUser = _grupUserService.GetDetayById(id);
            if (grupUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupId = new SelectList(_grupService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", grupUser.GrupId);
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName", grupUser.UserId);
            return View(grupUser);
        }

        // POST: EczaneNobet/GrupUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,UserId")] GrupUser grupUser)
        {
            if (ModelState.IsValid)
            {
                _grupUserService.Update(grupUser);
                return RedirectToAction("Index");
            }
            ViewBag.GrupId = new SelectList(_grupService.GetList().Select(s => new { s.Id, s.Adi }), "Id", "Adi", grupUser.GrupId);
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName", grupUser.UserId);
            return View(grupUser);
        }

        // GET: EczaneNobet/GrupUser/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var grupUser = _grupUserService.GetDetayById(id);
            if (grupUser == null)
            {
                return HttpNotFound();
            }
            return View(grupUser);
        }

        // POST: EczaneNobet/GrupUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var grupUser = _grupUserService.GetDetayById(id);
            _grupUserService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
