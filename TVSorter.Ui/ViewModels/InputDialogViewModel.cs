// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="InputDialogViewModel.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   The view model for the input dialog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ReactiveUI;

namespace TVSorter.Ui.ViewModels;

/// <summary>
///     The view model for the input dialog.
/// </summary>
public class InputDialogViewModel : ViewModelBase
{
    private string _prompt = string.Empty;
    private string _inputText = string.Empty;

    /// <summary>
    ///     Gets or sets the prompt message.
    /// </summary>
    public string Prompt
    {
        get => _prompt;
        set => this.RaiseAndSetIfChanged(ref _prompt, value);
    }

    /// <summary>
    ///     Gets or sets the input text.
    /// </summary>
    public string InputText
    {
        get => _inputText;
        set => this.RaiseAndSetIfChanged(ref _inputText, value);
    }
}
