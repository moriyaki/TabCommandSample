using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ModuleA.ViewModels;

namespace TabCommandSample.ViewModels
{
    public interface IMainWindowViewModel;

    public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private readonly IMessenger _messenger;

        public MainWindowViewModel(IMessenger messenger)
        {
            _messenger = messenger;

            Tabs = new ObservableCollection<TabViewModel>
            {
                new TabViewModel(_messenger) { Title = "Tab A" },
                new TabViewModel(_messenger) { Title = "Tab B" },
                new TabViewModel(_messenger) { Title = "Tab C" }
            };

            _messenger.Register<CanUpdateChangedMessage>(this, (_, _)
                => SaveCommand.NotifyCanExecuteChanged());
        }

        [ObservableProperty]
        private string title = "CommunityToolkit.Mvvm Application";

        public ObservableCollection<TabViewModel> Tabs { get; } = [];

        [RelayCommand(CanExecute = nameof(CanSaveCommand))]
        private void Save()
        {
            foreach (var tab in Tabs)
            {
                tab.UpdateCommand.Execute(this);
            }
        }

        private bool CanSaveCommand()
        {
            foreach (var tab in Tabs)
            {
                if (!tab.CanUpdate) return false;
            }
            return true;
        }
    }
}
