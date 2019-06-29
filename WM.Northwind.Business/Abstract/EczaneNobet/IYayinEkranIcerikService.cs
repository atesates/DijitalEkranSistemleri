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
    public interface IYayinEkranIcerikService
    {
        YayinEkranIcerik GetById(int yayinEkranIcerikId);
        List<YayinEkranIcerik> GetList();
        //List<YayinEkranIcerik> GetByCategory(int categoryId);
        void Insert(YayinEkranIcerik yayinEkranIcerik);
        void Update(YayinEkranIcerik yayinEkranIcerik);
        void Delete(int yayinEkranIcerikId);
        YayinEkranIcerikDetay GetDetayById(int yayinEkranIcerikId);
        List <YayinEkranIcerikDetay> GetDetaylar();
        List <YayinEkranIcerikDetay> GetDetayByEkranIcerikId(int ekranIcerikId);
        List<YayinEkranIcerikDetay> GetDetaylarByEkranIdByEkranIcerikIdByDate(int yayinEkranId, int ekranIcerikId, DateTime baslangicZamani);
        List<YayinEkranIcerikDetay> GetDetaylarByEkranIdByEkranIcerikId(int yayinEkranId, int ekranIcerikId);
        List<YayinEkranIcerikDetay> GetDetaylarByUser(User user);


    }
} 