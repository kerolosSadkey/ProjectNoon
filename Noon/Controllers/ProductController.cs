using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
namespace Noon.Controllers
{
    public class ProductController : Controller
    {
        IUnitOfWork unitOfWork;
        IRepository<Product> repoProduct;
        // GET: Product

        public ProductController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repoProduct = unitOfWork.getProductRepo();
        }
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
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repoProduct.Add(product);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = repoProduct.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repoProduct.Update(product);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            repoProduct.Remove(id);
            unitOfWork.Save();
            var customers = repoProduct.GetAll();
            return PartialView("_CusPartial", customers);
        }
    }
}