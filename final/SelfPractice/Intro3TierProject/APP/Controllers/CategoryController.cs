using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryService service;
        public CategoryController(CategoryService service) 
        { 
            this.service = service;
        }
        [HttpPost("create")]
        public IActionResult Create(CategoryDTO cDto)
        {
            var res = service.Create(cDto);
            if (res == true)
            {
                return Ok(res);
            }
            else { return BadRequest(res); }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CategoryDTO cDto)
        {
            cDto.Id = id;
            var res = service.Update(cDto);
            if (res == true)
            {
                return Ok(res);
            }
            else { return BadRequest(res); }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res == true) { return Ok(res); }
            else { return BadRequest(res); }
        }
        [HttpGet("all")]
        public IActionResult GetAll() 
        { 
            var data = service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var data = service.GetById(id);
            return Ok(data);
        }
    }
}
