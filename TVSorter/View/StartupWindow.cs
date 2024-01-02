using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ninject;

namespace TVSorter.View;

public partial class StartupWindow : Form
{
    public StartupWindow()
    {
        InitializeComponent();

        this.pictureBox1.Width = 500;
        this.pictureBox1.Height = 100;
        this.pictureBox1.Image = new System.Drawing.Bitmap(Resources.Resources.logo_no_background, 500, 100);

        this.versionLabel.Text = $"v{CompositionRoot.Version}";
    }

    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        var mainForm = CompositionRoot.Get<MainForm>();
        mainForm.Show();

        Hide();
    }

    private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) => this.customProgressBar1.Value = e.ProgressPercentage;

    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;

        for (int i = 0; i < 10; i++)
        {
            worker.ReportProgress(10 * (i + 1));
        }
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
