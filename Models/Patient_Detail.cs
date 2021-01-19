using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_system_MVC.Models
{
    public class Patient_Detail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
