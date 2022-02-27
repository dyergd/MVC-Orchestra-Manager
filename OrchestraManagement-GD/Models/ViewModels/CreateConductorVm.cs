using OrchestraManagement_GD.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Models.ViewModels
{
    public class CreateConductorVm
    {
        //creating a View model to use for our create view instead of our conductor class
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Conductor GetConductorInstance() //creating a instance of conductor based on the data in CreateConductorVm
        {
            return new Conductor
            {
                Id = 0,
                FirstName = this.FirstName,
                LastName = this.LastName
            };

        }


    }
}
