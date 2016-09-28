using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Core;
using Core.Entities;
using Core.Repositories;
using Ninject;

namespace Web.IoC
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            _ninjectKernel.Bind<DbDataContext>()
                          .ToSelf()
                          .WithConstructorArgument("DefaultConnection",
                                                   ConfigurationManager.ConnectionStrings[1].ConnectionString);

            _ninjectKernel.Bind<Repository<Computer>>().To<ComputerRepository>();
            _ninjectKernel.Bind<Repository<Manufacturer>>().To<ManufacturerRepository>();
            _ninjectKernel.Bind<Repository<User>>().To<UserRepository>();
            _ninjectKernel.Bind<IDataManager>().To<DataManager>();
        }

        private readonly IKernel _ninjectKernel;
    }
}