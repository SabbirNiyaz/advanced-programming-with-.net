using AutoMapper;
using DataTier.EF.Models;
using DataTier.Repos;
using LogicTier.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.Services
{
    public class CourseService
    {

        CourseRepo repo;
        public CourseService(CourseRepo repo)
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
        public List<CourseDTO> GetAll()
        {
            List<Course> data = repo.GetAll();
            var ret = GetMapper().Map<List<CourseDTO>>(data);
            return ret;
        }
        public CourseDTO GetById(int id)
        {
            var data = repo.GetById(id);
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
