using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBurger_MVC_API_MAUI.Data;
using ProyectoBurger_MVC_API_MAUI.Models;

namespace ProyectoBurger_MVC_API_MAUI.Controllers
{
    public class Promo_JDSController : Controller
    {
        private readonly ProyectoBurger_MVC_API_MAUIContext _context;

        public Promo_JDSController(ProyectoBurger_MVC_API_MAUIContext context)
        {
            _context = context;
        }

        // GET: Promo_JDS
        public async Task<IActionResult> Index_JDS()
        {
            return View(await _context.Promo_JDS.ToListAsync());
        }

        // GET: Promo_JDS/Details/5
        public async Task<IActionResult> Details_JDS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo_JDS = await _context.Promo_JDS
                .FirstOrDefaultAsync(m => m.PromoId_JDS == id);
            if (promo_JDS == null)
            {
                return NotFound();
            }

            return View(promo_JDS);
        }

        // GET: Promo_JDS/Create
        public IActionResult Create_JDS()
        {
            return View();
        }

        // POST: Promo_JDS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_JDS([Bind("PromoId_JDS,Descripcion_JDS,FechaPromo_JDS,BurgerId_JDS")] Promo_JDS promo_JDS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo_JDS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index_JDS));
            }
            return View(promo_JDS);
        }

        // GET: Promo_JDS/Edit/5
        public async Task<IActionResult> Edit_JDS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo_JDS = await _context.Promo_JDS.FindAsync(id);
            if (promo_JDS == null)
            {
                return NotFound();
            }
            return View(promo_JDS);
        }

        // POST: Promo_JDS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_JDS(int id, [Bind("PromoId_JDS,Descripcion_JDS,FechaPromo_JDS,BurgerId_JDS")] Promo_JDS promo_JDS)
        {
            if (id != promo_JDS.PromoId_JDS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo_JDS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Promo_JDSExists(promo_JDS.PromoId_JDS))
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
            return View(promo_JDS);
        }

        // GET: Promo_JDS/Delete/5
        public async Task<IActionResult> Delete_JDS(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo_JDS = await _context.Promo_JDS
                .FirstOrDefaultAsync(m => m.PromoId_JDS == id);
            if (promo_JDS == null)
            {
                return NotFound();
            }

            return View(promo_JDS);
        }

        // POST: Promo_JDS/Delete/5
        [HttpPost, ActionName("Delete_JDS")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo_JDS = await _context.Promo_JDS.FindAsync(id);
            if (promo_JDS != null)
            {
                _context.Promo_JDS.Remove(promo_JDS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index_JDS));
        }

        private bool Promo_JDSExists(int id)
        {
            return _context.Promo_JDS.Any(e => e.PromoId_JDS == id);
        }
    }
}
