using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.Domain.Areas.Services.Implementation
{
    internal class SapEntryCalculationService : ISapEntryCalculationService
    {
        public IReadOnlyCollection<SapEntry> CalculateEntries(DailyReport report)
        {
            var grpd = report.SortedReportEntries.GroupBy(f => f.WorkDescription);
            var entries = grpd.Select(CreateFromReportEntries).ToList();
            return entries;
        }

        private SapEntry CreateFromReportEntries(IGrouping<string, ReportEntry> entries)
        {
            var reportedTimeSpans = default(TimeSpan);
            entries.ForEach(f => reportedTimeSpans += f.CalculateReportedMinutes());

            return new SapEntry(
                Math.Round(reportedTimeSpans.TotalHours, 2).ToString(),
                string.IsNullOrEmpty(entries.Key) ? "No description" : entries.Key);
        }
    }
}