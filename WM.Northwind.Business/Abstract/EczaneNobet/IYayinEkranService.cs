using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
using WM.Northwind.Entities.Concrete.EczaneNobet;
//using WM.Northwind.Entities.Concrete.Optimization.EczaneNobet;

namespace WM.Northwind.Business.Abstract.EczaneNobet
{
    public interface IYayinEkranService
    {
        YayinEkran GetById(int yayinEkranId);
        List<YayinEkran> GetList();
        //List<YayinEkran> GetByCategory(int categoryId);
        void Insert(YayinEkran yayinEkran);
        void Update(YayinEkran yayinEkran);
        void Delete(int yayinEkranId);
        YayinEkranDetay GetDetayById(int yayinEkranId);
        YayinEkranDetay GetDetayByIdByDate(int yayinEkranId, DateTime time);
        List<YayinEkranDetay> GetDetaylarByIdlerByDate(List<int> yayinEkranIdler, DateTime time);
        List<YayinEkranDetay> GetDetaylarByEkranIdler(List<int> yayinEkranIdler);
        List<YayinEkranDetay> GetDetaylarByEkranId(int ekranId);
        List<YayinEkranDetay> GetDetaylarByEkranIdByEkranTasarimId(int ekranId, int ekranTasarimId);
        List<YayinEkranDetay> GetDetaylar();
        List<YayinEkranDetay> GetDetaylarByUser(User user);
    }
} 