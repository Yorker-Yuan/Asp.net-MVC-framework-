using MVCCheckBoxList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCheckBoxList.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductModel product = new ProductModel();
            using (DbModels db = new DbModels())
            {
                product.Products = db.tProducts.ToList<tProduct>();
            }
            return View(product);

        }
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            var selectedProduct = model.Products.Where(a => a.IsChecked == true).ToList<tProduct>();
            //建立內容物件
            return Content(string.Join("-",selectedProduct.Select(b=>b.fProductName)));

        }
    }
}