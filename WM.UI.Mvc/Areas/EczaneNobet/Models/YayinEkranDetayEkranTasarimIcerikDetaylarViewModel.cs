using System;
using System.Collections.Generic;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Models
{
    public class YayinEkranDetayEkranTasarimIcerikDetaylarViewModel
    {
        //public List<Sektor> Sektorler { get; set; }
        public YayinEkranDetay YayinEkranDetay { get; set; }
        public List<EkranTasarimIcerikDetaylarViewModel> EkranTasarimIcerikDetaylarViewModeller { get; set; }


    }
}