using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.Views;

public partial class SplashScreenView : Window
{
    public SplashScreenView()
    {
        InitializeComponent();
    }

    public async Task InitializeAsync()
    {
        if (DataContext is SplashScreenViewModel viewModel)
        {
            await viewModel.InitializeAsync();
        }   
    }
}