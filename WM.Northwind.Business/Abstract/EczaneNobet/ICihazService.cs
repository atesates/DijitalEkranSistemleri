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
    public interface ICihazService
    {
        Cihaz GetById(int cihazId);
        List<Cihaz> GetList();
        //List<Cihaz> GetByCategory(int categoryId);
        void Insert(Cihaz cihaz);
        void Update(Cihaz cihaz);
        void Delete(int cihazId);
        CihazDetay GetDetayById(int cihazId);
        List<CihazDetay> GetDetaylar();
        List<CihazDetay> GetDetaylarListByUser(User user);
        List<CihazDetay> GetDetaylarListByEkranDetaylar(List<EkranDetay> ekranDetaylar);



    }
} 