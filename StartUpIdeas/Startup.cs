using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartUpIdeas.Startup))]
namespace StartUpIdeas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
