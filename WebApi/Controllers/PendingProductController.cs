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
    public class PendingProductController : Controller
    {
        private IPendingProductsService _PendingProductsService;

        public PendingProductController(IPendingProductsService PendingProductsService)
        {
            _PendingProductsService = PendingProductsService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _PendingProductsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _PendingProductsService.GetAllDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallpendingproductsbyuserid")]
        public IActionResult GetAllPendingProductsByUserId(int userId)
        {
            var result = _PendingProductsService.GetAllDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(PendingProducts PendingProducts)
        {
            var result = _PendingProductsService.Add(PendingProducts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(PendingProducts PendingProducts)
        {
            var result = _PendingProductsService.Update(PendingProducts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PendingProducts PendingProducts)
        {
            var result = _PendingProductsService.Delete(PendingProducts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
