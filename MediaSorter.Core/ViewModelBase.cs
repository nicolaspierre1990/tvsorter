using Prism.Events;
using Prism.Mvvm;
using System.ComponentModel;

namespace MediaSorter.Core
{
    public abstract class ViewModelBase: BindableBase
    {
        private bool _isBusy;


        public ViewModelBase(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            InitializeViewModel();
            InitializeCommands();
        }

        public bool IsBusy { get => _isBusy; set => _isBusy = value; }
        public IEventAggregator EventAggregator { get; }

        public abstract Task InitializeViewModel();
        public abstract void InitializeCommands();
        public abstract void RefreshCommands();

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            RefreshCommands();
        }
    }
}