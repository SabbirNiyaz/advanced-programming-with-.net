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
    public class ProductService
    {
        Repository<Product> repo;
        public ProductService(Repository<Product> repo)
        {
            this.repo = repo;
        }
        public List<ProductDTO> GetAll()
        {
            var data = repo.GetAll(); // Get all data form repo class
            var mapper = MapperConfig.GetMapper(); // Get mapper instance from MapperConfig class
            var dtoData = mapper.Map<List<ProductDTO>>(data); // Map data to DTOs
            return dtoData;
        }
        public ProductDTO? GetById(int id)
        {
            return MapperConfig.GetMapper().Map<ProductDTO?>(repo.GetById(id)); // Shortcut
        }
        public bool Create(ProductDTO pDto)
        {
            var p = MapperConfig.GetMapper().Map<Product>(pDto);
            return repo.Create(p);
        }
        public bool Update(ProductDTO pDto)
        {
            var p = MapperConfig.GetMapper().Map<Product>(pDto);
            return repo.Update(p);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
