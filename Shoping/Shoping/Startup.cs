using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shoping.Startup))]
namespace Shoping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
