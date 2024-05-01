namespace RestaurantMVC.UI.Areas.Admin.ViewModels
{
    public class ProductCreateViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageURL { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
