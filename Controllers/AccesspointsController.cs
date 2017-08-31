using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWeeFee.Models;

namespace MyWeeFee.Controllers
{
    public class AccesspointsController : Controller
    {
        private readonly MyWeeFeeContext _context;

        public AccesspointsController(MyWeeFeeContext context)
        {
            _context = context;
        }

        // GET: Accesspoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.T_Accesspoints.ToListAsync());
        }

        // GET: Accesspoints/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesspoint = await _context.T_Accesspoints
                .SingleOrDefaultAsync(m => m.Location == id);
            if (accesspoint == null)
            {
                return NotFound();
            }

            return View(accesspoint);
        }

        // GET: Accesspoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accesspoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Location,SSID,Encryption")] Accesspoint accesspoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesspoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accesspoint);
        }

        // GET: Accesspoints/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesspoint = await _context.T_Accesspoints.SingleOrDefaultAsync(m => m.Location == id);
            if (accesspoint == null)
            {
                return NotFound();
            }
            return View(accesspoint);
        }

        // POST: Accesspoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Location,SSID,Encryption")] Accesspoint accesspoint)
        {
            if (id != accesspoint.Location)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesspoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesspointExists(accesspoint.Location))
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
            return View(accesspoint);
        }

        // GET: Accesspoints/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesspoint = await _context.T_Accesspoints
                .SingleOrDefaultAsync(m => m.Location == id);
            if (accesspoint == null)
            {
                return NotFound();
            }

            return View(accesspoint);
        }

        // POST: Accesspoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accesspoint = await _context.T_Accesspoints.SingleOrDefaultAsync(m => m.Location == id);
            _context.T_Accesspoints.Remove(accesspoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesspointExists(string id)
        {
            return _context.T_Accesspoints.Any(e => e.Location == id);
        }
    }
}
