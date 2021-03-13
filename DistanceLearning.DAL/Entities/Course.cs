using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistanceLearning.DAL.Entities
{
    public class Course
    {
        public long Id { get; set; }

        public int LessonQuantityPerWeek { get; set; }

        public int TotalLessonsQuantity { get; set; }

        public long? TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Theme { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Cost { get; set; }

        public int PersonQuantity { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<Order> Orders { get; set; }
    }
}