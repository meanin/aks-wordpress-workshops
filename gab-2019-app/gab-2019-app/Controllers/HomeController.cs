using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using gab_2019_app.Models;

namespace gab_2019_app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var hostname = Environment.GetEnvironmentVariable("HOSTNAME");
            var digits = new string(hostname.Where(char.IsDigit).TakeLast(2).ToArray());
            if (!int.TryParse(digits, out var number))
                number = 0;
            var model = new IndexViewModel
            {
                Hostname = hostname,
                Color = GetColor(number)
            };
            return View(model);
        }

        private string GetColor(int number)
        {
            switch (number % 10)
            {
                case 0: return "#ff0000";
                case 1: return "#ff4000";
                case 2: return "#ff8000";
                case 3: return "#ffbf00";
                case 4: return "#ffff00";
                case 5: return "#bfff00";
                case 6: return "#80ff00";
                case 7: return "#40ff00";
                case 8: return "#00ff00";
                default: return "#00ff40";

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
