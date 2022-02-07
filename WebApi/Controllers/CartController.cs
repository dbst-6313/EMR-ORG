using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cartService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetCartDetails()
        {
            var result = _cartService.GetCartDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
         
        [HttpGet("getdetailsbyuser")]
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
        [HttpPost("update")]
        public IActionResult Update(Carts carts)
        {
            var result = _cartService.Update(carts);
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
