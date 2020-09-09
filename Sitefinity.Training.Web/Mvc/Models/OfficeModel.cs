

//using SitefinityWebApp.MVC.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Threading;
//using Telerik.Sitefinity.DynamicModules;
//using Telerik.Sitefinity.DynamicModules.Model;
//using Telerik.Sitefinity.Model;
//using Telerik.Sitefinity.GeoLocations.Model;
//using Telerik.Sitefinity.Utilities.TypeConverters;
//using Telerik.Sitefinity.Versioning;
//using Telerik.Sitefinity.Locations;
//using Telerik.Sitefinity.Configuration;
//using Telerik.Sitefinity.Locations.Configuration;
//using Telerik.Sitefinity.Modules.Libraries;
//using Telerik.Sitefinity.RelatedData;
//using Telerik.Sitefinity.GenericContent.Model;
//using Telerik.Sitefinity.Security;
//using Telerik.Sitefinity;
//using Telerik.Sitefinity.Data;
//using Telerik.Microsoft.Practices.ObjectBuilder2;

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

//            // IMPORTANT: eagerly load data to prevent "N" roundtrips to database
//            offices.SetRelatedDataSourceContext();

//            return offices.ToArray()
//                .Select(o => ToViewModel(o));
//        }

//        public string CreateOffice()
//        {
//            var result = "New York Office was created";

//            try
//            {
//                // Set a transaction name and get the version manager
//                var transactionName = "creatingAModule";
//                var versionManager = VersionManager.GetManager(null, transactionName);

//                // Set the culture name for the multilingual fields
//                var cultureName = "en";
//                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

//                DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(this.ProviderName, transactionName);
//                Type officeType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.MeettheTeam.Office");

//                dynamicModuleManager.Provider.SuppressSecurityChecks = true;
//                DynamicContent officeItem = dynamicModuleManager.CreateDataItem(this.OfficeType);

//                // This is how values for the properties are set
//                officeItem.SetString("Title", "New York", cultureName);
//                officeItem.SetString("Info", "LOREM IPSUM", cultureName);
//                Address address = new Address();
//                CountryElement addressCountry = Config.Get<LocationsConfig>().Countries.Values.First(x => x.Name == "United States");
//                address.CountryCode = addressCountry.IsoCode;
//                address.StateCode = addressCountry.StatesProvinces.Values.First().Abbreviation;
//                address.City = "New York";
//                address.Street = "Baker Street";
//                address.Zip = "12";
//                officeItem.SetValue("Address", address);


//                // Get related item manager
//                LibrariesManager pictureManager = LibrariesManager.GetManager();
//                var pictureItem = pictureManager.GetImages().FirstOrDefault(i => i.Status == ContentLifecycleStatus.Master && i.Title.StartsWith("New York"));
//                if (pictureItem != null)
//                {
//                    // This is how we relate an item
//                    officeItem.CreateRelation(pictureItem, "Picture");
//                }


//                officeItem.SetString("UrlName", "new-york");
//                officeItem.SetValue("Owner", SecurityManager.GetCurrentUserId());
//                officeItem.SetValue("PublicationDate", DateTime.UtcNow);


//                officeItem.SetWorkflowStatus(dynamicModuleManager.Provider.ApplicationName, "Draft", new CultureInfo(cultureName));

//                // Create a version and commit the transaction in order changes to be persisted to data store
//                versionManager.CreateVersion(officeItem, false);
//                TransactionManager.CommitTransaction(transactionName);

//                // Use lifecycle so that LanguageData and other Multilingual related values are correctly created
//                DynamicContent checkOutOfficeItem = dynamicModuleManager.Lifecycle.CheckOut(officeItem) as DynamicContent;
//                DynamicContent checkInOfficeItem = dynamicModuleManager.Lifecycle.CheckIn(checkOutOfficeItem) as DynamicContent;
//                versionManager.CreateVersion(checkInOfficeItem, false);
//                TransactionManager.CommitTransaction(transactionName);

//                dynamicModuleManager.Provider.SuppressSecurityChecks = false;
//            }
//            catch (Exception ex)
//            {
//                result = ex.ToString();
//            }

//            return result;
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