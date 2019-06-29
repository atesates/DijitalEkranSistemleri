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
    public class GrupUserManager : IGrupUserService
    {
        private IGrupUserDal _grupUserDal;

        public GrupUserManager(IGrupUserDal grupUserDal)
        {
            _grupUserDal = grupUserDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int grupUserId)
        {
            _grupUserDal.Delete(new GrupUser { Id = grupUserId });
        }

        public GrupUser GetById(int grupUserId)
        {
            return _grupUserDal.Get(x => x.Id == grupUserId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<GrupUser> GetList()
        {
            return _grupUserDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(GrupUser grupUser)
        {
            _grupUserDal.Insert(grupUser);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(GrupUser grupUser)
        {
            _grupUserDal.Update(grupUser);
        }
        public GrupUserDetay GetDetayById(int grupUserId)
        {
            return _grupUserDal.GetDetay(x => x.Id == grupUserId);
        }
            
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<GrupUserDetay> GetDetaylar()
        {
            return _grupUserDal.GetDetayList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<GrupUserDetay> GetDetaylarListByUser(User user)
        {
            var grupUserlar = _grupUserDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            
            return _grupUserDal.GetDetayList(w => grupIdler.Contains(w.GrupId));
        }

    } 
}