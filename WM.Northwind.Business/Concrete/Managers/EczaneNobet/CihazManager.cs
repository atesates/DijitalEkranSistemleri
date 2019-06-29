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
    public class CihazManager : ICihazService
    {
        private ICihazDal _cihazDal;
        private IGrupUserDal _grupUserDal;
        private IEkranDal _ekranDal;

        public CihazManager(ICihazDal cihazDal, IGrupUserDal grupUserDal, IEkranDal ekranDal)
        {
            _cihazDal = cihazDal;
            _ekranDal = ekranDal;
            _grupUserDal = grupUserDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int cihazId)
        {
            _cihazDal.Delete(new Cihaz { Id = cihazId });
        }

        public Cihaz GetById(int cihazId)
        {
            return _cihazDal.Get(x => x.Id == cihazId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<Cihaz> GetList()
        {
            return _cihazDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(Cihaz cihaz)
        {
            _cihazDal.Insert(cihaz);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Cihaz cihaz)
        {
            _cihazDal.Update(cihaz);
        }
        public CihazDetay GetDetayById(int cihazId)
        {
            return _cihazDal.GetDetay(x => x.Id == cihazId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<CihazDetay> GetDetaylar()
        {
            return _cihazDal.GetDetayList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<CihazDetay> GetDetaylarListByUser(User user)
        {
            var cihazlar = _cihazDal.GetList();
            var grupIdler = _grupUserDal.GetList(w=>w.UserId == user.Id).Select(s=>s.GrupId).ToList();
            var cihazIdler = cihazlar.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _cihazDal.GetDetayList(w => cihazIdler.Contains(w.Id));
        }

        public List<CihazDetay> GetDetaylarListByEkranDetaylar(List<EkranDetay> ekranDetaylar)
        {
            var cihazIdler = ekranDetaylar.Select(s => s.CihazId);
            return  _cihazDal.GetDetayList(x => cihazIdler.Contains(x.Id));           
        }

    }
}