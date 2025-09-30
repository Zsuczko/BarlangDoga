using BarlangDoga.Data;
using BarlangDoga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarlangDoga.Pages
{
    public class TelepulesSzurModel : PageModel
    {

        private readonly BarlangokDbContext _context;

        public TelepulesSzurModel(BarlangokDbContext context)
        {
            _context = context;
        }

        public IList<string> Telepulesek { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ValasztottTelepules {  get; set; }

        public IList<Barlang> Barlangok { get; set; }
        public void OnGet()
        {

            Telepulesek = _context.barlangok.Select(x=>x.Telepules).Distinct().ToList();

            Barlangok = _context.barlangok.Where(x=>x.Telepules == ValasztottTelepules).ToList();
        }
    }
}
