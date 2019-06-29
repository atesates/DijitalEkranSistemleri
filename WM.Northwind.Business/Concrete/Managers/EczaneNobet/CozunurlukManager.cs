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
    public class CozunurlukManager : ICozunurlukService
    {
        private ICozunurlukDal _cozunurlukDal;

        public CozunurlukManager(ICozunurlukDal cozunurlukDal)
        {
            _cozunurlukDal = cozunurlukDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int cozunurlukId)
        {
            _cozunurlukDal.Delete(new Cozunurluk { Id = cozunurlukId });
        }

        public Cozunurluk GetById(int cozunurlukId)
        {
            return _cozunurlukDal.Get(x => x.Id == cozunurlukId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<Cozunurluk> GetList()
        {
            return _cozunurlukDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(Cozunurluk cozunurluk)
        {
            _cozunurlukDal.Insert(cozunurluk);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Cozunurluk cozunurluk)
        {
            _cozunurlukDal.Update(cozunurluk);
        }
                        

    } 
}