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
using WM.UI.Mvc.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [Authorize]
    public class UserRoleController : Controller
    {
        #region ctor
        private IUserRoleService _userRoleService;
        private IUserService _userService;
        private IRoleService _roleService;
        private IGrupUserService _grupUserService;

        public UserRoleController(IUserRoleService userRoleService,
                                  IUserService userService,
                                  IRoleService roleService,
                                  IGrupUserService grupUserService)
        {
            _userRoleService = userRoleService;
            _userService = userService;
            _roleService = roleService;
            _grupUserService = grupUserService;
        }
        #endregion

        // GET: EczaneNobet/UserRole
        public ActionResult Index()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            var userlar = _grupUserService.GetDetaylarListByUser(user).Select(s => s.UserId).ToList();
            var model = _userRoleService.GetDetaylar().Where(w => w.RoleId >= rolId && userlar.Contains(w.UserId)).ToList();

            return View(model);
        }

        // GET: EczaneNobet/UserRole/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRole = _userRoleService.GetDetayById(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: EczaneNobet/UserRole/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(_roleService.GetList().Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName");
            return View();
        }

        // POST: EczaneNobet/UserRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,UserId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _userRoleService.Insert(userRole);
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(_roleService.GetList().Select(s => new { s.Id, s.Name }), "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName", userRole.UserId);
            return View(userRole);
        }

        // GET: EczaneNobet/UserRole/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRole = _userRoleService.GetDetayById(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(_roleService.GetList().Select(s => new { s.Id, s.Name }), "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName", userRole.UserId);
            return View(userRole);
        }

        // POST: EczaneNobet/UserRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,UserId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _userRoleService.Update(userRole);
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(_roleService.GetList().Select(s => new { s.Id, s.Name }), "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(_userService.GetList().Select(s => new { s.Id, s.UserName }), "Id", "UserName", userRole.UserId);
            return View(userRole);
        }

        // GET: EczaneNobet/UserRole/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRole = _userRoleService.GetDetayById(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: EczaneNobet/UserRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userRole = _userRoleService.GetDetayById(id);
            _userRoleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
