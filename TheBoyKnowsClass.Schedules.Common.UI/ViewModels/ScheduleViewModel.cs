using System;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.Schedules.Common.Models;

namespace TheBoyKnowsClass.Schedules.Common.UI.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private Schedule _schedule;

        public ScheduleViewModel()
        {
            _schedule = new Schedule();
            Refresh();
        }

        public ScheduleViewModel(Schedule schedule)
        {
            _schedule = schedule;
            Refresh();
        }

        public Models.Schedule Schedule
        {
            get { return _schedule; }
            set 
            { 
                _schedule = value;
                Refresh();
            }
        }

        private void Refresh()
        {
            RaisePropertyChanged("IsActiveMonday0");
            RaisePropertyChanged("IsActiveMonday1");
            RaisePropertyChanged("IsActiveMonday2");
            RaisePropertyChanged("IsActiveMonday3");
            RaisePropertyChanged("IsActiveMonday4");
            RaisePropertyChanged("IsActiveMonday5");
            RaisePropertyChanged("IsActiveMonday6");
            RaisePropertyChanged("IsActiveMonday7");
            RaisePropertyChanged("IsActiveMonday8");
            RaisePropertyChanged("IsActiveMonday9");
            RaisePropertyChanged("IsActiveMonday10");
            RaisePropertyChanged("IsActiveMonday11");
            RaisePropertyChanged("IsActiveMonday12");
            RaisePropertyChanged("IsActiveMonday13");
            RaisePropertyChanged("IsActiveMonday14");
            RaisePropertyChanged("IsActiveMonday15");
            RaisePropertyChanged("IsActiveMonday16");
            RaisePropertyChanged("IsActiveMonday17");
            RaisePropertyChanged("IsActiveMonday18");
            RaisePropertyChanged("IsActiveMonday19");
            RaisePropertyChanged("IsActiveMonday20");
            RaisePropertyChanged("IsActiveMonday21");
            RaisePropertyChanged("IsActiveMonday22");
            RaisePropertyChanged("IsActiveMonday23");

            RaisePropertyChanged("IsActiveTuesday0");
            RaisePropertyChanged("IsActiveTuesday1");
            RaisePropertyChanged("IsActiveTuesday2");
            RaisePropertyChanged("IsActiveTuesday3");
            RaisePropertyChanged("IsActiveTuesday4");
            RaisePropertyChanged("IsActiveTuesday5");
            RaisePropertyChanged("IsActiveTuesday6");
            RaisePropertyChanged("IsActiveTuesday7");
            RaisePropertyChanged("IsActiveTuesday8");
            RaisePropertyChanged("IsActiveTuesday9");
            RaisePropertyChanged("IsActiveTuesday10");
            RaisePropertyChanged("IsActiveTuesday11");
            RaisePropertyChanged("IsActiveTuesday12");
            RaisePropertyChanged("IsActiveTuesday13");
            RaisePropertyChanged("IsActiveTuesday14");
            RaisePropertyChanged("IsActiveTuesday15");
            RaisePropertyChanged("IsActiveTuesday16");
            RaisePropertyChanged("IsActiveTuesday17");
            RaisePropertyChanged("IsActiveTuesday18");
            RaisePropertyChanged("IsActiveTuesday19");
            RaisePropertyChanged("IsActiveTuesday20");
            RaisePropertyChanged("IsActiveTuesday21");
            RaisePropertyChanged("IsActiveTuesday22");
            RaisePropertyChanged("IsActiveTuesday23");

            RaisePropertyChanged("IsActiveWednesday0");
            RaisePropertyChanged("IsActiveWednesday1");
            RaisePropertyChanged("IsActiveWednesday2");
            RaisePropertyChanged("IsActiveWednesday3");
            RaisePropertyChanged("IsActiveWednesday4");
            RaisePropertyChanged("IsActiveWednesday5");
            RaisePropertyChanged("IsActiveWednesday6");
            RaisePropertyChanged("IsActiveWednesday7");
            RaisePropertyChanged("IsActiveWednesday8");
            RaisePropertyChanged("IsActiveWednesday9");
            RaisePropertyChanged("IsActiveWednesday10");
            RaisePropertyChanged("IsActiveWednesday11");
            RaisePropertyChanged("IsActiveWednesday12");
            RaisePropertyChanged("IsActiveWednesday13");
            RaisePropertyChanged("IsActiveWednesday14");
            RaisePropertyChanged("IsActiveWednesday15");
            RaisePropertyChanged("IsActiveWednesday16");
            RaisePropertyChanged("IsActiveWednesday17");
            RaisePropertyChanged("IsActiveWednesday18");
            RaisePropertyChanged("IsActiveWednesday19");
            RaisePropertyChanged("IsActiveWednesday20");
            RaisePropertyChanged("IsActiveWednesday21");
            RaisePropertyChanged("IsActiveWednesday22");
            RaisePropertyChanged("IsActiveWednesday23");

            RaisePropertyChanged("IsActiveThursday0");
            RaisePropertyChanged("IsActiveThursday1");
            RaisePropertyChanged("IsActiveThursday2");
            RaisePropertyChanged("IsActiveThursday3");
            RaisePropertyChanged("IsActiveThursday4");
            RaisePropertyChanged("IsActiveThursday5");
            RaisePropertyChanged("IsActiveThursday6");
            RaisePropertyChanged("IsActiveThursday7");
            RaisePropertyChanged("IsActiveThursday8");
            RaisePropertyChanged("IsActiveThursday9");
            RaisePropertyChanged("IsActiveThursday10");
            RaisePropertyChanged("IsActiveThursday11");
            RaisePropertyChanged("IsActiveThursday12");
            RaisePropertyChanged("IsActiveThursday13");
            RaisePropertyChanged("IsActiveThursday14");
            RaisePropertyChanged("IsActiveThursday15");
            RaisePropertyChanged("IsActiveThursday16");
            RaisePropertyChanged("IsActiveThursday17");
            RaisePropertyChanged("IsActiveThursday18");
            RaisePropertyChanged("IsActiveThursday19");
            RaisePropertyChanged("IsActiveThursday20");
            RaisePropertyChanged("IsActiveThursday21");
            RaisePropertyChanged("IsActiveThursday22");
            RaisePropertyChanged("IsActiveThursday23");

            RaisePropertyChanged("IsActiveFriday0");
            RaisePropertyChanged("IsActiveFriday1");
            RaisePropertyChanged("IsActiveFriday2");
            RaisePropertyChanged("IsActiveFriday3");
            RaisePropertyChanged("IsActiveFriday4");
            RaisePropertyChanged("IsActiveFriday5");
            RaisePropertyChanged("IsActiveFriday6");
            RaisePropertyChanged("IsActiveFriday7");
            RaisePropertyChanged("IsActiveFriday8");
            RaisePropertyChanged("IsActiveFriday9");
            RaisePropertyChanged("IsActiveFriday10");
            RaisePropertyChanged("IsActiveFriday11");
            RaisePropertyChanged("IsActiveFriday12");
            RaisePropertyChanged("IsActiveFriday13");
            RaisePropertyChanged("IsActiveFriday14");
            RaisePropertyChanged("IsActiveFriday15");
            RaisePropertyChanged("IsActiveFriday16");
            RaisePropertyChanged("IsActiveFriday17");
            RaisePropertyChanged("IsActiveFriday18");
            RaisePropertyChanged("IsActiveFriday19");
            RaisePropertyChanged("IsActiveFriday20");
            RaisePropertyChanged("IsActiveFriday21");
            RaisePropertyChanged("IsActiveFriday22");
            RaisePropertyChanged("IsActiveFriday23");

            RaisePropertyChanged("IsActiveSaturday0");
            RaisePropertyChanged("IsActiveSaturday1");
            RaisePropertyChanged("IsActiveSaturday2");
            RaisePropertyChanged("IsActiveSaturday3");
            RaisePropertyChanged("IsActiveSaturday4");
            RaisePropertyChanged("IsActiveSaturday5");
            RaisePropertyChanged("IsActiveSaturday6");
            RaisePropertyChanged("IsActiveSaturday7");
            RaisePropertyChanged("IsActiveSaturday8");
            RaisePropertyChanged("IsActiveSaturday9");
            RaisePropertyChanged("IsActiveSaturday10");
            RaisePropertyChanged("IsActiveSaturday11");
            RaisePropertyChanged("IsActiveSaturday12");
            RaisePropertyChanged("IsActiveSaturday13");
            RaisePropertyChanged("IsActiveSaturday14");
            RaisePropertyChanged("IsActiveSaturday15");
            RaisePropertyChanged("IsActiveSaturday16");
            RaisePropertyChanged("IsActiveSaturday17");
            RaisePropertyChanged("IsActiveSaturday18");
            RaisePropertyChanged("IsActiveSaturday19");
            RaisePropertyChanged("IsActiveSaturday20");
            RaisePropertyChanged("IsActiveSaturday21");
            RaisePropertyChanged("IsActiveSaturday22");
            RaisePropertyChanged("IsActiveSaturday23");

            RaisePropertyChanged("IsActiveSunday0");
            RaisePropertyChanged("IsActiveSunday1");
            RaisePropertyChanged("IsActiveSunday2");
            RaisePropertyChanged("IsActiveSunday3");
            RaisePropertyChanged("IsActiveSunday4");
            RaisePropertyChanged("IsActiveSunday5");
            RaisePropertyChanged("IsActiveSunday6");
            RaisePropertyChanged("IsActiveSunday7");
            RaisePropertyChanged("IsActiveSunday8");
            RaisePropertyChanged("IsActiveSunday9");
            RaisePropertyChanged("IsActiveSunday10");
            RaisePropertyChanged("IsActiveSunday11");
            RaisePropertyChanged("IsActiveSunday12");
            RaisePropertyChanged("IsActiveSunday13");
            RaisePropertyChanged("IsActiveSunday14");
            RaisePropertyChanged("IsActiveSunday15");
            RaisePropertyChanged("IsActiveSunday16");
            RaisePropertyChanged("IsActiveSunday17");
            RaisePropertyChanged("IsActiveSunday18");
            RaisePropertyChanged("IsActiveSunday19");
            RaisePropertyChanged("IsActiveSunday20");
            RaisePropertyChanged("IsActiveSunday21");
            RaisePropertyChanged("IsActiveSunday22");
            RaisePropertyChanged("IsActiveSunday23");
        }

        #region Monday

        public bool IsActiveMonday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveMonday0");
            }
        }

        public bool IsActiveMonday1
        {
            get 
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(1); 
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveMonday1");
            }
        }

        public bool IsActiveMonday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveMonday2");
            }
        }

        public bool IsActiveMonday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveMonday3");
            }
        }

        public bool IsActiveMonday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveMonday4");
            }
        }

        public bool IsActiveMonday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveMonday5");
            }
        }

        public bool IsActiveMonday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveMonday6");
            }
        }

        public bool IsActiveMonday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveMonday7");
            }
        }

        public bool IsActiveMonday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveMonday8");
            }
        }

        public bool IsActiveMonday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveMonday9");
            }
        }

        public bool IsActiveMonday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveMonday10");
            }
        }

        public bool IsActiveMonday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveMonday11");
            }
        }

        public bool IsActiveMonday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveMonday12");
            }
        }

        public bool IsActiveMonday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveMonday13");
            }
        }

        public bool IsActiveMonday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveMonday14");
            }
        }

        public bool IsActiveMonday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveMonday15");
            }
        }

        public bool IsActiveMonday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveMonday16");
            }
        }

        public bool IsActiveMonday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveMonday17");
            }
        }

        public bool IsActiveMonday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveMonday18");
            }
        }

        public bool IsActiveMonday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveMonday19");
            }
        }

        public bool IsActiveMonday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveMonday20");
            }
        }

        public bool IsActiveMonday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveMonday21");
            }
        }

        public bool IsActiveMonday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveMonday22");
            }
        }

        public bool IsActiveMonday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Monday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Monday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveMonday23");
            }
        }

        #endregion

        #region Tuesday

        public bool IsActiveTuesday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveTuesday0");
            }
        }

        public bool IsActiveTuesday1
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(1);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveTuesday1");
            }
        }

        public bool IsActiveTuesday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveTuesday2");
            }
        }

        public bool IsActiveTuesday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveTuesday3");
            }
        }

        public bool IsActiveTuesday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveTuesday4");
            }
        }

        public bool IsActiveTuesday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveTuesday5");
            }
        }

        public bool IsActiveTuesday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveTuesday6");
            }
        }

        public bool IsActiveTuesday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveTuesday7");
            }
        }

        public bool IsActiveTuesday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveTuesday8");
            }
        }

        public bool IsActiveTuesday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveTuesday9");
            }
        }

        public bool IsActiveTuesday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveTuesday10");
            }
        }

        public bool IsActiveTuesday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveTuesday11");
            }
        }

        public bool IsActiveTuesday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveTuesday12");
            }
        }

        public bool IsActiveTuesday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveTuesday13");
            }
        }

        public bool IsActiveTuesday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveTuesday14");
            }
        }

        public bool IsActiveTuesday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveTuesday15");
            }
        }

        public bool IsActiveTuesday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveTuesday16");
            }
        }

        public bool IsActiveTuesday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveTuesday17");
            }
        }

        public bool IsActiveTuesday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveTuesday18");
            }
        }

        public bool IsActiveTuesday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveTuesday19");
            }
        }

        public bool IsActiveTuesday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveTuesday20");
            }
        }

        public bool IsActiveTuesday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveTuesday21");
            }
        }

        public bool IsActiveTuesday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveTuesday22");
            }
        }

        public bool IsActiveTuesday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Tuesday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Tuesday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveTuesday23");
            }
        }

        #endregion

        #region Wednesday

        public bool IsActiveWednesday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveWednesday0");
            }
        }

        public bool IsActiveWednesday1
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(1);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveWednesday1");
            }
        }

        public bool IsActiveWednesday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveWednesday2");
            }
        }

        public bool IsActiveWednesday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveWednesday3");
            }
        }

        public bool IsActiveWednesday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveWednesday4");
            }
        }

        public bool IsActiveWednesday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveWednesday5");
            }
        }

        public bool IsActiveWednesday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveWednesday6");
            }
        }

        public bool IsActiveWednesday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveWednesday7");
            }
        }

        public bool IsActiveWednesday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveWednesday8");
            }
        }

        public bool IsActiveWednesday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveWednesday9");
            }
        }

        public bool IsActiveWednesday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveWednesday10");
            }
        }

        public bool IsActiveWednesday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveWednesday11");
            }
        }

        public bool IsActiveWednesday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveWednesday12");
            }
        }

        public bool IsActiveWednesday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveWednesday13");
            }
        }

        public bool IsActiveWednesday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveWednesday14");
            }
        }

        public bool IsActiveWednesday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveWednesday15");
            }
        }

        public bool IsActiveWednesday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveWednesday16");
            }
        }

        public bool IsActiveWednesday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveWednesday17");
            }
        }

        public bool IsActiveWednesday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveWednesday18");
            }
        }

        public bool IsActiveWednesday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveWednesday19");
            }
        }

        public bool IsActiveWednesday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveWednesday20");
            }
        }

        public bool IsActiveWednesday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveWednesday21");
            }
        }

        public bool IsActiveWednesday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveWednesday22");
            }
        }

        public bool IsActiveWednesday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Wednesday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Wednesday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveWednesday23");
            }
        }

        #endregion

        #region Thursday

        public bool IsActiveThursday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveThursday0");
            }
        }

        public bool IsActiveThursday1
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(1);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveThursday1");
            }
        }

        public bool IsActiveThursday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveThursday2");
            }
        }

        public bool IsActiveThursday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveThursday3");
            }
        }

        public bool IsActiveThursday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveThursday4");
            }
        }

        public bool IsActiveThursday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveThursday5");
            }
        }

        public bool IsActiveThursday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveThursday6");
            }
        }

        public bool IsActiveThursday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveThursday7");
            }
        }

        public bool IsActiveThursday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveThursday8");
            }
        }

        public bool IsActiveThursday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveThursday9");
            }
        }

        public bool IsActiveThursday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveThursday10");
            }
        }

        public bool IsActiveThursday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveThursday11");
            }
        }

        public bool IsActiveThursday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveThursday12");
            }
        }

        public bool IsActiveThursday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveThursday13");
            }
        }

        public bool IsActiveThursday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveThursday14");
            }
        }

        public bool IsActiveThursday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveThursday15");
            }
        }

        public bool IsActiveThursday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveThursday16");
            }
        }

        public bool IsActiveThursday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveThursday17");
            }
        }

        public bool IsActiveThursday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveThursday18");
            }
        }

        public bool IsActiveThursday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveThursday19");
            }
        }

        public bool IsActiveThursday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveThursday20");
            }
        }

        public bool IsActiveThursday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveThursday21");
            }
        }

        public bool IsActiveThursday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveThursday22");
            }
        }

        public bool IsActiveThursday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Thursday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Thursday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveThursday23");
            }
        }

        #endregion

        #region Friday

        public bool IsActiveFriday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveFriday0");
            }
        }

        public bool IsActiveFriday1
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(1);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveFriday1");
            }
        }

        public bool IsActiveFriday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveFriday2");
            }
        }

        public bool IsActiveFriday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveFriday3");
            }
        }

        public bool IsActiveFriday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveFriday4");
            }
        }

        public bool IsActiveFriday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveFriday5");
            }
        }

        public bool IsActiveFriday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveFriday6");
            }
        }

        public bool IsActiveFriday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveFriday7");
            }
        }

        public bool IsActiveFriday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveFriday8");
            }
        }

        public bool IsActiveFriday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveFriday9");
            }
        }

        public bool IsActiveFriday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveFriday10");
            }
        }

        public bool IsActiveFriday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveFriday11");
            }
        }

        public bool IsActiveFriday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveFriday12");
            }
        }

        public bool IsActiveFriday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveFriday13");
            }
        }

        public bool IsActiveFriday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveFriday14");
            }
        }

        public bool IsActiveFriday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveFriday15");
            }
        }

        public bool IsActiveFriday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveFriday16");
            }
        }

        public bool IsActiveFriday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveFriday17");
            }
        }

        public bool IsActiveFriday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveFriday18");
            }
        }

        public bool IsActiveFriday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveFriday19");
            }
        }

        public bool IsActiveFriday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveFriday20");
            }
        }

        public bool IsActiveFriday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveFriday21");
            }
        }

        public bool IsActiveFriday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveFriday22");
            }
        }

        public bool IsActiveFriday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Friday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Friday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveFriday23");
            }
        }

        #endregion

        #region Saturday

        public bool IsActiveSaturday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveSaturday0");
            }
        }

        public bool IsActiveSaturday1
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(1);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveSaturday1");
            }
        }

        public bool IsActiveSaturday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveSaturday2");
            }
        }

        public bool IsActiveSaturday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveSaturday3");
            }
        }

        public bool IsActiveSaturday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveSaturday4");
            }
        }

        public bool IsActiveSaturday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveSaturday5");
            }
        }

        public bool IsActiveSaturday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveSaturday6");
            }
        }

        public bool IsActiveSaturday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveSaturday7");
            }
        }

        public bool IsActiveSaturday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveSaturday8");
            }
        }

        public bool IsActiveSaturday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveSaturday9");
            }
        }

        public bool IsActiveSaturday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveSaturday10");
            }
        }

        public bool IsActiveSaturday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveSaturday11");
            }
        }

        public bool IsActiveSaturday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveSaturday12");
            }
        }

        public bool IsActiveSaturday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveSaturday13");
            }
        }

        public bool IsActiveSaturday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveSaturday14");
            }
        }

        public bool IsActiveSaturday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveSaturday15");
            }
        }

        public bool IsActiveSaturday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveSaturday16");
            }
        }

        public bool IsActiveSaturday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveSaturday17");
            }
        }

        public bool IsActiveSaturday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveSaturday18");
            }
        }

        public bool IsActiveSaturday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveSaturday19");
            }
        }

        public bool IsActiveSaturday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveSaturday20");
            }
        }

        public bool IsActiveSaturday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveSaturday21");
            }
        }

        public bool IsActiveSaturday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveSaturday22");
            }
        }

        public bool IsActiveSaturday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Saturday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Saturday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveSaturday23");
            }
        }

        #endregion

        #region Sunday

        public bool IsActiveSunday0
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(0);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(0, value);
                RaisePropertyChanged("IsActiveSunday0");
            }
        }

        public bool IsActiveSunday1
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(1);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(1, value);
                RaisePropertyChanged("IsActiveSunday1");
            }
        }

        public bool IsActiveSunday2
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(2);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(2, value);
                RaisePropertyChanged("IsActiveSunday2");
            }
        }

        public bool IsActiveSunday3
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(3);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(3, value);
                RaisePropertyChanged("IsActiveSunday3");
            }
        }

        public bool IsActiveSunday4
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(4);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(4, value);
                RaisePropertyChanged("IsActiveSunday4");
            }
        }

        public bool IsActiveSunday5
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(5);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(5, value);
                RaisePropertyChanged("IsActiveSunday5");
            }
        }

        public bool IsActiveSunday6
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(6);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(6, value);
                RaisePropertyChanged("IsActiveSunday6");
            }
        }

        public bool IsActiveSunday7
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(7);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(7, value);
                RaisePropertyChanged("IsActiveSunday7");
            }
        }

        public bool IsActiveSunday8
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(8);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(8, value);
                RaisePropertyChanged("IsActiveSunday8");
            }
        }

        public bool IsActiveSunday9
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(9);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(9, value);
                RaisePropertyChanged("IsActiveSunday9");
            }
        }

        public bool IsActiveSunday10
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(10);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(10, value);
                RaisePropertyChanged("IsActiveSunday10");
            }
        }

        public bool IsActiveSunday11
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(11);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(11, value);
                RaisePropertyChanged("IsActiveSunday11");
            }
        }

        public bool IsActiveSunday12
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(12);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(12, value);
                RaisePropertyChanged("IsActiveSunday12");
            }
        }

        public bool IsActiveSunday13
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(13);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(13, value);
                RaisePropertyChanged("IsActiveSunday13");
            }
        }

        public bool IsActiveSunday14
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(14);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(14, value);
                RaisePropertyChanged("IsActiveSunday14");
            }
        }

        public bool IsActiveSunday15
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(15);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(15, value);
                RaisePropertyChanged("IsActiveSunday15");
            }
        }

        public bool IsActiveSunday16
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(16);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(16, value);
                RaisePropertyChanged("IsActiveSunday16");
            }
        }

        public bool IsActiveSunday17
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(17);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(17, value);
                RaisePropertyChanged("IsActiveSunday17");
            }
        }

        public bool IsActiveSunday18
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(18);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(18, value);
                RaisePropertyChanged("IsActiveSunday18");
            }
        }

        public bool IsActiveSunday19
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(19);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(19, value);
                RaisePropertyChanged("IsActiveSunday19");
            }
        }

        public bool IsActiveSunday20
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(20);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(20, value);
                RaisePropertyChanged("IsActiveSunday20");
            }
        }

        public bool IsActiveSunday21
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(21);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(21, value);
                RaisePropertyChanged("IsActiveSunday21");
            }
        }

        public bool IsActiveSunday22
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(22);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(22, value);
                RaisePropertyChanged("IsActiveSunday22");
            }
        }

        public bool IsActiveSunday23
        {
            get
            {
                return _schedule.ScheduleDays[DayOfWeek.Sunday].GetActivityStatus(23);
            }
            set
            {
                _schedule.ScheduleDays[DayOfWeek.Sunday].SetActivityStatus(23, value);
                RaisePropertyChanged("IsActiveSunday23");
            }
        }

        #endregion

    }
}
