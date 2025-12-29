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
    public class DeptsController : ControllerBase
    {
        UniContext db;
        public DeptsController(UniContext context) // Dependency Injection // context is CodeFirstContext's object
        {
            db = context;
        }

        // Mapper
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeptsDTO, Dept_table>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Create Departments
        [HttpPost("create")]
        public IActionResult Create(DeptsDTO dDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var d = new Dept_table
            {
                DeptName = dDTO.DeptName,
                SId = dDTO.SId
            };

            db.Depts.Add(d);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = d.Id }, d);

        }

        // Get All Departments
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var dData = db.Depts.ToList();
            return Ok(dData);
        }

        // Update Students
        [HttpPost("update/{id}")]
        public IActionResult Update(DeptsDTO dDTO)
        {
            var dExist = db.Depts.Find(dDTO.Id);
            if (dExist == null)
            {
                return NotFound("Department is not found");
            }
            db.Entry(dExist).CurrentValues.SetValues(dDTO);
            db.SaveChanges();
            return Ok(dExist);
        }

        // Delete Departments by Id
        [HttpDelete("delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            var dExist = db.Depts.Find(Id);
            if (dExist == null)
            {
                return NotFound("Department is not found");
            }
            db.Depts.Remove(dExist);
            db.SaveChanges();
            return Ok("Department deleted successfully");

        }
    }
}

