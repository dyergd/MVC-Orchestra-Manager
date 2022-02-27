using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchestraManagement_GD.Models;
using OrchestraManagement_GD.Models.ViewModels;
using OrchestraManagement_GD.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOrchestraRepository orchestraRepository;

      
        public HomeController(ILogger<HomeController> logger, IOrchestraRepository orcRepository)
        {
                                                                    //injecting the IOrchestraRepository into this class to be able to use the Dbcontext class
            _logger = logger;
            orchestraRepository = orcRepository;
        }

        
        public IActionResult Index()                                //The action method that returns the home/index page
        {
            var allOrchestra = orchestraRepository.ReadAll();       //reads the orchestra in allOrchestra varible
            var model = allOrchestra.Select(b =>                    //creates a orchestradetails view model object that will be used to generate the view
               new OrchestraDetailsVM
               {
                   Id = b.Id,
                   Name = b.Name,
                   AddressLine1 = b.AddressLine1,
                   AddressLine2 = b.AddressLine2,
                   City = b.City,
                   State = b.State,
                   ZipCode = b.ZipCode,
                   WebsiteURL = b.WebsiteURL,
                   NumberOfMusicians = b.Musicians.Count
               });
            return View(model);
            
        }

        public IActionResult About()                                //The action method that returns the About page
        {
            return View();
        }

        public IActionResult Developer()                            //The action method that returns the developer page
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
