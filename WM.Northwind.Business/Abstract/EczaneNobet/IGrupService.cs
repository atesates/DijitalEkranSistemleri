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
    public interface IGrupService
    {
        Grup GetById(int GrupId);
        List<Grup> GetList();
        //List<Grup> GetByCategory(int categoryId);
        void Insert(Grup Grup);
        void Update(Grup Grup);
        void Delete(int GrupId);
        List<Grup> GetListByUser(User user);

    }
} 