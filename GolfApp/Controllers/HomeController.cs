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
using System.IO;

namespace GolfApp.Controllers
{
    public class HomeController : Controller
    {
        private IEquipmentRepository repo { get; set; }

        public HomeController(IEquipmentRepository temp)
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

        public IActionResult Products(string category, int pageNum = 1)
        {

            StringBuilder QParam = new StringBuilder();
            if (pageNum != 0)
            {
                QParam.Append($"Page=-");
            }

            int pageSize = 28;

            var x = new EquipmentViewModel
            {
                equipment = repo.equipment
                .Where(x => x.Category == category || category == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumEquipment = repo.equipment
                    .Where(x => x.Category == category || category == null).Count(),
                    EquipmentPerPage = pageSize,
                    CurrentPage = pageNum,
                    UrlParams = QParam.ToString(),
                    LinksPerPage = 10
                }
            };


            return View(x);
        }

        public IActionResult Details(string referencehandle)
        {
            var x = repo.equipment
                .Single(x => x.Reference_Handle == referencehandle || referencehandle == null);
            return View(x);
        }

        public IActionResult AddProduct()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            BufferedSingleFileUploadDb entities = new BufferedSingleFileUploadDb();
            entities.tblFiles.Add(new tblFile
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            entities.SaveChanges();
            return RedirectToAction("AddProduct");
        }
    }
}
