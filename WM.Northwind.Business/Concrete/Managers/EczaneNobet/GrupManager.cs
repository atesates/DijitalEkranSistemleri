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
    public class GrupManager : IGrupService
    {
        private IGrupDal _GrupDal;
        private IGrupUserDal _GrupUserDal;

        public GrupManager(IGrupDal GrupDal, 
            IGrupUserDal GrupUserDal
            )
        {
            _GrupDal = GrupDal;
            _GrupUserDal = GrupUserDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int GrupId)
        {
            _GrupDal.Delete(new Grup { Id = GrupId });
        }

        public Grup GetById(int GrupId)
        {
            return _GrupDal.Get(x => x.Id == GrupId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<Grup> GetList()
        {
            return _GrupDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(Grup Grup)
        {
            _GrupDal.Insert(Grup);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Grup Grup)
        {
            _GrupDal.Update(Grup);
        }
        
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Grup> GetListByUser(User user)
        {
            var gruplar = _GrupUserDal.GetList(w => w.User.Id == user.Id).Select(s => s.GrupId).ToList();
            return _GrupDal.GetList(w => gruplar.Contains(w.Id));
        }
    } 
}