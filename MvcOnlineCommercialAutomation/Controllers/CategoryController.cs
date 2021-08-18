﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context con = new Context();

        public ActionResult Index()
        {
            var values = con.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            con.Categories.Add(c);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var ctg = con.Categories.Find(id);
            con.Categories.Remove(ctg);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCategory(int id)
        {
            var category = con.Categories.Find(id);
            return View("BringCategory", category);
        }

        public ActionResult UpdateCategory(Category c)
        {
            var ctg = con.Categories.Find(c.CategoryID);
            ctg.CategoryName = c.CategoryName;
            con.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}