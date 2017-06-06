using Autofac;
using DAL.Abstract;
using DAL.Concrete;

namespace DAL.DI
{
    public class DalAutoFacModule : Module
    {
        /// <summary>
        ///     Register EF Implementation as type of Repo Interface
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).SingleInstance();
        }
    }
}