using Microsoft.AspNetCore.Mvc;
using OrchestraManagement_GD.Models.Entities;
using OrchestraManagement_GD.Models.ViewModels;
using OrchestraManagement_GD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Controllers
{
    public class OrchestraController : Controller
    {
        private readonly IOrchestraRepository orchestraRepository;
       

        public OrchestraController(IOrchestraRepository orcRepository)  //injecting the IOrchestraRepository into this class to be able to use the Dbcontext class
        {
            orchestraRepository = orcRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var allOrchestra = orchestraRepository.ReadAll();           //reads the orchestra in allOrchestra varible
            var model = allOrchestra.Select(b =>                        //creates a orchestradetails view model object that will be used to generate the view
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
            return View(model);                                        //returns the view based on the model
        }


        [HttpGet]
        public IActionResult Create()                                  //gets the create view
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Orchestra orchestra)
        {
            if (ModelState.IsValid)
            {
                orchestraRepository.Create(orchestra);                //calls the create method in the dborchestrarepositorty
                return RedirectToAction("Index");                     //once created return to the view
            }

            return View(orchestra);                                 //returns the view
        }

        
        public IActionResult Details(int id)
        {
            var orchestra = orchestraRepository.Details(id);        //reads the orchestra from the db
           
            if (orchestra == null)                                  //checks to see if the orchestra exists
            {
                return RedirectToAction("Index");                   //returns to the orchestra index if the orchestra does not exist
            }
            return View(orchestra);
        }

       
        public IActionResult Edit(int id)
        {
            var orchestra = orchestraRepository.Details(id);        //reads the orchestra from the db
            if (orchestra == null)                                  //checks to see if the orchestra exists
            {
                return RedirectToAction("Index");                   //returns to the orchestra index if the orchestra does not exist
            }

            ViewData["Orchestra"] = orchestra;
            return View(orchestra); 
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]Orchestra orchestra) 
        {
            if(ModelState.IsValid) 
            {
                orchestraRepository.Edit(orchestra.Id, orchestra); //calls the edit method in dborchestrarepository, gives the edit method the updated orchestra object
                return RedirectToAction("Index");                  //returns to the orchestra index 
            }   

            return View(orchestra);
        }

        
        public IActionResult Delete(int id)
        {
            var orchestra = orchestraRepository.Details(id);      //reads the orchestra from the db
            if (orchestra == null)                                //checks to see if the orchestra exists
            {
                return RedirectToAction("Index");                //returns to the orchestra index if the orchestra does not exist
            }

            return View(orchestra);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {  
            orchestraRepository.Delete(id);                     // deletes the orchestra
            return RedirectToAction("Index");
        }

    






    }
}
