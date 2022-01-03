using MediaSorter.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace MediaSorter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IEventAggregator, EventAggregator>();
        }
    }
}
