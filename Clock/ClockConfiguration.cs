using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Clock
{
    public class ClockConfiguration : INotifyPropertyChanged
    {
        private double secondsAngle = 0;
        public double SecondsAngle
        {
            get
            {
                return secondsAngle;
            }
            set
            {
                if (value != secondsAngle)
                {
                    secondsAngle = value;
                    OnPropertyChanged();
                }
            }
        }
        private double minutessAngle = 0;
        public double MinutesAngle
        {
            get
            {
                return minutessAngle;
            }
            set
            {
                if (value != minutessAngle)
                {
                    minutessAngle = value;
                    OnPropertyChanged();
                }
            }
        }
        private double hoursAngle = 0;
        public double HoursAngle
        {
            get
            {
                return hoursAngle;
            }
            set
            {
                if (value != hoursAngle)
                {
                    hoursAngle = value;
                    OnPropertyChanged();
                }
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ClockConfiguration()
        {
            SecondsAngle = GetSecondsAngle();
            MinutesAngle = GetMinutesAngle();
            HoursAngle = GetHoursAngle();
        }
        public static double GetSecondsAngle()
        {
            TimeSpan day = (DateTime.Now - DateTime.Now.Date);
            return (day.Seconds + day.Milliseconds / 1000.0) * 360 / 60.0;
        }
        public static double GetMinutesAngle()
        {
            TimeSpan day = (DateTime.Now - DateTime.Now.Date);
            return (day.Minutes + (day.Seconds + day.Milliseconds / 1000.0) / 60.0) * 360 / 60.0;
        }
        public static double GetHoursAngle()
        {
            TimeSpan day = (DateTime.Now - DateTime.Now.Date);
            return (day.Hours % 12) * 360 / 12.0 + (day.Minutes + (day.Seconds + day.Milliseconds / 1000.0) / 60.0) / 60.0 * 360 / 12.0;
        }
    }
}
