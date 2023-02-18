using ShaligramBuildcon_MVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShaligramBuildcon_MVC.SignalR
{
    public static class GenerateMsgHTML
    {
        /// <summary>
        /// Generate HTML content for each messages
        /// </summary>
        /// <returns></returns>
        //public static MvcHtmlString GenerateMessages(this List<SignalR_Notifications> messages, string type)
        //{
        //    StringBuilder mainsb = new StringBuilder();

        //    //Static a tag
        //    TagBuilder firstSpan = ITag("icon-git-compare");
        //    TagBuilder secondSpan = SpanTag("visible-xs-inline-block position-right", "New Messages");
        //    TagBuilder thirdSpan = null;
        //    if (messages.Count > 0)
        //    {
        //        thirdSpan = SpanTag("badge bg-danger", messages.Count.ToString());
        //    }
        //    TagBuilder aLink = AnchorLink();
        //    aLink.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", Convert.ToString(firstSpan), Convert.ToString(secondSpan), Convert.ToString(thirdSpan));
        //    mainsb.Append(aLink);

        //    TagBuilder mainDiv = new TagBuilder("div");
        //    mainDiv.MergeAttribute("class", "dropdown-menu dropdown-content");

        //    StringBuilder innersb = new StringBuilder();

        //    TagBuilder innerDiv = new TagBuilder("div");
        //    innerDiv.MergeAttribute("class", "dropdown-content-heading");
        //    innerDiv.MergeAttribute("style", "padding-bottom: 5px;");

        //    List<string> notificationType = new List<string>();
        //    notificationType.Add("Booking");
        //    notificationType.Add("Inquiry");
        //    notificationType.Add("Payment");

        //    //Create Filter Notification Combobox
        //    #region Notification Filter Combobox
        //    TagBuilder innerDivDropDown = new TagBuilder("select");
        //    innerDivDropDown.MergeAttribute("onchange", "filterNotification()");
        //    innerDivDropDown.AddCssClass("dropdown-content-body k-textbox");
        //    innerDivDropDown.MergeAttribute("style", "padding:5px; float:right;");
        //    innerDivDropDown.MergeAttribute("id", "filterCombo");

        //    TagBuilder option = new TagBuilder("option");
        //    option.MergeAttribute("value", "-1");
        //    option.InnerHtml = "--Select--";
        //    innerDivDropDown.InnerHtml = option.ToString();
        //    foreach (var item in notificationType)
        //    {
        //        option = new TagBuilder("option");
        //        option.MergeAttribute("value", item);
        //        option.InnerHtml = item;
        //        if (type == item)
        //        {
        //            option.MergeAttribute("selected", "selected");
        //        }
        //        innerDivDropDown.InnerHtml += option.ToString();
        //    }
        //    innerDiv.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", "Notifications", Convert.ToString(innerDivDropDown));
        //    innersb.Append(innerDiv);
        //    #endregion

        //    //Delete All Button
        //    TagBuilder innerDiv2 = new TagBuilder("div");
        //    innerDiv2.MergeAttribute("class", "dropdown-content-heading");
        //    TagBuilder innerDivButton = new TagBuilder("input");
        //    innerDivButton.AddCssClass("btn btn-info btn-xs legitRipple");
        //    innerDivButton.MergeAttribute("type", "button");
        //    innerDivButton.MergeAttribute("onclick", "deleteAllNotification()");
        //    innerDivButton.MergeAttribute("style", "float:right;");
        //    innerDivButton.MergeAttribute("id", "deleteButton");
        //    innerDivButton.MergeAttribute("value", "Delete All");
        //    innerDiv2.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}", Convert.ToString(innerDivButton));
        //    innersb.Append(innerDiv2);

        //    TagBuilder innerDivBr = new TagBuilder("br/");
        //    innersb.Append(innerDivBr);

        //    TagBuilder ul = new TagBuilder("ul");
        //    ul.MergeAttribute("class", "media-list dropdown-content-body width-350");
        //    ul.MergeAttribute("id", "ulBar");

        //    StringBuilder lisb = new StringBuilder();
        //    if (messages.Count > 0)
        //    {
        //        foreach (var item in messages)
        //        {
        //            var CreatedByNameList = item.CreatedBy.Split(' ');
        //            string CreatedBy = string.Empty;
        //            foreach(var obj in CreatedByNameList)
        //            {
        //                CreatedBy = string.Concat(CreatedBy,obj.Substring(0, 1));
        //            }
        //            string aLinkClass;
        //            switch (item.NotificationType)
        //            {
        //                case "Booking":
        //                    //DivIcon = "icon-git-branch";
        //                    aLinkClass = "btn bg-success-400 btn-rounded btn-icon btn-xs legitRipple";
        //                    break;
        //                case "Inquiry":
        //                    //DivIcon = "icon-git-commit";
        //                    aLinkClass = "btn bg-pink-400 btn-rounded btn-icon btn-xs legitRipple";
        //                    break;
        //                case "Payment":
        //                    //DivIcon = "icon-git-merge";
        //                    aLinkClass = "btn bg-blue btn-rounded btn-icon btn-xs legitRipple";
        //                    break;
        //                default:
        //                    //DivIcon = "icon-git-pull-request";
        //                    aLinkClass = "btn bg-warning-400 btn-rounded btn-icon btn-xs legitRipple";
        //                    break;
        //            }

        //            #region Generate LI Tags
        //            //Generate Li Tag for each notification
        //            TagBuilder li = new TagBuilder("li");
        //            li.AddCssClass("media");

        //            //Li Tag Child String Builder
        //            StringBuilder lisbChild = new StringBuilder();

        //            //CheckBox Div Tag
        //            TagBuilder checkboxDiv = new TagBuilder("input");
        //            checkboxDiv.MergeAttribute("type", "checkbox");
        //            checkboxDiv.MergeAttribute("class", "notificationcheck");
        //            checkboxDiv.MergeAttribute("id", "chk_" + item.NotificationId.ToString());
        //            checkboxDiv.MergeAttribute("name", "chk_" + item.NotificationId);

        //            TagBuilder checkboxMainDiv = new TagBuilder("div");
        //            checkboxMainDiv.MergeAttribute("class", "media-left media-middle");
        //            checkboxMainDiv.InnerHtml = checkboxDiv.ToString();
        //            lisbChild.Append(checkboxMainDiv);

        //            //First Div Tag
        //            TagBuilder firstDiv = new TagBuilder("div");
        //            firstDiv.MergeAttribute("class", "media-left media-middle");

        //            TagBuilder firstDivaLink = new TagBuilder("a");
        //            firstDivaLink.MergeAttribute("class", aLinkClass);
        //            firstDivaLink.MergeAttribute("href", "javascript:void(0);");

        //            TagBuilder firstDivSpan = SpanTag("letter-icon", CreatedBy);
        //            firstDivaLink.InnerHtml = firstDivSpan.ToString();

        //            firstDiv.InnerHtml = firstDivaLink.ToString();
        //            lisbChild.Append(firstDiv);


        //            //Second Div Tag
        //            StringBuilder secondDivsb = new StringBuilder();

        //            //Delete Btn for Notification
        //            TagBuilder deleteIconSpan = SpanTag("icon-cancel-square2", "");
        //            TagBuilder deleteBtn = new TagBuilder("a");
        //            deleteBtn.MergeAttribute("class", "media-annotation pull-right");
        //            deleteBtn.MergeAttribute("onclick", "DeleteMsg("+ item.NotificationId +")");
        //            deleteBtn.InnerHtml = deleteIconSpan.ToString();

        //            TagBuilder secondDivFirstSpan = SpanTag("text-semibold", item.ProjectName);
        //            secondDivFirstSpan.MergeAttribute("style", "color:#166dba;");
        //            TagBuilder secondDivSecSpan = deleteBtn;
        //            TagBuilder secondDivThirdSpan = SpanTag("text-muted", item.NotificationText);

        //            TagBuilder secondDiv = new TagBuilder("div");
        //            secondDiv.MergeAttribute("class", "media-body");

        //            TagBuilder secondDivaLink = new TagBuilder("div");
        //            secondDivaLink.MergeAttribute("class", "media-heading");
        //            secondDivaLink.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(secondDivFirstSpan), Convert.ToString(secondDivSecSpan));
        //            secondDivsb.Append(secondDivaLink);
        //            secondDivsb.Append(secondDivThirdSpan);

        //            TagBuilder secondDivChild = new TagBuilder("div");
        //            secondDivChild.MergeAttribute("class", "media-annotation");
        //            secondDivChild.InnerHtml = item.NotificationTimeSpan;
        //            secondDivsb.Append(secondDivChild);

        //            secondDiv.InnerHtml = secondDivsb.ToString();
        //            lisbChild.Append(secondDiv);

        //            //Append Li Childs into Parent
        //            li.InnerHtml = lisbChild.ToString();

        //            //Append childs into Li Tag
        //            lisb.Append(li.ToString());
        //            #endregion
        //        }
        //    }
        //    else
        //    {
        //        #region Generate No Notification Div Tags
        //        //Generate Li Tag for each notification
        //        TagBuilder li = new TagBuilder("li");
        //        li.AddCssClass("media");

        //        //Li Tag Child String Builder
        //        StringBuilder lisbChild = new StringBuilder();

        //        //No Notification Div Tag
        //        TagBuilder firstDiv = new TagBuilder("div");
        //        firstDiv.MergeAttribute("class", "media-body");
        //        firstDiv.MergeAttribute("style", "text-align:center;");


        //        TagBuilder Nospan = SpanTag("text-semibold", "No Notifications");
        //        firstDiv.InnerHtml = Nospan.ToString();
        //        lisbChild.Append(firstDiv);

        //        //Append Li Childs into Parent
        //        li.InnerHtml = lisbChild.ToString();

        //        //Append childs into Li Tag
        //        lisb.Append(li.ToString());
        //        #endregion
        //    }
        //    //Append all Li into Ul Tag
        //    ul.InnerHtml = lisb.ToString();

        //    //Append Whole UL List into InnerSB
        //    innersb.Append(ul);
        //    mainDiv.InnerHtml = innersb.ToString();
        //    mainsb.Append(mainDiv);
        //    return MvcHtmlString.Create(mainsb.ToString());
        //}

        private static TagBuilder AnchorLink()
        {
            TagBuilder aLink = new TagBuilder("a");
            aLink.MergeAttribute("class", "dropdown-toggle");
            aLink.MergeAttribute("data-toggle", "dropdown");
            //aLink.MergeAttribute("data-action", "click-trigger");
            aLink.MergeAttribute("href", "javascript:void(0);");
            return aLink;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static TagBuilder SpanTag(string className, string text)
        {
            TagBuilder span = new TagBuilder("span");
            span.MergeAttribute("class", className);
            span.InnerHtml = text;
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
    }
}