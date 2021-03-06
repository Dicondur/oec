﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DCOEC.Models;

namespace DCOEC.Controllers
{
    public class DCFarmsController : Controller
    {
        private readonly OECContext _context;

        public DCFarmsController(OECContext context)
        {
            _context = context;
        }

        // GET: DCFarms
        public async Task<IActionResult> Index()
        {
            var oECContext = _context.Farm
                .Include(f => f.ProvinceCodeNavigation)
                .OrderBy(x => x.Name);
            return View(await oECContext.ToListAsync());
        }

        // GET: DCFarms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farm
                .Include(f => f.ProvinceCodeNavigation)
                .SingleOrDefaultAsync(m => m.FarmId == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // GET: DCFarms/Create
        public IActionResult Create()
        {
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode");
            return View();
        }

        // POST: DCFarms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmId,Name,Address,Town,County,ProvinceCode,PostalCode,HomePhone,CellPhone,Email,Directions,DateJoined,LastContactDate")] Farm farm)
        {
                try
                {
                if (ModelState.IsValid)
                {
                    _context.Add(farm);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "New record.. Saved";
                    return RedirectToAction(nameof(Index));
                }
                }
                catch (Exception Ex)
                {
              
                TempData["Message"] = Ex.InnerException.Message;
                ModelState.AddModelError("InnerException", Ex.InnerException.Message);
                }
                //return RedirectToAction(nameof(Index));
           
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", farm.ProvinceCode);
            return View(farm);
        }

        // GET: DCFarms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farm.SingleOrDefaultAsync(m => m.FarmId == id);
            if (farm == null)
            {
                return NotFound();
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province.OrderBy(x => x.Name), "ProvinceCode", "Name", farm.ProvinceCode);

            return View(farm);
        }

        // POST: DCFarms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmId,Name,Address,Town,County,ProvinceCode,PostalCode,HomePhone,CellPhone,Email,Directions,DateJoined,LastContactDate")] Farm farm)
        {
            if (id != farm.FarmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farm);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Edit Changes.. Saved";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmExists(farm.FarmId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception Ex)
                {
                    TempData["Message"] = Ex.InnerException;
                    ModelState.AddModelError("InnerException", Ex.InnerException.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province.OrderBy(x => x.Name), "ProvinceCode", "Name", farm.ProvinceCode);
            return View(farm);
        }

        // GET: DCFarms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farm
                .Include(f => f.ProvinceCodeNavigation)
                .SingleOrDefaultAsync(m => m.FarmId == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // POST: DCFarms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farm = await _context.Farm.SingleOrDefaultAsync(m => m.FarmId == id);
            _context.Farm.Remove(farm);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                TempData["Message"] = ex.InnerException.Message;
            }
            TempData["Message"] = "Delete success";
            return RedirectToAction(nameof(Index));
        }

        private bool FarmExists(int id)
        {
            return _context.Farm.Any(e => e.FarmId == id);
        }
    }
}
