using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_lyashuk.Data;
using wt_lab8_8razor_postgresql_lyashuk.Models;

namespace wt_lab8_8razor_postgresql_lyashuk.Pages.Players
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player? Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FindAsync(id);
            if (Player == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Player == null)
            {
                return NotFound();
            }

            var playerToDelete = await _context.Players.FindAsync(Player.Id);
            if (playerToDelete != null)
            {
                _context.Players.Remove(playerToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}