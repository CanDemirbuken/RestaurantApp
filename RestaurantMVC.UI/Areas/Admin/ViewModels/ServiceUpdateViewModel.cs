namespace RestaurantMVC.UI.Areas.Admin.ViewModels
{
    public class ServiceUpdateViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
