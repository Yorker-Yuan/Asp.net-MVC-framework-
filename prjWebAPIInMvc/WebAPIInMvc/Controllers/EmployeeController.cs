using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIInMvc.Models;

namespace WebAPIInMvc.Controllers
{
    public class EmployeeController : ApiController
    {
        private dbCRUDEntities db = new dbCRUDEntities();

        // GET: api/Employee
        public IQueryable<tEmployee> GettEmployees()
        {
            return db.tEmployees;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(tEmployee))]
        public IHttpActionResult GettEmployee(int id)
        {
            tEmployee tEmployee = db.tEmployees.Find(id);
            if (tEmployee == null)
            {
                return NotFound();
            }

            return Ok(tEmployee);
        }
        //修改
        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttEmployee(int id, tEmployee tEmployee)
        {

            if (id != tEmployee.fEmpId)
            {
                return BadRequest();
            }

            db.Entry(tEmployee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        //新增
        // POST: api/Employee
        [ResponseType(typeof(tEmployee))]
        public IHttpActionResult PosttEmployee(tEmployee tEmployee)
        {

            db.tEmployees.Add(tEmployee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tEmployee.fEmpId }, tEmployee);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(tEmployee))]
        public IHttpActionResult DeletetEmployee(int id)
        {
            tEmployee tEmployee = db.tEmployees.Find(id);
            if (tEmployee == null)
            {
                return NotFound();
            }

            db.tEmployees.Remove(tEmployee);
            db.SaveChanges();

            return Ok(tEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tEmployeeExists(int id)
        {
            return db.tEmployees.Count(e => e.fEmpId == id) > 0;
        }
    }
}