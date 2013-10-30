using System;
using System.Collections.Generic;

namespace TheBoyKnowsClass.Schedules.Common.Models
{
    public class Schedule
    {
        public Schedule()
        {
            ScheduleDays = new Dictionary<DayOfWeek, ScheduleDay>();

            for (int i = 0; i < 7; i++)
            {
                ScheduleDays.Add((DayOfWeek)i ,new ScheduleDay() {DayOfWeek = (DayOfWeek)i});
            }
        }

        public Dictionary<DayOfWeek,ScheduleDay> ScheduleDays { get; set; }

        public bool IsCurrentlyActive()
        {
            DateTime now = DateTime.Now;
            DayOfWeek dayOfWeek = now.DayOfWeek;
            int hours = now.TimeOfDay.Hours;

            return ScheduleDays[dayOfWeek].GetActivityStatus(hours);
        }

        public TimeSpan GetNextStart()
        {
            DateTime now = DateTime.Now;
            DayOfWeek dayOfWeek = now.DayOfWeek;
            int hours = now.TimeOfDay.Hours;

            if(ScheduleDays[dayOfWeek].GetActivityStatus(hours))
            {
                return new TimeSpan(0);
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = hours; j < 24; j++)
                {
                    if (ScheduleDays[now.AddDays(i).DayOfWeek].GetActivityStatus(i))
                    {
                        return new TimeSpan(j, i, 0, 0).Subtract(DateTime.Now.TimeOfDay);
                    }
                }
                hours = 0;
            }

            throw new Exception("error no next active times found");
        }

    }
}
