namespace API.Domain.Product.Command
{
    public abstract class ProductBaseCommand
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
    }
}