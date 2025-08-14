namespace KayraWebAPI.Dtos
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }=DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}
