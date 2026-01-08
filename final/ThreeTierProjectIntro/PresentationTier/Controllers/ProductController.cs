using LogicTier.DTOs;
using LogicTier.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationTier.Controllers
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
        public IActionResult Create(ProductDTO pDto)
        {
            var res = service.Create(pDto);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPatch("update/{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO pDto)
        {
            pDto.Id = id;
            var res = service.Update(pDto);
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
