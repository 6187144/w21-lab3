#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using w21_lab3.Models;

namespace w21_lab3.Pages_Product
{
    public class DeleteModel : PageModel
    {
        private readonly StoreDBContext _context;

        public DeleteModel(StoreDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            if (claimsIdentity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);

                if (Product == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return Redirect("../Identity/Account/Login");
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id);

            if (Product != null)
            {
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
