using System;

namespace DistanceLearning.DAL.Entities
{
    public class Lesson
    {
        public long Id { get; set; }

        public long CourseId { get; set; }

        public string Theme { get; set; }

        public string HomeworkLink { get; set; }

        public Course Course { get; set; }

        public DateTime? StartTime { get; set; }

        public string LessonLink { get; set; }
    }
}