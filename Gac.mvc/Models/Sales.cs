namespace Gac.mvc.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        public string SalesAddress1 { get; set; }
        public string SalesAddress2 { get; set; }
        public string SalesAddress3 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
