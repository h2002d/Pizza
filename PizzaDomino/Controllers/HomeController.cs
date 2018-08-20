﻿using PizzaDomino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaDomino.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Goods action

        public ActionResult CreateGood()
        {
            ViewBag.Categories = Category.GetCategoryById(null);
            var good = new Goods();
            return View(good);
        }

        public ActionResult EditGood(int id)
        {
            ViewBag.Categories = Category.GetCategoryById(null);
            Goods good = Goods.GetGoodById(id).First();
            return View("CreateGood", good);
        }

        [HttpPost]
        public ActionResult CreateGood(Goods newGood)
        {
            int id = newGood.Save();

            // file is uploaded

            return RedirectToAction("EditGood", new { id = id });
        }

        [HttpPost]
        public JsonResult UploadImage()
        {
            try
            {
                HttpPostedFile file = null;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    file = System.Web.HttpContext.Current.Request.Files["HttpPostedFileBase"];
                }
                string stamp = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
                string filename = file.FileName.Split('.')[0] + stamp + "." + file.FileName.Split('.')[1];
                string pic = System.IO.Path.GetFileName(filename);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/Goods"), pic);
                file.SaveAs(path);
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Ingredients actions
        public ActionResult CreateIngredient(int goodId)
        {
            var ingredient = new Ingredients();
            ingredient.GoodId = goodId;
            return View(ingredient);
        }

        public ActionResult EditIngredient(int id)
        {
            Ingredients ingredient = Ingredients.GetIngredientsById(id).First();
            return View("CreateIngredient", ingredient);
        }

        [HttpPost]
        public JsonResult CreateIngredient(Ingredients newIngredient)
        {
            newIngredient.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteTemplate(int id)
        {
            Ingredients ingredient = Ingredients.GetIngredientsById(id).FirstOrDefault();
            ingredient.Delete();
            return null;
        }
        #endregion

        #region Category
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category newCategory)
        {
            newCategory.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            Category category = Category.GetCategoryById(id).FirstOrDefault();
            category.Delete();
            return RedirectToAction("Index");
        }
        public ActionResult EditCategory(int id)
        {
            return View("CreateCategory", new { id = id });
        }
        #endregion
    }
}