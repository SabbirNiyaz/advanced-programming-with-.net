using IntroCoreWebApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet("all")]  // Route Pattern | Url =  GET: /api/department/all
        public IActionResult All() {
            var d1 = new DepartmentDTO()
            {
                Id = 1,
                Name = "CSE",
            };
            var d2 = new DepartmentDTO()
            {
                Id = 2,
                Name = "EEE",
            };

            var data = new List<DepartmentDTO> { d1, d2 };
            return Ok(data);
        }

        [HttpGet("{id}")] // Url = GET: /api/department/{id}
        public IActionResult Get(int id)
        {
            var data = new DepartmentDTO()
            {
                Id = id,
                Name = $"{id}"
            };
            return Ok(data);
        }
        [HttpGet("id/{id}/name/{name}")] // Url = GET: /api/department/id/{id}/name/{name}
        public IActionResult Get(int id, string name)
        {
            var data = new DepartmentDTO()
            {
                Id = id,
                Name = name
            };
            return Ok(data);
        }

        [HttpPost("create")] // POST: /api/department/create  
        public IActionResult Create(DepartmentDTO department)
        {
            return Ok(department); // Create (receive) a department object
        }
}
