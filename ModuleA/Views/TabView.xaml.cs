using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using ModuleA.ViewModels;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TabView : UserControl
    {
        public TabView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ITabViewModel>();
        }
    }
}
