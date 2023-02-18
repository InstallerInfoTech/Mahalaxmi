using Data.ShaligramBuildcon_MVC.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Helper
{
    public class WebHelper
    {
        public static string SiteRootPathUrl
        {
            get
            {
                string msRootUrl;
                if (HttpContext.Current.Request.ApplicationPath != null && string.IsNullOrEmpty(HttpContext.Current.Request.ApplicationPath.Split('/')[1]))
                {
                    msRootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host +
                                ":" +
                                HttpContext.Current.Request.Url.Port;
                }
                else
                {
                    msRootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
                }

                return msRootUrl + "/";
            }
        }
        public static Inquiry GetDateDetails(DateTime date)
        {
            Inquiry objDateModel = new Inquiry();
            objDateModel.InquiryDay = Convert.ToInt16(date.Day);
            objDateModel.InquiryMonth = Convert.ToInt16(date.Month);
            objDateModel.InquiryYear = Convert.ToInt16(date.Year);
            var WeekStart = date.AddDays(-(int)date.DayOfWeek + 1);
            var WeekEnd = WeekStart.AddDays(7).AddSeconds(-1);
            objDateModel.InquiryWeekNo = Convert.ToInt16(CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
            objDateModel.InquiryStartWeekDate = WeekStart;
            objDateModel.InquiryEndWeekDate = WeekEnd;

            return objDateModel;
        }
    }
}