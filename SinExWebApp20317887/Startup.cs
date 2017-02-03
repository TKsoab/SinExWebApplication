using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinExWebApp20317887.Startup))]
namespace SinExWebApp20317887
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
