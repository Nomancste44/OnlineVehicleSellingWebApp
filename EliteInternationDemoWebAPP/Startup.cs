using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EliteInternationDemoWebAPP.Startup))]
namespace EliteInternationDemoWebAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
