using Microsoft.Owin;
using Owin;
//using Microsoft.AspNet.SignalR.Redis;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartupAttribute(typeof(WatcherWeb.Startup))]
namespace WatcherWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
            app.MapSignalR();

        }

       

    }
}
