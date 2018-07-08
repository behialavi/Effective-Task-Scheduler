using log4net;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AZW.TaskScheduler
{
    public class CustomTaskScheduler
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(CustomTaskScheduler));
        private static readonly ConcurrentDictionary<int, Tuple<TaskModel, Task>> tasksCollection =
            new ConcurrentDictionary<int, Tuple<TaskModel, Task>>();


        public static void RunTask(TaskTemplate taskTemplate)
        {
            if (!tasksCollection.ContainsKey(taskTemplate.TaskId))
            {
                log.Info("Inside RunTask....");
                var tuple = CustomTaskFactory.BuildTask(taskTemplate.TaskType, taskTemplate);
                tasksCollection.TryAdd(taskTemplate.TaskId, tuple);
                tuple.Item2.Start();
                TaskScheduler.DAO.TaskSchedulerDAO.UpdateLastStartDate(new TaskRunTimeModel() { TaskId = taskTemplate.TaskId, LastStartDate = DateTime.Now });
            }
        }

        public static void CancelTask(TaskTemplate taskTemplate)
        {
            if (tasksCollection.ContainsKey(taskTemplate.TaskId))
            {
                Tuple<TaskModel, Task> tupleValue = null;
                if(tasksCollection.TryRemove(taskTemplate.TaskId, out tupleValue))
                {
                    TaskScheduler.DAO.TaskSchedulerDAO.UpdateLastStopDate(new TaskRunTimeModel() { TaskId = taskTemplate.TaskId, LastStopDate = DateTime.Now });
                    tupleValue.Item1.CancellationTokenSource.Cancel();
                    tupleValue.Item1.CancellationTokenSource.Dispose();
                }
            }
        }

        public static bool CheckIfTasksAlreadyRunning(int taskId)
        {
            return tasksCollection.ContainsKey(taskId);
        }

    }
}
