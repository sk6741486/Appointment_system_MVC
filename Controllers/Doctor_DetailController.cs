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
    public class Doctor_DetailController : Controller
    {
        private readonly Appointment_system_MVCContext _context;

        public Doctor_DetailController(Appointment_system_MVCContext context)
        {
            _context = context;
        }

        // GET: Doctor_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctor_Detail.ToListAsync());
        }

        // GET: Doctor_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor_Detail = await _context.Doctor_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor_Detail == null)
            {
                return NotFound();
            }

            return View(doctor_Detail);
        }
        [Authorize]
        // GET: Doctor_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sepicaligation,Email,Phone")] Doctor_Detail doctor_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor_Detail);
        }
        [Authorize]
        // GET: Doctor_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor_Detail = await _context.Doctor_Detail.FindAsync(id);
            if (doctor_Detail == null)
            {
                return NotFound();
            }
            return View(doctor_Detail);
        }

        // POST: Doctor_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sepicaligation,Email,Phone")] Doctor_Detail doctor_Detail)
        {
            if (id != doctor_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Doctor_DetailExists(doctor_Detail.Id))
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
            return View(doctor_Detail);
        }
        [Authorize]
        // GET: Doctor_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor_Detail = await _context.Doctor_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor_Detail == null)
            {
                return NotFound();
            }

            return View(doctor_Detail);
        }

        // POST: Doctor_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor_Detail = await _context.Doctor_Detail.FindAsync(id);
            _context.Doctor_Detail.Remove(doctor_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Doctor_DetailExists(int id)
        {
            return _context.Doctor_Detail.Any(e => e.Id == id);
        }
    }
}
