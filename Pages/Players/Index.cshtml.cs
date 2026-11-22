using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_lyashuk.Data;
using wt_lab8_8razor_postgresql_lyashuk.Models;

namespace wt_lab8_8razor_postgresql_lyashuk.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Player> Players { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Players.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Search))
            {
                query = query.Where(p => p.Nickname.Contains(Search));
            }

            Players = await query
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
    }
}