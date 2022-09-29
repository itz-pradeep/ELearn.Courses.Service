using ELearn.Courses.Service.DataAccess;
using ELearn.Courses.Service.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELearn.Courses.Service.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ICourseContext _courseContext;

        public CourseRepository(ICourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public async Task CreateAsync(Course entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(Course));

            await _courseContext.Courses.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courseContext.Courses.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<Course> GetAsync(Guid id)
        {
            return await _courseContext.Courses.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Course>> GetAsync()
        {
            return await _courseContext.Courses.Find(_ => true).ToListAsync();
        }


    }
}
