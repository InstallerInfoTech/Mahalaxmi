using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ShaligramBuildcon_MVC.Helper;
using ShaligramBuildcon_MVC.Models;

namespace ShaligramBuildcon_MVC.SignalR
{
    public class NotificationHub : Hub
    {
        string connString = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"];
        public void SendNotifications()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.updateMessages();
        }
    }
}