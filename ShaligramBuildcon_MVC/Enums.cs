using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC
{
    public class Enums1
    {
        public enum NotifyType
        {
            [Description("Success Message")]
            Success = 1,

            [Description("Error Message")]
            Error = 2,

            [Description("Warning Message")]
            WarningMessage = 3,

            [Description("System Error Message")]
            SystemErrorMessage = 4
        }

        public enum ProjectStatus
        {
            [Description("New")]
            New = 8,
            [Description("In Progress")]
            InProgress = 3,
            [Description("Completed")]
            Completed = 4,
            [Description("UNDER CONSTRUCTION")]
            UNDERCONSTRUCTION = 5,
            [Description("Pending")]
            Pending = 106,
        }
    }

    public static class EnumExtension
    {
        /// <summary>
        /// The get description.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDescription1(this Enum element)
        {
            var type = element.GetType();
            var memberInfo = type.GetMember(Convert.ToString(element));
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return Convert.ToString(element);
        }
    }
}