using Gac.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Gac.mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context context;

        public ProductController(Context _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var products = context.Products.Include(p => p.Sales).ToList();
            ViewBag.SalesList = context.Sales.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            // Ensure Sales is not null before saving
            product.Sales = context.Sales.FirstOrDefault(s => s.SalesId == product.SalesId);

            // Check if Sales exists before proceeding
            if (product.Sales == null)
            {
                ViewBag.ErrorMessage = "Invalid Sales ID selected.";
                ViewBag.SalesList = context.Sales.ToList();
                return View("Index", context.Products.Include(p => p.Sales).ToList());
            }

            // Calculate Amount
            product.Amount = product.Unit * product.Price;

            // Save product
            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public JsonResult GetSalesDetails(int salesId)
        {
            var sales = context.Sales.FirstOrDefault(s => s.SalesId == salesId);
            return Json(sales);
        }
    }
}
