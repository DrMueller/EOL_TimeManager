using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;

namespace Mmu.TimeManager.DataAccess.Areas.Repositories
{
    internal class ProjectRepository : RepositoryBase<Project, ProjectDataModel, string>, IProjectRepository
    {
        public ProjectRepository(
            IDataModelRepository<ProjectDataModel, string> dataModelRepository,
            IDataModelAdapter<ProjectDataModel, Project, string> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}