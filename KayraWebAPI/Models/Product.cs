namespace KayraWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        /// <summary>
        /// İsimi
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Açıklaması
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Fiyatı
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Stok Miktarı
        /// </summary>
        public int StockQuantity { get; set; }
        /// <summary>
        /// Oluşturma Tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } 
        public DateTime? DeletedAt { get; set; }

    }
}
