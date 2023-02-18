using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ShaligramBuildcon_MVC.App_Start.Startup))]

namespace ShaligramBuildcon_MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {   
            app.MapSignalR();
        }
    }
}
