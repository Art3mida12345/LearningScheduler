using System.Collections.Generic;
using DistanceLearning.DAL.Entities;

namespace DistanceLearning.BL.Interfaces
{
    public interface IAvailabilityService
    {
        public List<TeacherScheduleRequest> GetSlots(long personId);
    }
}