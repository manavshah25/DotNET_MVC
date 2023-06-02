using Demo_Project_MVC.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Demo_Project_MVC.Controllers
{
    public class BoughtController : Controller
    {
        //ProjectDb Db = new ProjectDbEntities();
        private readonly BoughtController bought;
        private readonly AppDBContext context;
        public BoughtController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: Bought
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayBought()
        {
            List<Bought> Blist = context.Boughts.OrderByDescending(x => x.Id).ToList();
            return View(Blist);
        }
        [HttpGet]
        public ActionResult BuyProduct()
        {
            List<String> Blist = context.products.Select(x => x.PName).ToList();
            ViewBag.BName = new SelectList(Blist);
            return View();

        }
        [HttpPost]
        public ActionResult BuyProduct(Bought b)
        {
            context.Boughts.Add(b);
            context.SaveChanges();
            return RedirectToAction("DisplayBought");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Bought buy = context.Boughts.Where(x => x.Id == Id).SingleOrDefault();
            return View(buy);
        }
        [HttpPost]
        public ActionResult Delete(int Id, Bought b)
        {
            context.Boughts.Remove(context.Boughts.Where(x => x.Id == Id).SingleOrDefault());
            context.SaveChanges();
            return RedirectToAction("DisplayBought");
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            Bought bu = context.Boughts.Where(x => x.Id == Id).SingleOrDefault();
            return View(bu);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Bought buy = context.Boughts.Where(x => x.Id == Id).SingleOrDefault();
            List<string> Blist = context.products.Select(x => x.PName).ToList();
            ViewBag.BName = new SelectList(Blist);
            return View(buy);
        }
        [HttpPost]
        public ActionResult Edit(int Id, Bought b)
        {
            Bought buy = context.Boughts.Where(x => x.Id == Id).SingleOrDefault();
            buy.BDate = b.BDate;
            buy.BName = b.BName;
            buy.BQunt = b.BQunt;
            context.SaveChanges();
            return RedirectToAction("DisplayBought");
        }
    }
}