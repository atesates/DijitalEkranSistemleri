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
    public class GrupController : Controller
    {
        private IGrupService _grupService;

        public GrupController(IGrupService grupService)
        {
            _grupService = grupService;
        }
        // GET: EczaneNobet/Grup
        public ActionResult Index()
        {
            var model = _grupService.GetList();
            return View(model);
        }

        // GET: EczaneNobet/Grup/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grup grup = _grupService.GetById(id);
            if (grup == null)
            {
                return HttpNotFound();
            }
            return View(grup);
        }

        // GET: EczaneNobet/Grup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EczaneNobet/Grup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                _grupService.Insert(grup);
                return RedirectToAction("Index");
            }

            return View(grup);
        }

        // GET: EczaneNobet/Grup/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grup grup = _grupService.GetById(id);
            if (grup == null)
            {
                return HttpNotFound();
            }
            return View(grup);
        }

        // POST: EczaneNobet/Grup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                _grupService.Update(grup);
                return RedirectToAction("Index");
            }
            return View(grup);
        }

        // GET: EczaneNobet/Grup/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grup grup = _grupService.GetById(id);
            if (grup == null)
            {
                return HttpNotFound();
            }
            return View(grup);
        }

        // POST: EczaneNobet/Grup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grup grup = _grupService.GetById(id);
            _grupService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
