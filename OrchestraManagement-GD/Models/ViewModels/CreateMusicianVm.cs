using OrchestraManagement_GD.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Models.ViewModels
{
    public class CreateMusicianVM
    {
        //creating a View model to use for our create view instead of our musician class
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        [Display(Name = "Is Section Leader")]
        public bool IsSectionLeader { get; set; }

        public Musician GetMusicianInstance() //creating a instance of musician based on the data in CreateMusicianVM
        {
            return new Musician
            { Id = 0,
              FirstName = this.FirstName,
              LastName = this.LastName,
              SectionName = this.SectionName,
              IsSectionLeader = this.IsSectionLeader
            };

        }

    }
}
