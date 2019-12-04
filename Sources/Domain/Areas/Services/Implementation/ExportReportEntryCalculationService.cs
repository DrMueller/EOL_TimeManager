using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.Domain.Areas.Services.Implementation
{
    internal class ExportReportEntryCalculationService : IExportReportEntryCalculationService
    {
        public IReadOnlyCollection<ExportReportEntry> CalculateEntries(DailyReport report)
        {
            var grpd = report.SortedReportEntries.GroupBy(f => f.WorkDescription);
            var entries = grpd.Select(CreateFromReportEntries).ToList();
            return entries;
        }

        private static ExportReportEntry CreateFromReportEntries(IGrouping<string, ReportEntry> entries)
        {
            var reportedTimeSpans = default(TimeSpan);
            entries.ForEach(f => reportedTimeSpans += f.CalculateReportedMinutes());
            var absoluteTime = Math.Round(reportedTimeSpans.TotalHours, 2).ToString(CultureInfo.InvariantCulture);

            return new ExportReportEntry(
                absoluteTime,
                reportedTimeSpans.ToString(),
                string.IsNullOrEmpty(entries.Key) ? "No description" : entries.Key);
        }
    }
}