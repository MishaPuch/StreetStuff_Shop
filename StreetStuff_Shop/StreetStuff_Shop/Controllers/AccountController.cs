using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using StreetStuff_Shop.ViewModels;

namespace StreetStuff_Shop.Controllers
{
    public class AccountController : Controller
    {
        private IDbContext db;
        public AccountController(IDbContext db) 
        { 
            this.db = db;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            User ? user=db.AppDbContext().Users.FirstOrDefault(u=>u.Email==login.email &&u.Password==login.password );
            if (user != null)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return Redirect("Login");
            }
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Profile(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult CreateAccount()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
