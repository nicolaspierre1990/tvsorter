using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Splat;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.Views;

public partial class ShowDetailDialogView : Window
{
    public ShowDetailDialogView()
    {
        InitializeComponent();
        var viewModel = Locator.Current.GetService<ShowDetailDialogViewModel>();
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