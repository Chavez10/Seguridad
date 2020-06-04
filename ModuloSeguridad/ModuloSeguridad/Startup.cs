using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModuloSeguridad.Startup))]
namespace ModuloSeguridad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
