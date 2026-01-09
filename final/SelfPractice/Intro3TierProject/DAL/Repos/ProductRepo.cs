using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo : IRepository<Product>
    {
        // Use Database Represent Class (PMContext) via Constructor
        PMContext db;
        public ProductRepo(PMContext db)
        {
            this.db = db;
        }

        // CRUD Opertation
        public bool Create(Product entity)
        {
            db.Products.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Product entity)
        {
            var ex = db.Products.Find(entity.Id);
            db.Entry(ex).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = db.Products.Find(id);
            return db.SaveChanges() > 0;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return db.Products.Find(id);
        }
    }
}
