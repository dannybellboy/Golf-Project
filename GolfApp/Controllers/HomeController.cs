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
using Microsoft.AspNetCore.Hosting;

namespace GolfApp.Controllers
{
    public class HomeController : Controller
    {
        private IShaftRepository repo { get; set; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IShaftRepository temp, IWebHostEnvironment webHostEnvironment)
        {
            repo = temp;
            _webHostEnvironment = webHostEnvironment;
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
                shaft = repo.shafts
                .Where(x => x.shaftName == shaft || shaft == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumEquipment = repo.shafts
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
            var x = new ShaftViewModel
            {
                shaft = repo.shafts
                .Where(x => x.shaftID == shaftID)
            };

            return View(x);
        }

        public IActionResult AddProduct()
        {
            
            return View();

        }
        //[HttpPost]
        /*public ActionResult AddProduct(HttpPostedFileBase postedFile)
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
        }*/
        public IActionResult Admin()
        {
            ViewBag.ShaftCount = repo.shafts.Count();
            ViewBag.BrandCount = repo.brands.Count();
            ViewBag.AdapterCount = repo.adapterSettings.Count();
            ViewBag.BuildTypeCount = repo.buildTypes.Count();
            ViewBag.GripModelCount = repo.gripModels.Count();
            ViewBag.ModelFlexCount = repo.modelFlexes.Count();
            return View();
        }

        public IActionResult AdminTable(string model, string searchString)
        {
            object x = repo.shafts.ToList();
            Dictionary<int, string> dic = new Dictionary<int, string>();
            switch (model)
            {
                case "shaft":
                    ViewBag.currModel = "shafts";
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        x = repo.shafts.Where(s => s.shaftName.Contains(searchString)).ToList();
                    } else
                    {
                        x = repo.shafts.ToList();
                    }
                    break;
                case "brand":
                    ViewBag.currModel = "brands";
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        x = repo.brands.Where(s => s.brandName.Contains(searchString)).ToList();
                    }
                    else
                    {
                        x = repo.brands.ToList();
                    }
                    break;
                case "adapter":
                    ViewBag.currModel = "adapter";
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        x = repo.adapterSettings.Where(s => s.adapterName.Contains(searchString)).ToList();
                    }
                    else
                    {
                        x = repo.adapterSettings.ToList();
                    }
                    List<AdapterSettings> adapters = (List <AdapterSettings>) x;
                    foreach (var adapter in adapters)
                    {
                        Brand b = repo.brands.Single(b => b.brandID == adapter.brandID);
                        try
                        {
                            dic.Add(adapter.brandID, b.brandName);
                        } catch
                        {

                        }
                    }
                    ViewBag.dict = dic;
                    break;
                case "type":
                    ViewBag.currModel = "type";
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        x = repo.buildTypes.Where(s => s.typeName.Contains(searchString)).ToList();
                    }
                    else
                    {
                        x = repo.buildTypes.ToList();
                    }
                    break;
                case "grip":
                    ViewBag.currModel = "grip";
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        x = repo.gripModels.Where(s => s.gripModel.Contains(searchString)).ToList();
                    }
                    else
                    {
                        x = repo.gripModels.ToList();
                    }
                    List<GripModel> grips = (List<GripModel>)x;
                    foreach (var grip in grips)
                    {
                        Brand b = repo.brands.Single(b => b.brandID == grip.brandID);
                        try
                        {
                            dic.Add(grip.brandID, b.brandName);
                        }
                        catch
                        {

                        }
                    }
                    ViewBag.dict = dic;
                    break;
                case "modelFlex":
                    ViewBag.currModel = "modelFlex";
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        x = repo.modelFlexes.Where(s => s.modelFlexName.Contains(searchString)).ToList();
                    }
                    else
                    {
                        x = repo.modelFlexes.ToList();
                    }
                    break;
                default:
                    break;
            }
            return View(x);
        }







        [HttpGet]
        public IActionResult AdminAddShaft()
        {
            ViewBag.currModel = "Shaft";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminAddShaftAsync(Shaft x)
        {
            string folder = "";

            if (x.shaftImage != null)
            {
                folder = "shafts/images/";
                folder += Guid.NewGuid().ToString() + "_" + x.shaftImage.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                await x.shaftImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); ;

            }
            x.imagePath = folder ;
            x.shaftID = repo.GetMaxID("shaft") + 1;
            repo.CreateShaft(x);
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult AdminAddBrand()
        {
            ViewBag.currModel = "Brand";
            return View();
        }

        [HttpPost]
        public IActionResult AdminAddBrand(Brand x)
        {
            x.brandID = repo.GetMaxID("brand") + 1;
            repo.CreateBrand(x);
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult AdminAddAdapterSetting()
        {
            ViewBag.currModel = "Adapter Settings";
            ViewBag.Brands = repo.brands.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AdminAddAdapterSetting(AdapterSettings x)
        {
            x.adapterID = repo.GetMaxID("adapterSetting") + 1;
            repo.CreateAdapterSettings(x);
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult AdminAddBuildType()
        {
            ViewBag.currModel = "Build Type";
            return View();
        }

        [HttpPost]
        public IActionResult AdminAddBuildType(BuildType x)
        {
            x.typeID = repo.GetMaxID("buildType") + 1;
            repo.CreateBuildType(x);
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult AdminAddGripModel()
        {
            ViewBag.currModel = "Grip Model";
            ViewBag.Brands = repo.brands.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AdminAddGripModel(GripModel x)
        {
            x.gripID = repo.GetMaxID("grip") + 1;
            repo.CreateGripModel(x);
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult AdminAddModelFlex()
        {
            ViewBag.currModel = "Model Flex";
            return View();
        }

        [HttpPost]
        public IActionResult AdminAddModelFlex(ModelFlex x)
        {
            x.modelFlexID = repo.GetMaxID("modelFlex") + 1;
            repo.CreateModelFlex(x);
            return RedirectToAction("Admin");
        }








        [HttpGet]
        public IActionResult AdminEditShaft(int shaftID)
        {

            var x = repo.shafts.Where(x => x.shaftID == shaftID).Single();
            x.shaftID = shaftID;
            ViewBag.ID = shaftID;


            return View("AdminAddShaft", x);


        }
        [HttpPost]
        public IActionResult AdminEditShaft(Shaft s)
        {

                repo.SaveShaft(s);
                return RedirectToAction("AdminTable", new {model = "shaft", searchString = ""});
 
        }

        [HttpGet]
        public IActionResult AdminEditBrand(int brandID)
        {

            var x = repo.brands.Where(x => x.brandID == brandID).Single();
            x.brandID = brandID;
            ViewBag.ID = brandID;

            return View("AdminAddBrand", x);


        }
        [HttpPost]
        public IActionResult AdminEditBrand(Brand b)
        {

            repo.SaveBrand(b);
            return RedirectToAction("AdminTable", new { model = "brand", searchString = "" });

        }

        [HttpGet]
        public IActionResult AdminEditAdapterSetting(int adapterID)
        {

            var x = repo.adapterSettings.Where(x => x.adapterID == adapterID).Single();
            x.adapterID = adapterID;
            ViewBag.ID = adapterID;
            ViewBag.Brands = repo.brands.ToList();


            return View("AdminAddAdapterSetting", x);


        }
        [HttpPost]
        public IActionResult AdminEditAdapterSetting(AdapterSettings a)
        {

            repo.SaveAdapterSettings(a);
            return RedirectToAction("AdminTable", new { model = "adapter", searchString = "" });

        }

        [HttpGet]
        public IActionResult AdminEditBuildType(int typeID)
        {

            var x = repo.buildTypes.Where(x => x.typeID == typeID).Single();
            x.typeID = typeID;
            ViewBag.ID = typeID;

            return View("AdminAddBuildType", x);


        }
        [HttpPost]
        public IActionResult AdminEditBuildType(Brand b)
        {

            repo.SaveBrand(b);
            return RedirectToAction("AdminTable", new { model = "type", searchString = "" });

        }

        [HttpGet]
        public IActionResult AdminEditGripModel(int gripID)
        {

            var x = repo.gripModels.Where(x => x.gripID == gripID).Single();
            x.gripID = gripID;
            ViewBag.ID = gripID;
            ViewBag.Brands = repo.brands.ToList();


            return View("AdminAddGripModel", x);


        }
        [HttpPost]
        public IActionResult AdminEditGripModel(GripModel a)
        {

            repo.SaveGripModel(a);
            return RedirectToAction("AdminTable", new { model = "grip", searchString = "" });

        }


        [HttpGet]
        public IActionResult AdminEditModelFlex(int modelFlexID)
        {

            var x = repo.modelFlexes.Where(x => x.modelFlexID == modelFlexID).Single();
            x.modelFlexID = modelFlexID;
            ViewBag.ID = modelFlexID;

            return View("AdminAddModelFlex", x);


        }
        [HttpPost]
        public IActionResult AdminEditModelFlex(ModelFlex b)
        {

            repo.SaveModelFlex(b);
            return RedirectToAction("AdminTable", new { model = "modelFlex", searchString = "" });

        }





        public IActionResult AdminDeleteShaft(int shaftID)
        {
            var x = repo.shafts.Where(x => x.shaftID == shaftID).Single();
            repo.DeleteShaft(x);
            return RedirectToAction("AdminTable", new { model = "shaft", searchString = "" });
        }

        public IActionResult AdminDeleteBrand(int brandID)
        {
            var x = repo.brands.Where(x => x.brandID == brandID).Single();
            repo.DeleteBrand(x);
            return RedirectToAction("AdminTable", new { model = "brand", searchString = "" });
        }

         public IActionResult AdminDeleteAdapterSetting(int adapterID)
        {
            var x = repo.adapterSettings.Where(x => x.adapterID == adapterID).Single();
            repo.DeleteAdapterSettings(x);
            return RedirectToAction("AdminTable", new { model = "brand", searchString = "" });
        }

        public IActionResult AdminDeleteBuildType(int typeID)
        {
            var x = repo.buildTypes.Where(x => x.typeID == typeID).Single();
            repo.DeleteBuildType(x);
            return RedirectToAction("AdminTable", new { model = "type", searchString = "" });
        }

        public IActionResult AdminDeleteGripModel(int gripID)
        {
            var x = repo.gripModels.Where(x => x.gripID == gripID).Single();
            repo.DeleteGripModel(x);
            return RedirectToAction("AdminTable", new { model = "grip", searchString = "" });
        }

        public IActionResult AdminDeleteModelFlex(int modelFlexID)
        {
            var x = repo.modelFlexes.Where(x => x.modelFlexID == modelFlexID).Single();
            repo.DeleteModelFlex(x);
            return RedirectToAction("AdminTable", new { model = "modelFlex", searchString = "" });
        }



    }
}
