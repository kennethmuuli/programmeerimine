using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET: Rentals
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _rentalService.List(page, 3);

            return View(result);
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.GetById(id.Value);

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PickUpTime,ReturnTime,HadBooking,OverdueTime,ReturnedLate,VehicleDamaged")] Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            await _rentalService.Save(rental);
            return RedirectToAction(nameof(Index));
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.GetById(id.Value);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PickUpTime,ReturnTime,HadBooking,OverdueTime,ReturnedLate,VehicleDamaged")] Rental rental)
        {
            if (id != rental.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            await _rentalService.Save(rental);
            return RedirectToAction(nameof(Index));
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.GetById(id.Value);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rentalService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
          return _rentalService.RentalExists(id);
        }
    }
}
