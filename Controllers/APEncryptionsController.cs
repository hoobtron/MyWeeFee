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
    public class APEncryptionsController : Controller
    {
        private readonly MyWeeFeeContext _context;

        public APEncryptionsController(MyWeeFeeContext context)
        {
            _context = context;
        }

        // GET: APEncryptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.T_APEncryptions.ToListAsync());
        }

        // GET: APEncryptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aPEncryption = await _context.T_APEncryptions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (aPEncryption == null)
            {
                return NotFound();
            }

            return View(aPEncryption);
        }

        // GET: APEncryptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: APEncryptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Encryption")] APEncryption aPEncryption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aPEncryption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPEncryption);
        }

        // GET: APEncryptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aPEncryption = await _context.T_APEncryptions.SingleOrDefaultAsync(m => m.Id == id);
            if (aPEncryption == null)
            {
                return NotFound();
            }
            return View(aPEncryption);
        }

        // POST: APEncryptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Encryption")] APEncryption aPEncryption)
        {
            if (id != aPEncryption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPEncryption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!APEncryptionExists(aPEncryption.Id))
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
            return View(aPEncryption);
        }

        // GET: APEncryptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aPEncryption = await _context.T_APEncryptions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (aPEncryption == null)
            {
                return NotFound();
            }

            return View(aPEncryption);
        }

        // POST: APEncryptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aPEncryption = await _context.T_APEncryptions.SingleOrDefaultAsync(m => m.Id == id);
            _context.T_APEncryptions.Remove(aPEncryption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool APEncryptionExists(int id)
        {
            return _context.T_APEncryptions.Any(e => e.Id == id);
        }
    }
}
