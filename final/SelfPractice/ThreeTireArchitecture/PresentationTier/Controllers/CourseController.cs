using LogicTier.DTOs;
using LogicTier.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseService service;
        public CourseController(CourseService service)
        {
            this.service = service;
        }

        // Get All
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);

        }
        // Get by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = service.GetById(id);
            return Ok(data);
        }
        // Create
        [HttpPost("create")]
        public IActionResult Create(CourseDTO c)
        {
            var res = service.Create(c);
            return Ok(res);
        }
        // Update   
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CourseDTO c)
        {
            c.Id = id; // make sure ID comes from URL
            var res = service.Update(c);
            return Ok(res);
        }
        // Delete
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            return Ok(res);
        }
    }
}
