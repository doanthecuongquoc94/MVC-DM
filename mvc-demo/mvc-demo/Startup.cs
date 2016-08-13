using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_demo.Startup))]
namespace mvc_demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
