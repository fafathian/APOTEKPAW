using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apotekkk.Models;

namespace apotekkk.Controllers
{
    public class TransaksisController : Controller
    {
        private readonly ApotekContext _context;

        public TransaksisController(ApotekContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var apotekContext = _context.Transaksi.Include(t => t.IdApotekerNavigation).Include(t => t.IdObatNavigation).Include(t => t.IdPembeliNavigation);
            return View(await apotekContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi
                .Include(t => t.IdApotekerNavigation)
                .Include(t => t.IdObatNavigation)
                .Include(t => t.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["IdApoteker"] = new SelectList(_context.Apoteker, "IdApoteker", "IdApoteker");
            ViewData["IdObat"] = new SelectList(_context.Obat, "IdObat", "IdObat");
            ViewData["IdPembeli"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,IdObat,IdPembeli,IdApoteker,TglTransaksi,TotalHarga")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdApoteker"] = new SelectList(_context.Apoteker, "IdApoteker", "IdApoteker", transaksi.IdApoteker);
            ViewData["IdObat"] = new SelectList(_context.Obat, "IdObat", "IdObat", transaksi.IdObat);
            ViewData["IdPembeli"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli", transaksi.IdPembeli);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["IdApoteker"] = new SelectList(_context.Apoteker, "IdApoteker", "IdApoteker", transaksi.IdApoteker);
            ViewData["IdObat"] = new SelectList(_context.Obat, "IdObat", "IdObat", transaksi.IdObat);
            ViewData["IdPembeli"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli", transaksi.IdPembeli);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,IdObat,IdPembeli,IdApoteker,TglTransaksi,TotalHarga")] Transaksi transaksi)
        {
            if (id != transaksi.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.IdTransaksi))
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
            ViewData["IdApoteker"] = new SelectList(_context.Apoteker, "IdApoteker", "IdApoteker", transaksi.IdApoteker);
            ViewData["IdObat"] = new SelectList(_context.Obat, "IdObat", "IdObat", transaksi.IdObat);
            ViewData["IdPembeli"] = new SelectList(_context.Pembeli, "IdPembeli", "IdPembeli", transaksi.IdPembeli);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi
                .Include(t => t.IdApotekerNavigation)
                .Include(t => t.IdObatNavigation)
                .Include(t => t.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);
            _context.Transaksi.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksi.Any(e => e.IdTransaksi == id);
        }
    }
}
