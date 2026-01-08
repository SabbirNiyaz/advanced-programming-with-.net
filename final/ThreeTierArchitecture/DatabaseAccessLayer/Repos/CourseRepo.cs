using DatabaseAccessLayer.EF;
using DatabaseAccessLayer.EF.Models;
using DatabaseAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repos
{
    public class CourseRepo : IRepository<Course>
    {
        UMSContext db;
        public CourseRepo(UMSContext db)
        {
            this.db = db;
        }

        public bool Create(Course s)
        {
            db.Courses.Add(s);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Courses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();

        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Course obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
