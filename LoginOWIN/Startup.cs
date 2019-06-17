using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginOWIN.Startup))]
namespace LoginOWIN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
