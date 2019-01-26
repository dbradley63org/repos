using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cycle.web.Startup))]
namespace cycle.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
