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
    public class NewsController : ControllerBase
    {
        CodeFirstContext db;
        public NewsController(CodeFirstContext context) // Dependency Injection // context is CodeFirstContext's object
        {
            db = context;
        }

        // Mapper
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Create News
        [HttpPost("create")]
        public IActionResult Create(NewsDTO nDTO)
        {
            //var nMap = GetMapper().Map<News>(nDTO); // Map NewsDTO and initialize to cMap
            //db.News.Add(nMap); // Add in Database
            //db.SaveChanges();
            //return Ok(nMap);

            // Bug fix
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (nDTO.CId <= 0)
                return BadRequest("CId must be a positive category id.");

            var category = db.Categories.Find(nDTO.CId);
            if (category == null)
                return BadRequest($"Category with Id {nDTO.CId} not found.");

            var news = new News
            {
                Title = nDTO.Title,
                Date = nDTO.Date,
                CId = nDTO.CId,
                Cat = category // optional: attach navigation so EF tracks relation
            };

            db.News.Add(news);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = news.Id }, news);
            
        }

        // Get All News
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var nData = db.News.ToList();
            return Ok(nData);
        }

        // Update News
        [HttpPost("update/{id}")]
        public IActionResult Update(NewsDTO nDTO)
        {
            var nExist = db.News.Find(nDTO.Id);
            if (nExist == null)
            {
                return NotFound("News not found");
            }
            db.Entry(nExist).CurrentValues.SetValues(nDTO);
            db.SaveChanges();
            return Ok(nExist);
        }

        // Delete News by Id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var nExist = db.News.Find(id);
            if (nExist == null)
            {
                return NotFound("News not found");
            }
            db.News.Remove(nExist);
            db.SaveChanges();
            return Ok("News deleted successfully");

        }
    }
}
