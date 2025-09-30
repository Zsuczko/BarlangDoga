using BarlangDoga.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarlangDoga.Pages
{
    public class OsszesitoModel : PageModel
    {

        private readonly BarlangokDbContext _context;

        public OsszesitoModel(BarlangokDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, int> Telepulesek { get; set; }
        public void OnGet()
        {
            Telepulesek = new Dictionary<string, int>();
            foreach (var item in _context.barlangok)
            {
                if (!Telepulesek.ContainsKey(item.Telepules)) {
                    Telepulesek[item.Telepules] = 0;
                }
                Telepulesek[item.Telepules]++;
            }
        }
    }
}
