// These lines import the required namespaces
using IntroCoreWebApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCoreWebApi.Controllers
{
    [Route("api/[controller]")]  // Means the route will be: api/Student (Controller)
    [ApiController]  // Automatically handles validation and API-specific features.
    public class StudentController : ControllerBase // ControllerBase used because this controller returns JSON (no views).
    {
        [HttpGet]  // GET /api/Student (Controller)
        public IActionResult GetAll()
        {
            // Two StudentDTO objects are created manually
            var s1 = new StudentDTO()
            {
                Id = 1,
                Name = "Sabbir",
                Email = "sabbir@gmail.com",
                Phone = "01711111111"
            };
            var s2 = new StudentDTO()
            {
                Id = 2,
                Name = "Niyaz",
                Email = "niyaz@gmail.com",
                Phone = "01311111111"
            };

            var data = new List<StudentDTO>() { s1, s2};  // Then they’re added to a list
            return Ok(data); // Ok() returns an HTTP 200 status code & Sends the list of students as JSON response
        }
        /*
         *** Final Output Example (JSON data):
          [
            {
                "id": 1,
                "name": "Sabbir",
                "email": "sabbir@gmail.com",
                "phone": "01711111111"
            },
            {
                "id": 2,
                "name": "Niyaz",
                "email": "niyaz@gmail.com",
                "phone": "01311111111"
              }
          ]
        */


        [HttpPost] // POST /api/Student
        public IActionResult Post(StudentDTO student)
        {
            return Ok(student); // Can create object from API Testing or client side 
        } 
    } 
}
}
