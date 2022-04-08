using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
namespace Noon.Controllers
{
    public class SellerController : Controller
    {
        IUnitOfWork unitOfWork;
        IRepository<Seller> repoSeller;
        // GET: Seller

        public SellerController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repoSeller = unitOfWork.getSellerRepo();
        }
        // GET: Seller
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
        // POST: Sellers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seller Seller)
        {
            if (ModelState.IsValid)
            {
                repoSeller.Add(Seller);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(Seller);
        }

        // GET: Sellers/Edit/5
        public ActionResult Edit(int id)
        {
            Seller Seller = repoSeller.GetById(id);

            if (Seller == null)
            {
                return HttpNotFound();
            }
            return View(Seller);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seller Seller)
        {
            if (ModelState.IsValid)
            {
                repoSeller.Update(Seller);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(Seller);
        }

        public ActionResult Delete(int id)
        {
            repoSeller.Remove(id);
            unitOfWork.Save();
            var sellers = repoSeller.GetAll();
            return PartialView("_CusPartial", sellers);
        }
    }
}