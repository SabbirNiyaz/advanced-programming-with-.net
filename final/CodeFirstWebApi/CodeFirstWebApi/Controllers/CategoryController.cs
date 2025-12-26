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
    public class CategoryController : ControllerBase
    {
        CodeFirstContext db;
        public CategoryController(CodeFirstContext context) // Dependency Injection // context is CodeFirstContext's object
        {
            db = context;
        }

        // Mapper
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpPost("create")]
        public IActionResult Create(CategoryDTO cDTO)
        {
            var cMap = GetMapper().Map<Category>(cDTO); // Map CategoryDTO and initialize to cMap
            db.Categories.Add(cMap); // Add in Database
            db.SaveChanges();
            return Ok(cMap);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var cData = db.Categories.ToList();
            return Ok(cData);
        }
        // Update Category
        [HttpPost("update/{id}")]
        public IActionResult Update(CategoryDTO cDTO)
        {
            var cExist = db.Categories.Find(cDTO.Id);
            if (cExist == null)
            {
                return NotFound("Categry not found");
            }
            db.Entry(cExist).CurrentValues.SetValues(cDTO);
            db.SaveChanges();
            return Ok(cExist);
        }

        // Delete Category by Id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var cExist = db.Categories.Find(id);
            if (cExist == null)
            {
                return NotFound("Category not found");
            }
            db.Categories.Remove(cExist);
            db.SaveChanges();
            return Ok("Category deleted successfully");

        }
    }
}
