using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Model;
using Repository;

namespace Noon.Controllers
{
    public class CustomersController : Controller
    {
        IUnitOfWork unitOfWork;
        IRepository<Customer> CustomerRepository;

        public CustomersController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CustomerRepository = unitOfWork.getCustomerRepo();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = CustomerRepository.GetAll();
            return View(customers);
        }


        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Email,Password,Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.Add(customer);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = CustomerRepository.GetById(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Email,Password,Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.Update(customer);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            CustomerRepository.Remove(id);
            unitOfWork.Save();
            var customers = CustomerRepository.GetAll();
            return PartialView("_CusPartial", customers);
        }


    }
}
