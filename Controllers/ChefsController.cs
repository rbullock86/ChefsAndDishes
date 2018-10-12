using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Chefs.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Chefs.Controllers
{

    public class ChefsController : Controller
    {
        private ChefsContext dbContext;

        public ChefsController(ChefsContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("Chefs")]
        public IActionResult Chefs()
        {
            Console.WriteLine("Hitting Chefs page");
            // grab all chefs for list
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            return View("Chefs", AllChefs);
        }

        [HttpGet]
        [Route("Dishes")]
        public IActionResult Dishes()
        {
            Console.WriteLine("Hitting Dishes page");
            // grab all dishes for list
            List<Dish> AllDishes = dbContext.Dishes
                                    .Include(dish => dish.creator)
                                    .ToList();
            return View("Dishes", AllDishes);
        }

        [HttpGet]
        [Route("Chefs/New")]
        public IActionResult NewChef()
        {
            Console.WriteLine("Hitting New Chef page");
            // grab all chefs for list
            return View("NewChef");
        }

        [HttpGet]
        [Route("Dishes/New")]
        public IActionResult NewDishes()
        {
            Console.WriteLine("Hitting New Dish page");
            // grab all chefs for list
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("NewDish");
        }

        [HttpPost]
        [Route("Chefs/create")]
        public IActionResult CreateChef(Chef NewChef)
        {
            Console.WriteLine("Hitting Create New Chef");
            if(ModelState.IsValid)
            {
                Console.WriteLine("NewChef data is valid");
                dbContext.Add(NewChef);
                dbContext.SaveChanges();
                return RedirectToAction("Chefs");
            }
            return View("NewChef");
        }

        [HttpPost]
        [Route("Dishes/create")]
        public IActionResult CreateDish(Dish NewDish)
        {
            Console.WriteLine("Hitting Create New Dish");
            if(ModelState.IsValid)
            {
                Console.WriteLine("NewDish data is valid");
                dbContext.Add(NewDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("NewDish");
        }
    }
}