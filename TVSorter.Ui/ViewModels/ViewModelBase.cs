using System;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

public class ViewModelBase : ReactiveObject
{
    private bool _isBusy;
    private bool _isInitialized;

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    protected ViewModelBase()
    {

    }

    public void SetIsBusy(bool isBusy) => IsBusy = isBusy;

    public async Task EnsureInitialized()
    {
        if (!_isInitialized)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));

            _isInitialized = true;
            await InitializeView(cts.Token);
        }
    }


    public virtual Task InitializeView(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}