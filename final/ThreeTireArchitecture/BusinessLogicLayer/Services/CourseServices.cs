using AutoMapper;
using BusinessLogicLayer.DTOs;
using DatabaseAccessLayer.EF.Models;
using DatabaseAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CourseServices
    {
        CourseRepo repo;
        public CourseServices(CourseRepo repo)
        {
            this.repo = repo;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public List<CourseDTO> Get()
        {
            List<Course> data = repo.Get();
            var ret = GetMapper().Map<List<CourseDTO>>(data);
            return ret;
        }
        public CourseDTO Get(int id)
        {
            var data = repo.Get(id);
            var ret = GetMapper().Map<CourseDTO>(data);
            return ret;
        }
        public bool Create(CourseDTO student)
        {
            Course s = GetMapper().Map<Course>(student);
            return repo.Create(s);
        }

        public bool Update(CourseDTO d)
        {
            var mappeed = GetMapper().Map<Course>(d);
            return repo.Update(mappeed);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
