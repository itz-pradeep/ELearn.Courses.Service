using ELearn.Courses.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELearn.Courses.Service.Repository
{
    public interface ICourseRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<IReadOnlyList<Course>> GetAsync();
        Task CreateAsync(Course entity);
        Task DeleteAsync(Guid id);
    }
}
