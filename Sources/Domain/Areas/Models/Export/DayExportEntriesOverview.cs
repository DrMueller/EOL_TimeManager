namespace Mmu.TimeManager.Domain.Areas.Models.Export
{
    public class DayExportEntriesOverview
    {
        public TimeDescription TimeDescription { get; }

        public DayExportEntriesOverview(TimeDescription timeDescription)
        {
            TimeDescription = timeDescription;
        }
    }
}