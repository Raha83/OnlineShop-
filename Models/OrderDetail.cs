namespace Eshop
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int orderId { get; set; }
        public Product product { get; set; } = null!;
        public Order order { get; set; } = null!;
    }
}