using Demo_Project_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Demo_Project_MVC.Controllers
{
   
    public class ProductController : Controller
    {
        //ProjectDb Db = new ProjectDbEntities();
        private readonly ProductController Product;
        private readonly AppDBContext context;
        public ProductController(AppDBContext context)
        {
            this.context = context;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> Plist = context.products.OrderByDescending(x => x.Id).ToList();
            return View(Plist);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            context.products.Add(p);
            context.SaveChanges();
            return RedirectToAction("DisplayProduct");    
        }
        [HttpGet]
        public ActionResult UpdateProduct(int Id)
        {
            Product pr = context.products.Where(x => x.Id == Id).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int Id, Product p)
        {
            Product pr = context.products.Where(x => x.Id == Id).SingleOrDefault();
            pr.PName = p.PName;
            pr.PQunt = p.PQunt;
            context.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            Product pr = context.products.Where(x => x.Id == Id).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int Id, Product p)
        {
            context.products.Remove(context.products.Where(x => x.Id == Id).SingleOrDefault());
            context.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        public ActionResult Details(int Id)
        {
            Product pr = context.products.Where(x => x.Id == Id).SingleOrDefault();
            return View(pr);
        }
    }
}