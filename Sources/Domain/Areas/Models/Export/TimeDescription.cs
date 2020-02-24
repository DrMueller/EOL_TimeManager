using System;
using System.Globalization;

namespace Mmu.TimeManager.Domain.Areas.Models.Export
{
    public class TimeDescription
    {
        private readonly TimeSpan _timeSpan;

        public string AbsoluteTimeDescription
        {
            get
            {
                var absoluteTime = Math.Round(_timeSpan.TotalHours, 2).ToString(CultureInfo.InvariantCulture);

                return absoluteTime;
            }
        }

        public string TimeDescriptionInMinutes
        {
            get
            {
                return _timeSpan.ToString(@"hh\:mm");
            }
        }

        public TimeDescription(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }
    }
}