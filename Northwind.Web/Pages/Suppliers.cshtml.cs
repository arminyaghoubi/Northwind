using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.DataContext.Sqlite;
using Northwind.EntityModels;

namespace Northwind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly NorthwindContext _context;

        public IEnumerable<Supplier>? Suppliers { get; set; }

        public SuppliersModel(NorthwindContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";

            Suppliers = _context.Suppliers
                .OrderBy(s => s.Country)
                .ThenBy(s => s.CompanyName);
        }
    }
}
