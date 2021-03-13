using System;
using System.Collections.Generic;
using System.Linq;
using DistanceLearning.BL.Interfaces;
using DistanceLearning.DAL.Entities;

namespace DistanceLearning.BL.Services
{
    public class LecturerScheduler : ILecturerScheduler
    {
        public static readonly Settings _settings = new Settings();

        public static readonly List<Course> _courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                LessonQuantityPerWeek = 3,
                TotalLessonsQuantity = 12,
                TeacherId = 1,
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow.AddYears(1)
            },
            new Course
            {
                Id = 2,
                LessonQuantityPerWeek = 4,
                TotalLessonsQuantity = 12,
                TeacherId = 1,
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow.AddYears(1)
            },
        };

        public void ValidateAvailabilityForWeek(List<TeacherScheduleRequest> availabilitySlots)
        {
            if (availabilitySlots.Count == 0)
            {
                return;
            }

            // Step 1. Sorting lecturer courses by learning days per week
            var lecturerCourses =
                _courses
                    // Select lecturer course
                    .Where(c => c.TeacherId == availabilitySlots[0].TeacherId)

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

            var slotsGrouped = availabilitySlots.Select(slot =>
                {
                    var slotsTotalMinutes = (int) (slot.EndTime - slot.StartTime).TotalMinutes;
                    var group = new
                    {
                        DayOfWeek = (int)slot.StartTime.DayOfWeek,
                        Count = (slotsTotalMinutes + _settings.SessionBreak) / (_settings.SessionDuration + _settings.SessionBreak)
                    };

                    return group;
                })
                .GroupBy(s => s.DayOfWeek);

            var slots = slotsGrouped
                .Select(s => s.Sum(count => count.Count))
                .ToList();

            var courseSlots = lecturerCourses.Sum(course => course.LessonQuantityPerWeek);

            if (slots.Sum() < courseSlots)
            {
                throw new Exception($"The count of selected available lessons slots should be more than {courseSlots} with duration {_settings.SessionDuration} and break {_settings.SessionBreak}");
            }

            // Step 4. Validate possibility to create schedule by days
            foreach (var course in lecturerCourses)
            {
                // Sorting descending
                slots.Sort((a, b) => b.CompareTo(a));
                var courseBookedDays = 0;

                for (var dayIndex = 0; dayIndex < slots.Count && courseBookedDays < course.LessonQuantityPerWeek; dayIndex++)
                {
                    if (slots.Count < course.LessonQuantityPerWeek)
                    {
                        throw new Exception("Defined availability slots are invalid, add more time or work day");
                    }

                    slots[dayIndex]--;
                    courseBookedDays++;

                    if (slots[dayIndex] == 0)
                    {
                        slots.RemoveAt(dayIndex);
                        dayIndex--;
                    }
                }
            }
        }
    }
}