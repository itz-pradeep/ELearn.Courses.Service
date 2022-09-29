using ELearn.Courses.Service.Model;
using ELearn.Courses.Service.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ELearn.Courses.Service.DataAccess
{
    public class CourseContext : ICourseContext
    {
        private readonly IMongoDatabase _db;
        public CourseContext(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Course> Courses => _db.GetCollection<Course>("Courses");
    }
}
