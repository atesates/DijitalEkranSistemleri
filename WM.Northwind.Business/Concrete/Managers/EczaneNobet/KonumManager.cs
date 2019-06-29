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
    public class KonumManager : IKonumService
    {
        private IKonumDal _konumDal;
        private IGrupDal _grupDal;
        private IGrupUserDal _grupUserDal;

        public KonumManager(IKonumDal konumDal,
            IGrupDal grupDal,
            IGrupUserDal grupUserDal
            )
        {
            _konumDal = konumDal;
            _grupDal = grupDal;
            _grupUserDal = grupUserDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int konumId)
        {
            _konumDal.Delete(new Konum { Id = konumId });
        }

        public Konum GetById(int konumId)
        {
            return _konumDal.Get(x => x.Id == konumId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<Konum> GetList()
        {
            return _konumDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(Konum konum)
        {
            _konumDal.Insert(konum);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Konum konum)
        {
            _konumDal.Update(konum);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<KonumDetay> GetDetaylarListByUser(User user)
        {
            var konumlar = _konumDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            var konumIdler = konumlar.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _konumDal.GetDetayList(w => konumIdler.Contains(w.Id));
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<KonumDetay> GetDetaylar()
        {
            return _konumDal.GetDetayList();
        }
    } 
}