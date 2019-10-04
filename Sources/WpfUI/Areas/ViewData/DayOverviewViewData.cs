namespace Mmu.TimeManager.WpfUI.Areas.ViewData
{
    public class DayOverviewViewData
    {
        public string DateDescription { get; }

        public string ReportedTimeDescription { get; }

        public DayOverviewViewData(string dateDescription, string reportedTimeDescription)
        {
            DateDescription = dateDescription;
            ReportedTimeDescription = reportedTimeDescription;
        }
    }
}