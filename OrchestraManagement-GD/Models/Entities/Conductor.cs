using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Models.Entities
{
    public class Conductor
    {
        //Added required data annoation to signify that the field is required to create the Conductor object
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }


    }
}
