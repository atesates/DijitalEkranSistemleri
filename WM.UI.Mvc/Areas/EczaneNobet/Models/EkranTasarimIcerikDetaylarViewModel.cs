using System;
using System.Collections.Generic;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.UI.Mvc.Areas.EczaneNobet.Models
{
    public class EkranTasarimIcerikDetaylarViewModel
    {
        //public List<Sektor> Sektorler { get; set; }
        public EkranDetay EkranDetay { get; set; }
        public EkranTasarimDetay EkranTasarimDetay { get; set; }
        public List<YayinEkranDetay> YayinEkranDetaylar { get; set; }
        public List<EkranIcerikDetay> EkranIcerikDetaylar { get; set; }
        public List<EkranTasarimIcerikDetay> EkranTasarimIcerikDetaylar { get; set; }
        public List<UserRoleDetay> UserRoleDetay { get; set; }
        public DateTime TasarimBaslamaZamani { get; set; }
        public DateTime? TasarimBitisZamani { get; set; }

    }
}