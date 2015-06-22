using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KLFBlog.Startup))]
namespace KLFBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
