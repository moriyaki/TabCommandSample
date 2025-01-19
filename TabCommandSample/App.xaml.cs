using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using ModuleA.ViewModels;
using TabCommandSample.ViewModels;


namespace TabCommandSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// サービスの登録をします
        /// </summary>
        public App()
        {
            Services = ConfigureServices();
            Ioc.Default.ConfigureServices(Services);
        }

        /// <summary>
        /// 現在の App インスタンスを取得します
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// サービスプロバイダです
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// サービスを登録します
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IMessenger, WeakReferenceMessenger>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddTransient<ITabViewModel, TabViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
