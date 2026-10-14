namespace Eshop
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public int price { get; set; }
        public string? description { get; set; }
    }
}
