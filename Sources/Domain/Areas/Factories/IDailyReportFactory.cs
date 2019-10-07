using System;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.Domain.Areas.Factories
{
    public interface IDailyReportFactory
    {
        DailyReport Create(DateTime reportDate);
    }
}