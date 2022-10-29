using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task02.Startup))]
namespace Task02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
