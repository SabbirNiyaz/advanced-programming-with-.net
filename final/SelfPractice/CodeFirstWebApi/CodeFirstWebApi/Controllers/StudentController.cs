using AutoMapper;
using CodeFirstWebApi.DTOs;
using CodeFirstWebApi.EF;
using CodeFirstWebApi.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        UniContext db;
        public StudentController(UniContext context) // Dependency Injection // context is CodeFirstContext's object
        {
            db = context;
        }

        // Mapper
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student_table>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Create Students
        [HttpPost("create")]
        public IActionResult Create(StudentDTO sDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var student = new Student_table
            {
                Name = sDTO.Name
            };

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, student);

        }

        // Get All Students
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var sData = db.Students.ToList();
            return Ok(sData);
        }

        // Update Students
        [HttpPost("update/{id}")]
        public IActionResult Update(StudentDTO sDTO)
        {
            var sExist = db.Students.Find(sDTO.Id);
            if (sExist == null)
            {
                return NotFound("Student ID is not found");
            }
            db.Entry(sExist).CurrentValues.SetValues(sDTO);
            db.SaveChanges();
            return Ok(sExist);
        }

        // Delete Students by Id
        [HttpDelete("delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            var sExist = db.Students.Find(Id);
            if (sExist == null)
            {
                return NotFound("Student ID is not found");
            }
            db.Students.Remove(sExist);
            db.SaveChanges();
            return Ok("Student deleted successfully");

        }
    }
}
