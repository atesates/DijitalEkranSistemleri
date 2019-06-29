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
    public class EkranIcerikManager : IEkranIcerikService
    {
        private IEkranIcerikDal _ekranIcerikDal;
        private IGrupUserDal _grupUserDal;

        public EkranIcerikManager(IEkranIcerikDal ekranIcerikDal,
                                    IGrupUserDal grupUserDal
                                    )
        {
            _ekranIcerikDal = ekranIcerikDal;
            _grupUserDal = grupUserDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int ekranIcerikId)
        {
            _ekranIcerikDal.Delete(new EkranIcerik { Id = ekranIcerikId });
        }

        public EkranIcerik GetById(int ekranIcerikId)
        {
            return _ekranIcerikDal.Get(x => x.Id == ekranIcerikId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranIcerik> GetList()
        {
            return _ekranIcerikDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(EkranIcerik ekranIcerik)
        {
            _ekranIcerikDal.Insert(ekranIcerik);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(EkranIcerik ekranIcerik)
        {
            _ekranIcerikDal.Update(ekranIcerik);
        }
        public EkranIcerikDetay GetDetayById(int ekranIcerikId)
        {
           return _ekranIcerikDal.GetDetay(x => x.Id == ekranIcerikId);
        }
            
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranIcerikDetay> GetDetaylar()
        {
           return _ekranIcerikDal.GetDetayList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranIcerikDetay> GetDetaylarById(List<int> ekranIcerikIdler)
        {
            return _ekranIcerikDal.GetDetayList(w=> ekranIcerikIdler .Contains( w.Id));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranIcerikDetay> GetDetaylarListByUser(User user)
        {
            var ekranIcerikler = _ekranIcerikDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            var ekranIcerikIdler = ekranIcerikler.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _ekranIcerikDal.GetDetayList(w => ekranIcerikIdler.Contains(w.Id));
        }
    } 
}