using System;

namespace ELearn.Courses.Service.Model
{
    public class Course : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string Technology { get; set; }
        public string LaunchUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
