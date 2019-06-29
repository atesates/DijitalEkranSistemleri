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
//using WM.Northwind.Entities.Concrete.Optimization.EczaneNobet;
//using WM.Optimization.Abstract.Samples;

namespace WM.Northwind.Business.Concrete.Managers.EczaneNobet
{
    public class CihazDurumManager : ICihazDurumService
    {
        private ICihazDurumDal _CihazDurumDal;

        public CihazDurumManager(ICihazDurumDal CihazDurumDal)
        {
            _CihazDurumDal = CihazDurumDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int CihazDurumId)
        {
            _CihazDurumDal.Delete(new CihazDurum { Id = CihazDurumId });
        }

        public CihazDurum GetById(int CihazDurumId)
        {
            return _CihazDurumDal.Get(x => x.Id == CihazDurumId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<CihazDurum> GetList()
        {
            return _CihazDurumDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(CihazDurum CihazDurum)
        {
            _CihazDurumDal.Insert(CihazDurum);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(CihazDurum CihazDurum)
        {
            _CihazDurumDal.Update(CihazDurum);
        }
        
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<CihazDurum> GetListByRoleId(int roleId)
        {
            if(roleId != 1)//admin olmayana deomain değişti gelmesin
                return _CihazDurumDal.GetList(w=>w.Id!=5);
            else
                return _CihazDurumDal.GetList();
        }
    } 
}