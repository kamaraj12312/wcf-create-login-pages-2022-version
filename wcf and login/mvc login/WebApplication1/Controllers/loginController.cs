using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class loginController : Controller
    {

        ServiceReference1.Service1Client ser = new ServiceReference1.Service1Client();
        ServiceReference1.vlogin vlogin = new ServiceReference1.vlogin();
        [HttpGet]

        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login(ServiceReference1.vlogin vlog)
        {
            string check = ser.UserLogin(vlog);
            if (check == "true")
            {
                Session["Username"] = vlog.UserName.ToString();
                return RedirectToAction("User", "Login");
            }
            else
            {
                TempData["error"] = "<script> alert('Incorrect Usrename or Password... Please try again')</script>";
                return View();
            }
        }
    }
}