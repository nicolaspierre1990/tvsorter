// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="MainForm.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The main form of the program.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View;



using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// The main form of the program.
/// </summary>
public partial class MainForm
{


    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly IContainer components = null;

    /// <summary>
    ///   The log.
    /// </summary>
    private Log log;

    /// <summary>
    ///   The log page.
    /// </summary>
    private TabPage logPage;

    /// <summary>
    ///   The main tabs.
    /// </summary>
    private TabControl mainTabs;

    /// <summary>
    ///   The missing duplicate episodes.
    /// </summary>
    private MissingDuplicateEpisodes missingDuplicateEpisodes;

    /// <summary>
    ///   The missing duplicate page.
    /// </summary>
    private TabPage missingDuplicatePage;

    /// <summary>
    ///   The settings.
    /// </summary>
    private Settings settings;

    /// <summary>
    ///   The settings page.
    /// </summary>
    private TabPage settingsPage;

    /// <summary>
    ///   The sort episodes.
    /// </summary>
    private SortEpisodes sortEpisodes;

    /// <summary>
    ///   The sort episodes page.
    /// </summary>
    private TabPage sortEpisodesPage;

    /// <summary>
    ///   The tv shows.
    /// </summary>
    private TvShows tvShows;

    /// <summary>
    ///   The tv shows page.
    /// </summary>
    private TabPage tvShowsPage;



    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">
    /// true if managed resources should be disposed; otherwise, false.
    /// </param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    ///   the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        mainTabs = new TabControl();
        sortEpisodesPage = new TabPage();
        tvShowsPage = new TabPage();
        missingDuplicatePage = new TabPage();
        missingDuplicateEpisodes = new MissingDuplicateEpisodes();
        settingsPage = new TabPage();
        logPage = new TabPage();
        mainTabs.SuspendLayout();
        missingDuplicatePage.SuspendLayout();
        SuspendLayout();
        // 
        // mainTabs
        // 
        mainTabs.Controls.Add(sortEpisodesPage);
        mainTabs.Controls.Add(tvShowsPage);
        mainTabs.Controls.Add(missingDuplicatePage);
        mainTabs.Controls.Add(settingsPage);
        mainTabs.Controls.Add(logPage);
        mainTabs.Dock = DockStyle.Fill;
        mainTabs.Location = new Point(0, 0);
        mainTabs.Margin = new Padding(4, 5, 4, 5);
        mainTabs.Name = "mainTabs";
        mainTabs.SelectedIndex = 0;
        mainTabs.Size = new Size(1256, 978);
        mainTabs.TabIndex = 0;
        // 
        // sortEpisodesPage
        // 
        sortEpisodesPage.Controls.Add(new SortEpisodes());
        sortEpisodesPage.Location = new Point(4, 29);
        sortEpisodesPage.Margin = new Padding(4, 5, 4, 5);
        sortEpisodesPage.Name = "sortEpisodesPage";
        sortEpisodesPage.Padding = new Padding(4, 5, 4, 5);
        sortEpisodesPage.TabIndex = 1;
        sortEpisodesPage.Text = "Sort Episode Files";
        sortEpisodesPage.UseVisualStyleBackColor = true;
        // 
        // tvShowsPage
        // 
        tvShowsPage.Controls.Add(new TvShows());
        tvShowsPage.Location = new Point(4, 29);
        tvShowsPage.Margin = new Padding(4, 5, 4, 5);
        tvShowsPage.Name = "tvShowsPage";
        tvShowsPage.Size = new Size(1248, 945);
        tvShowsPage.TabIndex = 2;
        tvShowsPage.Text = "TV Shows";
        tvShowsPage.UseVisualStyleBackColor = true;
        // 
        // missingDuplicatePage
        // 
        missingDuplicatePage.Controls.Add(missingDuplicateEpisodes);
        missingDuplicatePage.Location = new Point(4, 29);
        missingDuplicatePage.Margin = new Padding(4, 5, 4, 5);
        missingDuplicatePage.Name = "missingDuplicatePage";
        missingDuplicatePage.Size = new Size(1248, 945);
        missingDuplicatePage.TabIndex = 3;
        missingDuplicatePage.Text = "Missing / Duplicate Episodes";
        missingDuplicatePage.UseVisualStyleBackColor = true;
        // 
        // missingDuplicateEpisodes
        // 
        missingDuplicateEpisodes.Dock = DockStyle.Fill;
        missingDuplicateEpisodes.Location = new Point(0, 0);
        missingDuplicateEpisodes.Margin = new Padding(5, 8, 5, 8);
        missingDuplicateEpisodes.Name = "missingDuplicateEpisodes";
        missingDuplicateEpisodes.Size = new Size(1248, 945);
        missingDuplicateEpisodes.TabIndex = 0;
        // 
        // settingsPage
        // 
        settingsPage.Controls.Add(new Settings());
        settingsPage.Location = new Point(4, 29);
        settingsPage.Margin = new Padding(4, 5, 4, 5);
        settingsPage.Name = "settingsPage";
        settingsPage.Size = new Size(1248, 945);
        settingsPage.TabIndex = 4;
        settingsPage.Text = "Settings";
        settingsPage.UseVisualStyleBackColor = true;
        // 
        // logPage
        // 
        logPage.Controls.Add(new Log());
        logPage.Location = new Point(4, 29);
        logPage.Margin = new Padding(4, 5, 4, 5);
        logPage.Name = "logPage";
        logPage.Size = new Size(1248, 945);
        logPage.TabIndex = 5;
        logPage.Text = "Log";
        logPage.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1256, 978);
        Controls.Add(mainTabs);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4, 5, 4, 5);
        MinimumSize = new Size(1261, 1005);
        Name = "MainForm";
        Text = "TV Sorter";
        Load += MainFormLoad;
        mainTabs.ResumeLayout(false);
        missingDuplicatePage.ResumeLayout(false);
        ResumeLayout(false);
    }
}