using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistation.Models;

namespace UserRegistation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
            tUser user = new tUser();
            return View(user);
        }

        [HttpPost]
        public ActionResult AddOrEdit(tUser user)
        {
            using (dbUserRegistationEntities db = new dbUserRegistationEntities())
            {
                if(db.tUser.Any(a=>a.fName == user.fName))
                {
                    ViewBag.DuplicateMsg = "會員已存在";
                    return View("AddOrEdit", user);
                }
                db.tUser.Add(user);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.successMsg = "註冊成功!";
                return View("AddOrEdit",new tUser());
        }
    }
}