using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Adapters.Implementation
{
    internal class ProjectDataModelAdapter : DataModelAdapterBase<ProjectDataModel, Project, string>, IProjectDataModelAdapter
    {
        public ProjectDataModelAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override Project Adapt(ProjectDataModel dataModel)
        {
            return new Project(dataModel.Description, dataModel.Id);
        }
    }
}