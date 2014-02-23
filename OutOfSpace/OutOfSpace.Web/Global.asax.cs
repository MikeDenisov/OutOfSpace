using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using OutOfSpace.Web.App_Start;

namespace OutOfSpace.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
