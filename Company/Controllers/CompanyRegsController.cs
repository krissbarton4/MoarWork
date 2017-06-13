using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Models;

namespace Company.Controllers
{
    public class CompanyRegsController : Controller
    {
        private readonly CompanyContext _context;

        public CompanyRegsController(CompanyContext context)
        {
            _context = context;    
        }

        // GET: CompanyRegs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyReg.ToListAsync());
        }

        // GET: CompanyRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyReg = await _context.CompanyReg
                .SingleOrDefaultAsync(m => m.ID == id);
            if (companyReg == null)
            {
                return NotFound();
            }

            return View(companyReg);
        }

        // GET: CompanyRegs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyRegs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] CompanyReg companyReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyReg);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyReg);
        }

        // GET: CompanyRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyReg = await _context.CompanyReg.SingleOrDefaultAsync(m => m.ID == id);
            if (companyReg == null)
            {
                return NotFound();
            }
            return View(companyReg);
        }

        // POST: CompanyRegs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] CompanyReg companyReg)
        {
            if (id != companyReg.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyRegExists(companyReg.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(companyReg);
        }

        // GET: CompanyRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyReg = await _context.CompanyReg
                .SingleOrDefaultAsync(m => m.ID == id);
            if (companyReg == null)
            {
                return NotFound();
            }

            return View(companyReg);
        }

        // POST: CompanyRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyReg = await _context.CompanyReg.SingleOrDefaultAsync(m => m.ID == id);
            _context.CompanyReg.Remove(companyReg);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyRegExists(int id)
        {
            return _context.CompanyReg.Any(e => e.ID == id);
        }
    }
}
