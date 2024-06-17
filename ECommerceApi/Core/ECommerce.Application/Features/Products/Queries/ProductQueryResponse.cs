namespace ECommerce.Application.Features.Products.Queries
{
    public class GetAllProductsQueryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string BrandName { get; set; }
        public List<string> Categories { get; set; }
    }
}
