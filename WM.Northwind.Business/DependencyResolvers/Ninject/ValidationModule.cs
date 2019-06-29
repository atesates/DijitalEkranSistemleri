using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Business.ValidationRules.FluentValidation;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<LoginItem>>().To<LoginItemValidator>().InSingletonScope();
            //Bind<IValidator<Eczane>>().To<EczaneValidator>().InSingletonScope();
        }
    }
}
