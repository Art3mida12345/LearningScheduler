using System;

namespace DistanceLearning.DAL.Entities
{
    public class StudentScheduleRequest
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public Student Student { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}