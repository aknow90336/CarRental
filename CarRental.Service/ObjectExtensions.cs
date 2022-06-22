
using System;
using System.Linq;
using System.Web;

namespace CarRental.Service
{
    public static class ObjectExtensions
    {
        public static string PropUrlEncode(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             orderby p.Name
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}