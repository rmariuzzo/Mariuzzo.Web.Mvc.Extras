using System;
using System.Web.Mvc;
using Mariuzzo.Extensions;

namespace Mariuzzo.Web.Mvc.Extras
{
    /// <summary>
    /// The <code>EnumExtensions</code> class.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Return a <code>System.Web.Mvc.SelectListItem</code> from an enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="selected">A boolean value to indicate if the <code>System.Web.Mvc.SelectListItem</code> is selected.</param>
        /// <returns></returns>
        public static SelectListItem ToSelectListItem(this Enum value, bool selected = false)
        {
            return new SelectListItem { Value = value.ToString(), Text = value.GetDescription(), Selected = selected };
        }
    }
}
