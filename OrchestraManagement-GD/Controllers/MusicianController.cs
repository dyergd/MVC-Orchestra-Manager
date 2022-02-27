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
    public class MusicianController : Controller
    {
                                                                                
        private readonly IOrchestraRepository orchestraRepository; 

        public MusicianController(IOrchestraRepository orchestraRepo)           //injecting the IOrchestraRepository into this class to be able to use the Dbcontext class
        {
            orchestraRepository = orchestraRepo;
        }
        
        public IActionResult Edit(int Id, int musicianId)
        {
            var musician = orchestraRepository.MusicianDetails(musicianId);     //reads the musician from the db
            if (musician == null)                                               //checks to see if the musician exists
            {
                return RedirectToAction("Details", "Orchestra");                //returns to the orchestra details if the musician does not exist
            }

            var orchestra = orchestraRepository.Details(Id);
            if (orchestra == null)
            {
                return RedirectToAction("Index", "Orchestra");
            }

            ViewData["Orchestra"] = orchestra;                                  //reads the orchestra from the db and puts it into a viewdata object
            return View(musician);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Musician musician)
        {
            if(ModelState.IsValid) 
            {
                orchestraRepository.EditMusician(musician.Id, musician);       //calls the edit method in dbOrchestraRepository, gives the edit method the updated musician object
                return RedirectToAction("Details" , "Orchestra");              //returns to the orchestra details
            }

           
            return View(musician);
        }
  
        public IActionResult Create([Bind(Prefix = "id")] int orchesctraId)
        {
            var orchestra = orchestraRepository.Details(orchesctraId);         //reads the orchestra from the db 

            if (orchestra == null)                                             // checks to see if the orchestra exists
            {
                return RedirectToAction("Index", "Orchestra");                 //returns to the orchestra index if the orchestra does not exist
            }

            ViewData["Orchestra"] = orchestra;                                 //adds the orchestra object to a viewdata object

            return View();                                                     //returns the musician create view 
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(int orchestraId, CreateMusicianVM muscianVm)
        {
            if (ModelState.IsValid)
            {
                var musician = muscianVm.GetMusicianInstance();                 //grabs the musician instance from the create musician vm, and puts it into a varible
                orchestraRepository.AddMusician(orchestraId, musician);         //calls the add musician method in the dbOrchestraRepository, gives the method the orchestra id , and the musician object to insert
                return RedirectToAction("Details", "Orchestra", new { id = orchestraId }); //returns to the orchestra details
            }

            ViewData["Orchestra"] = orchestraRepository.Details(orchestraId);   //calls the edit method in dborchestrarepository, gives the edit method the updated musician object
            return View(muscianVm);
        }

        
        public IActionResult Delete(int Id, int musicianId)
        {
            var musicianToDelete = orchestraRepository.MusicianDetails(musicianId); //reads the musician from the db 
            if (musicianToDelete == null)                                       //checks to see if the musician exists
            {
                return RedirectToAction("Details", "Orchestra");                //returns to the orchestra details
            }

            var orchestra = orchestraRepository.Details(Id);
            if (orchestra == null)
            {
                return RedirectToAction("Index", "Orchestra");
            }


            ViewData["Orchestra"] = orchestra;
            return View(musicianToDelete);
        }


        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int id)
        {
            orchestraRepository.DeleteMusician(id);                         //calls the delete musician method in the dbOrchestraRepository, gives it the id of the musician we want to delete
            return RedirectToAction("Details", "Orchestra");                //returns to the orchestra details
        }
        
    }
}
