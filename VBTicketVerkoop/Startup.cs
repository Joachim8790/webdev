using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VBTicketVerkoop.Startup))]
namespace VBTicketVerkoop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
