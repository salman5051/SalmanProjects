using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviePass.Startup))]
namespace MoviePass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
