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
    public class IndexModel : PageModel
    {
        private readonly Eshop.EshopContext _context;

        public IndexModel(Eshop.EshopContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.products.AsNoTracking().ToListAsync();
        }
    }
}
