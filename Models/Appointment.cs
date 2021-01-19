using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_system_MVC.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int Doctor_DetailID { get; set; }
        public Doctor_Detail Doctor_Detail { get; set; }
        public int Patient_DetailID { get; set; }
        public Patient_Detail Patient_Detail { get; set; }
        public DateTime Appointment_date_time { get; set; }












    }
}
