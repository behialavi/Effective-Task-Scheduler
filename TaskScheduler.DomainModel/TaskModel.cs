
using System.Runtime.Serialization;
using System.Threading;

namespace TaskScheduler
{
    [DataContract]
    public class TaskModel 
    {
        public int TaskId { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
    }
}
