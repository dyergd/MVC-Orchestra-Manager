using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Models.ViewModels
{
    public class OrchestraDetailsVM
    {
        //creating a View model to use instead of our orchestra class
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Website URL")]
        public string WebsiteURL { get; set; }
        [Display(Name = "Number of Musicians")]
        public int NumberOfMusicians { get; set; }

        

    }
}
