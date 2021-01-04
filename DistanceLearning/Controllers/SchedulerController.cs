using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DistanceLearning.WEB.Controllers
{
    public class Settings
    {
        public int SessionDuration { get; set; }

        public const int WorkingHoursPerWeek = 40;

        public const int StartDayHours = 6;

        public const int EndDateHours = 22;
    }

    public class Course
    {
        public long CourseId { get; set; }

        public int LessonQuantityPerWeek { get; set; }

        public int TotalLessonsQuantity { get; set; }

        public long LecturerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    public class Lesson
    {
        public long CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime StartTime { get; set; }
    }

    public class AvailabilitySlot
    {
        public long UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }

    public class LecturerScheduler
    {
        private readonly Settings _settings = new Settings();

        private readonly List<Course> _courses = new List<Course>
        {
            new Course {CourseId = 1, LessonQuantityPerWeek = 2, TotalLessonsQuantity = 12}
        };


        public bool IsAvailabilityValid(List<AvailabilitySlot> availabilitySlots, long lecturerId)
        {
            // Step 1. Sorting lecturer courses by learning days per week
            var lecturerCourses = 
                _courses
                    // Select lecturer course
                    .Where(c => c.LecturerId == lecturerId)

                    // Select courses that currently available
                    .Where(c => c.StartDate.Date >= DateTime.UtcNow.Date && c.EndDate.Date <= DateTime.UtcNow.Date)
                    .OrderByDescending(c =>
                    {
                        var remainder = c.TotalLessonsQuantity - c.LessonQuantityPerWeek;

                        return remainder > c.LessonQuantityPerWeek ? c.LessonQuantityPerWeek : remainder;
                    })
                    .ToList();

            if (lecturerCourses.Count < 0)
            {
                return true;
            }

            // Step 2. Validate days count
            var daysCount = availabilitySlots.Select(s => s.StartTime.DayOfWeek).Distinct().Count();

            if (daysCount < lecturerCourses[0].LessonQuantityPerWeek)
            {
                throw new Exception($"The count of selected days should be more than {lecturerCourses[0].LessonQuantityPerWeek}");
            }

            // Step 3. Validate possibility to create schedule
            var slots = availabilitySlots.Select(slot => Enumerable.Repeat(
                new { IsAvailable = true, DayOfWeek = slot.StartTime.DayOfWeek}, )
);

            foreach (var course in lecturerCourses)
            {
                foreach (var slot in slots)
                {
                    
                }
            }
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class SchedulerController : ControllerBase
    {
        public SchedulerController()
        {
        }

        [HttpGet]
        public void Get()
        {
            return ;
        }
    }
}
