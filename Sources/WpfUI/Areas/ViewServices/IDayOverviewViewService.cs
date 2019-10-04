﻿using System.Threading.Tasks;
using Mmu.TimeManager.WpfUI.Areas.ViewData;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices
{
    public interface IDayOverviewViewService
    {
        Task<DayOverviewViewData> LoadAllAsync();
    }
}