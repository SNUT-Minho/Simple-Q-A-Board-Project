using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetNote.Startup))]
namespace DotNetNote
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
