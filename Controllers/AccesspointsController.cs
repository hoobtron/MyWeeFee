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
            var myWeeFeeContext = _context.T_Accesspoints.Include(a => a.APEncryption);
            return View(await myWeeFeeContext.ToListAsync());
        }

        // GET: Accesspoints/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var accesspoint = await _context.T_Accesspoints
                .Include(a => a.APEncryption)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (accesspoint == null)
            {
                return NotFound();
            }

            return View(accesspoint);
        }

        // GET: Accesspoints/Create
        public IActionResult Create()
        {
            ViewData["EncryptionType"] = new SelectList(_context.T_APEncryptions, "Encryption", "Encryption");
            
            return View();
        }

        // POST: Accesspoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,SSID,Encryption")] Accesspoint accesspoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesspoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncryptionType"] = new SelectList(_context.T_APEncryptions, "Encryption", "Encryption", accesspoint.Encryption);
            return View(accesspoint);
        }

        // GET: Accesspoints/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var accesspoint = await _context.T_Accesspoints.SingleOrDefaultAsync(m => m.Id == id);
            if (accesspoint == null)
            {
                return NotFound();
            }
            ViewData["EncryptionType"] = new SelectList(_context.T_APEncryptions, "Encryption", "Encryption", accesspoint.Encryption);
            return View(accesspoint);
        }

        // POST: Accesspoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Location,SSID,Encryption")] Accesspoint accesspoint)
        {
            if (id != accesspoint.Id)
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
                    if (!AccesspointExists(accesspoint.Id))
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
            ViewData["EncryptionType"] = new SelectList(_context.T_APEncryptions, "Encryption", "Encryption", accesspoint.Encryption);
            return View(accesspoint);
        }

        // GET: Accesspoints/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var accesspoint = await _context.T_Accesspoints
                .Include(a => a.APEncryption)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (accesspoint == null)
            {
                return NotFound();
            }

            return View(accesspoint);
        }

        // POST: Accesspoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesspoint = await _context.T_Accesspoints.SingleOrDefaultAsync(m => m.Id == id);
            _context.T_Accesspoints.Remove(accesspoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesspointExists(int id)
        {
            return _context.T_Accesspoints.Any(e => e.Id == id);
        }
    }
}
