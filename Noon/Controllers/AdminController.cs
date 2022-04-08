using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
namespace Noon.Controllers
{
    public class AdminController : Controller
    {
        IUnitOfWork unitOfWork;
        IRepository<Admin> repoAdmin;
        // GET: Admin

        public AdminController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repoAdmin = unitOfWork.getAdminRepo();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

      

        // POST: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin Admin)
        {
            if (ModelState.IsValid)
            {
                repoAdmin.Add(Admin);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(Admin);
        }


        // GET: Admins/Edit/5
        public ActionResult Edit(int id)
        {
            Admin Admin = repoAdmin.GetById(id);

            if (Admin == null)
            {
                return HttpNotFound();
            }
            return View(Admin);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin Admin)
        {
            if (ModelState.IsValid)
            {
                repoAdmin.Update(Admin);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(Admin);
        }

        public ActionResult Delete(int id)
        {
            repoAdmin.Remove(id);
            unitOfWork.Save();
            var Admins = repoAdmin.GetAll();
            return PartialView("_CusPartial", Admins);
        }
    }
}