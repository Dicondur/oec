using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DCOEC.Models;
using Microsoft.AspNetCore.Http;

namespace DCOEC.Controllers
{
    public class DCTreatmentsController : Controller
    {
        private readonly OECContext _context;

        public DCTreatmentsController(OECContext context)
        {
            _context = context;
        }

        // GET: DCTreatments
        public async Task<IActionResult> Index(int? plotId, string farmName)
        {

            ViewBag.name = "";

            //store to session
            if (plotId != null)
            {


                //Set Session

                // create session variables
                HttpContext.Session.SetInt32("_plotId", Convert.ToInt32(plotId));
                //HttpContext.Session.SetString("_farmName", farmName);
                TempData["Message"] = "Plot ID stored to session.";

            }
            else //(plotId== null)
            {
                if (HttpContext.Session.GetString("_plotId") != null)
                {
                    plotId = Convert.ToInt32(HttpContext.Session.GetInt32("_plotId"));
                    //farmName = HttpContext.Session.GetString("_farmName");


                    //Set View Data
                    ViewData["PlotID"] = plotId;
                    ViewData["farmName"] = farmName;

                    TempData["Message"] = "Got Plot ID from session.";

                }
                else
                {

                    TempData["Message"] = "Select a Plot first";
                    return RedirectToAction("Index", "DCPlots");
                }


            }



            foreach(var x in _context.TreatmentFertilizer) {
                ViewBag.name = x.FertilizerNameNavigation.FertilizerName;
                //if (x.FertilizerNameNavigation.FertilizerName is null)
                //{

                //    ViewBag.name = "No fertilizer";
                //}
                //else
                //{
                //    ViewBag.name = x.FertilizerNameNavigation.FertilizerName + "+";
                //}

            }
        



            var oECContext = _context.Treatment
                                    .Include(t => t.Plot)
                                    .Where (x => x.PlotId == plotId);
            return View(await oECContext.ToListAsync());
        }

        // GET: DCTreatments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment
                .Include(t => t.Plot)
                .SingleOrDefaultAsync(m => m.TreatmentId == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // GET: DCTreatments/Create
        public IActionResult Create()
        {
            ViewData["PlotId"] = new SelectList(_context.Plot, "PlotId", "PlotId");
            return View();
        }

        // POST: DCTreatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreatmentId,Name,PlotId,Moisture,Yield,Weight")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlotId"] = new SelectList(_context.Plot, "PlotId", "PlotId", treatment.PlotId);
            return View(treatment);
        }

        // GET: DCTreatments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.TreatmentId == id);
            if (treatment == null)
            {
                return NotFound();
            }
            ViewData["PlotId"] = new SelectList(_context.Plot, "PlotId", "PlotId", treatment.PlotId);
            return View(treatment);
        }

        // POST: DCTreatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreatmentId,Name,PlotId,Moisture,Yield,Weight")] Treatment treatment)
        {
            if (id != treatment.TreatmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentExists(treatment.TreatmentId))
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
            ViewData["PlotId"] = new SelectList(_context.Plot, "PlotId", "PlotId", treatment.PlotId);
            return View(treatment);
        }

        // GET: DCTreatments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment
                .Include(t => t.Plot)
                .SingleOrDefaultAsync(m => m.TreatmentId == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // POST: DCTreatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatment = await _context.Treatment.SingleOrDefaultAsync(m => m.TreatmentId == id);
            _context.Treatment.Remove(treatment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentExists(int id)
        {
            return _context.Treatment.Any(e => e.TreatmentId == id);
        }
    }
}
