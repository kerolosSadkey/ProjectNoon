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

            return View("Index", users);
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
            return View("UserForm");
        }

        // POST: Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // means you create new user not updating
                if (model.Id == 0)
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

                    if (model.Role == "Customer")
                    {
                        return RedirectToAction("Customers");
                    }
                    else if (model.Role == "Seller")
                    {
                        return RedirectToAction("Seller");
                    }
                    else if (model.Role == "Shipper")
                    {
                        return RedirectToAction("Seller");
                    }
                }
                else
                {
                    var user = UserRepository.GetAll().Where(u => u.Id == model.Id)
                        .Include(u => u.Phones)
                        .Include(u => u.Addresses)
                        .FirstOrDefault();

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Balance = model.Balance;
                    user.Role = model.Role;
                    user.IsActive = model.IsActive;
                    user.Phones.FirstOrDefault().PhoneNumber = model.PhoneNumber;
                    user.Addresses.FirstOrDefault().City = model.City;
                    user.Addresses.FirstOrDefault().Street = model.Street;
                    unitOfWork.Save();
                }

            }

            if (model.Role == "Customer")
            {
                return RedirectToAction("Customers");
            }
            else if (model.Role == "Seller")
            {
                return RedirectToAction("Seller");
            }
            else if (model.Role == "Shipper")
            {
                return RedirectToAction("Seller");
            }
            else
            {
                return RedirectToAction("Admin");

            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = UserRepository.GetAll().Where(u => u.Id == id)
                .Include(u => u.Phones)
                .Include(u => u.Addresses)
                .FirstOrDefault();

            if (user == null)
            {
                return HttpNotFound();
            }

            var UserViewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Balance = user.Balance,
                Role = user.Role,
                IsActive = user.IsActive,
                PhoneNumber = user.Phones.FirstOrDefault().PhoneNumber,
                Street = user.Addresses.FirstOrDefault().Street,
                City = user.Addresses.FirstOrDefault().City,
            };

            return View("UserForm", UserViewModel);
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
