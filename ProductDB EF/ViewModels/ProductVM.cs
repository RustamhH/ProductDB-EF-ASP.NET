namespace ProductDB_EF.ViewModels
{
    public class ProductVM
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public double? Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
    }
}
