using System;

namespace DistanceLearning.DAL.Entities
{
    public class AvailabilitySlot
    {
        public long UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}