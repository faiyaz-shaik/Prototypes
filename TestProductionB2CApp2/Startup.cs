using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace TestProductionB2CApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}