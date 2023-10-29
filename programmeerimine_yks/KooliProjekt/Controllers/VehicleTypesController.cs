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
    public class VehicleTypesController : Controller
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypesController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index(int page = 1)
        {

            var result = await _vehicleTypeService.List(page, 3);

            return View(result);
        }

        // GET: VehicleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _vehicleTypeService.GetById(id.Value);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicleType);    
            }
            await _vehicleTypeService.Save(vehicleType);
            return RedirectToAction(nameof(Index));
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _vehicleTypeService.GetById(id.Value);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] VehicleType vehicleType)
        {
            if (id != vehicleType.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(vehicleType);
            }
            _vehicleTypeService.Save(vehicleType);
            return RedirectToAction(nameof(Index));
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _vehicleTypeService.GetById(id.Value);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var vehicleType = await _context.VehicleTypes.FindAsync(id);
            //if (vehicleType != null)
            //{
            //    _context.VehicleTypes.Remove(vehicleType);
            //}
            
            //await _context.SaveChangesAsync();
            await _vehicleTypeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleTypeExists(int id)
        {
          return _vehicleTypeService.VehicleTypeExists(id);
        }
    }
}
