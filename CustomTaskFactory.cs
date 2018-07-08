using log4net;
using System;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class CustomTaskFactory
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(CustomTaskFactory));
       
        public static Tuple<TaskModel,Task> BuildTask(TaskType taskType , TaskTemplate taskTemplate)
        {
            Task task = null;
            TaskAffairBase taskAffairBase = null;

            switch (taskType)
            {
                case TaskType.BirthDateSMSSending:
                    break;
                
                case TaskType.UserNotifyDispatch:
                    taskAffairBase = new UserNotifyDispatchAffair()
                    {
                        TaskTemplate = taskTemplate,
                        RealStartAt = GetRealTime(taskTemplate.DoStartAt.Value),
                        RealEndAt = GetRealTime(taskTemplate.DoEndAt.Value)
                    };
                    break;
            }
            task = new Task(() => {
                taskAffairBase.ExecuteTaskBody();
            }, taskAffairBase.CancelToken);

            taskAffairBase.Task = task;

            return Tuple.Create(new TaskModel() { TaskId = task.Id, CancellationTokenSource = taskAffairBase.CancellationSource }, task);
        }

        private static DateTime GetRealTime(DateTime startOrEndat)
        {
            var realTime = new DateTime(
                   startOrEndat.Year,
                   startOrEndat.Month,
                   startOrEndat.Day,
                   startOrEndat.Hour,
                   startOrEndat.Minute, 0);
            return realTime;
        }
    }
}
