using System.Collections.Generic;
using System.Threading.Tasks;
using Devcode.Api.Models;
using Devcode.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devcode.Api.Controllers
{
    [Route("api/catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogMockService _catalogService;

        public CatalogController(CatalogMockService catalogMockService)
        {
            _catalogService = catalogMockService;
        }

        [HttpGet]
        public async Task<IEnumerable<CatalogItem>> GetCatalogAsync()
        {
            var products = await _catalogService.GetCatalogAsync();
            return products;
        }   

        [HttpGet,Route("filter")]
        public async Task<IEnumerable<CatalogItem>> FilterAsync(int catalogBrandId,int catalogTypeId)
        {
            return await _catalogService.FilterAsync(catalogBrandId, catalogTypeId);
        }

        [HttpGet,Route("brands")]
        public async Task<IEnumerable<CatalogBrand>> GetCatalogBrandAsync()
        {
            return await _catalogService.GetCatalogBrandAsync();
        }

        [HttpGet,Route("types")]
        public async Task<IEnumerable<CatalogType>> GetCatalogTypeAsync()
        {
            return await _catalogService.GetCatalogTypeAsync();
        }
    }
}
