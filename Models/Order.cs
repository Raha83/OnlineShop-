namespace Eshop
{
    public class Order
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; } = null!;
        public ICollection<OrderDetail>? orderdetails { get; set; }
    }
}