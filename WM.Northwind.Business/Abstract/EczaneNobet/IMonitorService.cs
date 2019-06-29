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
    public interface IMonitorService
    {
        Monitor GetById(int monitorId);
        List<Monitor> GetList();
        //List<Monitor> GetByCategory(int categoryId);
        void Insert(Monitor monitor);
        void Update(Monitor monitor);
        void Delete(int monitorId);
        MonitorDetay GetDetayById(int monitorId);
        List<MonitorDetay> GetDetaylarListByUser(User user);
        List<MonitorDetay> GetDetaylar();


    }
} 