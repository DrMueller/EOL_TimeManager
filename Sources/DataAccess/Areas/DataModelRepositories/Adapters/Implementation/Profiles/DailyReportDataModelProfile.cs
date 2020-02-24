using AutoMapper;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models.Management;

namespace Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Adapters.Implementation.Profiles
{
    public class DailyReportDataModelProfile : Profile
    {
        public DailyReportDataModelProfile()
        {
            CreateMap<DailyReport, DailyReportDataModel>()
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.Date, c => c.MapFrom(f => f.Date))
                .ForMember(d => d.ReportEntries, c => c.MapFrom(f => f.SortedReportEntries));
        }
    }
}