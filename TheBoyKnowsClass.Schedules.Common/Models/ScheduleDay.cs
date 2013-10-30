using System;
using System.Collections.Generic;

namespace TheBoyKnowsClass.Schedules.Common.Models
{
    public class ScheduleDay
    {
        public ScheduleDay()
        {
            Schedule = new Dictionary<TimeSpan, bool>();

            for (int i=0; i < 24; i++ )
            {
                Schedule.Add(new TimeSpan(i, 0, 0), true); 
            }     
        }

        public DayOfWeek DayOfWeek { get; set; }

        public Dictionary<TimeSpan, bool> Schedule { get; set; }

        public bool GetActivityStatus(int i)
        {
            return Schedule[new TimeSpan(i, 0, 0)];
        }

        public void SetActivityStatus(int i, bool value)
        {
            Schedule[new TimeSpan(i, 0, 0)] = value;
        }

        public bool IsActive(TimeSpan timeSpan)
        {
            int hours = timeSpan.Hours;

            return GetActivityStatus(hours);
        }
    }
}
