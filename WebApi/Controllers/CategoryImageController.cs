using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryImageController : ControllerBase
    {
        ICategoryImageService _categoryImageService;

        public CategoryImageController(ICategoryImageService categoryImageService)
        {
            _categoryImageService = categoryImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _categoryImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]

        public IActionResult Add([FromForm] CategoryImage categoryImage,  IFormFile file)
        {
            var result = _categoryImageService.Add(categoryImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var categoryImage = _categoryImageService.GetById(Id).Data;
            var result = _categoryImageService.Delete(categoryImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var categoryImage = _categoryImageService.GetById(Id).Data;
            var result = _categoryImageService.Update(file, categoryImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}