using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eshop;

namespace OnlineShop.pages_customers
{
    public class IndexModel : PageModel
    {
        private readonly Eshop.EshopContext _context;

        public IndexModel(Eshop.EshopContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.customers.ToListAsync();
        }
    }
}
