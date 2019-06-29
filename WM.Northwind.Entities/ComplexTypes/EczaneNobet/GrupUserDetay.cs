using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;
using WM.Northwind.Entities.Concrete.EczaneNobet;


namespace WM.Northwind.Entities.ComplexTypes.EczaneNobet
{
    public class GrupUserDetay: IComplexType
 { 
        public int Id { get; set; }
        public int GrupId { get; set; }
        public int UserId { get; set; }
        public string GrupAdi { get; set; }
        public string UserAdi { get; set; }

    } 
} 