using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Appointment_system_MVC.Data;
using Appointment_system_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Appointment_system_MVC.Controllers
{
 
    [Authorize] 
    public class AppointmentsController : Controller
    {
        private readonly Appointment_system_MVCContext _context;

        public AppointmentsController(Appointment_system_MVCContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointment_system_MVCContext = _context.Appointment.Include(a => a.Clinic).Include(a => a.Doctor_Detail).Include(a => a.Patient_Detail);
            return View(await appointment_system_MVCContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Clinic)
                .Include(a => a.Doctor_Detail)
                .Include(a => a.Patient_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Clinic_address");
            ViewData["Doctor_DetailID"] = new SelectList(_context.Doctor_Detail, "Id", "Email");
            ViewData["Patient_DetailID"] = new SelectList(_context.Patient_Detail, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClinicId,Doctor_DetailID,Patient_DetailID,Appointment_date_time")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Clinic_address", appointment.ClinicId);
            ViewData["Doctor_DetailID"] = new SelectList(_context.Doctor_Detail, "Id", "Email", appointment.Doctor_DetailID);
            ViewData["Patient_DetailID"] = new SelectList(_context.Patient_Detail, "Id", "Name", appointment.Patient_DetailID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Clinic_address", appointment.ClinicId);
            ViewData["Doctor_DetailID"] = new SelectList(_context.Doctor_Detail, "Id", "Email", appointment.Doctor_DetailID);
            ViewData["Patient_DetailID"] = new SelectList(_context.Patient_Detail, "Id", "Name", appointment.Patient_DetailID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClinicId,Doctor_DetailID,Patient_DetailID,Appointment_date_time")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinic, "Id", "Clinic_address", appointment.ClinicId);
            ViewData["Doctor_DetailID"] = new SelectList(_context.Doctor_Detail, "Id", "Email", appointment.Doctor_DetailID);
            ViewData["Patient_DetailID"] = new SelectList(_context.Patient_Detail, "Id", "Name", appointment.Patient_DetailID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Clinic)
                .Include(a => a.Doctor_Detail)
                .Include(a => a.Patient_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
