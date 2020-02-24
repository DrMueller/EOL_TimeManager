namespace Mmu.TimeManager.Domain.Areas.Models.Management
{
    public class UpdateReportEntryResult
    {
        public string ErrorMessage { get; }
        public bool IsSuccess { get; }

        internal UpdateReportEntryResult(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}