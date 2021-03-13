using System.Collections.Generic;
using DistanceLearning.DAL.Enums;

namespace DistanceLearning.DAL.Entities
{
    public class Teacher
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Bio { get; set; }

        public short Rating { get; set; }

        public bool IsPmPreferred { get; set; }

        public List<Course> Courses { get; set; }

        public List<TeacherScheduleRequest> TeacherScheduleRequests { get; set; }
    }
}