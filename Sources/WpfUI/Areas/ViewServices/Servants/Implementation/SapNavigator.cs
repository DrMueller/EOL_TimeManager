using System;
using System.Diagnostics;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices.Servants.Implementation
{
    public class SapNavigator : ISapNavigator
    {
        private const string BaseUrl = "https://sap.trivadis.com/sap(bD1kZSZjPTEwMA==)/bc/bsp/sap/zptbsptri/default.htm?date={0}";

        public void NavigateToDay(DateTime sapDate)
        {
            var formattedDate = sapDate.ToString("dd.MM.yyyy");
            var url = string.Format(BaseUrl, formattedDate);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url);
        }
    }
}