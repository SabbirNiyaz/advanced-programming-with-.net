using LogicTier.DTOs;
using LogicTier.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationTier.Controllers
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

        [HttpPost("create")]
        public IActionResult Create(CategoryDTO catDto)
        {
            var res = service.Create(catDto);
            if(res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CategoryDTO catDto)
        {
            catDto.Id = id;
            var res = service.Update(catDto);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);

            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }

        }

    }
}
