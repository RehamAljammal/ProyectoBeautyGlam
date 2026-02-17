using BeautyGlam.Abstracciones.LogicaDeNegocio.Recuperacion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Autenticacion;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BeautyGlam.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthLN _authLN;
        private readonly IRecuperacionContrasenaLN _recuperacionLN;

        public AuthController()
        {
            _authLN = new AuthLN();
            _recuperacionLN = new RecuperacionContrasenaLN();
        }

        // ===================== LOGIN =====================
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginDTO model = new LoginDTO();
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            UsuarioAuthDTO usuario = _authLN.Validar(model.correo, model.contrasena);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Credenciales inválidas o usuario desactivado.");
                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                usuario.correo,
                DateTime.Now,
                DateTime.Now.AddMinutes(60),
                false,
                usuario.rol
            );

            string encrypted = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            cookie.HttpOnly = true;
            cookie.Path = "/";
            Response.Cookies.Add(cookie);

            if (string.IsNullOrWhiteSpace(returnUrl) == false && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            if (usuario.rol == "Admin")
            {
                return RedirectToAction("ListaDeProductos", "Productos");
            }

            return RedirectToAction("Index", "Home");
        }

        // ===================== REGISTER =====================
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterDTO model = new RegisterDTO();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            string error = _authLN.Registrar(model);

            if (string.IsNullOrWhiteSpace(error) == false)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            TempData["Msg"] = "Cuenta creada con éxito. Ahora puedes iniciar sesión.";
            return RedirectToAction("Login");
        }

        // ===================== RECUPERAR (GET) =====================
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RecuperarContrasena()
        {
            RecuperarContrasenaDTO model = new RecuperarContrasenaDTO();
            return View(model);
        }

        // ===================== RECUPERAR (POST) =====================
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RecuperarContrasena(RecuperarContrasenaDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            string urlBase = Request.Url.GetLeftPart(UriPartial.Authority);

            string error = await _recuperacionLN.SolicitarToken(model.correo, urlBase);

            if (string.IsNullOrWhiteSpace(error) == false)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            TempData["Msg"] = "Si el correo existe, te enviamos un enlace para restablecer tu contraseña.";
            return RedirectToAction("Login");
        }

        // ===================== RESTABLECER (GET) =====================
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RestablecerContrasena(string token)
        {
            RestablecerContrasenaDTO model = new RestablecerContrasenaDTO();
            model.token = token;
            return View(model);
        }

        // ===================== RESTABLECER (POST) =====================
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RestablecerContrasena(RestablecerContrasenaDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            string error = await _recuperacionLN.Restablecer(model.token, model.nuevaContrasena);

            if (string.IsNullOrWhiteSpace(error) == false)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            TempData["Msg"] = "Contraseña actualizada con éxito. Ya puedes iniciar sesión.";
            return RedirectToAction("Login");
        }

        // ===================== LOGOUT =====================
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                cookie.Expires = DateTime.Now.AddDays(-1);
                cookie.Path = "/";
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
