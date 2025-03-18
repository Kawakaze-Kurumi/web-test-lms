using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_test_lms.Models;

namespace web_test_lms.Controllers
{
    public class CportsController : Controller
    {
        private readonly Test1Context _context;

        public CportsController(Test1Context context)
        {
            _context = context;
        }

        // GET: Cports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cports.ToListAsync());
        }

        // GET: Cports/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cport = await _context.Cports
                .FirstOrDefaultAsync(m => m.Code == id);
            if (cport == null)
            {
                return NotFound();
            }

            return View(cport);
        }

        // GET: Cports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,PortName")] Cport cport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cport);
        }

        // GET: Cports/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cport = await _context.Cports.FindAsync(id);
            if (cport == null)
            {
                return NotFound();
            }
            return View(cport);
        }

        // POST: Cports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,PortName")] Cport cport)
        {
            if (id != cport.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CportExists(cport.Code))
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
            return View(cport);
        }

        // GET: Cports/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cport = await _context.Cports
                .FirstOrDefaultAsync(m => m.Code == id);
            if (cport == null)
            {
                return NotFound();
            }

            return View(cport);
        }

        // POST: Cports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cport = await _context.Cports.FindAsync(id);
            if (cport != null)
            {
                _context.Cports.Remove(cport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CportExists(string id)
        {
            return _context.Cports.Any(e => e.Code == id);
        }
    }
}
