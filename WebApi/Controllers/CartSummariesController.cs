using Business.Abstracts;
using Entity.Concretes;
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
    public class CartSummariesController : ControllerBase
    {

        private readonly ICartSummaryService _cartSummaryService;

        public CartSummariesController(ICartSummaryService cartSummaryService)
        {
            _cartSummaryService = cartSummaryService;
        }

        [HttpPost("add")]
        public IActionResult Add(CartSummary cartSummary)
        {
            var result = _cartSummaryService.Add(cartSummary);
            if (result.Success)
            {
               return Ok(result);   
            }

            return BadRequest(result);  
        }

        [HttpPost("update")]
        public IActionResult Update(CartSummary cartSummary)
        {
            var result = _cartSummaryService.Update(cartSummary);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CartSummary cartSummary)
        {
            var result = _cartSummaryService.Delete(cartSummary);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _cartSummaryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _cartSummaryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getCartSummaryDetailByUserId")]
        public IActionResult GetCartSummaryDetailByUserId(int userId)
        {
            var result = _cartSummaryService.GetCartSummaryDetailByUserId(userId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
