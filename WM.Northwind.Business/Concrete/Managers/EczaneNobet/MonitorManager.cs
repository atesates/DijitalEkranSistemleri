using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Business.Abstract;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.DataAccess.Abstract.EczaneNobet;
using WM.Core.Aspects.PostSharp.CacheAspects;
using WM.Core.CrossCuttingConcerns.Caching.Microsoft;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
using WM.Northwind.Entities.Concrete.Authorization;
//using WM.Northwind.Entities.Concrete.Optimization.EczaneNobet;
//using WM.Optimization.Abstract.Samples;

namespace WM.Northwind.Business.Concrete.Managers.EczaneNobet
{
    public class MonitorManager : IMonitorService
    {
        private IMonitorDal _monitorDal;
        private IGrupUserDal _grupUserDal;
        private IGrupDal _grupDal;

        public MonitorManager(IMonitorDal monitorDal,
            IGrupDal grupDal,
            IGrupUserDal grupUserDal)
        {
            _monitorDal = monitorDal;
            _grupUserDal = grupUserDal;
            _grupDal = grupDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int monitorId)
        {
            _monitorDal.Delete(new Monitor { Id = monitorId });
        }

        public Monitor GetById(int monitorId)
        {
            return _monitorDal.Get(x => x.Id == monitorId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<Monitor> GetList()
        {
            return _monitorDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(Monitor monitor)
        {
            _monitorDal.Insert(monitor);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Monitor monitor)
        {
            _monitorDal.Update(monitor);
        }
        public MonitorDetay GetDetayById(int monitorId)
        {
            return _monitorDal.GetDetay(x => x.Id == monitorId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<MonitorDetay> GetDetaylarListByUser(User user)
        {
            var monitorler = _monitorDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            var monitorIdler = monitorler.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _monitorDal.GetDetayList(w => monitorIdler.Contains(w.Id));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<MonitorDetay> GetDetaylar()
        {
            return _monitorDal.GetDetayList();
        }
    } 
}