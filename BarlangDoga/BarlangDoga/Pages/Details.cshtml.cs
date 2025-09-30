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
    public class DetailsModel : PageModel
    {
        private readonly BarlangDoga.Data.BarlangokDbContext _context;

        public DetailsModel(BarlangDoga.Data.BarlangokDbContext context)
        {
            _context = context;
        }

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
    }
}
