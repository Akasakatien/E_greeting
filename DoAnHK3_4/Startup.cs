using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnHK3_4.Startup))]
namespace DoAnHK3_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
