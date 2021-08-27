using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using Entity.Concretes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getAllProductDetail")]
        public IActionResult GetAllProductDetail()
        {
            var result = _productService.GetAllProductDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }
        [HttpGet("getProductDetailById")]
        public IActionResult GetProductDetailById(int id)
        {
            var result = _productService.GetProductDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}