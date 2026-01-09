using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        DataAccessFactory factory;
        public CategoryService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        // BLL.Services.CategoryService
        public bool Create(CategoryDTO cDto)
        {
            var entity = MapperConfig.GetMapper().Map<Category>(cDto);
            return factory.CategoryData().Create(entity);
        }
        public bool Update(CategoryDTO cDto)
        {
            var entity = MapperConfig.GetMapper().Map<Category>(cDto);
            return factory.CategoryData().Update(entity);
        }
        public bool Delete(int id)
        {
            return factory.CategoryData().Delete(id);
        }

        // Return to Controller
        public List<CategoryDTO> GetAll() 
        {
            return MapperConfig.GetMapper().Map<List<CategoryDTO>>(factory.CategoryData().GetAll());
        }
        public CategoryDTO? GetById(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO?>(factory.CategoryData().GetById(id));
        }
    }
}
