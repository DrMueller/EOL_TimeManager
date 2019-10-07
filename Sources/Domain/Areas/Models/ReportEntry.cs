using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class ReportEntry : Entity<string>
    {
        public TimeStamp BeginTime { get; private set; }
        public Project Project { get; private set; }
        public Maybe<TimeStamp> EndTime { get; private set; }
        public string WorkDescription { get; private set; }

        public ReportEntry(
            TimeStamp beginTime,
            Maybe<TimeStamp> endTime,
            string workDescription,
            Project project,
            string id) : base(id)
        {
            Guard.StringNotNullOrEmpty(() => workDescription);
            //Guard.ObjectNotNull(() => project);

            BeginTime = beginTime;
            EndTime = endTime;
            WorkDescription = workDescription;
            Project = project;
        }

        internal void AlignValues(ReportEntry newEntry)
        {
            BeginTime = newEntry.BeginTime;
            Project = newEntry.Project;
            EndTime = newEntry.EndTime;
            WorkDescription = newEntry.WorkDescription;
        }

        internal TimeSpan CalculateReportedMinutes()
        {
            return EndTime.Evaluate(to =>
             {
                 return to.ToTimeSpan() - BeginTime.ToTimeSpan();
             }, () => default);
        }
    }
}