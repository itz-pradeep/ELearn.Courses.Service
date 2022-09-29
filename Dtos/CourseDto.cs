using System;

namespace ELearn.Courses.Service.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string Technology { get; set; }
        public string LaunchUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
