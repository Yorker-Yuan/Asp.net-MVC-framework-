using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQueryAjaxInAspNetMVC.Startup))]
namespace JQueryAjaxInAspNetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
