using DataTier.EF;
using DataTier.EF.Models;
using DataTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repos
{
    internal class CategoryRepoV2 : IRepository<Category>
    {
        // Receive DbContext by use Constructor via Dependency Injection
        DatabaseRepresentContext db;
        public CategoryRepoV2(DatabaseRepresentContext db)
        {
            this.db = db;
        }
        // CRUD Operations
        public bool Create(Category cat)
        {
            db.Categories.Add(cat);
            return db.SaveChanges() > 0;
        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category? GetById(int id)
        {
            return db.Categories.Find(id);
        }
        public bool Update(Category cat)
        {
            var ex = GetById(cat.Id);
            db.Entry(ex).CurrentValues.SetValues(cat);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = GetById(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public bool FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
