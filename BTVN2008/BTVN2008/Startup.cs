using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTVN2008.Startup))]
namespace BTVN2008
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
