using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
//using WM.Northwind.Entities.Concrete.Optimization.EczaneNobet;

namespace WM.Northwind.Business.Abstract.EczaneNobet
{
    public interface IEkranTasarimIcerikService
    {
        EkranTasarimIcerik GetById(int ekranTasarimIcerikId);
        List<EkranTasarimIcerik> GetList();
        //List<EkranTasarimIcerik> GetByCategory(int categoryId);
        void Insert(EkranTasarimIcerik ekranTasarimIcerik);
        void Update(EkranTasarimIcerik ekranTasarimIcerik);
        void Delete(int ekranTasarimIcerikId);
        EkranTasarimIcerikDetay GetDetayById(int ekranTasarimIcerikId);
        List<EkranTasarimIcerikDetay> GetDetaylar();
        List<EkranTasarimIcerikDetay> GetDetaylarListByEkranTasarimId(int ekranTasarimId);
        List<EkranTasarimIcerikDetay> GetDetaylarListByEkranIcerikId(int ekranIcerikId);
        List<EkranTasarimIcerikDetay> GetDetaylarListByEkranIcerikIdEkranTasarimId(int ekranIcerikId, int ekranTasarimId);

    }
} 