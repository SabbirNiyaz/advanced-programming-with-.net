using DataTier.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repos
{
    public class Repository <T> where T : class
    {
        DbSet<T> table; // Pass dymamic DbSet
        DatabaseRepresentContext db;
        public Repository(DatabaseRepresentContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public List<T> GetAll()
        {
            return table.ToList();
        }
        public T? GetById(int id)
        {
            return table.Find(id);
        }
        public bool Create(T obj)
        {
            table.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool Update(T obj)
        {
            db.Set<T>().Update(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = GetById(id);
            table.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
