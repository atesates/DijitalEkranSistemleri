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
    public interface IGrupUserService
    {
        GrupUser GetById(int grupUserId);
        List<GrupUser> GetList();
        //List<GrupUser> GetByCategory(int categoryId);
        void Insert(GrupUser grupUser);
        void Update(GrupUser grupUser);
        void Delete(int grupUserId);
        GrupUserDetay GetDetayById(int grupUserId);
        List <GrupUserDetay> GetDetaylar();
        List<GrupUserDetay> GetDetaylarListByUser(User user);

    }
} 