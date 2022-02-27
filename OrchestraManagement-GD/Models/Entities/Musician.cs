using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Models.Entities
{
    public class Musician
    {
        //Added required data annoation to signify that the field is required to create the musician object

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string SectionName { get; set; }

        [Required]
        public bool IsSectionLeader { get; set; }





    }
}
