using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BarlangDoga.Data;
using BarlangDoga.Models;

namespace BarlangDoga.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly BarlangDoga.Data.BarlangokDbContext _context;

        public DeleteModel(BarlangDoga.Data.BarlangokDbContext context)
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

            var barlang = await _context.barlangok.FirstOrDefaultAsync(m => m.Id == id);

            if (barlang == null)
            {
                return NotFound();
            }
            else
            {
                Barlang = barlang;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlang = await _context.barlangok.FindAsync(id);
            if (barlang != null)
            {
                Barlang = barlang;
                _context.barlangok.Remove(Barlang);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
