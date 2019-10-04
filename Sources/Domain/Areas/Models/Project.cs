using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.TimeManager.Domain.Areas.Models
{
    public class Project : AggregateRoot<string>
    {
        public string Description { get; }

        public Project(
            string description,
            string id) : base(id)
        {
            Guard.StringNotNullOrEmpty(() => description);

            Description = description;
        }
    }
}