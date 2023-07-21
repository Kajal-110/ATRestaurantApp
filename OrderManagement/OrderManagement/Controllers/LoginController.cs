using Newtonsoft.Json;
using OrderManagement.Models.CustomModels;
using OrderManagement.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OrderManagement.Controllers
{
    public class LoginController : Controller
    {
        public IAuthService authObj;
        public LoginController(IAuthService _authObj)
        {
            authObj = _authObj;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (authObj.Login(loginModel).id > 0)
            {
                string userData = JsonConvert.SerializeObject(authObj.Login(loginModel));

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                    (
                    1, "USER", DateTime.Now, DateTime.Now.AddMinutes(15), true, userData
                    );

                string enTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
                Response.Cookies.Add(faCookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Authentication Faild!!!";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}