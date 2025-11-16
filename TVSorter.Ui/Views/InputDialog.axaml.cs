// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="InputDialog.axaml.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   The code-behind for the input dialog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Avalonia.Controls;
using Avalonia.Interactivity;
using TVSorter.Ui.ViewModels;

namespace TVSorter.Ui.Views;

/// <summary>
///     The input dialog for text entry.
/// </summary>
public partial class InputDialog : Window
{
    public InputDialog()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is InputDialogViewModel viewModel)
        {
            Close(viewModel.InputText);
        }
        else
        {
            Close(null);
        }
    }

    private void CancelButton_Click(object? sender, RoutedEventArgs e)
    {
        Close(null);
    }
}
