using System;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace BeautyGlam.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return;

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket == null) return;

            string[] roles = new string[1];
            roles[0] = ticket.UserData;

            GenericIdentity identity = new GenericIdentity(ticket.Name);
            GenericPrincipal principal = new GenericPrincipal(identity, roles);

            Context.User = principal;
        }
    }
}
