using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.UI.Mvc.Areas.EczaneNobet.Models;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    [HandleError]
    public class EkranTasarimIcerikController : Controller
    {
        #region ctor
        private IUserService _userService;
        private IGrupUserService _grupUserService;
        private ICihazService _cihazService;
        private IUserRoleService _userRoleService;
        private IEkranService _ekranService;
        private IYayinEkranService _yayinEkranService;
        private IEkranIcerikService _ekranIcerikService;
        private IEkranTasarimIcerikService _ekranTasarimIcerikService;
        private IEkranTasarimService _ekranTasarimService;
        private IKonumService _konumService;


        public EkranTasarimIcerikController(IUserService userService,
                                     IUserRoleService userRoleService,
                                      ICihazService cihazService,
                                      IGrupUserService grupUserService,
                                      IEkranService ekranService,
                                      IYayinEkranService yayinEkranService,
                                      IEkranIcerikService ekranIcerikService,
                                      IEkranTasarimService ekranTasarimService,
                                      IEkranTasarimIcerikService ekranTasarimIcerikService,
                                      IKonumService konumService
        )
        {
            _userService = userService;
            _ekranService = ekranService;
            _userRoleService = userRoleService;
            _cihazService = cihazService;
            _ekranIcerikService = ekranIcerikService;
            _ekranTasarimService = ekranTasarimService;
            _konumService = konumService;
            _grupUserService = grupUserService;
            _ekranTasarimIcerikService = ekranTasarimIcerikService;
            _yayinEkranService = yayinEkranService;
        }
        #endregion
        public ActionResult Index()
        {
          
            return View();
        }
  
        // GET: AlimNobet/EkranIcerik/Create
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Create()
        {

            var user = _userService.GetByUserName(User.Identity.Name);
            var rolId = _userRoleService.GetListByUserId(user.Id).FirstOrDefault().RoleId;
            var ekranTasarimler = _ekranTasarimService.GetDetaylarListByUser(user).ToList();
            var ekranIcerikler = _ekranIcerikService.GetDetaylarListByUser(user).ToList();
            if (rolId == 2)
            {
                ekranTasarimler = _ekranTasarimService.GetDetaylar();
                ekranIcerikler = _ekranIcerikService.GetDetaylar();
            }
            ViewBag.EkranTasarimId = new SelectList(ekranTasarimler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            ViewBag.EkranIcerikId = new SelectList(ekranIcerikler.Select(s => new { s.Id, s.Adi }), "Id", "Adi");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EkranTasarimId,EkranIcerikId")] EkranTasarimIcerik ekranTasarimIcerik)
        {//,BaslamaSaati, BaslamaDakikasi, BitisSaati, BitisDakikasi

            if (ModelState.IsValid)
            {
                ekranTasarimIcerik.BoyutX = 50;
                ekranTasarimIcerik.BoyutY = 30;
                ekranTasarimIcerik.KoordinatX = 1;
                ekranTasarimIcerik.KoordinatY = 1;

                _ekranTasarimIcerikService.Insert(ekranTasarimIcerik);
                return RedirectToAction("Index", "EkranTasarim");
            }

            //ViewBag.EkranId = new SelectList(_ekranService.GetList().Select(s => new { s.Id, s.Konum.Adi }), "Id", "Adi", yayinEkran.Ekran.Konum.Adi);
            return View(ekranTasarimIcerik);
        }
     
        // GET: EczaneNobet/Eczane/Delete/5
        [Authorize(Roles = "Admin, Grup Yönetici")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EkranTasarimIcerik ekranTasarimIcerik = _ekranTasarimIcerikService.GetById(id);
            if (ekranTasarimIcerik == null)
            {
                return HttpNotFound();
            }
            return View(ekranTasarimIcerik);
        }
        // POST: EczaneNobet/Eczane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EkranTasarimIcerik ekranTasarimIcerik = _ekranTasarimIcerikService.GetById(id);
                _ekranTasarimIcerikService.Delete(id);
                TempData["MessageSuccess"] = "Ekran iceriği başarıyla silinmiştir.";
            }
            catch (Exception ex)
            {
                TempData["MessageDanger"] = "ERROR:" + ex.InnerException.InnerException.Message.ToString();
            }
            return RedirectToAction("Index", "EkranTasarim");
        }

    }
}