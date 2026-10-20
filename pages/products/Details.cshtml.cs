using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eshop;

namespace OnlineShop.pages_products
{
    public class DetailsModel : PageModel
    {
        private readonly Eshop.EshopContext _context;

        public DetailsModel(Eshop.EshopContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minPrice = 500000;
            var product = await _context.products.FromSqlInterpolated($"SELECT * FROM products WHERE price > {minPrice}").FirstOrDefaultAsync(m => m.id == id);

            if (product is not null)
            {
                Product = product;

                return Page();
            }

            return NotFound();
        }
    }
}
