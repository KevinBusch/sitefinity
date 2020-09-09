using SitefinityWebApp.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;

namespace SitefinityWebApp.Mvc.Models
{
    public class FlatTaxonomyModel
    {
        private readonly TaxonomyManager taxonomyManager;

        public FlatTaxonomyModel()
        {
            this.taxonomyManager = TaxonomyManager.GetManager();
        }

        public IQueryable<FlatTaxonomyViewModel> Taxonomies
        {
            get; 
            private set;
        }

        public void Populate()
        {
            this.Taxonomies = this.taxonomyManager
                .GetTaxonomies<FlatTaxonomy>()
                .Select(t => ToViewModel(t));
        }

        private FlatTaxonomyViewModel ToViewModel(FlatTaxonomy t)
        {
            var viewModel = new FlatTaxonomyViewModel();
            viewModel.Id = t.Id;
            viewModel.Name = t.Title.Value;
            viewModel.TaxaCount = this.taxonomyManager
                .GetTaxa<FlatTaxon>()
                .Where(taxon => taxon.TaxonomyId == t.Id)
                .Count();

            return viewModel;
        }
    }
}