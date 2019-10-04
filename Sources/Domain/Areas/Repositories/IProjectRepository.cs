using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.Domain.Areas.Repositories
{
    public interface IProjectRepository : IRepository<Project, string>
    {
    }
}