using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskScheduler.Startup))]
namespace TaskScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
