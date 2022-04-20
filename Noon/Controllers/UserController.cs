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
using Noon.ViewModels;
using Repository;

namespace Noon.Controllers
{
    public class UserController : Controller
    {
        // Unit Of Work which is responsible on operations on Context
        IUnitOfWork unitOfWork;

        // User Repo which is responsible on operations on user
        IRepository<User> UserRepository;
        IRepository<Phone> PhoneRepository;
        IRepository<Address> AddressRepository;

        // Constructor
        public UserController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepository = unitOfWork.getUserRepo();
            PhoneRepository = unitOfWork.getPhoneRepo();
            AddressRepository = unitOfWork.getAddressRepo();
        }

        // GET: Customers
        public ActionResult Customers()
        {
            // Get all users including his phone and address
            var users = UserRepository.GetAll()
                .Include(u => u.Phones)
                .Include(u => u.Addresses)
                .Where(u => u.Role == "Customer");

            return View("Index",users);
        }

        // GET: Sellers
        public ActionResult Sellers()
        {
            // Get all users including his phone and address
            var users = UserRepository.GetAll()
                .Include(u => u.Phones)
                .Include(u => u.Addresses)
                .Where(u => u.Role == "Seller");

            return View("Index", users);
        }

        // GET: Shippers
        public ActionResult Shippers()
        {
            // Get all users including his phone and address
            var users = UserRepository.GetAll()
                .Include(u => u.Phones)
                .Include(u => u.Addresses)
                .Where(u => u.Role == "Shipper");

            return View("Index", users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Balance = model.Balance,
                    Role = model.Role,
                    IsActive = model.IsActive,
                };
                
                UserRepository.Add(user);
                unitOfWork.Save();

                //var lastUser = UserRepository.GetAll().LastOrDefault();

                var phone = new Phone
                {
                    PhoneNumber = model.PhoneNumber,
                    UserID = user.Id
                };

                var address = new Address
                {
                    Street = model.Street,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    UserID = user.Id
                };

                PhoneRepository.Add(phone);
                AddressRepository.Add(address);

                unitOfWork.Save();

                if(model.Role == "Customer")
                {
                    return RedirectToAction("Customer");
                }
                else if(model.Role == "Seller")
                {
                    return RedirectToAction("Seller");
                }
                else if(model.Role == "Shipper")
                {
                    return RedirectToAction("Seller");
                }
            }

            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(/*int id*/)
        {
            //User user = UserRepository.GetById(id);

            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            return View(/*user*/);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Email,Password,Balance")] User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.Update(user);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Suspend(int id)
        {
            // get the user
            var user = UserRepository.GetById(id);

            // suspend the user
            user.IsActive = false;

            // update database
            UserRepository.Update(user);

            // save updates
            unitOfWork.Save();

            // get all users
            var users = UserRepository.GetAll();

            return PartialView("_UserPartial", users);
        }

        public ActionResult Activate(int id)
        {
            // get the user
            var user = UserRepository.GetById(id);

            // suspend the user
            user.IsActive = true;

            // update database
            UserRepository.Update(user);

            // save updates
            unitOfWork.Save();

            // get all users
            var users = UserRepository.GetAll();

            return PartialView("_UserPartial", users);
        }


    }
}
