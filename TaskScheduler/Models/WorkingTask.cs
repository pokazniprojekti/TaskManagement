using System;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler.Models
{
    public class WorkingTask
    {

        public int Id { get; set; }


        public ApplicationUser Users { get; set; }


        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [Required]
        public string IsActive { get; set; }

        [Required]
        [StringLength(100)]
        public string Assign { get; set; }

        [Required]
        [StringLength(255)]
        public string Visibility { get; set; }


        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        


    }
}