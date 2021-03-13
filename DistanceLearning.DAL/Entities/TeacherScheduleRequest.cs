using System;

namespace DistanceLearning.DAL.Entities
{
    public class TeacherScheduleRequest
    {
        public long Id { get; set; }

        public long TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}