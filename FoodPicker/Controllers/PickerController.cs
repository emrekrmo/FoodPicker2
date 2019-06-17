using BLL;
using Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodPicker.Controllers
{
    public class PickerController : Controller
    {
        private readonly UnitOfWork _uw;
        public PickerController()
        {
            _uw = new UnitOfWork();
        }

        // GET: Picker
        public ActionResult Index()
        {
            bool es = User.Identity.IsAuthenticated;

            List<Food> foodList = _uw.foodRep.GetAll();

            string strUserId = User.Identity.GetUserId();
            foodList = _uw.db.Foods.Where(x => x.ApplicationUserId == strUserId).ToList();

            //List<Food> foodList = _uw.foodRep.GetAll();
            //ViewBag.RandomFood = _uw.foodRep.RandomFood();
            //ViewBag.HealthyRandomFood = _uw.foodRep.HealtyRandomFood();

            return View(foodList);
        }

        public ActionResult AllRandom()
        {
            List<Food> foodList = _uw.foodRep.GetAll();

            string strUserId = User.Identity.GetUserId();
            foodList = _uw.db.Foods.Where(x => x.ApplicationUserId == strUserId).ToList();

            Random rnd = new Random();
            Food randomFood = foodList.ElementAt(rnd.Next(foodList.Count()));

            ViewBag.RandomFood = randomFood;

            return View();
        }

        public ActionResult HealthyRandom()
        {
            string strUserId = User.Identity.GetUserId();
            List<Food> healthyFoodList = _uw.db.Foods.Where(x => x.IsHealty == true && x.ApplicationUserId == strUserId).ToList();

            Random rnd = new Random();
            Food randomHealtyFood = healthyFoodList.ElementAt(rnd.Next(healthyFoodList.Count()));

            ViewBag.RandomFood = randomHealtyFood;

            return View();
        }

        //[HttpPost]
        //public ActionResult SelectedRandom(List<Food> selectedFoodList)
        //{
        //    ViewBag.SelectedRandomFood = _uw.foodRep.SelectedRandomFood(selectedFoodList);
        //    return View();
        //}
    }
}