using AZW.TaskScheduler.Globalization;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler
{
    public enum IntervalType:short 
    {
        [Display(Name = "EveryMinute", ResourceType = typeof(Texts))]
        EveryMinute = 1,
        [Display(Name = "Hourly", ResourceType = typeof(Texts))]
        Hourly = 2 ,
        [Display(Name = "Daily", ResourceType = typeof(Texts))]
        Daily =3 ,
        [Display(Name = "Weekly", ResourceType = typeof(Texts))]
        Weekly = 4 ,
        [Display(Name = "Monthly", ResourceType = typeof(Texts))]
        Monthly = 5

    }

    public class IntervalTypePair
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}