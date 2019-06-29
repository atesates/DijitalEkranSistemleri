using System;
using System.Collections.Generic;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Models
{
    public class EkranDetayYayinEkranDetayEkranTasarimIcerikDetaylarViewModel
    {
       
        public EkranDetay EkranDetay { get; set; }
        public List<YayinEkranDetayEkranTasarimIcerikDetaylarViewModel> YayinEkranDetayEkranTasarimIcerikDetaylarViewModeller { get; set; }
        public List<UserRoleDetay> UserRoleDetay { get; set; }

    }
}