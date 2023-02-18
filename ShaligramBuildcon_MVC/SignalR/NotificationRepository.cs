using ShaligramBuildcon_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.SignalR
{
    public static class NotificationRepository
    {
        private static string _connString = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"];
        //public static List<SignalR_Notifications> GetAllMessages(string type)
        //{
        //    List<SignalR_Notifications> notifications = new List<SignalR_Notifications>();
        //    using (var connection = new SqlConnection(_connString))
        //    {
        //        connection.Open();
        //        string query = ((type == "-1") || string.IsNullOrEmpty(type)) ? @"SELECT * FROM Notifications ORDER BY NotificationDateTime DESC" : @"SELECT * FROM Notifications WHERE NotificationType = '" + type + "' ORDER BY NotificationDateTime DESC";
                
        //        using (var command = new SqlCommand(query, connection))
        //        {
        //            command.Notification = null;

        //            var dependency = new SqlDependency(command);
        //            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            var reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                notifications.Add(item: new SignalR_Notifications
        //                {
        //                    NotificationId = (int)reader["NotificationId"],
        //                    NotificationText = reader["NotificationText"] != DBNull.Value ? (string)reader["NotificationText"] : "",
        //                    NotificationType = reader["NotificationType"] != DBNull.Value ? (string)reader["NotificationType"] : "",
        //                    NotificationDateTime = Convert.ToDateTime(reader["NotificationDateTime"]),
        //                    NotificationTimeSpan = TimeAgo(Convert.ToDateTime(reader["NotificationDateTime"])),
        //                    ProjectName = reader["ProjectName"] != DBNull.Value ? (string)reader["ProjectName"] : "",
        //                    CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : "",
        //                });
        //            }
        //        }
        //    }
        //    return notifications;
        //}
        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            NotificationHub nh = new NotificationHub();
            if (e.Type == SqlNotificationType.Change)
            {
                nh.SendNotifications();
            }
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = timeSpan.Seconds < 0 ?
                    "About a second ago" : String.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("About {0} minutes ago", timeSpan.Minutes) :
                    "About a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("About {0} hours ago", timeSpan.Hours) :
                    "About an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("About {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("About {0} months ago", timeSpan.Days / 30) :
                    "About a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("About {0} years ago", timeSpan.Days / 365) :
                    "About a year ago";
            }

            return result;
        }
    }
}