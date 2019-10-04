using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Implementation;
using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Servants;
using Mmu.TimeManager.DataAccess.Areas.DataModels;

namespace Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Implementation
{
    internal class ProjectDataModelRepository : FileSystemDataModelRepository<ProjectDataModel>, IProjectDataModelRepository
    {
        public ProjectDataModelRepository(
            IFileSystemProxy<ProjectDataModel> fileSystemProxy,
            IDataModelFileAdapter<ProjectDataModel> dataModelFileAdapter) : base(fileSystemProxy, dataModelFileAdapter)
        {
        }
    }
}