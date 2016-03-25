using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebApp2.Startup))]
namespace TestWebApp2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
