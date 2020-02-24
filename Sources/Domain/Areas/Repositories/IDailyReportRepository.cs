using System;
using System.Threading.Tasks;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.TimeManager.Domain.Areas.Models.Management;

namespace Mmu.TimeManager.Domain.Areas.Repositories
{
    public interface IDailyReportRepository : IRepository<DailyReport, string>
    {
        Task<Maybe<DailyReport>> LoadByDateAsync(DateTime reportData);
    }
}