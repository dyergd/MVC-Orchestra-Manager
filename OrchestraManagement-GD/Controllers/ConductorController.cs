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
    public class ConductorController : Controller
    {
        private readonly IOrchestraRepository orchestraRepository;

        public ConductorController(IOrchestraRepository orchestraRepo)          //injecting the IOrchestraRepository into this class to be able to use the Dbcontext class
        {
            orchestraRepository = orchestraRepo;
        }

        public IActionResult Edit(int Id, int conductorId)
        {
            var conductor = orchestraRepository.ConductorDetails(conductorId);  //reads the conductor from the db
            if (conductor == null)                                              //checks to see if the conductor exists
            {
                return RedirectToAction("Details", "Orchestra");                //returns to the orchestra details if the conductor does not exist
            }

            var orchestra = orchestraRepository.Details(Id);
            if (orchestra == null)
            {
                return RedirectToAction("Index", "Orchestra");
            }

            ViewData["Orchestra"] = orchestra;                                  //reads the orchestra from the db and puts it into a viewdata object
            return View(conductor);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                orchestraRepository.EditConductor(conductor.Id, conductor);     //calls the edit method in dbOrchestraRepository, gives the edit method the updated conductor object
                return RedirectToAction("Details", "Orchestra");                //returns to the orchestra details
            }


            return View(conductor);
        }


        public IActionResult Create([Bind(Prefix = "id")] int orchesctraId)
        {
            var orchestra = orchestraRepository.Details(orchesctraId);          //reads the orchestra from the db 

            if (orchestra == null)                                              // checks to see if the orchestra exists
            {
                return RedirectToAction("Index", "Orchestra");                  //returns to the orchestra index if the orchestra does not exist
            }

            ViewData["Orchestra"] = orchestra;                                  //adds the orchestra object to a viewdata object

            return View();                                                      //returns the conductor create view 
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(int orchestraId, CreateConductorVm createConductorVm)
        {
            var orchestra = orchestraRepository.Details(orchestraId);

            if (orchestra.NumberOfConductors < 1)                               //checks to see if a conductor already exists for the orchestra
            {

                if (ModelState.IsValid)                                         //if a conductor doesnt exsist you can create one
                {
                    var conductor = createConductorVm.GetConductorInstance();   //grabs the conductor instance from the create conductor vm, and puts it into a varible
                    orchestraRepository.AddConductor(orchestraId, conductor);   //calls the add conductor method in the dbOrchestraRepository, gives the method the orchestra id , and the conductor object to insert
                    return RedirectToAction("Details", "Orchestra", new { id = orchestraId }); //returns to the orchestra details
                }
            }

            else                                                                //if a conductor exists you are redirected to the orchestra details page
            {
                return RedirectToAction("Details", "Orchestra");
            }


            ViewData["Orchestra"] = orchestra;                                 //calls the edit method in dborchestrarepository, gives the edit method the updated conductor object
            return View(createConductorVm);
        }


        public IActionResult Delete(int Id, int conductorId)
        {
            var conductorToDelete = orchestraRepository.ConductorDetails(conductorId); //reads a conductor from the db
            if (conductorToDelete == null)                                      //checks to see if the conductor exists
            {
                return RedirectToAction("Details", "Orchestra");                //returns to the orchestra details
            }

            var orchestra = orchestraRepository.Details(Id);                    //reads the orchestra
            if (orchestra == null)                                              //checks to see if the orchestra is null
            {
                return RedirectToAction("Index", "Orchestra");                  //returns you to the orchestra index if the orchestra doesnt exsist
            }
            ViewData["Orchestra"] = orchestra;
            return View(conductorToDelete);
        }


        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int id) 
        {
            orchestraRepository.DeleteConductor(id);                            //takes the conductor id and uses it to execute the delete conductor method
            return RedirectToAction("Details", "Orchestra");                    //returns to the orchestra details
        }

    }
}

