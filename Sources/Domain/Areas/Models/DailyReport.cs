using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class DailyReport : AggregateRoot<string>
    {
        private readonly List<ReportEntry> _reportEntries;
        public DateTime Date { get; }
        public IReadOnlyCollection<ReportEntry> ReportEntries => _reportEntries.Select(re => re.DeepCopy()).ToList();

        public DailyReport(
            DateTime date,
            List<ReportEntry> reportEntries,
            string id) : base(id)
        {
            Guard.ObjectNotNull(() => reportEntries);
            Date = date;
            _reportEntries = reportEntries;
        }

        public TimeSpan CalculateReportedHours()
        {
            var reportedTimeSpans = _reportEntries.Select(f => f.CalculateReportedMinutes());
            var result = default(TimeSpan);

            foreach (var rep in reportedTimeSpans)
            {
                result += rep;
            };

            return result;
        }

        public void RemoveReportEntry(string reportEntryId)
        {
            var existingEntry = _reportEntries.SingleOrDefault(f => f.Id == reportEntryId);
            if (existingEntry != null)
            {
                _reportEntries.Remove(existingEntry);
            }
        }

        public void UpsertReportEntry(ReportEntry entry)
        {
            var existingEntry = _reportEntries.SingleOrDefault(e => e == entry);
            if (existingEntry != null)
            {
                existingEntry.AlignValues(entry);
            }
            else
            {
                _reportEntries.Add(entry);
            }
        }
    }
}