using System;

namespace SitefinityWebApp.Mvc.ViewModels
{
    public class FlatTaxonomyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TaxaCount { get; set; }
    }
}