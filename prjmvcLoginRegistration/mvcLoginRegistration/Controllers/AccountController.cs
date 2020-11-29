using mvcLoginRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcLoginRegistration.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (AccountDbContext db = new AccountDbContext())
            {
                return View(db.userAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(CUserAccount user)
        {
            if (ModelState.IsValid)
            {
                using (AccountDbContext db = new AccountDbContext())
                {
                    db.userAccounts.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Msg = user.fName + "註冊成功!!";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CUserAccount user)
        {
            using (AccountDbContext db = new AccountDbContext())
            {
                var account = db.userAccounts.Single(a => a.fUserName == user.fUserName && a.fPassword == user.fPassword);
                if (account != null)
                {
                    Session["UserId"] = account.fUserId.ToString();
                    Session["UserName"] = account.fUserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else {
                    ModelState.AddModelError("","使用者名稱或密碼錯誤");
                }
            }
                return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
    }
}