using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953501_BYSTROVA.Models;

namespace WEB_953501_BYSTROVA.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> demoList;
        public HomeController()
        {
            demoList = new List<ListDemo>
            {
                new ListDemo(1, "Item 1"),
                new ListDemo(2, "Item 2"),
                new ListDemo(3, "Item 3"),
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lab1()
        {          
            return View();
        }

        public IActionResult Lab2()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["List"] = new SelectList(demoList, "ListItemValue", "ListItemText");

            return View();
        }

        public IActionResult Lab3()
        {
            ViewData["Text"] = "Лабораторная работа 3";

            return View();
        }

        public IActionResult Lab5()
        {
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Lab6()
        {
            ViewData["Text"] = "Лабораторная работа 6";

            return View();
        }

        public IActionResult Lab7()
        {
            return RedirectToAction("Index", "Cart");
        }
    }
}
