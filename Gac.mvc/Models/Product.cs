namespace Gac.mvc.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int SalesId { get; set; } // Foreign Key
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; } // Calculated field

        public virtual Sales Sales { get; set; } // Navigation Property
    }
}
