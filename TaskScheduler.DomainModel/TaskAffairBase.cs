using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public abstract class TaskAffairBase : IDisposable
    {
        protected static ILog log;
        public CancellationTokenSource CancellationSource { get; set; }

        private DateTime _timeOfSending;
        
        public TaskAffairBase()
        {
            CancellationSource = new CancellationTokenSource();
            CancelToken = CancellationSource.Token;
        }

        protected TimeSpan TimeSpanUntilNow { get; set; }
        protected TimeSpan TimeOut
        {
            get
            {
                return TimeSpan.FromTicks(this.TaskTemplate.Interval);
            }
        }

        public DateTime RealStartAt
        {
            get;set;
        }

        public DateTime RealEndAt
        {
            get; set;
        }
        public virtual void ExecuteTaskBody()
        {
            while (true)
            {
                if (RealStartAt.Year == DateTime.Now.Year &&
                    RealStartAt.Month == DateTime.Now.Month &&
                    RealStartAt.Day == DateTime.Now.Day &&
                    RealStartAt.Hour == DateTime.Now.Hour &&
                    RealStartAt.Minute == DateTime.Now.Minute)
                {
                    RealStartAt += TimeOut;
                    log.Info(string.Format("Task execution with id of:{0}", Task.Id));
                    OnExecuting(this.CancelToken);
                    Thread.Sleep(TimeOut - TimeSpan.FromSeconds(2));
                }

                if (RealEndAt.Year == DateTime.Now.Year &&
                    RealEndAt.Month == DateTime.Now.Month &&
                    RealEndAt.Day == DateTime.Now.Day &&
                    RealEndAt.Hour == DateTime.Now.Hour &&
                    RealEndAt.Minute == DateTime.Now.Minute)
                {
                    CancelTask();
                }

            }
        }

        public CancellationToken CancelToken { get; set; }

        public TaskTemplate TaskTemplate { get; set; }

        public Task Task { get; set; }
        protected void CancelTask()
        {
            CancellationSource.Cancel();
            //TODO:Write some code to update underlying DB table.
            this.Dispose();
        }

        protected abstract void DoTask();
        protected virtual void OnExecuting(CancellationToken cancelToken)
        {
            if (cancelToken.IsCancellationRequested)
            {
                Task.Wait();
                Task.Dispose();
                log.Info(string.Format("Execution thread has been disposed:{0}", Task.Id));
                //TODO:Write some code to update underlying DB table.
            }
            else
            {
                DoTask();
            }
        }

        public void Dispose()
        {
        }
    }
}
