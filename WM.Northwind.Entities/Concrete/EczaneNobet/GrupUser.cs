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
    public class GrupUser : IEntity
    {
        public int Id { get; set; }
        public int GrupId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Grup Grup { get; set; }

    }
}