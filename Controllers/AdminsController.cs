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

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.T_Admins
                .SingleOrDefaultAsync(m => m.Email == id);
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
        public async Task<IActionResult> Create([Bind("Email,Firstname,Surename,Password")] Admin admin)
        {

/* Test 1
            // TODO  intercept SqlException (unique email)

            if (ModelState.IsValid)
            {
                if (!AdminExists(admin.Email))
                {
                    _context.Add(admin);
                    await _context.SaveChangesAsync();     
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // TODO: message: email exists already
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(admin);

/* Test 2
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(admin);               
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Email))
                    {
                        await _context.SaveChangesAsync();     
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // TODO: message: email exists already
                        return RedirectToAction(nameof(Create));
                        throw;
                    }
                }
                
            }
            return View(admin);

 */
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.T_Admins.SingleOrDefaultAsync(m => m.Email == id);
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
        public async Task<IActionResult> Edit(string id, [Bind("Email,Firstname,Surename,Password")] Admin admin)
        {
            if (id != admin.Email)
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
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.T_Admins
                .SingleOrDefaultAsync(m => m.Email == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admin = await _context.T_Admins.SingleOrDefaultAsync(m => m.Email == id);
            _context.T_Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(string id)
        {
            return _context.T_Admins.Any(e => e.Email == id);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email) {

            
            if (AdminExists(email))
            {
                return Json(data: $"{email} ist bereits in Verwendung!");
            }

            return Json(data: true);
        }
    }
}