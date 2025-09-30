using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarlangDoga.Data;
using BarlangDoga.Models;

namespace BarlangDoga.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BarlangDoga.Data.BarlangokDbContext _context;

        public CreateModel(BarlangDoga.Data.BarlangokDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Barlang Barlang { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.barlangok.Add(Barlang);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
