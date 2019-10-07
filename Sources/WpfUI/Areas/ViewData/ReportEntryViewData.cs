using System;

namespace Mmu.TimeManager.WpfUI.Areas.ViewData
{
    public class ReportEntryViewData
    {
        public string From { get; set; }

        public bool IsValid
        {
            get
            {
                return true;
                //return !string.IsNullOrEmpty(WorkDescription) && !string.IsNullOrEmpty(ProjectId);
                //return !string.IsNullOrEmpty(WorkDescription);
            }
        }

        public ReportEntryViewData()
        {

        }

        public string ProjectId { get; set; }
        public string ReportEntryId { get; set; }
        public string To { get; set; }
        public string WorkDescription { get; set; }
    }
}