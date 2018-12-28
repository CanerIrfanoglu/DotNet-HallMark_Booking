using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(roomBooking.Startup))]
namespace roomBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
