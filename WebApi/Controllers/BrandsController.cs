using Business.Abstracts;
using Core.Utilities.FileHelper;
using Entity.Concretes;
using Entity.Concretes.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("add")]   
        public IActionResult Add([FromForm] BrandFormData brandFormData)
        {
            var brandPath = FileHelper.Upload(brandFormData.file);
            Brand brand = new Brand();
            brand.BrandImagePath = brandPath.Message;
            brand.BrandName = brandFormData.BrandName;

            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] BrandFormData brandFormData)
        {
            var brandPath = FileHelper.Upload(brandFormData.file);
            Brand brand = new Brand();

            brand.BrandImagePath = brandPath.Message;
            brand.BrandName = brandFormData.BrandName;

            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);  
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);  
        }


    }
}
