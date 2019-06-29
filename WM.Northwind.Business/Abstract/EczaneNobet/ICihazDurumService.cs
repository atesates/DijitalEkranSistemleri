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
    public interface ICihazDurumService
    {
        CihazDurum GetById(int CihazDurumId);
        List<CihazDurum> GetList();
        //List<CihazDurum> GetByCategory(int categoryId);
        void Insert(CihazDurum CihazDurum);
        void Update(CihazDurum CihazDurum);
        void Delete(int CihazDurumId);
        List<CihazDurum> GetListByRoleId(int roleId);

    }
} 