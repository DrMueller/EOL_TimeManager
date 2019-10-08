using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class SapEntry
    {
        public string AbsoluteTimeDescription { get; }
        public string DescriptionExternal { get; }

        public SapEntry(string absoluteTimeDescription, string descriptionExternal)
        {
            Guard.StringNotNullOrEmpty(() => descriptionExternal);

            AbsoluteTimeDescription = absoluteTimeDescription;
            DescriptionExternal = descriptionExternal;
        }
    }
}