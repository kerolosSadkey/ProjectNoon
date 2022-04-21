using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noon.Controllers
{
    public class AuthController : Controller
    {
        IUnitOfWork unitOfWork;
        IRepository<User> UserRepository;

        public AuthController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepository = unitOfWork.getUserRepo();
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User _admin)
        {
            var result = UserRepository.GetAll()
                .Where(u => u.Role == "Admin")
                .Where(u => u.Email == _admin.Email)
                .Where(u => u.Password == _admin.Password)
                .FirstOrDefault();

            if (result == null)
                return View("Index");

            Session["Admin"] = _admin;
            return RedirectToAction("Index", "User", new {Role = "Customer"});
        }
    }
}