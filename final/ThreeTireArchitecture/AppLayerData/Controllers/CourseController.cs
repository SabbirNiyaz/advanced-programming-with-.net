using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseServices service;
        public CourseController(CourseServices service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);

        }
        [HttpPost("create")]
        public IActionResult Create(CourseDTO c)
        {
            var res = service.Create(c);
            return Ok(res);
        }
        //[HttpPost("update")]
        //public IActionResult Update(CourseDTO c)
        //{
        //    var res = service.Update(c);
        //    return Ok(res);
        //}
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CourseDTO c)
        {
            c.Id = id;              // make sure ID comes from URL
            var res = service.Update(c);
            return Ok(res);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }
    }
}
