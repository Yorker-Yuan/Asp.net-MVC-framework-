using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<CEmployee> empList;
            HttpResponseMessage res = GlobalVariables.webAPIClient.GetAsync("Employee").Result;
            empList = res.Content.ReadAsAsync<IEnumerable<CEmployee>>().Result;
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CEmployee());
            else
            {
                HttpResponseMessage res = GlobalVariables.webAPIClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(res.Content.ReadAsAsync<CEmployee>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(CEmployee emp)
        {
            if (emp.fEmpId == 0)
            {
                HttpResponseMessage res = GlobalVariables.webAPIClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMsg"] = "新增成功!!";
            }
            else
            {
                HttpResponseMessage res = GlobalVariables.webAPIClient.PutAsJsonAsync("Employee/" + emp.fEmpId, emp).Result;
                TempData["SuccessMsg"] = "更新成功!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage res = GlobalVariables.webAPIClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMsg"] = "刪除成功!!";
            return RedirectToAction("Index");
        }
    }
}