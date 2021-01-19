using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Appointment_system_MVC.Models;

namespace Appointment_system_MVC.Data
{
    public class Appointment_system_MVCContext : DbContext
    {
        public Appointment_system_MVCContext (DbContextOptions<Appointment_system_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment_system_MVC.Models.Patient_Detail> Patient_Detail { get; set; }

        public DbSet<Appointment_system_MVC.Models.Doctor_Detail> Doctor_Detail { get; set; }

        public DbSet<Appointment_system_MVC.Models.Clinic> Clinic { get; set; }

        public DbSet<Appointment_system_MVC.Models.Appointment> Appointment { get; set; }
    }
}
