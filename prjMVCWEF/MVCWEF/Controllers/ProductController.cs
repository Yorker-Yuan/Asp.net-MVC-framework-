using MVCWEF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWEF.Controllers
{
    public class ProductController : Controller
    {
        string connectionStrings = @"Data Source = LAPTOP-49GQ7CD1\SQLEXPRESS;Initial Catalog = dbMVCCRUD; Integrated Security = True;";
        [HttpGet]
        // GET: Product
        public ActionResult Index()
        {
            DataTable dtbProduct = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionStrings))
            {
                con.Open();
                SqlDataAdapter sqladapter = new SqlDataAdapter("SELECT * FROM tProduct",con);
                sqladapter.Fill(dtbProduct);
            }
                return View(dtbProduct);
        }
        [HttpGet]
        // GET: Product/Create
        public ActionResult Create()
        {
            var product = new CProduct();
            return View(product);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(CProduct product)
        {
            using (SqlConnection con = new SqlConnection(connectionStrings))
            {
                con.Open();
                string query = "INSERT INTO tProduct VALUES (@fProductName,@fPrice,@fCount)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@fProductName",product.fProductName);
                cmd.Parameters.AddWithValue("@fPrice", product.fPrice);
                cmd.Parameters.AddWithValue("@fCount", product.fCount);
                cmd.ExecuteNonQuery();
                
            }
                return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            CProduct product = new CProduct();
            DataTable dtb = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionStrings))
            {
                con.Open();
                string query = "SELECT * FROM tProduct Where fProductId = @fProductId";
                SqlDataAdapter adapter = new SqlDataAdapter(query,con);
                adapter.SelectCommand.Parameters.AddWithValue("@fProductId",id);
                adapter.Fill(dtb);
            }
            if (dtb.Rows.Count == 1)
            {
                product.fProductId = Convert.ToInt32(dtb.Rows[0][0].ToString());
                product.fProductName = dtb.Rows[0][1].ToString();
                product.fPrice = Convert.ToDecimal(dtb.Rows[0][2].ToString());
                product.fCount = Convert.ToInt32(dtb.Rows[0][3].ToString());
                return View(product);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(CProduct product)
        {
            using (SqlConnection con = new SqlConnection(connectionStrings))
            {
                con.Open();
                string query = "UPDATE tProduct SET fProductName = @fProductName,fPrice = @fPrice,fCount = @fCount where fProductId = @fProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fProductId", product.fProductId);
                cmd.Parameters.AddWithValue("@fProductName", product.fProductName);
                cmd.Parameters.AddWithValue("@fPrice", product.fPrice);
                cmd.Parameters.AddWithValue("@fCount", product.fCount);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionStrings))
            {
                con.Open();
                string query = "DELETE FROM tProduct where fProductId = @fProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fProductId", id);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        
    }
}
