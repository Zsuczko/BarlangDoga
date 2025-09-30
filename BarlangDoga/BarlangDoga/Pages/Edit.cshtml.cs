using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarlangDoga.Data;
using BarlangDoga.Models;

namespace BarlangDoga.Pages
{
    public class EditModel : PageModel
    {
        private readonly BarlangDoga.Data.BarlangokDbContext _context;

        public EditModel(BarlangDoga.Data.BarlangokDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Barlang Barlang { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlang =  await _context.barlangok.FirstOrDefaultAsync(m => m.Id == id);
            if (barlang == null)
            {
                return NotFound();
            }
            Barlang = barlang;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Barlang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarlangExists(Barlang.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BarlangExists(int id)
        {
            return _context.barlangok.Any(e => e.Id == id);
        }
    }
}
