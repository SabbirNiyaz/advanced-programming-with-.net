using DataTier.EF;
using DataTier.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repos
{
    // Each RepoClass handle only one Entity/Table
    public class CategoryRepo
    {
        // Receive DbContext by use Constructor via Dependency Injection
        DatabaseRepresentContext db;
        public CategoryRepo(DatabaseRepresentContext db)
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
    }
}
