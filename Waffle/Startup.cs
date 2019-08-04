using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Waffle.Startup))]
namespace Waffle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
