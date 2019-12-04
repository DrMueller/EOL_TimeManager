using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class ExportReportEntry
    {
        public string AbsoluteTimeDescription { get; }
        public string TimeDescriptionInMinutes { get; }
        public string DescriptionExternal { get; }

        public ExportReportEntry(
            string absoluteTimeDescription,
            string timeDescriptionInMinutes,
            string descriptionExternal)
        {
            Guard.StringNotNullOrEmpty(() => descriptionExternal);

            AbsoluteTimeDescription = absoluteTimeDescription;
            TimeDescriptionInMinutes = timeDescriptionInMinutes;
            DescriptionExternal = descriptionExternal;
        }
    }
}