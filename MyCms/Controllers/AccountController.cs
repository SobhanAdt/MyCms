using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataLayer;
using System.Security;
using System.Web.Security;

namespace MyCms.Controllers
{

    public class AccountController : Controller
    {
        MyCmsContext db = new MyCmsContext();

        private ILoginRepository loginRepository;

        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsExitUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName,login.RemmberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName","کاربری یافت نشد");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}