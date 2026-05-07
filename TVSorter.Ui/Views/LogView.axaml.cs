using Avalonia.Controls;
using Splat;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.Views;

public partial class LogView : UserControl
{
    public LogView()
    {
        InitializeComponent();
        var viewModel = Locator.Current.GetService<LogViewModel>();
        DataContext = viewModel;

        AttachedToVisualTree += async (s, e) =>
        {
            if (viewModel != null)
            {
                await viewModel.EnsureInitialized();
            }
        };
    }
}