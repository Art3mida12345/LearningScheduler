using System;

namespace DistanceLearning.DAL.Entities
{
    public class Lesson
    {
        public long CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime StartTime { get; set; }
    }
}