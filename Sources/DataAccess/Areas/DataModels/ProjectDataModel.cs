using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.TimeManager.DataAccess.Areas.DataModels
{
    internal class ProjectDataModel : AggregateRootDataModel<string>
    {
        public string Description { get; set; }
    }
}