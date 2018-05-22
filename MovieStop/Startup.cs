using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieStop.Startup))]
namespace MovieStop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
