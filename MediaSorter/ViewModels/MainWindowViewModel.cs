using MediaSorter.Core;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MediaSorter.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title;
        private ObservableCollection<MenuItem> _menuItems;

        public MainWindowViewModel(IEventAggregator eventAggregator) 
            : base(eventAggregator)
        {

        }

        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public ObservableCollection<MenuItem> MenuItems { get => _menuItems; set => SetProperty(ref _menuItems, value); }
        public DelegateCommand<TabItem> SelectedTabChangedCommand { get; set; }

        public override void InitializeCommands()
        {
            SelectedTabChangedCommand = new DelegateCommand<TabItem>(InitializeTab, (i) => !IsBusy);
        }

        public override Task InitializeViewModel()
        {
            Title = $"MediaSorter v{Assembly.GetExecutingAssembly().GetName().Version}";

            return Task.CompletedTask;
        }

        public override void RefreshCommands()
        {
            SelectedTabChangedCommand?.RaiseCanExecuteChanged();
        }

        #region Commands

        private void InitializeTab(TabItem obj)
        {
            Debug.WriteLine(obj.Name);
        }

        #endregion
    }
}
