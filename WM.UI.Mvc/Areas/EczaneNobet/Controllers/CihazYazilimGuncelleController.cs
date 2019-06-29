using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WM.Core.Aspects.PostSharp.TranstionAspects;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Controllers
{
    public class CihazYazilimGuncelleController : Controller
    {
     
        public ActionResult YazilimEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazilimEdit(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/RaspVersion/"),
                                                 Path.GetFileName(file.FileName));
                    //WebImage img = new WebImage(file.InputStream);
                    

                    //img.Save(path);
                    file.SaveAs(path);
                    TempData["MessageSuccess"] = "Dosya başarıyla yüklendi.";
                }
                catch (Exception ex)
                {
                    TempData["MessageDanger"] = "HATA:" + ex.Message.ToString();
                }
            else
            {
                TempData["MessageDanger"]  = "Dosya seçmediniz.";
            }
            return RedirectToAction("YazilimEdit", "CihazYazilimGuncelle");


           


        }
    }
}