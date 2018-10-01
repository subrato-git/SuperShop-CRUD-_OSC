using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperShop.Startup))]
namespace SuperShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
