using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using OnlineShop.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var implementationCategory = new CategoryModel();
            var model = implementationCategory.ListAll();
            return View( model );
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            // After clicked submit, this function will be called
            try
            {
                // TODO: Add insert logic here
                if( !ModelState.IsValid ) throw new Exception("Error occured when create new Category.");

                var model = new CategoryModel();
                int insertedID = model.Create
                (
                    collection.Name,
                    collection.Alias,
                    collection.ParentID,
                    collection.Order,
                    collection.Status
                );

                if( insertedID <= 0 ) throw new Exception( "Error occured when create new Category." );

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError( "", ex.Message );
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
