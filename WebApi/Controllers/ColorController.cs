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
    public class ColorController : ControllerBase
    {
        IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Colors colors)
        {
            var result = _colorService.Add(colors);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Colors colors)
        {
            var result = _colorService.Update(colors);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Colors colors)
        {
            var result = _colorService.Delete(colors);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAllColors();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
