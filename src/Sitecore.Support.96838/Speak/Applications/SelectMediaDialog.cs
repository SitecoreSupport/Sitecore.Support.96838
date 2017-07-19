using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Speak.Applications
{
    public class SelectMediaDialog : Sitecore.Speak.Applications.SelectMediaDialog
    {
        public override void Initialize()
        {
            base.Initialize();

            Uri tempUri = null;
            string lang = null;
            try
            {
                tempUri = new Uri(HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query)["ro"]);
                lang = HttpUtility.ParseQueryString(tempUri.Query)["lang"];
            }
            catch (Exception e)
            {
                Log.Warn("Sitecore.Support.96838: " + e.Message, this);
            }

            if (!string.IsNullOrEmpty(lang))
            {
                base.DataSource.Parameters["Language"] = lang;
            }
        }
    }
}