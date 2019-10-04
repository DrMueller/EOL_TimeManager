using System;
using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Adapters.Implementation
{
    internal class DailyReportDataModelAdapter : DataModelAdapterBase<DailyReportDataModel, DailyReport, string>, IDailyReportDataModelAdapter
    {
        public DailyReportDataModelAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override DailyReport Adapt(DailyReportDataModel dataModel)
        {
            throw new NotImplementedException();
        }
    }
}