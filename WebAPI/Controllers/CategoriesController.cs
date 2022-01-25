using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           var result = _categoryService.GetAll();
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getallbydescription")]
        public IActionResult GetAllByDescription(string description)
        {
            var result = _categoryService.GetAllByDescription(description);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            return result.Success == true
                ? Ok(result)
                : BadRequest(result.Title + " : " + result.Message);
        }

    }
}
