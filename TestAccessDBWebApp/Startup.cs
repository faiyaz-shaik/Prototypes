using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAccessDBWebApp.Startup))]
namespace TestAccessDBWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
