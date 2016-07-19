using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Attributes
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        HttpSessionStateBase session;

        public CustomAuthAttribute(HttpSessionStateBase session)
        {
            this.session = session;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // если пользователь не авторизован, то он перенаправляется на Account/Login
            var auth = session["User"];
            if (auth == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary { 
                { "controller", "Account" }, { "action", "LoginUser" } 
            });
            }
        }
    }
}