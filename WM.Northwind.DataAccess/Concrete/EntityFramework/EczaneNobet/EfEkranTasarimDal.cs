using System;
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
    public class EfEkranTasarimDal : EfEntityRepositoryBase<EkranTasarim, EczaneNobetContext>, IEkranTasarimDal
    {
        public EkranTasarimDetay GetDetay(Expression<Func<EkranTasarimDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.EkranTasarimlar
                    .Select(s => new EkranTasarimDetay
                    {
                        Aciklama = s.Aciklama,
                        Adi = s.Adi,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        Id = s.Id,
                        SonDegisiklikTarihi = s.SonDegisiklikTarihi,
                        GrupAdi = s.Grup.Adi,

                    }).SingleOrDefault(filter);
            }
        }
        public List<EkranTasarimDetay> GetDetayList(Expression<Func<EkranTasarimDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.EkranTasarimlar
                    .Select(s => new EkranTasarimDetay
                    {
                        Aciklama = s.Aciklama,
                        Adi = s.Adi,
                        BaslamaTarihi = s.BaslamaTarihi,
                        BitisTarihi = s.BitisTarihi,
                        Id = s.Id,
                        SonDegisiklikTarihi = s.SonDegisiklikTarihi,
                        GrupAdi = s.Grup.Adi,


                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}