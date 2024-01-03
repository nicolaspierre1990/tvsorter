using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using TVSorter.Storage;

namespace TVSorter.View;

public partial class StartupWindow : Form
{
    private readonly IStorageProvider _storageProvider;

    public StartupWindow()
    {
        InitializeComponent();

        this.pictureBox1.Width = 500;
        this.pictureBox1.Height = 100;
        this.pictureBox1.Image = new System.Drawing.Bitmap(Resources.Resources.logo_no_background, 500, 100);

        this.versionLabel.Text = $"v{CompositionRoot.Version}";
        _storageProvider = CompositionRoot.Get<IStorageProvider>();
    }

    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        var mainForm = CompositionRoot.Get<MainForm>();
        mainForm.Show();

        Hide();
    }

    private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        customProgressBar1.CustomText = e.UserState.ToString();
        customProgressBar1.Value = e.ProgressPercentage;
    }

    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;

        worker.ReportProgress(25, "Loading DataProvider");

        while (!_storageProvider.IsAvailable)
        {
            Task.Delay(100).GetAwaiter().GetResult();
        }

        worker.ReportProgress(50, "Loading Data");

        Task.Delay(100).GetAwaiter().GetResult();

        worker.ReportProgress(100, "Loading UI");
    }

    private void StartupWindow_Shown(object sender, EventArgs e)
    {
        var backgroundWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        backgroundWorker.DoWork += BackgroundWorker_DoWork;
        backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
        backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

        backgroundWorker.RunWorkerAsync();
    }
}
