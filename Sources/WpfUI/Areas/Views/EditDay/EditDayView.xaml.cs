using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    /// <summary>
    /// Interaction logic for EditDayView.xaml
    /// </summary>
    public partial class EditDayView : UserControl, IViewMap<EditDayViewModel>
    {
        public EditDayView()
        {
            InitializeComponent();
        }
    }
}