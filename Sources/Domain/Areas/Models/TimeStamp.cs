using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class TimeStamp : ValueObject<TimeStamp>
    {
        public string Description
        {
            get
            {
                return $"{Hour}:{Minute}";
            }
        }

        public string Hour { get; }
        public string Minute { get; }

        public TimeStamp(string hour, string minute)
        {
            Guard.StringNotNullOrEmpty(() => hour);
            Guard.StringNotNullOrEmpty(() => minute);

            Hour = hour;
            Minute = minute;
        }

        public static TimeStamp Parse(string str)
        {
            var splitted = str.Split(':');
            return new TimeStamp(splitted[0], splitted[1]);
        }

        public static Maybe<TimeStamp> TryParsing(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Maybe.CreateNone<TimeStamp>();
            }

            return Parse(str);
        }

        internal TimeSpan ToTimeSpan()
        {
            return new TimeSpan(
                int.Parse(Hour),
                int.Parse(Minute),
                0);
        }
    }
}