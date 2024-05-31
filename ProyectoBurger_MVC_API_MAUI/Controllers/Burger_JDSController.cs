using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBurger_MVC_API_MAUI.Data;
using ProyectoBurger_MVC_API_MAUI.Models;

namespace ProyectoBurger_MVC_API_MAUI.Controllers
{
    public class Burger_JDSController : Controller
    {
        private readonly ProyectoBurger_MVC_API_MAUIContext _context;

        public Burger_JDSController(ProyectoBurger_MVC_API_MAUIContext context)
        {
            _context = context;
        }

        // GET: Burger_JDS
        public async Task<IActionResult> Index_JDS()
        {
            return View(await _context.Burger_JDS.ToListAsync());
        }

        // GET: Burger_JDS/Details/5
        public async Task<IActionResult> Details_JDS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger_JDS = await _context.Burger_JDS
                .FirstOrDefaultAsync(m => m.BurgerId_JDS == id);
            if (burger_JDS == null)
            {
                return NotFound();
            }

            return View(burger_JDS);
        }

        // GET: Burger_JDS/Create
        public IActionResult Create_JDS()
        {
            return View();
        }

        // POST: Burger_JDS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_JDS([Bind("BurgerId_JDS,Name_JDS,WithCheese_JDS,Precio_JDS")] Burger_JDS burger_JDS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burger_JDS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index_JDS));
            }
            return View(burger_JDS);
        }

        // GET: Burger_JDS/Edit/5
        public async Task<IActionResult> Edit_JDS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger_JDS = await _context.Burger_JDS.FindAsync(id);
            if (burger_JDS == null)
            {
                return NotFound();
            }
            return View(burger_JDS);
        }

        // POST: Burger_JDS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_JDS(int id, [Bind("BurgerId_JDS,Name_JDS,WithCheese_JDS,Precio_JDS")] Burger_JDS burger_JDS)
        {
            if (id != burger_JDS.BurgerId_JDS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burger_JDS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Burger_JDSExists(burger_JDS.BurgerId_JDS))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index_JDS));
            }
            return View(burger_JDS);
        }

        // GET: Burger_JDS/Delete/5
        public async Task<IActionResult> Delete_JDS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger_JDS = await _context.Burger_JDS
                .FirstOrDefaultAsync(m => m.BurgerId_JDS == id);
            if (burger_JDS == null)
            {
                return NotFound();
            }

            return View(burger_JDS);
        }

        // POST: Burger_JDS/Delete/5
        [HttpPost, ActionName("Delete_JDS")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burger_JDS = await _context.Burger_JDS.FindAsync(id);
            if (burger_JDS != null)
            {
                _context.Burger_JDS.Remove(burger_JDS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index_JDS));
        }

        private bool Burger_JDSExists(int id)
        {
            return _context.Burger_JDS.Any(e => e.BurgerId_JDS == id);
        }
    }
}
