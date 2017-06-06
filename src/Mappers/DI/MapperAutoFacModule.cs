using Autofac;

namespace Mappers.DI
{
    public class MapperAutoFacModule : Module
    {
        /// <summary>
        ///     Register AutoMapper implementation as a singleton-instance of IObjectMapper
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AmObjectMapper>().As<IObjectMapper>().SingleInstance();
        }
    }
}