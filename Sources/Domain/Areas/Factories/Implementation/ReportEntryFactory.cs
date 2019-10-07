using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.Domain.Areas.Factories.Implementation
{
    internal class ReportEntryFactory : IReportEntryFactory
    {
        public ReportEntry Create(TimeStamp beginTime, Maybe<TimeStamp> endTime, string workDescription, string id)
        {
            id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;

            return new ReportEntry(
                beginTime,
                endTime,
                workDescription,
                null,
                id);
        }
    }
}