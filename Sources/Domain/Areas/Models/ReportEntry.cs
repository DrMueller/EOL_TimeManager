using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class ReportEntry : Entity<string>
    {
        public DateTime From { get; }
        public Project Project { get; }
        public DateTime To { get; }
        public string WorkDescription { get; }

        public ReportEntry(
            DateTime from,
            DateTime to,
            string workDescription,
            Project project,
            string id) : base(id)
        {
            Guard.StringNotNullOrEmpty(() => workDescription);
            Guard.ObjectNotNull(() => project);

            From = from;
            To = to;
            WorkDescription = workDescription;
            Project = project;
        }
    }
}