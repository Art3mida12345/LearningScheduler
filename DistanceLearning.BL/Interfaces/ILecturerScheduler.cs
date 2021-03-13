using System.Collections.Generic;
using DistanceLearning.DAL.Entities;

namespace DistanceLearning.BL.Interfaces
{
    public interface ILecturerScheduler
    {
        public void ValidateAvailabilityForWeek(List<TeacherScheduleRequest> availabilitySlots);
    }
}