using System;
using System.Collections.Generic;
using DistanceLearning.DAL.Enums;

namespace DistanceLearning.DAL.Entities
{
    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime AccountCreatedDate { get; set; }

        public bool IsPmPreferred { get; set; }

        public List<Order> Orders { get; set; }

        public List<StudentScheduleRequest> StudentScheduleRequests { get; set; }
    }
}