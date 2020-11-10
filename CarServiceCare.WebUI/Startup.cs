using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarServiceCare.WebUI.Startup))]
namespace CarServiceCare.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
