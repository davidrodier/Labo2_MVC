using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Labo2.Startup))]
namespace Labo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
