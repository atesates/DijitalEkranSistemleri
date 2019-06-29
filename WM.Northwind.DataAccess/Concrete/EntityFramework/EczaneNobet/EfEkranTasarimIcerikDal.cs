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
    public class EfEkranTasarimIcerikDal : EfEntityRepositoryBase<EkranTasarimIcerik, EczaneNobetContext>, IEkranTasarimIcerikDal
    {
        public EkranTasarimIcerikDetay GetDetay(Expression<Func<EkranTasarimIcerikDetay, bool>> filter)
        {
            using (var ctx = new EczaneNobetContext())
            {
                return ctx.EkranTasarimIcerikler
                    .Select(s => new EkranTasarimIcerikDetay
                    {
                        BoyutX = s.BoyutX,
                        BoyutY = s.BoyutY,
                        Id = s.Id,
                        KoordinatX = s.KoordinatX,
                        KoordinatY = s.KoordinatY,
                        EkranTasarimId = s.EkranTasarimId,
                        EkranTasarimBaslamaTarihi = s.EkranTasarim.BaslamaTarihi,
                        EkranTasarimSonDegisiklikTarihi = s.EkranTasarim.SonDegisiklikTarihi,
                        EkranIcerikAdi = s.EkranIcerik.Adi,
                        EkranIcerikId = s.EkranIcerikId,
                        EkranTasarimAdi = s.EkranTasarim.Adi,
                        Url = s.EkranIcerik.Url,
                        Uzanti = s.EkranIcerik.Uzanti,
                        
                    }).SingleOrDefault(filter);
            }
        }
        public List<EkranTasarimIcerikDetay> GetDetayList(Expression<Func<EkranTasarimIcerikDetay, bool>> filter = null)
        {
            using (var ctx = new EczaneNobetContext())
            {
                var liste = ctx.EkranTasarimIcerikler
                    .Select(s => new EkranTasarimIcerikDetay
                    {
                        BoyutX = s.BoyutX,
                        BoyutY = s.BoyutY,
                        Id = s.Id,
                        KoordinatX = s.KoordinatX,
                        KoordinatY = s.KoordinatY,
                        EkranTasarimId = s.EkranTasarimId,
                        EkranTasarimBaslamaTarihi = s.EkranTasarim.BaslamaTarihi,
                        EkranTasarimSonDegisiklikTarihi = s.EkranTasarim.SonDegisiklikTarihi,
                        EkranIcerikAdi = s.EkranIcerik.Adi,
                        EkranIcerikId = s.EkranIcerikId,
                        EkranTasarimAdi = s.EkranTasarim.Adi,
                        Url = s.EkranIcerik.Url,
                        Uzanti = s.EkranIcerik.Uzanti
                    });

                return filter == null
                    ? liste.ToList()
                    : liste.Where(filter).ToList();
            }
        }
    }
}