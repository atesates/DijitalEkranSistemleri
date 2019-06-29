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
    public class KonumController : Controller
    {
        #region ctor
        private ICihazService _cihazService;
        private IGrupService _grupService;
        private IUserRoleService _userRoleService;
        private IUserService _userService;
        private ICozunurlukService _cozunurlukService;
        private IMonitorService _monitorService;
        private IKonumService _konumService;

        public KonumController(ICihazService cihazService,
                                IUserRoleService userRoleService,
                                IUserService userService,
                                ICozunurlukService cozunurlukService,
                                IKonumService konumService,
                                IMonitorService monitorService,
                                IGrupService grupService)
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
        // GET: EczaneNobet/Konum        
        public ActionResult Index()
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            var konumDetaylar = _konumService.GetDetaylarListByUser(user);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            List<UserRoleDetay> userRoleDetaylar = _userRoleService.GetDetaylarByUserId(user.Id).ToList();
          
            if (rolId == 2)
            {
                konumDetaylar = _konumService.GetDetaylar();
            }

            var model = new KonumDetayViewModel()
            {
                KonumDetaylar = konumDetaylar,
                UserRoleDetaylar = userRoleDetaylar
            };
            return View(model);
        }

        // GET: EczaneNobet/Konum/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var konum = _konumService.GetById(id);
            if (konum == null)
            {
                return HttpNotFound();
            }
            return View(konum);
        }

        // GET: EczaneNobet/Konum/Create
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Create()
        {
            //var users = _userService.GetList();
            //ViewBag.UserId = new SelectList(users, "Id", "UserName");
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            return View();
        }

        // POST: EczaneNobet/Konum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GrupId,Enlem,Boylam,BaslamaTarihi,Adi,Aciklama")] Konum konum)
        {
            var user = _userService.GetByUserName(User.Identity.Name);
            //konum.UserId = user.Id;
            konum.BaslamaTarihi = System.DateTime.Now;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            var users = _userService.GetList();
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            if (ModelState.IsValid)
            {
                _konumService.Insert(konum);
                TempData["MessageSuccess"] = konum.Aciklama;
               
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
            return View(konum);
        }

        // GET: EczaneNobet/Konum/Edit/5
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konum konum = _konumService.GetById(id);
            if (konum == null)
            {
                return HttpNotFound();
            }
            var users = _userService.GetList();
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi", konum.GrupId);
            return View(konum);
        }

        // POST: EczaneNobet/Konum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include = "Id,GrupId,Enlem,Boylam,BaslamaTarihi,BitisTarihi,Adi,Aciklama")] Konum konum)
        {
            if (ModelState.IsValid)
            {
                _konumService.Update(konum);
                return RedirectToAction("Index");
            }
            var gruplar = _grupService.GetList();
            ViewBag.GrupId = new SelectList(gruplar, "Id", "Adi");
            return View(konum);
        }

        // GET: EczaneNobet/Konum/Delete/5
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konum konum = _konumService.GetById(id);
            if (konum == null)
            {
                return HttpNotFound();
            }
            return View(konum);
        }

        // POST: EczaneNobet/Konum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Konum konum = _konumService.GetById(id);
            _konumService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
