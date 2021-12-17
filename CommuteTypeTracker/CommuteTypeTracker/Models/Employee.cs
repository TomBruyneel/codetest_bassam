using System.ComponentModel.DataAnnotations;

namespace CommuteTypeTracker.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }
        public CommuteType DefaultCommuteType { get; set; }
        public List<DailyCommute> dailyCommutes { get; set; }
    }
}
