using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.TimeManager.WpfUI.Areas.ViewData
{
    public class ReportEntryViewData : ViewModelBase
    {
        private string _beginTime;
        private string _endTime;
        private string _workDescription;

        public string BeginTime
        {
            get => _beginTime;
            set
            {
                if (_beginTime != value)
                {
                    _beginTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(WorkDescription);
            }
        }

        public string ReportEntryId { get; }

        public string WorkDescription
        {
            get => _workDescription;
            set
            {
                if (_workDescription != value)
                {
                    _workDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public ReportEntryViewData(string reportEntryId)
        {
            ReportEntryId = reportEntryId;
        }
    }
}