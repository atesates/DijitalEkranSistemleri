using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Northwind.Entities.Concrete.EczaneNobet
{
    public class YayinEkranIcerik : IEntity
    {
        public int Id { get; set; }
        public int EkranIcerikId { get; set; }
        public int Alan { get; set; }
        public int YayinEkranId { get; set; }
        public DateTime BaslamaZamani { get; set; }
        public DateTime? BitisZamani { get; set; }

        public virtual EkranIcerik EkranIcerik { get; set; }
        public virtual YayinEkran YayinEkran { get; set; }

    }
}