using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Web.Models;
using EShop.Web.ViewModels;

namespace EShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private EshopDbContext db = new EshopDbContext();
        private Product aProduct = new Product();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList().Where(x=>x.Stock>0));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UnitPrice,Stock,Vat,BuyFrom,PurchaseDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UnitPrice,Stock,Vat,BuyFrom,PurchaseDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            ViewBag.Products = new SelectList(db.Products.Where(x => x.Stock > 0).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(SaleProductViewModel model)
        {
            ViewBag.Products = new SelectList(db.Products.Where(x => x.Stock > 0).ToList(), "Id", "Name");
            if (!ModelState.IsValid)
                return View();
            if (model.Quantity > 0)
            {
                var product = db.Products.FirstOrDefault(x => x.Id == model.ProductId);
                product.Stock = product.Stock - model.Quantity;
            }
            var saleProduct = new SaleProduct
            {
                ProductId = model.ProductId,
                TotalPrice = model.TotalPrice,
                Quantity = model.Quantity,
                SaleDate = DateTime.Now
            };
            db.SaleProducts.Add(saleProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetAvailableProductById(int ProductId)
        {
            var products = db.Products.ToList();
            var company = products.FirstOrDefault(c => c.Id == ProductId);
            if (company != null)
                return Json(new
                {
                    Available = company.Stock
                }, JsonRequestBehavior.AllowGet);
            return null;
        }

        [HttpPost]
        public ActionResult GetTotalPriceByQuantity(int Quantity, int ProductId)
        {
            var products = db.Products.FirstOrDefault(x => x.Id == ProductId);
            if (products != null)
            {
                return Json(new
                {
                    TotalPrice = products.UnitPrice * Quantity
                }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult CurrentMonthSale()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return View(db.SaleProducts.Where(x => x.SaleDate >= startDate && x.SaleDate <= endDate));
        }
    }
}
