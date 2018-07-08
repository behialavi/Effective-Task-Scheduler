
using TaskScheduler.Globalization;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler
{
    public enum TaskType : short
    {
        [Display(Name = "BirthDateSMSSending", ResourceType = typeof(Texts))]
        BirthDateSMSSending = 1 ,

        [Display(Name = "UserNotifyDispatch", ResourceType = typeof(Texts))]
        UserNotifyDispatch =2 ,

        [Display(Name = "DailyBackup", ResourceType = typeof(Texts))]
        DailyBackup = 3 

    }

    [Serializable]
    public class TaskTypePair  
    {
        public int Key { get; set; }

        public string Value { get; set; }
    }

}
