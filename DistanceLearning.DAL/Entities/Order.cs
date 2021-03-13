using System.ComponentModel.DataAnnotations.Schema;
using DistanceLearning.DAL.Enums;

namespace DistanceLearning.DAL.Entities
{
    public class Order
    {
        public long StudentId { get; set; }

        public Student Student { get; set; }

        public long CourseId { get; set; }

        public Course Course { get; set; }

        public PayStatus PayStatus { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Cost { get; set; }
    }
}