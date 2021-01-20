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
    public class Patient_DetailController : Controller
    {
        private readonly Appointment_system_MVCContext _context;

        public Patient_DetailController(Appointment_system_MVCContext context)
        {
            _context = context;
        }

        // GET: Patient_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patient_Detail.ToListAsync());
        }

        // GET: Patient_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Detail = await _context.Patient_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient_Detail == null)
            {
                return NotFound();
            }

            return View(patient_Detail);
        }

        // GET: Patient_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DOB,Address,Phone")] Patient_Detail patient_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient_Detail);
        }

        // GET: Patient_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Detail = await _context.Patient_Detail.FindAsync(id);
            if (patient_Detail == null)
            {
                return NotFound();
            }
            return View(patient_Detail);
        }

        // POST: Patient_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DOB,Address,Phone")] Patient_Detail patient_Detail)
        {
            if (id != patient_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Patient_DetailExists(patient_Detail.Id))
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
            return View(patient_Detail);
        }

        // GET: Patient_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Detail = await _context.Patient_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient_Detail == null)
            {
                return NotFound();
            }

            return View(patient_Detail);
        }

        // POST: Patient_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient_Detail = await _context.Patient_Detail.FindAsync(id);
            _context.Patient_Detail.Remove(patient_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Patient_DetailExists(int id)
        {
            return _context.Patient_Detail.Any(e => e.Id == id);
        }
    }
}
