using System;
using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class DailyReport : AggregateRoot<string>
    {
        private readonly List<ReportEntry> _reportEntries;

        public DateTime Date { get; }

        public DailyReport(
            DateTime date,
            List<ReportEntry> reportEntries,
            string id) : base(id)
        {
            Guard.ObjectNotNull(() => reportEntries);
            Date = date;
            _reportEntries = reportEntries;
        }
    }
}