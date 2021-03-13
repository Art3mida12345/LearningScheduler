using System;
using System.Collections.Generic;
using System.Linq;
using DistanceLearning.BL.Interfaces;
using DistanceLearning.DAL.Entities;

namespace DistanceLearning.BL.Services
{
    public class Scheduler
    {
        private readonly IAvailabilityService _availabilityService;

        public Scheduler(IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        public List<Lesson> GetSchedule(long lecturerId)
        {
            // Step 1. Sorting lecturer courses by learning days per week
            var lecturerCourses =
                LecturerScheduler._courses
                    // Select lecturer course
                    .Where(c => c.TeacherId == lecturerId)
                    // Select courses that currently available
                    .Where(c => c.StartDate.Date <= DateTime.UtcNow.Date && c.EndDate.Date >= DateTime.UtcNow.Date)
                    .OrderByDescending(c =>
                    {
                        var remainder = c.TotalLessonsQuantity - c.LessonQuantityPerWeek;

                        return remainder > c.LessonQuantityPerWeek ? c.LessonQuantityPerWeek : remainder;
                    })
                    .ToList();

            if (lecturerCourses.Count < 0)
            {
                return new List<Lesson>();
            }

            var lecturerSlots = _availabilityService.GetSlots(lecturerId);

            // Step 2. Create schedule
            foreach (var course in lecturerCourses)
            {
                for (int i = 0; i < course.LessonQuantityPerWeek; i++)
                {
                    if (lecturerSlots.Count < course.LessonQuantityPerWeek)
                    {
                        throw new Exception("Defined availability slots are invalid, add more time or work day");
                    }

                    //lecturerSlots[i]--;

                    //if (lecturerSlots[i] == 0)
                    {
                        lecturerSlots.RemoveAt(i);
                    }
                }
            }

            return new List<Lesson>();
        }
    }
}