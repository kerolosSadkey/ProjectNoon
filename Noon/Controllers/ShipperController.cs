using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
namespace Noon.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
        IUnitOfWork unitOfWork;
        IRepository<Shipper> repoShipper;
        // GET: Shipper

        public ShipperController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repoShipper = unitOfWork.getShipperRepo();
        }
        // GET: Shipper
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
        // POST: Shippers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shipper Shipper)
        {
            if (ModelState.IsValid)
            {
                repoShipper.Add(Shipper);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(Shipper);
        }

        // GET: Shippers/Edit/5
        public ActionResult Edit(int id)
        {
            Shipper Shipper = repoShipper.GetById(id);

            if (Shipper == null)
            {
                return HttpNotFound();
            }
            return View(Shipper);
        }

        // POST: Shipper/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shipper Shipper)
        {
            if (ModelState.IsValid)
            {
                repoShipper.Update(Shipper);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(Shipper);
        }

        public ActionResult Delete(int id)
        {
            repoShipper.Remove(id);
            unitOfWork.Save();
            var Shippers = repoShipper.GetAll();
            return PartialView("_CusPartial", Shippers);
        }
    }
}