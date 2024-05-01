namespace RestaurantMVC.UI.Areas.Admin.ViewModels
{
    public class SliderCreateViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonLink { get; set; }
        public IFormFile? ImageURL { get; set; }
    }
}
