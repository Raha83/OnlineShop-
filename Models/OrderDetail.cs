namespace Eshop
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int orderId { get; set; }
        public virtual Product product { get; set; } = null!;
        public virtual Order order { get; set; } = null!;
    }
}