using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkillMatrix.Web.Startup))]
namespace SkillMatrix.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
