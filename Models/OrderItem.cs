namespace OrderTrackingApi.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }         // ID of the product
        public string ProductName { get; set; }    // Name of the product
        public int Quantity { get; set; }          // Quantity ordered
        public decimal Price { get; set; }         // Price per item

        public decimal Total => Quantity * Price;  // Calculated total
    }
}

