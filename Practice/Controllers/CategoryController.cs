using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = CategoryDataContext.LoadCategories();
            return View(categories);
        }

        public ActionResult Insert()
        {
            if (Request.Form.Count > 0)
            {
                Category _category = new Category();
                _category.CategoryName = Request.Form["CategoryName"];
                _category.Description = Request.Form["Description"];
                CategoryDataContext.InsertCategory(_category);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category _category = CategoryDataContext.LoadCategoryByID(id);
            return View(_category);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            Category _Category = new Category();
            _Category.CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            _Category.CategoryName = Request.Form["CategoryName"];
            _Category.Description = Request.Form["Description"];
            CategoryDataContext.EditCategory(_Category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            CategoryDataContext.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}