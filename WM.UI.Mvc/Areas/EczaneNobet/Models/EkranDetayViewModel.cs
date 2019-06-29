using System;
using System.Collections.Generic;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Models
{
    public class EkranDetayViewModel
    {
        //public List<Cihaz> Cihazlar { get; set; }
        //public List<Monitor> Monitorler { get; set; }
        public List<EkranDetay> EkranDetaylar { get; set; }
        public List<CihazDetay> CihazDetaylar { get; set; }
        public List<KonumDetay> Konumlar { get; set; }
        public List<EkranIcerikDetay> EkranIcerikDetaylar { get; set; }
        public List<EkranTasarimDetay> EkranTasarimDetaylar { get; set; }
        public List<UserRoleDetay> UserRoleDetaylar { get; set; }
        public List<YayinEkranDetay> YayinEkranDetaylar { get; set; }


    }
}