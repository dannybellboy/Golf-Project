using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GolfApp.Models;
using GolfApp.Models.ViewModels;
using System.Text;

namespace GolfApp.Controllers
{
    public class HomeController : Controller
    {
        private IShaftRepository repo { get; set; }

        public HomeController(IShaftRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Products(string shaft, int pageNum = 1)
        {

            StringBuilder QParam = new StringBuilder();
            if (pageNum != 0)
            {
                QParam.Append($"Page=-");
            }

            int pageSize = 28;

            var x = new ShaftViewModel
            {
                shaft = repo.shaft
                .Where(x => x.shaftName == shaft || shaft == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumEquipment = repo.shaft
                    .Where(x => x.shaftName == shaft || shaft == null).Count(),
                    EquipmentPerPage = pageSize,
                    CurrentPage = pageNum,
                    UrlParams = QParam.ToString(),
                    LinksPerPage = 10
                }
            };


            return View(x);
        }

        public IActionResult Details(int shaftID)
        {
            var x = repo.shaft
                .Where(x => x.shaftID == shaftID);
            return View(x);
        }
    }
}
