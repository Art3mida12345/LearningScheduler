using System;
using System.Collections.Generic;
using DistanceLearning.BL.Interfaces;
using DistanceLearning.DAL.Entities;

namespace DistanceLearning.BL.Services
{
    public class AvailabilityService: IAvailabilityService
    {
        public List<TeacherScheduleRequest> GetSlots(long personId)
        {
            var slots = new List<TeacherScheduleRequest>
            {
                new TeacherScheduleRequest
                {
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddDays(1),
                    TeacherId = 1
                },
                new TeacherScheduleRequest
                {
                    StartTime = DateTime.UtcNow.AddDays(2),
                    EndTime = DateTime.UtcNow.AddDays(3),
                    TeacherId = 1
                },
                new TeacherScheduleRequest
                {
                    StartTime = DateTime.UtcNow.AddDays(4),
                    EndTime = DateTime.UtcNow.AddDays(5),
                    TeacherId = 1
                },
                new TeacherScheduleRequest
                {
                    StartTime = DateTime.UtcNow.AddDays(6),
                    EndTime = DateTime.UtcNow.AddDays(7),
                    TeacherId = 1
                },
            };

            return slots;
        }
    }
}