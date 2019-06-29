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
    public class YayinEkranIcerikManager : IYayinEkranIcerikService
    {
        private IYayinEkranIcerikDal _yayinEkranIcerikDal;
        private IGrupUserDal _grupUserDal;
        private IEkranIcerikDal _ekranIcerikDal;

        public YayinEkranIcerikManager(IYayinEkranIcerikDal yayinEkranIcerikDal,
                                    IEkranIcerikDal ekranIcerikDal,
                                    IGrupUserDal grupUserDal)
        {
            _yayinEkranIcerikDal = yayinEkranIcerikDal;
            _grupUserDal = grupUserDal;
            _ekranIcerikDal = ekranIcerikDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int yayinEkranIcerikId)
        {
            _yayinEkranIcerikDal.Delete(new YayinEkranIcerik { Id = yayinEkranIcerikId });
        }

        public YayinEkranIcerik GetById(int yayinEkranIcerikId)
        {
            return _yayinEkranIcerikDal.Get(x => x.Id == yayinEkranIcerikId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranIcerik> GetList()
        {
            return _yayinEkranIcerikDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(YayinEkranIcerik yayinEkranIcerik)
        {
            _yayinEkranIcerikDal.Insert(yayinEkranIcerik);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(YayinEkranIcerik yayinEkranIcerik)
        {
            _yayinEkranIcerikDal.Update(yayinEkranIcerik);
        }
        public YayinEkranIcerikDetay GetDetayById(int yayinEkranIcerikId)
        {
            return _yayinEkranIcerikDal.GetDetay(x => x.Id == yayinEkranIcerikId);
        }
            
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranIcerikDetay> GetDetaylar()
        {
            return _yayinEkranIcerikDal.GetDetayList();
        }

        //List <YayinEkranIcerikDetay> GetDetayByEkranIcerikId(int ekranIcerikId);
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranIcerikDetay> GetDetayByEkranIcerikId(int ekranIcerikId)
        {
            return _yayinEkranIcerikDal.GetDetayList(x => x.EkranIcerikId == ekranIcerikId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranIcerikDetay> GetDetaylarByEkranIdByEkranIcerikIdByDate(int yayinEkranId, int ekranIcerikId, DateTime baslangicZamani)
        {
            return _yayinEkranIcerikDal.GetDetayList(x => x.YayinEkranId == yayinEkranId && x.BaslamaZamani == baslangicZamani && x.EkranIcerikId == ekranIcerikId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranIcerikDetay> GetDetaylarByEkranIdByEkranIcerikId(int yayinEkranId, int ekranIcerikId)
        {
            return _yayinEkranIcerikDal.GetDetayList(x => x.YayinEkranId == yayinEkranId && x.EkranIcerikId == ekranIcerikId);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<YayinEkranIcerikDetay> GetDetaylarByUser(User user)
        {
            var ekranIceriklar = _ekranIcerikDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            var ekranIcerikIdler = ekranIceriklar.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _yayinEkranIcerikDal.GetDetayList(w => ekranIcerikIdler.Contains(w.EkranIcerikId));
        }
    } 
}