using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repository;
namespace Noon.Controllers
{
    public class CategoryController : Controller
    {

        IUnitOfWork unitOfWork;
        IRepository<Category> repoCatogry;
        // GET: Catogry

        public CategoryController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repoCatogry = unitOfWork.getCategoryRepo();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {
            if (ModelState.IsValid)
            {
                repoCatogry.Add(Category);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(Category);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Category Catogry = repoCatogry.GetById(id);

            if (Catogry == null)
            {
                return HttpNotFound();
            }
            return View(Catogry);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category Catogry)
        {
            if (ModelState.IsValid)
            {
                repoCatogry.Update(Catogry);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(Catogry);
        }

        public ActionResult Delete(int id)
        {
            repoCatogry.Remove(id);
            unitOfWork.Save();
            var customers = repoCatogry.GetAll();
            return PartialView("_CusPartial", customers);
        }
    }
}