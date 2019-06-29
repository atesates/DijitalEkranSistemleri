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
    public class EkranTasarimIcerikManager : IEkranTasarimIcerikService
    {
        private IEkranTasarimIcerikDal _ekranTasarimIcerikDal;

        public EkranTasarimIcerikManager(IEkranTasarimIcerikDal ekranTasarimIcerikDal)
        {
            _ekranTasarimIcerikDal = ekranTasarimIcerikDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int ekranTasarimIcerikId)
        {
            _ekranTasarimIcerikDal.Delete(new EkranTasarimIcerik { Id = ekranTasarimIcerikId });
        }

        public EkranTasarimIcerik GetById(int ekranTasarimIcerikId)
        {
            return _ekranTasarimIcerikDal.Get(x => x.Id == ekranTasarimIcerikId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimIcerik> GetList()
        {
            return _ekranTasarimIcerikDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(EkranTasarimIcerik ekranTasarimIcerik)
        {
            _ekranTasarimIcerikDal.Insert(ekranTasarimIcerik);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(EkranTasarimIcerik ekranTasarimIcerik)
        {
            _ekranTasarimIcerikDal.Update(ekranTasarimIcerik);
        }
        public EkranTasarimIcerikDetay GetDetayById(int ekranTasarimIcerikId)
        {
            return _ekranTasarimIcerikDal.GetDetay(x => x.Id == ekranTasarimIcerikId);
        }
            
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimIcerikDetay> GetDetaylar()
        {
            return _ekranTasarimIcerikDal.GetDetayList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimIcerikDetay> GetDetaylarListByEkranTasarimId(int ekranTasarimId)
        {
            return _ekranTasarimIcerikDal.GetDetayList(w => w.EkranTasarimId == ekranTasarimId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimIcerikDetay> GetDetaylarListByEkranIcerikId(int ekranIcerikId)
        {
            return _ekranTasarimIcerikDal.GetDetayList(w => w.EkranIcerikId == ekranIcerikId);
        }
        //List<EkranTasarimIcerikDetay> GetDetaylarListByEkranIcerikIdEkranTasarimId(int ekranIcerikId, int ekranTasarimId);

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimIcerikDetay> GetDetaylarListByEkranIcerikIdEkranTasarimId(int ekranIcerikId, int ekranTasarimId)
        {
            return _ekranTasarimIcerikDal.GetDetayList(w => w.EkranIcerikId == ekranIcerikId && w.EkranTasarimId == ekranTasarimId);
        }
    }
}