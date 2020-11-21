using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (dbMVCCRUDEntities db = new dbMVCCRUDEntities()) 
            {
                var details = db.tCustomers.ToList();
                return View(details);

            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (dbMVCCRUDEntities db = new dbMVCCRUDEntities())
            {
                var details = db.tCustomers.Where(a=>a.fId == id).FirstOrDefault();
                return View(details);
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(tCustomer customer)
        {
            try
            {
                // TODO: Add insert logic here
                using (dbMVCCRUDEntities db = new dbMVCCRUDEntities())
                {
                    db.tCustomers.Add(customer);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (dbMVCCRUDEntities db = new dbMVCCRUDEntities())
            {
                var details = db.tCustomers.Where(a => a.fId == id).FirstOrDefault();
                return View(details);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tCustomer customer)
        {
            try
            {
                // TODO: Add update logic here
                using (dbMVCCRUDEntities db = new dbMVCCRUDEntities())
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (dbMVCCRUDEntities db = new dbMVCCRUDEntities())
            {
                var details = db.tCustomers.Where(a => a.fId == id).FirstOrDefault();
                return View(details);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (dbMVCCRUDEntities db = new dbMVCCRUDEntities())
                {
                    tCustomer customer = db.tCustomers.Where(a => a.fId == id).FirstOrDefault();
                    db.tCustomers.Remove(customer);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
