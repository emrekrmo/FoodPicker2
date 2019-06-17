using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodPicker.Controllers
{
    public class HomeController : Controller
    {
        //private readonly UnitOfWork _uw;
        //public HomeController()
        //{
        //    _uw = new UnitOfWork();
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Register()
        //{
        //    return View();
        //}

        public ActionResult ComingSoon()
        {
            return View();
        }
    }
}