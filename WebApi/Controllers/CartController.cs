using Business.Abstract;
using Entity.Concrete;
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
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getdetailsbyuserıd")]
        public IActionResult GetCartDetailsByUserId(int userId)
        {
            var result = _cartService.GetCartDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Carts carts)
        {
            var result = _cartService.Add(carts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
         
        [HttpGet("getdetailsbyuserid")]
        public IActionResult GetCartDetailsByUserId(int userId)
        {
            var result = _cartService.Update(carts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(Carts carts)
        {
            var result = _cartService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Carts carts)
        {
            var result = _cartService.Delete(carts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
