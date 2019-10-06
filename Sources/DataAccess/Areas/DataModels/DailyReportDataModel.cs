using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using System;

namespace Mmu.TimeManager.DataAccess.Areas.DataModels
{
    internal class DailyReportDataModel : AggregateRootDataModel<string>
    {
        public DateTime Date { get; set; }
    }
}