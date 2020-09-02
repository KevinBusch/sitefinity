

//using SitefinityWebApp.MVC.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Telerik.Sitefinity.DynamicModules;
//using Telerik.Sitefinity.DynamicModules.Model;
//using Telerik.Sitefinity.Model;
//using Telerik.Sitefinity.Utilities.TypeConverters;

//namespace SitefinityWebApp.MVC.Models
//{
//    public class OfficeModel
//    {
//        public string ProviderName { get; set; }

//        protected DynamicModuleManager GetManager()
//        {
//            return DynamicModuleManager.GetManager(this.ProviderName);
//        }

//        public Type OfficeType => TypeResolutionService.ResolveType
//            ("Telerik.Sitefinity.DynamicTypes.Model.Meettheteam.Office");

//        public IEnumerable<OfficeViewModel> GetOfficesViewModels()
//        {
//            var offices = this.GetManager()
//                .GetDataItems(OfficeType)
//                .Where(o => o.Status == ContentLifecycleStatus.Live && o.Visible == true)
//                .OrderBy("Title");

//            return offices.ToArray()
//                .Select(o => ToViewModel(o));
//        }

//        private OfficeViewModel ToViewModel(DynamicContent office)
//        {
//            var officeViewModel = new OfficeViewModel();
//            officeViewModel.Id = office.Id;
//            officeViewModel.ProviderName = office.ProviderName;
//            officeViewModel.Title = office.GetString("Title").Value;
//            officeViewModel.Info = office.GetString("Info").Value;
//            officeViewModel.Picture = this.GetImageViewModel(office.GetRelatedItem<Image>("Picture"));
//        }

//        private ImageViewModel GetImageViewModel(IQueryable<Image> relatedImages)
//        {
//            var image = new ImageViewModel();
//            if (relatedImages.Count() > 0)
//            {
//                var relatedImage = relatedImages.First();
//                image.Id = relatedImage.Id;
//                image.ImageUrl = relatedImage.MediaUrl;
//                image.AltText = relatedImage.AlternativeText;
//            }
//        }
//    }
//}