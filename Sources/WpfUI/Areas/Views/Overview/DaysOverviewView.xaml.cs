using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.TimeManager.WpfUI.Areas.Views.Overview
{
    public partial class DaysOverviewView : UserControl, IViewMap<DaysOverviewViewModel>
    {
        public DaysOverviewView()
        {
            InitializeComponent();
        }
    }
}