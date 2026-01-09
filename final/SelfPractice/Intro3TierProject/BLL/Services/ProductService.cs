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
    public class ProductService
    {
        DataAccessFactory factory;
        public ProductService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        // Return to DataAccessFactory (Repo)
        public bool Create(ProductDTO pDto)
        {
            var entity = MapperConfig.GetMapper().Map<Product>(pDto);
            return factory.ProductData().Create(entity);
        }
        public bool Update(ProductDTO pDto)
        {
            var entity = MapperConfig.GetMapper().Map<Product>(pDto);
            return factory.ProductData().Update(entity);
        }
        public bool Delete(int id)
        {
            return factory.ProductData().Delete(id);
        }

        // Return to Controller
        public List<ProductDTO> GetAll()
        {
            return MapperConfig.GetMapper().Map<List<ProductDTO>>(factory.ProductData().GetAll());
        }
        public ProductDTO? GetById(int id)
        {
            return MapperConfig.GetMapper().Map<ProductDTO?>(factory.ProductData().GetById(id));
        }
    }
}
