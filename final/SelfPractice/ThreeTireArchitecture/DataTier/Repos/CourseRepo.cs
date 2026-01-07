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
    public class CourseRepo : IRepository<Course>
    {
        UMSContext db;
        public CourseRepo(UMSContext db)
        {
            this.db = db;
        }
        public bool Create(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Courses.Find(id);
            db.Courses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Course obj)
        {
            var ex = db.Courses.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
