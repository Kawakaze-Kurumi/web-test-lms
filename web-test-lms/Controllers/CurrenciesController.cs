﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_test_lms.Models;

namespace web_test_lms.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly Test1Context _context;

        public CurrenciesController(Test1Context context)
        {
            _context = context;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Currencies.ToListAsync());
        }

        // GET: Currencies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Code == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        // GET: Currencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,CurrName,Note")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        // GET: Currencies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,CurrName,Note")] Currency currency)
        {
            if (id != currency.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyExists(currency.Code))
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
            return View(currency);
        }

        // GET: Currencies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Code == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        // POST: Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            if (currency != null)
            {
                _context.Currencies.Remove(currency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyExists(string id)
        {
            return _context.Currencies.Any(e => e.Code == id);
        }
    }
}
