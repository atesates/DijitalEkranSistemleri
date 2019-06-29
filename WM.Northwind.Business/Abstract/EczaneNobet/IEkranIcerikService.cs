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
    public interface IEkranIcerikService
    {
        EkranIcerik GetById(int ekranIcerikId);
        List<EkranIcerik> GetList();
        //List<EkranIcerik> GetByCategory(int categoryId);
        void Insert(EkranIcerik ekranIcerik);
        void Update(EkranIcerik ekranIcerik);
        void Delete(int ekranIcerikId);
        EkranIcerikDetay GetDetayById(int ekranIcerikId);
        List<EkranIcerikDetay> GetDetaylar();
        List<EkranIcerikDetay> GetDetaylarListByUser(User user);
        List<EkranIcerikDetay> GetDetaylarById(List<int> ekranIcerikIdler);


    }
} 