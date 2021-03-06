﻿using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WM.Core.DAL.EntityFramework;
using WM.Northwind.DataAccess.Abstract.EczaneNobet;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.DataAccess.Concrete.EntityFramework.EczaneNobet
{
    public class EfEkranIcerikDal : EfEntityRepositoryBase<EkranIcerik, EczaneNobetContext>, IEkranIcerikDal
    {
        public EkranIcerikDetay GetDetay(Expression<Func<EkranIcerikDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.EkranIcerikler
                    .Select(s => new EkranIcerikDetay
                    {
                        Adi = s.Adi,
                        Uzanti = s.Uzanti,
                        Id = s.Id,
                        Url = s.Url,
                        GrupAdi = s.Grup.Adi,

                    }).SingleOrDefault(filter);
            }
        }
        public List<EkranIcerikDetay> GetDetayList(Expression<Func<EkranIcerikDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.EkranIcerikler
                    .Select(s => new EkranIcerikDetay
                    {
                        Adi = s.Adi,
                        Uzanti = s.Uzanti,
                        Id = s.Id,
                        Url = s.Url,
                        GrupAdi = s.Grup.Adi,

                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}