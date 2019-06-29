using System;
using System.Collections.Generic;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Models
{
    public class EkranIcerikTasarimDetaylarViewModel
    {

        public EkranIcerikDetay EkranIcerikDetay { get; set; }
        public List<EkranTasarimDetay>  EkranTasarimDetaylar { get; set; }
        public List<EkranTasarimIcerikDetay> EkranTasarimIcerikDetaylar { get; set; }
        public List<UserRoleDetay> UserRoleDetay { get; set; }


    }
}