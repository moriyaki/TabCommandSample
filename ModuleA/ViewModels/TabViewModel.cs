using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ModuleA.ViewModels
{
    public interface ITabViewModel;

    public partial class TabViewModel : ObservableObject, ITabViewModel
    {
        private readonly IMessenger _messenger;
        public TabViewModel(IMessenger messenger)
        {
            _messenger = messenger;
        }

        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        private bool canUpdate = true;
        partial void OnCanUpdateChanged(bool value)
        {
            UpdateCommand.NotifyCanExecuteChanged();
            _messenger.Send(new CanUpdateChangedMessage());
            
        }
        [ObservableProperty]
        private string updateText = string.Empty;

        [RelayCommand(CanExecute = nameof(CanUpdate))]
        private void Update()
            => UpdateText = $"Updated: {DateTime.Now}";
    }
    public class CanUpdateChangedMessage();
}
