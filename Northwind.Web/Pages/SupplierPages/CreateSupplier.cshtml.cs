using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.DataContext.Sqlite;
using Northwind.EntityModels;

namespace Northwind.Web.Pages.SupplierPages
{
    public class CreateSupplierModel : PageModel
    {
        private readonly NorthwindContext _context;

        [BindProperty]
        public Supplier Supplier { get; set; } = new();

        public CreateSupplierModel(NorthwindContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Create Supplier";
        }

        public async Task<IActionResult> OnPost()
        {
            if (Supplier is not null && ModelState.IsValid)
            {
                await _context.Suppliers.AddAsync(Supplier);
                await _context.SaveChangesAsync();
                return RedirectToPage("Suppliers");
            }
            else
            {
                return Page();
            }
        }
    }
}
