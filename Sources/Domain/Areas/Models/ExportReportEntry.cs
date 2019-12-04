using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class ExportReportEntry
    {
        public string AbsoluteTimeDescription { get; }
        public string RelativeTimeDescription { get; }
        public string DescriptionExternal { get; }

        public ExportReportEntry(
            string absoluteTimeDescription,
            string relativeTimeDescription,
            string descriptionExternal)
        {
            Guard.StringNotNullOrEmpty(() => descriptionExternal);

            AbsoluteTimeDescription = absoluteTimeDescription;
            RelativeTimeDescription = relativeTimeDescription;
            DescriptionExternal = descriptionExternal;
        }
    }
}