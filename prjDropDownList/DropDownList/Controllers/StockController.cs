using DropDownList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownList.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult AddOrEdit(int id=0)
        {
            tStock stock = new tStock();
            using (dbMVCProEntities db = new dbMVCProEntities())
            {
                if (id == 0)
                    stock = db.tStocks.Where(a => a.fStockId == id).FirstOrDefault();
                stock.ProductCollection = db.tProducts.ToList<tProduct>();
            }
            
            return View(stock);
        }
        [HttpPost]
        public ActionResult AddOrEdit(tStock stock)
        {
            
            return View(stock);
        }
    }
}