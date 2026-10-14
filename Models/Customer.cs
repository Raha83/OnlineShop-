using System.Collections;
using Microsoft.VisualBasic;

namespace Eshop
{
    public class Customer
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string email { get; set; } = null!;
        public ICollection<Order> orders { get; set; } = null!;

    }

}