namespace Pagination_Asp.NetCoreMVC.Models
{
    public class ProductModel
    {
        public List<Product> Products { get; set; }

        public int CurrentIndex { get; set; }

        public int PageCount { get; set; }
    }

    public class Product
    {
        public string PName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }
    }
}
 