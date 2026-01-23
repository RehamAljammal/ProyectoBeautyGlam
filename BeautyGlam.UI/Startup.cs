using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeautyGlam.UI.Startup))]
namespace BeautyGlam.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
