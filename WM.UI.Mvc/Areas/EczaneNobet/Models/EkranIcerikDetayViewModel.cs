using System;
using System.Collections.Generic;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Models
{
    public class EkranIcerikDetayViewModel
    {
        //public List<Cihaz> Cihazlar { get; set; }
        //public List<Monitor> Monitorler { get; set; }
        public List<EkranIcerikDetay> EkranIcerikDetaylar { get; set; }
        public List<UserRoleDetay> UserRoleDetaylar { get; set; }


    }
}