using DataTier.EF.Models;
using DataTier.Repos;
using LogicTier.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.Services
{
    public class CategoryService
    {
        CategoryRepo repo;
        public CategoryService(CategoryRepo repo)
        {
            this.repo = repo;
        }
        public List<CategoryDTO> GetAll()
        {
            var data = repo.GetAll(); // Get all data form repo class
            var mapper = MapperConfig.GetMapper(); // Get mapper instance from MapperConfig class
            var dtoData = mapper.Map<List<CategoryDTO>>(data); // Map data to DTOs
            return dtoData;
        }
        public CategoryDTO? GetById(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO?>(repo.GetById(id)); // Shortcut
        }
        public bool Create(CategoryDTO catDto)
        {
            var cat = MapperConfig.GetMapper().Map<Category>(catDto);
            return repo.Create(cat);
        }
        public bool Update(CategoryDTO catDto)
        {
            var cat = MapperConfig.GetMapper().Map<Category>(catDto);
            return repo.Update(cat);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
