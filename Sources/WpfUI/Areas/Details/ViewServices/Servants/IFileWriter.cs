using Mmu.TimeManager.Domain.Areas.Models.Export;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Servants
{
    public interface IFileWriter
    {
        void WriteAndOpenTextFile(DayExport dayExport);
    }
}