using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;
using WM.Northwind.Entities.Concrete.Authorization;

namespace WM.Northwind.Entities.Concrete.EczaneNobet
{
    public class Ekran : IEntity
    {
        public int Id { get; set; }
        public int MonitorId { get; set; }
        public int KonumId { get; set; }
        public int CihazId { get; set; }
        public int GrupId { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
        public string EkranUrl { get; set; }


        public virtual Grup Grup { get; set; }
        public virtual Konum Konum { get; set; }
        public virtual Cihaz Cihaz { get; set; }
        public virtual Monitor Monitor { get; set; }
        public virtual List<YayinEkran> YayinEkranlar { get; set; }

    }
}