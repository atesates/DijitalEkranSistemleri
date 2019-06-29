using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WM.Northwind.Business.Abstract;

namespace WM.UI.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminService _adminService;
        // GET: Admin
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            var osmaniye = new int[] { 10, 10, 10 };
            var zonguldak = new int[] { 41, 41, 41 };

           
            ViewBag.Osmaniye = osmaniye;
            ViewBag.Zonguldak = zonguldak;

            return View();
        }

    }
}