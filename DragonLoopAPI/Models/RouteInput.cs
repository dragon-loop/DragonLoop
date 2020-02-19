namespace DragonLoopAPI.Models
{
    public class ScheduleInput
    {
        public string StopName { get; set; }
        public string ExpectedTime { get; set; }
    }


    public class RouteInput
    {
        public ScheduleInput[] Schedules { get; set; }
        public int RouteId;
    }
}
