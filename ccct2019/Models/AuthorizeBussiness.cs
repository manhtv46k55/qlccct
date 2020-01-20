using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccct2019.Models
{
    public class AuthorizeBussiness : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext fillterContext)
        {
            if (HttpContext.Current.Session["userid"] == null)
            {
                fillterContext.Result = new RedirectResult("/User/Login");
                return;
            }
        }
    }
}