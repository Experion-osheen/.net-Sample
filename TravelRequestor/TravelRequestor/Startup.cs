using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelRequestor.Startup))]
namespace TravelRequestor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
