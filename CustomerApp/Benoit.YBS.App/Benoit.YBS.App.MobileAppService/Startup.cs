using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Benoit.YBS.App.MobileAppService.Startup))]

namespace Benoit.YBS.App.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}