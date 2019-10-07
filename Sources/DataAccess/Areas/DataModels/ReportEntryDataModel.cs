using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.TimeManager.DataAccess.Areas.DataModels
{
    internal class ReportEntryDataModel : EntityDataModel<string>
    {
        public TimeStampDataModel BeginTime { get; set; }
        public ProjectDataModel Project { get; set; }
        public TimeStampDataModel EndTime { get; set; }
        public string WorkDescription { get; set; }
    }
}