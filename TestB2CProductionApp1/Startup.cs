using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestB2CProductionApp1.Startup))]
namespace TestB2CProductionApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
