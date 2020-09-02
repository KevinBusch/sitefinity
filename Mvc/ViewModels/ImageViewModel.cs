using System;

namespace SitefinityWebApp.MVC.ViewModels
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string ProviderName { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }
}