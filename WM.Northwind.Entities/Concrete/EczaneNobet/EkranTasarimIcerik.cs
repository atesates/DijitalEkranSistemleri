using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Northwind.Entities.Concrete.EczaneNobet
{
    public class EkranTasarimIcerik : IEntity
    {
        public int Id { get; set; }
        public int EkranTasarimId { get; set; }
        public int EkranIcerikId { get; set; }
        public double BoyutX { get; set; }
        public double BoyutY { get; set; }
        public double KoordinatX { get; set; }
        public double KoordinatY { get; set; }
        public virtual EkranIcerik EkranIcerik { get; set; }
        public virtual EkranTasarim EkranTasarim { get; set; }

    }
}