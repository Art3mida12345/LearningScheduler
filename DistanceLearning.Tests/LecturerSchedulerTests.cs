using System;
using System.Collections.Generic;
using DistanceLearning.BL.Interfaces;
using DistanceLearning.BL.Services;
using DistanceLearning.DAL.Entities;
using NUnit.Framework;

namespace DistanceLearning.Tests
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

    public class Tests
    {
        private ILecturerScheduler _lecturerScheduler;
        private readonly Settings _settings = new Settings();
        private DateTime _monday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        private readonly DateTime _tuesday = DateTime.Now.StartOfWeek(DayOfWeek.Tuesday);
        private readonly DateTime _wednesday = DateTime.Now.StartOfWeek(DayOfWeek.Wednesday);
        private readonly DateTime _thursday = DateTime.Now.StartOfWeek(DayOfWeek.Thursday);
        private readonly DateTime _friday = DateTime.Now.StartOfWeek(DayOfWeek.Friday);

        [SetUp]
        public void Setup()
        {
            _lecturerScheduler = new LecturerScheduler();
        }

        [Test]
        public void Test1()
        {
            _lecturerScheduler.ValidateAvailabilityForWeek(
                new List<TeacherScheduleRequest>
                {
                    new TeacherScheduleRequest
                    {
                        TeacherId = 1,
                        StartTime = _tuesday,
                        EndTime = _tuesday.AddMinutes(_settings.SessionDuration)
                    },
                    new TeacherScheduleRequest
                    {
                        TeacherId = 1,
                        StartTime = _wednesday,
                        EndTime = _wednesday.AddMinutes(_settings.SessionDuration * 4 + _settings.SessionBreak * 3)
                    },
                    new TeacherScheduleRequest
                    {
                        TeacherId = 1,
                        StartTime = _thursday,
                        EndTime = _thursday.AddMinutes(_settings.SessionDuration * 5 + _settings.SessionBreak * 4)
                    },
                    new TeacherScheduleRequest
                    {
                        TeacherId = 1,
                        StartTime = _friday,
                        EndTime = _friday.AddMinutes(_settings.SessionDuration * 6 + _settings.SessionBreak * 5)
                    }
                });
        }
    }
}