using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OutOfSpace.Web.Startup))]
namespace OutOfSpace.Web
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}