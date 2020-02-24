using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.TimeManager.Domain.Areas.Models.Management;

namespace Mmu.TimeManager.Domain.Areas.Factories
{
    public interface IReportEntryFactory
    {
        ReportEntry Create(TimeStamp beginTime, Maybe<TimeStamp> endTime, string workDescription, string id);
    }
}