using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
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
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return;
            if (string.IsNullOrWhiteSpace(cookie.Value)) return;

            FormsAuthenticationTicket ticket = null;

            try
            {
                ticket = FormsAuthentication.Decrypt(cookie.Value);
            }
            catch
            {
                return; // cookie dañada / inválida
            }

            if (ticket == null) return;
            if (ticket.Expired) return;

            // ticket.Name = correo (lo estás guardando así)
            // ticket.UserData = rol (ej: "Admin") o "Admin,Inventario"
            string[] roles = new string[0];

            if (string.IsNullOrWhiteSpace(ticket.UserData) == false)
            {
                roles = ticket.UserData
                    .Split(new char[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(r => r.Trim())
                    .Where(r => r.Length > 0)
                    .Distinct()
                    .ToArray();
            }

            GenericIdentity identity = new GenericIdentity(ticket.Name, "Forms");
            GenericPrincipal principal = new GenericPrincipal(identity, roles);

            Context.User = principal;
            Thread.CurrentPrincipal = principal;
        }
    }
}
