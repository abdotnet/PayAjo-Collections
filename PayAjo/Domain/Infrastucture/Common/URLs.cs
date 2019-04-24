using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Common
{
    public class URLs
    {
        public static string GetCurrentUrl(bool onlydomain = false)
        {
            string currenturl = "";

            string Port = "";// HttpContext.Current.Request.ServerVariables["SERVER_PORT"];

            if (Port == null || Port == "80" || Port == "443")
            {
                Port = "";
            }
            else
            {
                Port = ":" + Port;
            }

            string Protocol = "";// HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];

            if (Protocol == null || Protocol == "0")
            {
                Protocol = "http://";
            }
            else
            {
                Protocol = "https://";
            }

            if (onlydomain)
            {
                // *** Figure out the base Url which points at the application's root
                currenturl = "";// Protocol + HttpContext .Current.Request.ServerVariables["SERVER_NAME"] + Port;
            }
            else
            {
                // *** Figure out the base Url which points at the application's root
                currenturl = "";// Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port + HttpContext.Current.Request.ApplicationPath;
                if (currenturl.EndsWith("/")) { currenturl = currenturl.Substring(0, currenturl.Length - 1); }
            }

            return currenturl;
        }

    }
}
