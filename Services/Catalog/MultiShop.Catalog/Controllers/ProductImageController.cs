using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            this._productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImageAsync()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await _productImageService.GetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün görseli başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görseli silindi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün görseli güncellendi.");
        }
    }
}
