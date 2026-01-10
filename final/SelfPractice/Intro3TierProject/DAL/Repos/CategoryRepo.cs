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
    public class CategoryRepo : IRepository<Category>
    {
        // Use Database Represent Class (PMContext) via Constructor
        PMContext db;
        public CategoryRepo(PMContext db)
        {
            this.db = db;
        }

        // CRUD Opertation
        public bool Create(Category entity)
        {
            db.Categories.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Category entity)
        {
            var ex = GetById(entity.Id);
            if (ex == null) return false;
            db.Entry(ex).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = GetById(id);
            if (ex == null) return false;
            db.Categories.Remove(ex);
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
    }
}
