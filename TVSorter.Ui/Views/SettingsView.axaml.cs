using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Splat;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        var viewModel = Locator.Current.GetService<SettingsViewModel>();
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