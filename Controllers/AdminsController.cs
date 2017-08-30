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
    public class AdminsController : Controller
    {
        private readonly MyWeeFeeContext _context;

        public AdminsController(MyWeeFeeContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.T_Admins.ToListAsync());
        }

        // Attention: parameter has to be named "id"!
        // if parameter mame is "email", then: HTTP ERROR 404

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var admin = await _context.T_Admins
                .SingleOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Email,Firstname,Surename,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var admin = await _context.T_Admins.SingleOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Email,Firstname,Surename,Password")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Email))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var admin = await _context.T_Admins
                .SingleOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.T_Admins.SingleOrDefaultAsync(m => m.Id == id);
            _context.T_Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(string email)
        {
            return _context.T_Admins.Any(e => e.Email == email);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailAvailable(string email, string initialEmail)
        {
            // check in DB if given email exists AND if it is not used for currently edited user (allow same/unchange for editing user)
            if ( AdminExists(email) && ( (!string.IsNullOrEmpty(initialEmail) && (email != initialEmail)) || (string.IsNullOrEmpty(initialEmail)) ) )
            {
                return Json(data: $"{email} ist bereits in Verwendung!");
            }
            return Json(data: true);
        }
    }
}
