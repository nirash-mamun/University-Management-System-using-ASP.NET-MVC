using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZerOneUniversityApp.Startup))]
namespace ZerOneUniversityApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
