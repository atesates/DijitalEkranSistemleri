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
    public interface IKonumService
    {
        Konum GetById(int konumId);
        List<Konum> GetList();
        //List<Konum> GetByCategory(int categoryId);
        void Insert(Konum konum);
        void Update(Konum konum);
        void Delete(int konumId);
        List<KonumDetay> GetDetaylarListByUser(User user);
        List<KonumDetay> GetDetaylar();


    }
} 