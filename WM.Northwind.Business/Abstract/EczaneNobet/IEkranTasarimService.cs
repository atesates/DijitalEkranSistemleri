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
    public interface IEkranTasarimService
    {
        EkranTasarim GetById(int ekranTasarimId);
        List<EkranTasarim> GetList();
        //List<EkranTasarim> GetByCategory(int categoryId);
        void Insert(EkranTasarim ekranTasarim);
        void Update(EkranTasarim ekranTasarim);
        void Delete(int ekranTasarimId);
        List<EkranTasarimDetay> GetDetaylarListByUser(User user);
        EkranTasarimDetay GetDetayById(int ekranTasarimId);
        List<EkranTasarimDetay> GetDetaylar();
        List<EkranTasarimDetay> GetDetaylarById(List<int> ekranTasarimIdler);


    }
} 