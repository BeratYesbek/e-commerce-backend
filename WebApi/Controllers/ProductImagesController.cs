using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] ProductImageDto productImageDto)
        {
            ProductImage productImage = new ProductImage();
            productImage.ProductId = productImageDto.ProductId;

            var result = _productImageService.Add(productImage, productImageDto.File);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}