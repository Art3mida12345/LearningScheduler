using DistanceLearning.DAL.Enums;

namespace DistanceLearning.DAL.Entities
{
    public class Admin
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long? CreatedByPersonId { get; set; }

        public Admin CreatedByPerson { get; set; }
    }
}