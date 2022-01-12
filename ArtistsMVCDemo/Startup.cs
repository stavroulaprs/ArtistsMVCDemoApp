using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtistsMVCDemo.Startup))]
namespace ArtistsMVCDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
