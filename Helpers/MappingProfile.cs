using AutoMapper;
using ELearn.Courses.Service.Dtos;
using ELearn.Courses.Service.Model;

namespace ELearn.Courses.Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<CourseCreateDto, Course>();
        }
    }
}
