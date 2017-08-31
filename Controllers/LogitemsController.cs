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
    public class LogitemsController : Controller
    {
        private readonly MyWeeFeeContext _context;

        public LogitemsController(MyWeeFeeContext context)
        {
            _context = context;
        }

        // GET: Logitems
        public async Task<IActionResult> Index()
        {
            return View(await _context.T_Logitems.ToListAsync());
        }

        // GET: Logitems/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logitem = await _context.T_Logitems
                .SingleOrDefaultAsync(m => m.Created == id);
            if (logitem == null)
            {
                return NotFound();
            }

            return View(logitem);
        }

        // GET: Logitems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,Email,Action")] Logitem logitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logitem);
        }

        // GET: Logitems/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logitem = await _context.T_Logitems.SingleOrDefaultAsync(m => m.Created == id);
            if (logitem == null)
            {
                return NotFound();
            }
            return View(logitem);
        }

        // POST: Logitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("Id,Created,Email,Action")] Logitem logitem)
        {
            if (id != logitem.Created)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogitemExists(logitem.Created))
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
            return View(logitem);
        }

        // GET: Logitems/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logitem = await _context.T_Logitems
                .SingleOrDefaultAsync(m => m.Created == id);
            if (logitem == null)
            {
                return NotFound();
            }

            return View(logitem);
        }

        // POST: Logitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var logitem = await _context.T_Logitems.SingleOrDefaultAsync(m => m.Created == id);
            _context.T_Logitems.Remove(logitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogitemExists(DateTime id)
        {
            return _context.T_Logitems.Any(e => e.Created == id);
        }
    }
}
