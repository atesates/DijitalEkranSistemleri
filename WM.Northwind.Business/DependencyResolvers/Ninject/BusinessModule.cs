using Ninject.Modules;
using System.Data.Entity;
using WM.Core.DAL;
using WM.Core.DAL.EntityFramework;
using WM.Northwind.Business.Abstract;
using WM.Northwind.Business.Abstract.Authorization;
using WM.Northwind.Business.Abstract.EczaneNobet;
using WM.Northwind.Business.Concrete.Managers;
using WM.Northwind.Business.Concrete.Managers.Authorization;
using WM.Northwind.Business.Concrete.Managers.EczaneNobet;
using WM.Northwind.DataAccess.Abstract;
using WM.Northwind.DataAccess.Abstract.EczaneNobet;
using WM.Northwind.DataAccess.Abstract.Authorization;
using WM.Northwind.DataAccess.Concrete.EntityFramework;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using WM.Northwind.DataAccess.Concrete.EntityFramework.EczaneNobet;
using WM.Northwind.DataAccess.Concrete.EntityFramework.Authorization;

namespace WM.BLL.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            #region Eczane Nöbet
            Bind<IAdminService>().To<AdminManager>().InSingletonScope();

            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope();
            Bind<IUserRoleDal>().To<EfUserRoleDal>();

            Bind<IMenuService>().To<MenuManager>().InSingletonScope();
            Bind<IMenuDal>().To<EfMenuDal>();

            Bind<IMenuRoleService>().To<MenuRoleManager>().InSingletonScope();
            Bind<IMenuRoleDal>().To<EfMenuRoleDal>();

            Bind<IMenuAltService>().To<MenuAltManager>().InSingletonScope();
            Bind<IMenuAltDal>().To<EfMenuAltDal>();

            Bind<IMenuAltRoleService>().To<MenuAltRoleManager>().InSingletonScope();
            Bind<IMenuAltRoleDal>().To<EfMenuAltRoleDal>();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>();

            Bind<IEkranService>().To<EkranManager>().InSingletonScope();
            Bind<IEkranDal>().To<EfEkranDal>();

            Bind<IEkranIcerikService>().To<EkranIcerikManager>().InSingletonScope();
            Bind<IEkranIcerikDal>().To<EfEkranIcerikDal>();

            Bind<IEkranTasarimService>().To<EkranTasarimManager>().InSingletonScope();
            Bind<IEkranTasarimDal>().To<EfEkranTasarimDal>();         

            Bind<IKonumService>().To<KonumManager>().InSingletonScope();
            Bind<IKonumDal>().To<EfKonumDal>();

            Bind<ICihazService>().To<CihazManager>().InSingletonScope();
            Bind<ICihazDal>().To<EfCihazDal>();

            Bind<ICozunurlukService>().To<CozunurlukManager>().InSingletonScope();
            Bind<ICozunurlukDal>().To<EfCozunurlukDal>();

            Bind<IMonitorService>().To<MonitorManager>().InSingletonScope();
            Bind<IMonitorDal>().To<EfMonitorDal>();

            Bind<ICihazDurumService>().To<CihazDurumManager>().InSingletonScope();
            Bind<ICihazDurumDal>().To<EfCihazDurumDal>();

            Bind<IGrupService>().To<GrupManager>().InSingletonScope();
            Bind<IGrupDal>().To<EfGrupDal>();

            Bind<IGrupUserService>().To<GrupUserManager>().InSingletonScope();
            Bind<IGrupUserDal>().To<EfGrupUserDal>();

            Bind<IEkranTasarimIcerikService>().To<EkranTasarimIcerikManager>().InSingletonScope();
            Bind<IEkranTasarimIcerikDal>().To<EfEkranTasarimIcerikDal>();

            Bind<IYayinEkranService>().To<YayinEkranManager>().InSingletonScope();
            Bind<IYayinEkranDal>().To<EfYayinEkranDal>();

            Bind<IYayinEkranIcerikService>().To<YayinEkranIcerikManager>().InSingletonScope();
            Bind<IYayinEkranIcerikDal>().To<EfYayinEkranIcerikDal>();
            #endregion

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<EczaneNobetContext>();
        }
    }
}
