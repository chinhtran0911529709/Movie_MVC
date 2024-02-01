using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_MVC.DAO;
using Movie_MVC.Models;
using Movie_MVC.Common;
namespace Movie_MVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        //public ActionResult Index()
        //{
        //    return View();
        //}


        // login
        // Get: Admin/Login
        
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
  //      [ValidateAntiForgeryToken]
        public ActionResult Login(string username , string password)
        {
            var dao = new UserDAO();
            var result = dao.Login(username, Encryptor.MD5Hash(password), true);
            if(result == 1)
            {
                // == 1 tuc la admin va dung tk , mk
                User user = dao.GetByUserName(username);
                Session.Add("UserName", user.UserName);
                Session.Add("Password", user.Password);
                Session.Add("Id", user.UserID);
                return RedirectToAction("index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
    }
}