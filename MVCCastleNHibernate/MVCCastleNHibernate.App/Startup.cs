using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCastleNHibernate.App.Startup))]
namespace MVCCastleNHibernate.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
