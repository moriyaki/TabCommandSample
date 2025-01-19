using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using TabCommandSample.ViewModels;

namespace TabCommandSample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<IMainWindowViewModel>();
        }
    }
}