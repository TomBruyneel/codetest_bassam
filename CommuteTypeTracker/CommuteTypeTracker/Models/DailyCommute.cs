namespace CommuteTypeTracker.Model
{
    public class DailyCommute
    {
        public int Id { get; set; }
        public DateTime DateOfCmmute { get; set; }
        public DateTime CreatdAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CommuteType CommuteType { get; set; }
    }
}
