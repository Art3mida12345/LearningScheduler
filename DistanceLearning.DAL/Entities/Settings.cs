namespace DistanceLearning.DAL.Entities
{
    public class Settings
    {
        public int SessionDuration { get; set; } = 45;

        public int SessionBreak { get; set; } = 15;

        public int WorkingHoursPerWeek = 40;

        public int StartDayHours = 6;

        public int EndDateHours = 22;
    }
}