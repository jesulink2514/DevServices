using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Devcode.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Devcode.Api.Services
{
    public class CatalogMockService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatalogMockService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mockCatalog = new ObservableCollection<CatalogItem>
            {
                new CatalogItem { Id = Common.MockCatalogItemId01, PictureUri = GetFullPictureUrl("/Images/fake_product_01.png"), Name = ".NET Bot Blue Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 2, CatalogType = "T-Shirt" },
                new CatalogItem { Id = Common.MockCatalogItemId02, PictureUri = GetFullPictureUrl("/Images/fake_product_02.png"), Name = ".NET Bot Purple Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 2, CatalogType = "T-Shirt" },
                new CatalogItem { Id = Common.MockCatalogItemId03, PictureUri = GetFullPictureUrl("/Images/fake_product_03.png"), Name = ".NET Bot Black Sweatshirt (M)", Price = 19.95M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 2, CatalogType = "T-Shirt" },
                new CatalogItem { Id = Common.MockCatalogItemId04, PictureUri = GetFullPictureUrl("/Images/fake_product_04.png"), Name = ".NET Black Cupt", Price = 17.00M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 1, CatalogType = "Mug" },
                new CatalogItem { Id = Common.MockCatalogItemId05, PictureUri = GetFullPictureUrl("/Images/fake_product_05.png"), Name = "Azure Black Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 1, CatalogBrand = "Azure", CatalogTypeId = 2, CatalogType = "T-Shirt" }
            };
        }
        private readonly ObservableCollection<CatalogBrand> _mockCatalogBrand = new ObservableCollection<CatalogBrand>
        {
            new CatalogBrand { Id = 1, Brand = "Azure" },
            new CatalogBrand { Id = 2, Brand = "Visual Studio" }
        };

        private readonly ObservableCollection<CatalogType> _mockCatalogType = new ObservableCollection<CatalogType>
        {
            new CatalogType { Id = 1, Type = "Mug" },
            new CatalogType { Id = 2, Type = "T-Shirt" }
        };

        private readonly ObservableCollection<CatalogItem> _mockCatalog;

        public async Task<ObservableCollection<CatalogItem>> GetCatalogAsync()
        {
            await Task.Delay(500);

            return _mockCatalog;
        }

        public async Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId)
        {

            await Task.Delay(500);

            return _mockCatalog
                .Where(c => c.CatalogBrandId == catalogBrandId &&
                c.CatalogTypeId == catalogTypeId)   
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
        {
            await Task.Delay(500);

            return _mockCatalogBrand;
        }

        public async Task<ObservableCollection<CatalogType>> GetCatalogTypeAsync()
        {
            await Task.Delay(500);

            return _mockCatalogType;
        }

        public string GetFullPictureUrl(string pictureUrl)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return $"{request.Scheme}://{request.Host.Value}{pictureUrl}";
        }
    }
}