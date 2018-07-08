using Framework;
using Framework.DomainModel;
using System;
using System.Runtime.Serialization;
using TaskScheduler.Globalization;

namespace TaskScheduler
{
    [DataContract]
    public class TaskTemplate  :EntityBase
    {
        [LocalizationDisplayName("TaskId", typeof(Texts))]
        [DataMember]
        public int TaskId { get; set; }

        [LocalizationDisplayName("TaskType", typeof(Texts))]
        [DataMember]
        public TaskType TaskType { get; set; }

        [LocalizationDisplayName("LastStartDate", typeof(Texts))]
        [DataMember]
        public DateTime? LastStartDate { get; set; }

        [LocalizationDisplayName("LastStopDate", typeof(Texts))]
        [DataMember]
        public DateTime? LastStopDate { get; set; }

        [LocalizationDisplayName("AlreadyRunning", typeof(Texts))]
        [DataMember]
        public bool AlreadyRunning { get; set; }

        [LocalizationDisplayName("DoStartAt", typeof(Texts))]
        [DataMember]
        public DateTime? DoStartAt { get; set; }

        [LocalizationDisplayName("DoEndAt", typeof(Texts))]
        [DataMember]
        public DateTime? DoEndAt { get; set; }

        [LocalizationDisplayName("Interval", typeof(Texts))]
        [DataMember]
        public long Interval { get; set; }


        public IntervalType IntervalType { get; set; }

        Action<TaskTemplate> OnJobExecutionCallback;

        Action<TaskTemplate> OnJobCancelCallback;

        public string ConnectionString { get; set; }

    }
}
