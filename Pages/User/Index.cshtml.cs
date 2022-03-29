using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using w21_lab3.Models;
namespace w21_lab3.Pages_User
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StoreDBContext _context;
        [BindProperty]
        public User? UserInfo { get; set; }

        public IndexModel(ILogger<IndexModel> logger, StoreDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> OnGet()
        {
            UserInfo = await _context.User.FirstOrDefaultAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UserInfo != null)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                _context.Attach(UserInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            // _logger.Log(LogLevel.Information, UserInfo.Name);
            return RedirectToPage("../Index");
        }
    }

}