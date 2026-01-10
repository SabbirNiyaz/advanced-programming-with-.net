using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductService service;
        public ProductController(ProductService service)
        {
            this.service = service;
        }
        [HttpPost("create")]
        public IActionResult Create(ProductDTO pDto)
        {
            var res = service.Create(pDto);
            if (res) return Ok(res);
            return BadRequest(res);
        }
        [HttpPatch("update/{id}")]
        public IActionResult Update(int id, ProductDTO pDto)
        {
            pDto.Id = id;
            var res = service.Update(pDto);
            if (res) return Ok(res);
            return BadRequest(res);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res) return Ok(res);
            return BadRequest(res);
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }
    }
}
