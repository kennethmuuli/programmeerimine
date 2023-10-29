using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _vehicleService.List(page, 3);

            return View(result);
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleService.GetById(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,LicencePlateNumber,OdometerRead,PricePerHour,Deposit,OverduePricePerHour,Booked")] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicle);
            }
            await _vehicleService.Save(vehicle);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleService.GetById(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,LicencePlateNumber,OdometerRead,PricePerHour,Deposit,OverduePricePerHour,Booked")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(vehicle);
            }
            await _vehicleService.Save(vehicle);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleService.GetById(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _vehicleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
          return _vehicleService.VehicleExists(id);
        }
    }
}
