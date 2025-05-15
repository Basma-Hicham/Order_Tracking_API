using OrderTrackingApi.Models;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public int OrderId { get; set; }

    [Required]
    public string Username { get; set; }

    [MinLength(1, ErrorMessage = "At least one item is required.")]
    public List<OrderItem> Items { get; set; } = new();

    public decimal Total { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";
}


