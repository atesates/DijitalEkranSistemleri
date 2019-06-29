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
    public class Grup : IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public virtual List<Ekran> Ekranlar { get; set; }
        public virtual List<EkranTasarim> EkranTasarimlar { get; set; }
        public virtual List<EkranIcerik> EkranIcerikler { get; set; }
        public virtual List<Cihaz> Cihazlar { get; set; }
        public virtual List<Konum> Konumlar { get; set; }
        public virtual List<Monitor> Monitorler { get; set; }
        public virtual List<GrupUser> GrupUserlar { get; set; }


    }
}