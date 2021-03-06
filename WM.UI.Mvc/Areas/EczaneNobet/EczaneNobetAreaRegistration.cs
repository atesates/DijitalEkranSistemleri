﻿using System.Web.Mvc;

namespace WM.UI.Mvc.Areas.EczaneNobet
{
    public class EczaneNobetAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EczaneNobet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            #region ekle

            context.MapRoute(
                    name: "EczaneCreate",
                    url: "eczane-ekle",
                    defaults: new { controller = "Eczane", action = "Create" }
                );

            context.MapRoute(
                name: "EczaneNobetMazeretCreate",
                url: "eczane-nobet-mazeret-ekle",
                defaults: new { controller = "EczaneNobetMazeret", action = "Create" }
            );

            context.MapRoute(
                name: "EczaneNobetIstekCreate",
                url: "eczane-nobet-istek-ekle",
                defaults: new { controller = "EczaneNobetIstek", action = "Create" }
            );

            context.MapRoute(
                name: "NobetGrupCreate",
                url: "en/nobet-grup-ekle",
                defaults: new { controller = "NobetGrup", action = "Create" }
            );

            context.MapRoute(
                name: "EczaneNobetGrupCreate",
                url: "eczane-nobet-grup-ekle",
                defaults: new { controller = "EczaneNobetGrup", action = "Create" }
            );

            context.MapRoute(
                name: "EczaneGrupTanimCreate",
                url: "eczane-grup-tanim-ekle",
                defaults: new { controller = "EczaneGrupTanim", action = "Create" }
            );

            context.MapRoute(
                name: "NobeGrupOzelTakvimCreate",
                url: "nobet-grup-ozel-takvim-ekle",
                defaults: new { controller = "NobetGrupGorevTipTakvimOzelGun", action = "Create" }
            );

            context.MapRoute(
                name: "NobeGrupGunKuralCreate",
                url: "nobet-grup-haftanin-gunleri-ekle",
                defaults: new { controller = "NobetGrupGorevTipGunKural", action = "Create" }
            );

            context.MapRoute(
                name: "Create",
                url: "eczane-nobet/{controller}/ekle",
                defaults: new { action = "Create" }
            );

            #endregion

            #region düzenle

            context.MapRoute(
                    name: "EczaneEdit",
                    url: "eczane-duzenle/{id}",
                    defaults: new { controller = "Eczane", action = "Edit", id = UrlParameter.Optional }
                );

            context.MapRoute(
                name: "EczaneNobetMazeretEdit",
                url: "eczane-nobet-mazeret-duzenle/{id}",
                defaults: new { controller = "EczaneNobetMazeret", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneNobetIstekEdit",
                url: "eczane-nobet-istek-duzenle/{id}",
                defaults: new { controller = "EczaneNobetIstek", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobetGrupEdit",
                url: "en/nobet-grup-duzenle/{id}",
                defaults: new { controller = "NobetGrup", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneNobetGrupEdit",
                url: "eczane-nobet-grup-duzenle/{id}",
                defaults: new { controller = "EczaneNobetGrup", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneGrupTanimEdit",
                url: "eczane-grup-tanim-duzenle/{id}",
                defaults: new { controller = "EczaneGrupTanim", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobeGrupOzelTakvimEdit",
                url: "nobet-grup-ozel-takvim-duzenle/{id}",
                defaults: new { controller = "NobetGrupGorevTipTakvimOzelGun", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobeGrupGunKuralEdit",
                url: "nobet-grup-haftanin-gunleri-duzenle/{id}",
                defaults: new { controller = "NobetGrupGorevTipGunKural", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Edit",
                "eczane-nobet/{controller}/duzenle/{id}",
                new { action = "Edit", id = UrlParameter.Optional }
            );

            #endregion

            #region sil

            context.MapRoute(
                    name: "EczaneDelete",
                    url: "eczane-sil/{id}",
                    defaults: new { controller = "Eczane", action = "Delete", id = UrlParameter.Optional }
                );

            context.MapRoute(
                name: "EczaneNobetMazeretDelete",
                url: "eczane-nobet-mazeret-sil/{id}",
                defaults: new { controller = "EczaneNobetMazeret", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneNobetIstekDelete",
                url: "eczane-nobet-istek-sil/{id}",
                defaults: new { controller = "EczaneNobetIstek", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobetGrupDelete",
                url: "en/nobet-grup-sil/{id}",
                defaults: new { controller = "NobetGrup", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneNobetGrupDelete",
                url: "eczane-nobet-grup-sil/{id}",
                defaults: new { controller = "EczaneNobetGrup", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneGrupTanimDelete",
                url: "eczane-grup-tanim-sil/{id}",
                defaults: new { controller = "EczaneGrupTanim", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobeGrupOzelTakvimDelete",
                url: "nobet-grup-ozel-takvim-sil/{id}",
                defaults: new { controller = "NobetGrupGorevTipTakvimOzelGun", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobeGrupGunKuralDelete",
                url: "nobet-grup-haftanin-gunleri-sil/{id}",
                defaults: new { controller = "NobetGrupGorevTipGunKural", action = "Delete", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Delete",
                "eczane-nobet/{controller}/sil/{id}",
                new { action = "Delete", id = UrlParameter.Optional }
            );

            #endregion

            #region detaylar

            context.MapRoute(
                    name: "EczaneDetails",
                    url: "eczane-detaylar/{id}",
                    defaults: new { controller = "Eczane", action = "Details", id = UrlParameter.Optional }
                );

            context.MapRoute(
                name: "EczaneNobetMazeretDetails",
                url: "eczane-nobet-mazeret-detaylar/{id}",
                defaults: new { controller = "EczaneNobetMazeret", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneNobetIstekDetails",
                url: "eczane-nobet-istek-detaylar/{id}",
                defaults: new { controller = "EczaneNobetIstek", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobetGrupDetails",
                url: "en/nobet-grup-detaylar/{id}",
                defaults: new { controller = "NobetGrup", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneNobetGrupDetails",
                url: "eczane-nobet-grup-detaylar/{id}",
                defaults: new { controller = "EczaneNobetGrup", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EczaneGrupTanimDetails",
                url: "eczane-grup-tanim-detaylar/{id}",
                defaults: new { controller = "EczaneGrupTanim", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobeGrupOzelTakvimDetails",
                url: "nobet-grup-ozel-takvim-detaylar/{id}",
                defaults: new { controller = "NobetGrupGorevTipTakvimOzelGun", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "NobeGrupGunKuralDetails",
                url: "nobet-grup-haftanin-gunleri-detaylar/{id}",
                defaults: new { controller = "NobetGrupGorevTipGunKural", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Details",
                "eczane-nobet/{controller}/detaylar/{id}",
                new { action = "Details", id = UrlParameter.Optional }
            );

            #endregion
            
            #region listeler

            context.MapRoute(
                name: "NobetYaz",
                url: "eczane-nobet-yaz",
                defaults: new { controller = "NobetYaz", action = "Index" }
            );

            context.MapRoute(
                name: "Eczane",
                url: "eczaneler",
                defaults: new { controller = "Eczane", action = "Index" }
            );

            context.MapRoute(
                name: "EczaneGrupTanim",
                url: "eczane-grup-tanimlar",
                defaults: new { controller = "EczaneGrupTanim", action = "Index" }
            );

            context.MapRoute(
                name: "EczaneNobetSonuc",
                url: "eczane-nobet-istatistikler",
                defaults: new { controller = "EczaneNobetSonuc", action = "PivotSonuclar" }
            );

            context.MapRoute(
                name: "EczaneNobetDegisim",
                url: "eczane-nobet-degisimler",
                defaults: new { controller = "EczaneNobetDegisim", action = "Index" }
            );

            context.MapRoute(
                name: "EczaneNobetDegistir",
                url: "eczane-nobet-degistir",
                defaults: new { controller = "EczaneNobetSonuc", action = "NobetDegistir" }
            );

            context.MapRoute(
                name: "NobetciEczaneHarita",
                url: "nobetci-eczane-harita",
                defaults: new { controller = "NobetciEczaneHarita", action = "Index" }
            );

            context.MapRoute(
                name: "EczaneNobetMazeret",
                url: "eczane-nobet-mazeret-ve-istekler",
                defaults: new { controller = "EczaneNobetMazeret", action = "Index" }
            );

            context.MapRoute(
                name: "EczaneNobetIstek",
                url: "eczane-nobet-istekler",
                defaults: new { controller = "EczaneNobetIstek", action = "Index" }
            );

            context.MapRoute(
                name: "NobetUstGrupKisitAyarla",
                url: "eczane-nobet-ayarlar",
                defaults: new { controller = "NobetUstGrupKisit", action = "KisitAyarla" }
            );


            context.MapRoute(
                name: "EczaneNobetSonucSil",
                url: "eczane-nobet-sil",
                defaults: new { controller = "EczaneNobetSonuc", action = "GelecekDonemSil" }
            );

            context.MapRoute(
                name: "NobetGrup",
                url: "en/nobet-gruplar",
                defaults: new { controller = "NobetGrup", action = "Index" }
            );

            context.MapRoute(
                name: "EczaneNobetGrup",
                url: "eczane-nobet-gruplar",
                defaults: new { controller = "EczaneNobetGrup", action = "Index" }
            );

            context.MapRoute(
                name: "NobeGrupOzelTakvim",
                url: "nobet-grup-ozel-takvim",
                defaults: new { controller = "NobetGrupGorevTipTakvimOzelGun", action = "Index" }
            );

            context.MapRoute(
                name: "NobeGrupGunKural",
                url: "nobet-grup-haftanin-gunleri",
                defaults: new { controller = "NobetGrupGorevTipGunKural", action = "Index" }
            );

            /*
                context.MapRoute(
                    "NobetGrup",
                    "NobetGrup",
                    new { controller = "NobetGrup", action = "Index" }
                );

                context.MapRoute(
                    "EczaneNobetGrup",
                    "EczaneNobetGrup",
                    new { controller = "EczaneNobetGrup", action = "Index" }
                );

                context.MapRoute(
                    "EczaneGrupTanim",
                    "EczaneGrupTanim",
                    new { controller = "EczaneGrupTanim", action = "Index" }
                );

                context.MapRoute(
                    "EczaneGrup",
                    "EczaneGrup",
                    new { controller = "EczaneGrup", action = "Index" }
                );
                context.MapRoute(
                    "NobetGrupKural",
                    "NobetGrupKural",
                    new { controller = "NobetGrupKural", action = "Index" }
                );

                context.MapRoute(
                    "EczaneNobetMazeret",
                    "EczaneNobetMazeret",
                    new { controller = "EczaneNobetMazeret", action = "Index" }
                );

                context.MapRoute(
                    "EczaneNobetIstek",
                    "EczaneNobetIstek",
                    new { controller = "EczaneNobetIstek", action = "Index" }
                );

                context.MapRoute(
                    "Eczane",
                    "Eczane",
                    new { controller = "Eczane", action = "Index" }
                );

                context.MapRoute(
                    "PivotSonuclar",
                    "PivotSonuclar",
                    new { controller = "EczaneNobetSonuc", action = "PivotSonuclar" }
                );

                context.MapRoute(
                    "GorselSonuclar",
                    "GorselSonuclar",
                    new { controller= "EczaneNobetSonuc", action = "GorselSonuclar"}
                );

                context.MapRoute(
                    "DemoPivotSonuclar",
                    "DemoPivotSonuclar",
                    new { controller = "EczaneNobetSonucDemo", action = "DemoPivot" }
                );

                context.MapRoute(
                    "DemoGorselSonuclar",
                    "DemoGorselSonuclar",
                    new { controller = "EczaneNobetSonucDemo", action = "GorselSonuclar" }
                );

                context.MapRoute(
                    "EczaneNobet",
                    "EczaneNobet",
                    new { controller = "EczaneNobet", action = "Index" }
                );
                */
            #endregion

            context.MapRoute(
                name: "NobetciEczaneler",
                url: "nobetci-eczaneler",
                defaults: new { controller = "NobetciEczaneHarita", action = "NobetciEczaneler" }
            );

            context.MapRoute(
            name: "EkranDigital",
            url: "onee/{cihazId}",///{name}/{password}",
                defaults: new
                {
                    controller = "EkranDigital",
                    action = "Index",
                    cihazId = UrlParameter.Optional,
                    //name = UrlParameter.Optional,
                    //password = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "EczaneNobet_default",
                "EczaneNobet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

          
        }
    }
}