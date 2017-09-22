using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginRegister.Models;
namespace loginRegister.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {

            using (OurDBcontext db= new OurDBcontext())
            {
                return View(db.UserAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount Account)
        {
            if (ModelState.IsValid)
            {
                using (OurDBcontext db= new OurDBcontext())
                {
                    db.UserAccount.Add(Account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = Account.FirstName + " " + Account.LastName + " Successfully Registered";
            }
            return View();
        }

        //methods for login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount User)
        {
            using (OurDBcontext db= new OurDBcontext())
            {
                var usr= db.UserAccount.Single(u=>u.UserName== User.UserName && u.Password== User.Password);
                if (usr!= null)
	                {
		                Session["UserId"]= usr.UserId.ToString() ;
                        Session["UserName"] = usr.UserName.ToString();
                        return RedirectToAction("LoggedIn");
                	}
                else
                {
                    ModelState.AddModelError("", "UserName and Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"]!= null)
            {
                return View(); 
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
	}
}