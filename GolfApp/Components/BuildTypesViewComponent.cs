using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GolfApp.Models;


namespace GolfApp.Components
{
    public class BuildTypesViewComponent : ViewComponent
    {
        private BuildType repo { get; set; }

        public BuildTypesViewComponent(BuildType temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var buildtypes = repo.typeName
                .Distinct()
                .ToList();


            return View(buildtypes);
        }
    }
}