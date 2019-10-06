using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.TimeManager.Domain.Areas.Models;
using System;
using System.Threading.Tasks;

namespace Mmu.TimeManager.Domain.Areas.Repositories
{
    public interface IDailyReportRepository : IRepository<DailyReport, string>
    {
        Task<DailyReport> LoadByDateAsync(DateTime date);
    }
}