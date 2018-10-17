using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Doan_28.Startup))]
namespace Doan_28
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
