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
    public class EkranTasarimManager : IEkranTasarimService
    {
        #region ctor
        private IEkranTasarimDal _ekranTasarimDal;
        private IGrupDal _grupDal;
        private IGrupUserDal _grupUserDal;

        public EkranTasarimManager(IEkranTasarimDal ekranTasarimDal,
            IGrupDal grupDal,
            IGrupUserDal grupUserDal
            )
        {
            _ekranTasarimDal = ekranTasarimDal;
            _grupDal = grupDal;
            _grupUserDal = grupUserDal;
        }
        #endregion
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int ekranTasarimId)
        {
            _ekranTasarimDal.Delete(new EkranTasarim { Id = ekranTasarimId });
        }

        public EkranTasarim GetById(int ekranTasarimId)
        {
            return _ekranTasarimDal.Get(x => x.Id == ekranTasarimId);
        }
         [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarim> GetList()
        {
            return _ekranTasarimDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Insert(EkranTasarim ekranTasarim)
        {
            _ekranTasarimDal.Insert(ekranTasarim);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(EkranTasarim ekranTasarim)
        {
            _ekranTasarimDal.Update(ekranTasarim);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimDetay> GetDetaylarListByUser(User user)
        {
            var ekranTasarimlar = _ekranTasarimDal.GetList();
            var grupIdler = _grupUserDal.GetList(w => w.UserId == user.Id).Select(s => s.GrupId).ToList();
            var ekranTasarimIdler = ekranTasarimlar.Where(w => grupIdler.Contains(w.GrupId))
                .Select(s => s.Id).ToList();
            return _ekranTasarimDal.GetDetayList(w => ekranTasarimIdler.Contains(w.Id));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public EkranTasarimDetay GetDetayById(int ekranTasarimId)
        {
            return _ekranTasarimDal.GetDetayList(w => w.Id == ekranTasarimId).FirstOrDefault();
        }


        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimDetay> GetDetaylar()
        {
            return _ekranTasarimDal.GetDetayList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<EkranTasarimDetay> GetDetaylarById(List<int> ekranTasarimIdler)
        {
            return _ekranTasarimDal.GetDetayList(w => ekranTasarimIdler.Contains(w.Id));
        }
    } 
}