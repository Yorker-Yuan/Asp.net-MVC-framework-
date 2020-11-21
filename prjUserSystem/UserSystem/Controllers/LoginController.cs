using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSystem.Models;

namespace UserSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(tUserLogin user)
        {
            using (dbUserRegistationEntities db = new dbUserRegistationEntities())
            {
                var details = db.tUserLogins.Where(a => a.fName == user.fName && a.fPassword == user.fPassword).FirstOrDefault();
                if (details == null)
                {
                    user.LoginErrorMsg = "帳號或密碼錯誤";
                    return View("Index", user);
                }
                else
                {
                    Session["UserId"] = details.fUserId;
                    Session["UserName"] = details.fName;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Logout()
        {
            int userId = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}