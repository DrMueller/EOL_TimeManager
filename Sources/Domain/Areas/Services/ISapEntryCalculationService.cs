using System.Collections.Generic;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.Domain.Areas.Services
{
    public interface ISapEntryCalculationService
    {
        IReadOnlyCollection<SapEntry> CalculateEntries(DailyReport report);
    }
}