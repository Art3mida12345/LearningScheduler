using System;

namespace DistanceLearning.DAL.Entities
{
    public class Course
    {
        public long CourseId { get; set; }

        public int LessonQuantityPerWeek { get; set; }

        public int TotalLessonsQuantity { get; set; }

        public long LecturerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}