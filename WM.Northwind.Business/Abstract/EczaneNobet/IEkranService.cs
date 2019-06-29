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
    public interface IEkranService
    {
        Ekran GetById(int ekranId);
        List<Ekran> GetList();
        //List<Ekran> GetByCategory(int categoryId);
        void Insert(Ekran ekran);
        void Update(Ekran ekran);
        void Delete(int ekranId);
        EkranDetay GetDetayById(int ekranId);
        EkranDetay GetDetayByKonumId(int konumId);
        EkranDetay GetDetayByCihazId(int cihazId);
        List <EkranDetay> GetDetaylar();
        List <EkranDetay> GetDetaylarListByUser(User user);


    }
} 