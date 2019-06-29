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
    public class EkranManager : IEkranService
    {
        private IEkranDal _ekranDal;
        private IGrupDal _grupDal;
        private IGrupUserDal _grupUserDal;

        public EkranManager(IEkranDal ekranDal,
                                IGrupDal grupDal, 
                                IGrupUserDal grupUserDal)
        {
            _ekranDal = ekranDal;
            _grupDal = grupDal;
            _grupUserDal = grupUserDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int ekranId)
        {
            _ekranDal.Delete(new Ekran { Id = ekranId });
        }

        public Ekran GetById(int ekranId)
        {
            return _ekranDal.Get(x => x.Id == ekranId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<Ekran> GetList()
        {
            return _ekranDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(Ekran ekran)
        {
            _ekranDal.Insert(ekran);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Ekran ekran)
        {
            _ekranDal.Update(ekran);
        }

        public EkranDetay GetDetayById(int ekranId)
        {
           return _ekranDal.GetDetay(x => x.Id == ekranId);
        }
            
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranDetay> GetDetaylar()
        {
           return _ekranDal.GetDetayList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranDetay> GetDetaylarListByUser(User user)
        {
            var ekranlar = _ekranDal.GetList();             
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s=>s.GrupId).ToList();
            var ekranIdler = ekranlar.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _ekranDal.GetDetayList(w=> ekranIdler.Contains(w.Id));
        }

        public EkranDetay GetDetayByKonumId(int konumId)
        {
            return _ekranDal.GetDetay(x => x.KonumId == konumId);
        }

        public EkranDetay GetDetayByCihazId(int cihazId)
        {
            return _ekranDal.GetDetay(x => x.CihazId == cihazId);
        }

     
    }
}