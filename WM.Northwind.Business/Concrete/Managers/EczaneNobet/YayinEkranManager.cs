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
    public class YayinEkranManager : IYayinEkranService
    {
        private IYayinEkranDal _yayinEkranDal;
        private IEkranDal _ekranDal;
        private IGrupUserDal _grupUserDal;

        public YayinEkranManager(IYayinEkranDal yayinEkranDal,
                                    IEkranDal ekranDal,
                                    IGrupUserDal grupUserDal)
        {
            _yayinEkranDal = yayinEkranDal;
            _ekranDal = ekranDal;
            _grupUserDal = grupUserDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int yayinEkranId)
        {
            _yayinEkranDal.Delete(new YayinEkran { Id = yayinEkranId });
        }

        public YayinEkran GetById(int yayinEkranId)
        {
            return _yayinEkranDal.Get(x => x.Id == yayinEkranId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkran> GetList()
        {
            return _yayinEkranDal.GetList();
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(YayinEkran yayinEkran)
        {
            _yayinEkranDal.Insert(yayinEkran);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(YayinEkran yayinEkran)
        {
            _yayinEkranDal.Update(yayinEkran);
        }

        public YayinEkranDetay GetDetayById(int yayinEkranId)
        {
            return _yayinEkranDal.GetDetay(x => x.Id == yayinEkranId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranDetay> GetDetaylar()
        {
            return _yayinEkranDal.GetDetayList();
        }
        
        public YayinEkranDetay GetDetayByIdByDate(int yayinEkranId, DateTime time)
        {
             return _yayinEkranDal.GetDetay(x => x.Id == yayinEkranId && x.BaslamaZamani < time && x.BitisZamani > time);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranDetay> GetDetaylarByIdlerByDate(List<int> yayinEkranIdler, DateTime time)
        {
            return _yayinEkranDal.GetDetayList(x => yayinEkranIdler.Contains(x.EkranId) && x.BaslamaZamani < time && x.BitisZamani > time);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranDetay> GetDetaylarByEkranIdler(List<int> yayinEkranIdler)
        {
            return _yayinEkranDal.GetDetayList(x => yayinEkranIdler.Contains(x.EkranId));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranDetay> GetDetaylarByEkranId(int ekranId)
        {
            return _yayinEkranDal.GetDetayList(x => ekranId == x.EkranId);
        }
        //List<YayinEkranDetay> GetDetaylarByEkranIdByEkranTasarimId(int ekranId, int ekranTasarimId);
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranDetay> GetDetaylarByEkranIdByEkranTasarimId(int ekranId, int ekranTasarimId)
        {
            return _yayinEkranDal.GetDetayList(x => ekranId == x.EkranId && x.EkranTasarimId == ekranTasarimId);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranDetay> GetDetaylarByUser(User user)
        {
            var ekranlar = _ekranDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            var ekranIdler = ekranlar.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();        
            return _yayinEkranDal.GetDetayList(w => ekranIdler.Contains(w.EkranId));
        }
    }
}