using DataTier.EF;
using DataTier.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repos
{
    public class ProductRepo
    {
        // Receive DbContext by use Constructor via Dependency Injection
        DatabaseRepresentContext db;
        public ProductRepo(DatabaseRepresentContext db)
        {
            this.db = db;
        }
        // CRUD Operations
        public bool Create(Product p)
        {
            db.Products.Add(p);
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
        public bool Update(Product p)
        {
            var ex = GetById(p.Id);
            db.Entry(ex).CurrentValues.SetValues(p);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = GetById(id);
            db.Products.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }

}
