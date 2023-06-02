using Demo_Project_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Dotnet_Project2.Controllers
{
    public class SoldController : Controller
    {
        // ProjectDbEntities Db = new ProjectDbEntities();
        // GET: Sold
        private readonly SoldController sold;
        private readonly AppDBContext context;
        public SoldController(AppDBContext context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySold()
        {
            List<Sold> Slist = context.Solds.OrderByDescending(x => x.Id).ToList();
            return View(Slist);
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<String> Slist = context.products.Select(x => x.PName).ToList();
            ViewBag.SName = new SelectList(Slist);
            return View();

        }
        [HttpPost]
        public ActionResult SaleProduct(Sold s)
        {
            context.Solds.Add(s);
            context.SaveChanges();
            return RedirectToAction("DisplaySold");
        }
        [HttpGet]
        public ActionResult SDelete(int Id)
        {
            Sold sd = context.Solds.Where(x => x.Id == Id).SingleOrDefault();
            return View(sd);
        }
        [HttpPost]
        public ActionResult SDelete(int Id, Sold s)
        {

            context.Solds.Remove(context.Solds.Where(x => x.Id == Id).SingleOrDefault());
            context.SaveChanges();
            return RedirectToAction("DisplaySold");
        }
        [HttpGet]
        public ActionResult SDetails(int Id)
        {
            Sold sd = context.Solds.Where(x => x.Id == Id).SingleOrDefault();
            return View(sd);
        }
        [HttpGet]
        public ActionResult SEdit(int Id)
        {
            Sold sd = context.Solds.Where(x => x.Id == Id).SingleOrDefault();
            List<string> Slist = context.products.Select(x => x.PName).ToList();
            ViewBag.SName = new SelectList(Slist);
            return View(sd);
        }
        [HttpPost]
        public ActionResult SEdit(int Id, Sold s)
        {
            Sold sd = context.Solds.Where(x => x.Id == Id).SingleOrDefault();
            sd.SDate = s.SDate;
            sd.SName = s.SName;
            sd.SQunt = s.SQunt;
            context.SaveChanges();
            return RedirectToAction("DisplaySold");
        }
    }
}