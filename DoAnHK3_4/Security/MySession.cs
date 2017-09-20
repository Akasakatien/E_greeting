using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.Security
{
    public class MySession
    {
        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var username = HttpContext.Current.Session["username"];
                if (username != null)
                    return username.ToString();
                return null;
            }
            set
            {
                HttpContext.Current.Session["username"] = value;
            }
        }
    }
}