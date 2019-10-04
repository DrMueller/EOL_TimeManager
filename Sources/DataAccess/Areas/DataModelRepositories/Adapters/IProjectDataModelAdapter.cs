using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Adapters
{
    internal interface IProjectDataModelAdapter : IDataModelAdapter<ProjectDataModel, Project, string>
    {
    }
}