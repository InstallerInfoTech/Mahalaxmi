using Data.ShaligramBuildcon_MVC.DB;
using ShaligramBuildcon_MVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace ShaligramBuildcon_MVC.Helper
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Status Template for Active/Inactive
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="isActive"></param>
        /// <param name="controllerName"></param>
        /// <param name="action"></param>
        /// <param name="parameter"></param>
        /// <param name="id"></param>
        /// <param name="gridId"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string SetStatusClientTemplate(this HtmlHelper helper, string isActive, string controllerName, string action, string parameter, string id, string gridId, string entityName)
        {

            string deactivteMessage = "Are you sure you want to deactivate this " + entityName + " ?";


            string activteMessage = "Are you sure you want to activate this " + entityName + " ?";

            var deactiveAttributes = " onclick='changeStatus(" + @"""" + controllerName + @"""" + ", " + @"""" +
                                    action + @"""" + ", " + @"""""" + ", "
                                    + @"""" + parameter + @"""" + ", " + @"""" + deactivteMessage + @"""" + ", " + id
                                    + ", " + @"""" + gridId + @"""" + @")'";

            var activeAttributes = " onclick='changeStatus(" + @"""" + controllerName + @"""" + ", " + @"""" +
                                   action + @"""" + ", " + @"""""" + ", "
                                   + @"""" + parameter + @"""" + ", " + @"""" + activteMessage + @"""" + ", " + id
                                   + ", " + @"""" + gridId + @"""" + @")'";


            return "# if (" + isActive + ")    {#" +
                     @"<a class='k-button' " + deactiveAttributes + @"><span class='k-icon k-i-check'></span></a>" +
                     "#}else { #" +
                     @"<a class='k-button' " + activeAttributes + @"><span class='k-icon k-i-close'></span></a>"
                     + "#}#";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString GenerateMenu(this HtmlHelper helper)
        {
            Mahalaxmi_HandicraftEntities context = new Mahalaxmi_HandicraftEntities();
            List<parentmenulist_Result> parentMenuList = new List<parentmenulist_Result>();
            parentMenuList = context.parentmenulist().ToList();

            List<childmenulist_Result> childMenuList = context.childmenulist().ToList();

            if (parentMenuList.Any())
            {
                TagBuilder ul = new TagBuilder("ul");
                ul.MergeAttribute("class", "nav navbar-nav navbar-nav-material");
                ul.MergeAttribute("id", "sideBar");

                StringBuilder sb = new StringBuilder();

                foreach (parentmenulist_Result menu in parentMenuList)
                {
                    List<childmenulist_Result> childList = childMenuList.Where(x => x.ParentMenuId == menu.MenuId).ToList();

                    if (childList.Any())
                    {
                        StringBuilder sbChild = new StringBuilder();


                        //li name 
                        TagBuilder liWithChild = new TagBuilder("li");
                        liWithChild.AddCssClass("dropdown");


                        //Static a tag
                        TagBuilder firstSpan = ITag("icon-make-group position-left");
                        TagBuilder secondSpan = SpanTag("caret");

                        TagBuilder aLink = AnchorLink(null, null, true);
                        aLink.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", Convert.ToString(firstSpan), Convert.ToString(menu.Name), Convert.ToString(secondSpan));

                        //ul name 
                        TagBuilder ulChild = new TagBuilder("ul");
                        ulChild.AddCssClass("dropdown-menu width-250");


                        foreach (childmenulist_Result childMenu in childList)
                        {

                            TagBuilder firstSpanchild = ITag("icon-task");

                            TagBuilder liChildaLink = AnchorLink(childMenu.Action, childMenu.Controller, false);
                            liChildaLink.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(firstSpanchild), Convert.ToString(childMenu.Name));

                            TagBuilder liChild = new TagBuilder("li") { InnerHtml = Convert.ToString(liChildaLink) };
                            liChild.AddCssClass("dropdown-submenu");

                            sbChild.Append(Convert.ToString(liChild));
                        }

                        ulChild.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}", Convert.ToString(sbChild));
                        liWithChild.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(aLink), Convert.ToString(ulChild));
                        sb.Append(Convert.ToString(liWithChild));
                    }
                    else
                    {
                        TagBuilder imageTag = ITag(menu.ImagePath + "  position-left");

                        TagBuilder aLink = AnchorLink(menu.Action, menu.Controller, false);
                        aLink.InnerHtml = string.Format("{0}{1}", Convert.ToString(imageTag), menu.Name);
                        //aLink.MergeAttribute("class", "legitRipple");


                        TagBuilder liWithChild = new TagBuilder("li") { InnerHtml = Convert.ToString(aLink) };
                        sb.Append(Convert.ToString(liWithChild));
                    }
                }

                ul.InnerHtml = sb.ToString();
                return MvcHtmlString.Create(ul.ToString());
            }

            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="isParent"></param>
        /// <returns></returns>
        private static TagBuilder AnchorLink(string actionName, string controllerName, bool isParent)
        {
            TagBuilder aLink = new TagBuilder("a");

            if (isParent)
            {
                aLink.MergeAttribute("class", "dropdown-toggle");
                aLink.MergeAttribute("data-toggle", "dropdown");
                //aLink.MergeAttribute("data-action", "click-trigger");
            }

            if (string.IsNullOrEmpty(controllerName))
            {
                aLink.MergeAttribute("href", "javascript:void(0);");
            }
            else if (string.IsNullOrEmpty(actionName))
            {
                aLink.MergeAttribute("href", "javascript:void(0);");
            }
            else
            {
                //aLink.MergeAttribute("id", controllerName);
                //aLink.MergeAttribute("href", "#/" + controllerName);
                aLink.MergeAttribute("id", controllerName);
                aLink.MergeAttribute("href", HtmlHelperExtensions.SiteRootPathUrl + "/" + controllerName + "/" + actionName);
            }
            return aLink;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static TagBuilder SpanTag(string className)
        {
            TagBuilder span = new TagBuilder("span");
            span.MergeAttribute("class", className);
            return span;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static TagBuilder ITag(string className)
        {
            TagBuilder span = new TagBuilder("i");
            span.MergeAttribute("class", className);
            return span;
        }

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

                return msRootUrl;
            }
        }

        public static MvcHtmlString DropDownListForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression,
                                                                            IEnumerable<SelectListItem> field, bool showBlank, IDictionary<String, string> javascript)
        {

            var fieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));

            TagBuilder tag = new TagBuilder("select");
            if (javascript != null)
            {
                foreach (var item in javascript)
                {
                    tag.MergeAttribute(item.Key, item.Value);
                }
            }

            tag.AddCssClass("FormField");

            tag.MergeAttribute("id", fieldName);
            tag.MergeAttribute("name", fieldName);

            if (showBlank)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", "-1");
            }

            foreach (var selectListItem in field)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", selectListItem.Value);
                option.InnerHtml = selectListItem.Text;

                if (selectListItem.Selected)
                {
                    option.MergeAttribute("selected", "selected");
                }
                tag.InnerHtml += option.ToString();
            }

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }

    public class ReportHelper
    {
        public static readonly string ReportApiController = WebHelper.SiteRootPathUrl + "/api/reportsapi/";

        public static readonly string ReportTemplate = WebHelper.SiteRootPathUrl + "/Template/telerikReportViewerTemplate.html";
    }
}