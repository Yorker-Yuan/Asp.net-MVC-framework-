using JQueryAjaxInAspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace JQueryAjaxInAspNetMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<tEmployee> GetAllEmployee()
        {
            using (dbJQueryAjaxMVCEntities db = new dbJQueryAjaxMVCEntities())
            {
                return db.tEmployees.ToList<tEmployee>();
            }
        }

        public ActionResult AddOrEdit(int id= 0)
        {
            tEmployee t = new tEmployee();
            if (id != 0)
            {
                using (dbJQueryAjaxMVCEntities db = new dbJQueryAjaxMVCEntities())
                {
                    t = db.tEmployees.Where(a => a.fEmpId == id).FirstOrDefault<tEmployee>();
                }
            }
            return View(t);
        }
        [HttpPost]
        public ActionResult AddOrEdit(tEmployee emp)
        {
            try
            {
                if (emp.fImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(emp.fImageUpload.FileName);
                    string extension = Path.GetExtension(emp.fImageUpload.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.fImagePath = "~/AppFiles/images/" + filename;
                    emp.fImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/images/"), filename));
                }
                using (dbJQueryAjaxMVCEntities db = new dbJQueryAjaxMVCEntities())
                {
                    if (emp.fEmpId == 0)
                    {
                        db.tEmployees.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "成功新增!!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(new { success = false,message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (dbJQueryAjaxMVCEntities db = new dbJQueryAjaxMVCEntities())
                {
                    tEmployee t = db.tEmployees.Where(a => a.fEmpId == id).FirstOrDefault<tEmployee>();
                    db.tEmployees.Remove(t);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "成功刪除!!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}