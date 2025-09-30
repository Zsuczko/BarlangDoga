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
    public class IndexModel : PageModel
    {
        private readonly BarlangDoga.Data.BarlangokDbContext _context;

        public IndexModel(BarlangDoga.Data.BarlangokDbContext context)
        {
            _context = context;
        }

        public IList<Barlang> Barlang { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Barlang = await _context.barlangok.ToListAsync();
        }
    }
}
