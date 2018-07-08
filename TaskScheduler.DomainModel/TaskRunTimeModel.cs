using System;


namespace TaskScheduler
{
   
    public struct TaskRunTimeModel
    {
        public int TaskId { get; set; }
        public DateTime? LastStartDate { get; set; }
        public DateTime? LastStopDate { get; set; }
    }
}
