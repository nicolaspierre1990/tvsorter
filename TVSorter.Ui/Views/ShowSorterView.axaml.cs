using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Splat;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.Views;

public partial class ShowSorterView : UserControl
{
    public ShowSorterView()
    {
        InitializeComponent();
        var viewModel = Locator.Current.GetService<ShowSorterViewModel>();
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