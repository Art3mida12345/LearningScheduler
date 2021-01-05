using System;
using System.Collections.Generic;
using System.Linq;
using DistanceLearning.DAL.Entities;

namespace DistanceLearning.BL.Services
{
    public class LecturerScheduler
    {
        private readonly Settings _settings = new Settings();

        private readonly List<Course> _courses = new List<Course>
        {
            new Course
            {
                CourseId = 1,
                LessonQuantityPerWeek = 2,
                TotalLessonsQuantity = 12,
                LecturerId = 1,
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow.AddYears(1)
            },
            new Course
            {
                CourseId = 2,
                LessonQuantityPerWeek = 2,
                TotalLessonsQuantity = 12,
                LecturerId = 1,
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow.AddYears(1)
            },
        };

        public void ValidateAvailability(List<AvailabilitySlot> availabilitySlots, long lecturerId)
        {
            // Step 1. Sorting lecturer courses by learning days per week
            var lecturerCourses =
                _courses
                    // Select lecturer course
                    .Where(c => c.LecturerId == lecturerId)

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
                return;
            }

            // Step 2. Validate days count
            var daysCount = availabilitySlots.Select(s => s.StartTime.DayOfWeek).Distinct().Count();
            var courseNeededDaysCount = lecturerCourses.Max(course => course.LessonQuantityPerWeek);

            if (daysCount < courseNeededDaysCount)
            {
                throw new Exception($"The count of selected days should be more than {courseNeededDaysCount}");
            }

            // Step 3. Validate slots count

            var slots = availabilitySlots.Select(slot =>
            {
                var slotsTotalMinutes = (int)(slot.EndTime - slot.StartTime).TotalMinutes;
                var slotsCount = slotsTotalMinutes / _settings.SessionDuration;

                return new
                {
                    DayOfWeek = (int)slot.StartTime.DayOfWeek,
                    Count = (slotsTotalMinutes - _settings.SessionBreak * (slotsCount - 1)) / _settings.SessionDuration
                };
            })
                .GroupBy(s => s.DayOfWeek)
                .Select(slot =>
                {
                    return slot.Sum(s => s.Count);
                })
                .ToList();

            var courseSlots = lecturerCourses.Sum(course => course.LessonQuantityPerWeek);

            if (slots.Sum() < courseSlots)
            {
                throw new Exception($"The count of selected available lessons slots should be more than {courseSlots} with duration {_settings.SessionDuration} and break {_settings.SessionBreak}");
            }

            // Step 4. Validate possibility to create schedule
            foreach (var course in lecturerCourses)
            {
                for (int i = 0; i < course.LessonQuantityPerWeek; i++)
                {
                    if (slots.Count < course.LessonQuantityPerWeek)
                    {
                        throw new Exception("Defined availability slots are invalid, add more time or work day");
                    }

                    slots[i]--;

                    if (slots[i] == 0)
                    {
                        slots.RemoveAt(i);
                    }
                }
            }
        }
    }
}