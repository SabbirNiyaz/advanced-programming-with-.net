using DataTier;
using DataTier.EF.Models;
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
        DataAccessFactory factory;
        public CategoryService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<CategoryDTO> GetAll()
        {
            var data = factory.CategoryData().GetAll; // Get all data form factory class
            var mapper = MapperConfig.GetMapper(); // Get mapper instance from MapperConfig class
            var dtoData = mapper.Map<List<CategoryDTO>>(data); // Map data to DTOs
            return dtoData;
        }
        public CategoryDTO? GetById(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO?>(factory.CategoryData().GetById(id)); // Shortcut
        }
        public bool Create(CategoryDTO catDto)
        {
            var cat = MapperConfig.GetMapper().Map<Category>(catDto);
            return factory.CategoryData().Create(cat);
        }
        public bool Update(CategoryDTO catDto)
        {
            var cat = MapperConfig.GetMapper().Map<Category>(catDto);
            return factory.CategoryData().Update(cat);
        }
        public bool Delete(int id)
        {
            return factory.CategoryData().Delete(id);
        }
    }
}
