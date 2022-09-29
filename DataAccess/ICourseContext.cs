using ELearn.Courses.Service.Model;
using MongoDB.Driver;

namespace ELearn.Courses.Service.DataAccess
{
    public interface ICourseContext
    {
        IMongoCollection<Course> Courses { get; }
    }
}
