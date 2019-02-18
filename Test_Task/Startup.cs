using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Task.Startup))]
namespace Test_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
