using Autofac;
using BL.Abstract;
using BL.Abstract.Logic;
using BL.Abstract.Validation;
using BL.Concrete;
using BL.Concrete.Logic;
using BL.Concrete.Validation;
using DAL.DI;
using DTO.PortalUser;
using DTO.Score;
using Mappers.DI;

namespace BL.DI
{
    public class BlAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Transient Lifetime
            builder.RegisterType<ScoreLogic>().As<IScoreLogic>().InstancePerDependency();
            builder.RegisterType<PortalUserLogic>().As<IPortalUserLogic>().InstancePerDependency();
            builder.RegisterType<IdentityLogic>().As<IIdentityLogic>().InstancePerDependency();
            builder.RegisterType<BlogPostLogic>().As<IBlogPostLogic>().InstancePerDependency();
            builder.RegisterType<FeedEntryLogic>().As<IFeedEntryLogic>().InstancePerDependency();
            builder.RegisterType<MenuElementLogic>().As<IMenuElementLogic>().InstancePerDependency();

            //Build Dependency Chain Repository
            builder.RegisterModule<DalAutoFacModule>();
            //Build Dependency Chain IObjectMapper
            builder.RegisterModule<MapperAutoFacModule>();
        }
    }
}