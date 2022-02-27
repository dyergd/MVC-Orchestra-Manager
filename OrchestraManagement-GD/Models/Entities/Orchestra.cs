using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Models.Entities
{
    public class Orchestra
    {
        //Added required data annoation to signify that the field is required to create the orchestra object
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Website URL")]
        public string WebsiteURL { get; set; }

        public ICollection<Musician> Musicians { get; set; } //Creates a Collection of Muscian within the orchestra
        public ICollection<Conductor> Conductors { get; set; } //Creates a Collection of Conductor within the orchestra

        [Display(Name = "Number of Musicians")]
        public int NumberOfMusicians { get { return Musicians.Count();} }

        public int NumberOfConductors { get { return Conductors.Count(); } }




        public Orchestra()
        {
            Musicians = new List<Musician>(); //Creates a list of Musician and is stored in Musicians
            Conductors = new List<Conductor>(); //Creates a list of Conductor and is stored in Conductors
        }







    }
}
