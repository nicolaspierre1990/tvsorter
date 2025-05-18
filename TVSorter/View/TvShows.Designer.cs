// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="TvShows.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The TV Shows tab.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View;



using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// The TV Shows tab.
/// </summary>
public partial class TvShows
{



    /// <summary>
    ///   The add show button.
    /// </summary>
    private Button addShowButton;

    /// <summary>
    ///   The alternate names button.
    /// </summary>
    private Button alternateNamesButton;

    /// <summary>
    ///   The format builder.
    /// </summary>
    private Button formatBuilder;

    /// <summary>
    ///   The remove show button.
    /// </summary>
    private Button removeShowButton;

    /// <summary>
    ///   The revert button.
    /// </summary>
    private Button revertButton;

    /// <summary>
    ///   The save button.
    /// </summary>
    private Button saveButton;

    /// <summary>
    ///   The search shows button.
    /// </summary>
    private Button searchShowsButton;

    /// <summary>
    ///   The selected show banner.
    /// </summary>
    private PictureBox selectedShowBanner;

    /// <summary>
    ///   The selected show custom format text.
    /// </summary>
    private TextBox selectedShowCustomFormatText;

    /// <summary>
    ///   The selected show folder name text.
    /// </summary>
    private TextBox selectedShowFolderNameText;

    /// <summary>
    ///   The selected show last updated.
    /// </summary>
    private Label selectedShowLastUpdated;

    /// <summary>
    ///   The selected show lock button.
    /// </summary>
    private Button selectedShowLockButton;

    /// <summary>
    ///   The selected show name.
    /// </summary>
    private Label selectedShowName;

    /// <summary>
    ///   The selected show tvdb.
    /// </summary>
    private Label selectedShowTvdb;

    /// <summary>
    ///   The selected show use custom format.
    /// </summary>
    private CheckBox selectedShowUseCustomFormat;

    /// <summary>
    ///   The selected show use dvd order.
    /// </summary>
    private CheckBox selectedShowUseDvdOrder;

    /// <summary>
    ///   The tv shows list.
    /// </summary>
    private ListBox tvShowsList;

    /// <summary>
    ///   The update all button.
    /// </summary>
    private Button updateAllButton;

    /// <summary>
    ///   The update show button.
    /// </summary>
    private Button updateShowButton;



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
        components = new Container();
        TableLayoutPanel selectedShowTable;
        GroupBox customSettingsGroup;
        Label destinationLabel;
        FlowLayoutPanel selectedShowButtons;
        Label folderNameLabel;
        GroupBox episodesGroup;
        selectedShowName = new Label();
        selectedShowBanner = new PictureBox();
        selectedShowLastUpdated = new Label();
        selectedShowTvdb = new Label();
        customFormatTable = new TableLayoutPanel();
        selectedShowUseCustomFormat = new CheckBox();
        selectedShowCustomFormatText = new TextBox();
        formatLabel = new Label();
        formatBuilder = new Button();
        useCustomDestinationDirectory = new CheckBox();
        customDestination = new ComboBox();
        saveButton = new Button();
        revertButton = new Button();
        updateShowButton = new Button();
        removeShowButton = new Button();
        resetLastUpdatedButton = new Button();
        namesGroup = new GroupBox();
        nameTable = new TableLayoutPanel();
        selectedShowFolderNameText = new TextBox();
        alternateNamesButton = new Button();
        episodesFlow = new FlowLayoutPanel();
        selectedShowUseDvdOrder = new CheckBox();
        selectedShowLockButton = new Button();
        updateAllButton = new Button();
        addShowButton = new Button();
        searchShowsButton = new Button();
        tvShowsList = new ListBox();
        topButtonsFlow = new FlowLayoutPanel();
        toolTip = new ToolTip(components);
        selectedShowTable = new TableLayoutPanel();
        customSettingsGroup = new GroupBox();
        destinationLabel = new Label();
        selectedShowButtons = new FlowLayoutPanel();
        folderNameLabel = new Label();
        episodesGroup = new GroupBox();
        selectedShowTable.SuspendLayout();
        ((ISupportInitialize)selectedShowBanner).BeginInit();
        customSettingsGroup.SuspendLayout();
        customFormatTable.SuspendLayout();
        selectedShowButtons.SuspendLayout();
        namesGroup.SuspendLayout();
        nameTable.SuspendLayout();
        episodesGroup.SuspendLayout();
        episodesFlow.SuspendLayout();
        topButtonsFlow.SuspendLayout();
        SuspendLayout();
        // 
        // selectedShowTable
        // 
        selectedShowTable.ColumnCount = 1;
        selectedShowTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        selectedShowTable.Controls.Add(selectedShowName, 0, 0);
        selectedShowTable.Controls.Add(selectedShowBanner, 0, 1);
        selectedShowTable.Controls.Add(selectedShowLastUpdated, 0, 3);
        selectedShowTable.Controls.Add(selectedShowTvdb, 0, 2);
        selectedShowTable.Controls.Add(customSettingsGroup, 0, 4);
        selectedShowTable.Controls.Add(selectedShowButtons, 0, 7);
        selectedShowTable.Controls.Add(namesGroup, 0, 5);
        selectedShowTable.Controls.Add(episodesGroup, 0, 6);
        selectedShowTable.Dock = DockStyle.Fill;
        selectedShowTable.Location = new Point(236, 53);
        selectedShowTable.Margin = new Padding(5, 4, 5, 4);
        selectedShowTable.Name = "selectedShowTable";
        selectedShowTable.RowCount = 8;
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 231F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 219F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 131F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 131F));
        selectedShowTable.RowStyles.Add(new RowStyle());
        selectedShowTable.Size = new Size(763, 999);
        selectedShowTable.TabIndex = 2;
        // 
        // selectedShowName
        // 
        selectedShowName.Anchor = AnchorStyles.Left;
        selectedShowName.AutoSize = true;
        selectedShowName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        selectedShowName.Location = new Point(5, 11);
        selectedShowName.Margin = new Padding(5, 0, 5, 0);
        selectedShowName.Name = "selectedShowName";
        selectedShowName.Size = new Size(157, 25);
        selectedShowName.TabIndex = 0;
        selectedShowName.Text = "Selected Show";
        // 
        // selectedShowBanner
        // 
        selectedShowBanner.Dock = DockStyle.Fill;
        selectedShowBanner.Location = new Point(5, 51);
        selectedShowBanner.Margin = new Padding(5, 4, 5, 4);
        selectedShowBanner.Name = "selectedShowBanner";
        selectedShowBanner.Size = new Size(753, 223);
        selectedShowBanner.TabIndex = 1;
        selectedShowBanner.TabStop = false;
        // 
        // selectedShowLastUpdated
        // 
        selectedShowLastUpdated.AutoSize = true;
        selectedShowLastUpdated.Dock = DockStyle.Fill;
        selectedShowLastUpdated.Location = new Point(5, 317);
        selectedShowLastUpdated.Margin = new Padding(5, 0, 5, 0);
        selectedShowLastUpdated.Name = "selectedShowLastUpdated";
        selectedShowLastUpdated.Size = new Size(753, 39);
        selectedShowLastUpdated.TabIndex = 2;
        selectedShowLastUpdated.Text = "Last Updated:";
        toolTip.SetToolTip(selectedShowLastUpdated, "The time that the show was last updated in TheTVDB.com's server time (UTC).");
        // 
        // selectedShowTvdb
        // 
        selectedShowTvdb.AutoSize = true;
        selectedShowTvdb.Dock = DockStyle.Fill;
        selectedShowTvdb.Location = new Point(5, 278);
        selectedShowTvdb.Margin = new Padding(5, 0, 5, 0);
        selectedShowTvdb.Name = "selectedShowTvdb";
        selectedShowTvdb.Size = new Size(753, 39);
        selectedShowTvdb.TabIndex = 3;
        selectedShowTvdb.Text = "TVDB ID: ";
        toolTip.SetToolTip(selectedShowTvdb, "The show's ID on TheTVDB.com");
        // 
        // customSettingsGroup
        // 
        customSettingsGroup.Controls.Add(customFormatTable);
        customSettingsGroup.Dock = DockStyle.Fill;
        customSettingsGroup.Location = new Point(5, 360);
        customSettingsGroup.Margin = new Padding(5, 4, 5, 4);
        customSettingsGroup.Name = "customSettingsGroup";
        customSettingsGroup.Padding = new Padding(5, 4, 5, 4);
        customSettingsGroup.Size = new Size(753, 211);
        customSettingsGroup.TabIndex = 4;
        customSettingsGroup.TabStop = false;
        customSettingsGroup.Text = "Custom Settings";
        // 
        // customFormatTable
        // 
        customFormatTable.ColumnCount = 3;
        customFormatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
        customFormatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        customFormatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
        customFormatTable.Controls.Add(selectedShowUseCustomFormat, 0, 0);
        customFormatTable.Controls.Add(selectedShowCustomFormatText, 1, 1);
        customFormatTable.Controls.Add(formatLabel, 0, 1);
        customFormatTable.Controls.Add(formatBuilder, 2, 1);
        customFormatTable.Controls.Add(useCustomDestinationDirectory, 0, 2);
        customFormatTable.Controls.Add(destinationLabel, 0, 3);
        customFormatTable.Controls.Add(customDestination, 1, 3);
        customFormatTable.Dock = DockStyle.Fill;
        customFormatTable.Location = new Point(5, 24);
        customFormatTable.Margin = new Padding(0);
        customFormatTable.Name = "customFormatTable";
        customFormatTable.RowCount = 4;
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        customFormatTable.Size = new Size(743, 183);
        customFormatTable.TabIndex = 3;
        // 
        // selectedShowUseCustomFormat
        // 
        selectedShowUseCustomFormat.Anchor = AnchorStyles.Left;
        selectedShowUseCustomFormat.AutoSize = true;
        customFormatTable.SetColumnSpan(selectedShowUseCustomFormat, 3);
        selectedShowUseCustomFormat.Location = new Point(5, 11);
        selectedShowUseCustomFormat.Margin = new Padding(5, 4, 5, 4);
        selectedShowUseCustomFormat.Name = "selectedShowUseCustomFormat";
        selectedShowUseCustomFormat.Size = new Size(160, 24);
        selectedShowUseCustomFormat.TabIndex = 0;
        selectedShowUseCustomFormat.Text = "Use Custom Format";
        toolTip.SetToolTip(selectedShowUseCustomFormat, "Indicates whether to use a custom format with this show.");
        selectedShowUseCustomFormat.UseVisualStyleBackColor = true;
        selectedShowUseCustomFormat.CheckedChanged += SelectedUseCustomFormatCheckedChanged;
        // 
        // selectedShowCustomFormatText
        // 
        selectedShowCustomFormatText.Dock = DockStyle.Fill;
        selectedShowCustomFormatText.Enabled = false;
        selectedShowCustomFormatText.Location = new Point(110, 51);
        selectedShowCustomFormatText.Margin = new Padding(5, 4, 5, 4);
        selectedShowCustomFormatText.Name = "selectedShowCustomFormatText";
        selectedShowCustomFormatText.Size = new Size(492, 27);
        selectedShowCustomFormatText.TabIndex = 2;
        toolTip.SetToolTip(selectedShowCustomFormatText, "The custom format to use for this show.");
        // 
        // formatLabel
        // 
        formatLabel.Anchor = AnchorStyles.Right;
        formatLabel.AutoSize = true;
        formatLabel.Location = new Point(41, 58);
        formatLabel.Margin = new Padding(5, 0, 5, 0);
        formatLabel.Name = "formatLabel";
        formatLabel.Size = new Size(59, 20);
        formatLabel.TabIndex = 1;
        formatLabel.Text = "Format:";
        // 
        // formatBuilder
        // 
        formatBuilder.Enabled = false;
        formatBuilder.Location = new Point(612, 51);
        formatBuilder.Margin = new Padding(5, 4, 5, 4);
        formatBuilder.Name = "formatBuilder";
        formatBuilder.Size = new Size(126, 33);
        formatBuilder.TabIndex = 3;
        formatBuilder.Text = "Format Builder";
        formatBuilder.UseVisualStyleBackColor = true;
        formatBuilder.Click += FormatBuilderClick;
        // 
        // useCustomDestinationDirectory
        // 
        useCustomDestinationDirectory.Anchor = AnchorStyles.Left;
        useCustomDestinationDirectory.AutoSize = true;
        customFormatTable.SetColumnSpan(useCustomDestinationDirectory, 2);
        useCustomDestinationDirectory.Location = new Point(5, 101);
        useCustomDestinationDirectory.Margin = new Padding(5, 4, 5, 4);
        useCustomDestinationDirectory.Name = "useCustomDestinationDirectory";
        useCustomDestinationDirectory.Size = new Size(254, 24);
        useCustomDestinationDirectory.TabIndex = 4;
        useCustomDestinationDirectory.Text = "Use Custom Destination Directory";
        useCustomDestinationDirectory.UseVisualStyleBackColor = true;
        useCustomDestinationDirectory.CheckedChanged += UseCustomDestinationDirectoryCheckedChanged;
        // 
        // destinationLabel
        // 
        destinationLabel.Anchor = AnchorStyles.Right;
        destinationLabel.AutoSize = true;
        destinationLabel.Location = new Point(12, 150);
        destinationLabel.Margin = new Padding(5, 0, 5, 0);
        destinationLabel.Name = "destinationLabel";
        destinationLabel.Size = new Size(88, 20);
        destinationLabel.TabIndex = 5;
        destinationLabel.Text = "Destination:";
        // 
        // customDestination
        // 
        customDestination.Dock = DockStyle.Fill;
        customDestination.DropDownStyle = ComboBoxStyle.DropDownList;
        customDestination.Enabled = false;
        customDestination.FormattingEnabled = true;
        customDestination.Location = new Point(110, 141);
        customDestination.Margin = new Padding(5, 4, 5, 4);
        customDestination.Name = "customDestination";
        customDestination.Size = new Size(492, 28);
        customDestination.TabIndex = 6;
        // 
        // selectedShowButtons
        // 
        selectedShowButtons.Controls.Add(saveButton);
        selectedShowButtons.Controls.Add(revertButton);
        selectedShowButtons.Controls.Add(updateShowButton);
        selectedShowButtons.Controls.Add(removeShowButton);
        selectedShowButtons.Controls.Add(resetLastUpdatedButton);
        selectedShowButtons.Dock = DockStyle.Fill;
        selectedShowButtons.Location = new Point(0, 837);
        selectedShowButtons.Margin = new Padding(0);
        selectedShowButtons.Name = "selectedShowButtons";
        selectedShowButtons.Size = new Size(763, 187);
        selectedShowButtons.TabIndex = 5;
        // 
        // saveButton
        // 
        saveButton.Location = new Point(5, 4);
        saveButton.Margin = new Padding(5, 4, 5, 4);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(101, 36);
        saveButton.TabIndex = 0;
        saveButton.Text = "Save";
        toolTip.SetToolTip(saveButton, "Saves any changes to the show's configuration.");
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButtonClick;
        // 
        // revertButton
        // 
        revertButton.Location = new Point(116, 4);
        revertButton.Margin = new Padding(5, 4, 5, 4);
        revertButton.Name = "revertButton";
        revertButton.Size = new Size(101, 36);
        revertButton.TabIndex = 1;
        revertButton.Text = "Revert";
        toolTip.SetToolTip(revertButton, "Revert's any unsaved changes to the show's configuration.");
        revertButton.UseVisualStyleBackColor = true;
        revertButton.Click += RevertButtonClick;
        // 
        // updateShowButton
        // 
        updateShowButton.Location = new Point(227, 4);
        updateShowButton.Margin = new Padding(5, 4, 5, 4);
        updateShowButton.Name = "updateShowButton";
        updateShowButton.Size = new Size(123, 36);
        updateShowButton.TabIndex = 2;
        updateShowButton.Text = "Update Show";
        toolTip.SetToolTip(updateShowButton, "Updates the show's episode data.");
        updateShowButton.UseVisualStyleBackColor = true;
        updateShowButton.Click += UpdateShowButtonClick;
        // 
        // removeShowButton
        // 
        removeShowButton.Location = new Point(360, 4);
        removeShowButton.Margin = new Padding(5, 4, 5, 4);
        removeShowButton.Name = "removeShowButton";
        removeShowButton.Size = new Size(101, 36);
        removeShowButton.TabIndex = 3;
        removeShowButton.Text = "Remove";
        toolTip.SetToolTip(removeShowButton, "Removes the show from TVSorter.");
        removeShowButton.UseVisualStyleBackColor = true;
        removeShowButton.Click += RemoveShowButtonClick;
        // 
        // resetLastUpdatedButton
        // 
        resetLastUpdatedButton.Location = new Point(471, 4);
        resetLastUpdatedButton.Margin = new Padding(5, 4, 5, 4);
        resetLastUpdatedButton.Name = "resetLastUpdatedButton";
        resetLastUpdatedButton.Size = new Size(153, 36);
        resetLastUpdatedButton.TabIndex = 4;
        resetLastUpdatedButton.Text = "Reset Last Updated";
        toolTip.SetToolTip(resetLastUpdatedButton, "Resets the Last Updated timestamp of the show. \r\nThis allows new data to be downloaded in the next\r\nupdate.");
        resetLastUpdatedButton.UseVisualStyleBackColor = true;
        resetLastUpdatedButton.Click += ResetLastUpdatedButtonClick;
        // 
        // namesGroup
        // 
        namesGroup.Controls.Add(nameTable);
        namesGroup.Dock = DockStyle.Fill;
        namesGroup.Location = new Point(5, 579);
        namesGroup.Margin = new Padding(5, 4, 5, 4);
        namesGroup.Name = "namesGroup";
        namesGroup.Padding = new Padding(5, 4, 5, 4);
        namesGroup.Size = new Size(753, 123);
        namesGroup.TabIndex = 6;
        namesGroup.TabStop = false;
        namesGroup.Text = "Names";
        // 
        // nameTable
        // 
        nameTable.ColumnCount = 3;
        nameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
        nameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        nameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
        nameTable.Controls.Add(folderNameLabel, 0, 0);
        nameTable.Controls.Add(selectedShowFolderNameText, 1, 0);
        nameTable.Controls.Add(alternateNamesButton, 1, 1);
        nameTable.Dock = DockStyle.Fill;
        nameTable.Location = new Point(5, 24);
        nameTable.Margin = new Padding(0);
        nameTable.Name = "nameTable";
        nameTable.RowCount = 2;
        nameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        nameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        nameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        nameTable.Size = new Size(743, 95);
        nameTable.TabIndex = 4;
        // 
        // folderNameLabel
        // 
        folderNameLabel.Anchor = AnchorStyles.Right;
        folderNameLabel.AutoSize = true;
        folderNameLabel.Location = new Point(46, 3);
        folderNameLabel.Margin = new Padding(5, 0, 5, 0);
        folderNameLabel.Name = "folderNameLabel";
        folderNameLabel.Size = new Size(55, 40);
        folderNameLabel.TabIndex = 1;
        folderNameLabel.Text = "Folder Name:";
        // 
        // selectedShowFolderNameText
        // 
        selectedShowFolderNameText.Dock = DockStyle.Fill;
        selectedShowFolderNameText.Location = new Point(111, 4);
        selectedShowFolderNameText.Margin = new Padding(5, 4, 5, 4);
        selectedShowFolderNameText.Name = "selectedShowFolderNameText";
        selectedShowFolderNameText.Size = new Size(491, 27);
        selectedShowFolderNameText.TabIndex = 2;
        toolTip.SetToolTip(selectedShowFolderNameText, "The folder name that the show is in.");
        // 
        // alternateNamesButton
        // 
        alternateNamesButton.Location = new Point(111, 51);
        alternateNamesButton.Margin = new Padding(5, 4, 5, 4);
        alternateNamesButton.Name = "alternateNamesButton";
        alternateNamesButton.Size = new Size(134, 33);
        alternateNamesButton.TabIndex = 3;
        alternateNamesButton.Text = "Alternate Names";
        toolTip.SetToolTip(alternateNamesButton, "Edit the alternate names used by the show.");
        alternateNamesButton.UseVisualStyleBackColor = true;
        alternateNamesButton.Click += AlternateNamesButtonClick;
        // 
        // episodesGroup
        // 
        episodesGroup.Controls.Add(episodesFlow);
        episodesGroup.Dock = DockStyle.Fill;
        episodesGroup.Location = new Point(5, 710);
        episodesGroup.Margin = new Padding(5, 4, 5, 4);
        episodesGroup.Name = "episodesGroup";
        episodesGroup.Padding = new Padding(5, 4, 5, 4);
        episodesGroup.Size = new Size(753, 123);
        episodesGroup.TabIndex = 7;
        episodesGroup.TabStop = false;
        episodesGroup.Text = "Episodes";
        // 
        // episodesFlow
        // 
        episodesFlow.Controls.Add(selectedShowUseDvdOrder);
        episodesFlow.Controls.Add(selectedShowLockButton);
        episodesFlow.Dock = DockStyle.Fill;
        episodesFlow.FlowDirection = FlowDirection.TopDown;
        episodesFlow.Location = new Point(5, 24);
        episodesFlow.Margin = new Padding(5, 4, 5, 4);
        episodesFlow.Name = "episodesFlow";
        episodesFlow.Size = new Size(743, 95);
        episodesFlow.TabIndex = 1;
        // 
        // selectedShowUseDvdOrder
        // 
        selectedShowUseDvdOrder.AutoSize = true;
        selectedShowUseDvdOrder.Location = new Point(5, 4);
        selectedShowUseDvdOrder.Margin = new Padding(5, 4, 5, 4);
        selectedShowUseDvdOrder.Name = "selectedShowUseDvdOrder";
        selectedShowUseDvdOrder.Size = new Size(132, 24);
        selectedShowUseDvdOrder.TabIndex = 0;
        selectedShowUseDvdOrder.Text = "Use DVD Order";
        toolTip.SetToolTip(selectedShowUseDvdOrder, "Indicates whether the show should use the DVD order for episodes.");
        selectedShowUseDvdOrder.UseVisualStyleBackColor = true;
        // 
        // selectedShowLockButton
        // 
        selectedShowLockButton.Location = new Point(5, 36);
        selectedShowLockButton.Margin = new Padding(5, 4, 5, 4);
        selectedShowLockButton.Name = "selectedShowLockButton";
        selectedShowLockButton.Size = new Size(120, 36);
        selectedShowLockButton.TabIndex = 1;
        selectedShowLockButton.Text = "Unlock Show";
        toolTip.SetToolTip(selectedShowLockButton, "Locks/Unlocks  the show.");
        selectedShowLockButton.UseVisualStyleBackColor = true;
        selectedShowLockButton.Click += SelectedShowLockButtonClick;
        // 
        // updateAllButton
        // 
        updateAllButton.Location = new Point(5, 4);
        updateAllButton.Margin = new Padding(5, 4, 5, 4);
        updateAllButton.Name = "updateAllButton";
        updateAllButton.Size = new Size(101, 36);
        updateAllButton.TabIndex = 0;
        updateAllButton.Text = "Update All";
        toolTip.SetToolTip(updateAllButton, "Updates the episode data for all the unlocked shows.");
        updateAllButton.UseVisualStyleBackColor = true;
        updateAllButton.Click += UpdateAllButtonClick;
        // 
        // addShowButton
        // 
        addShowButton.Location = new Point(116, 4);
        addShowButton.Margin = new Padding(5, 4, 5, 4);
        addShowButton.Name = "addShowButton";
        addShowButton.Size = new Size(101, 36);
        addShowButton.TabIndex = 1;
        addShowButton.Text = "Add Show";
        toolTip.SetToolTip(addShowButton, "Adds a new show.");
        addShowButton.UseVisualStyleBackColor = true;
        addShowButton.Click += AddShowButtonClick;
        // 
        // searchShowsButton
        // 
        searchShowsButton.Location = new Point(227, 4);
        searchShowsButton.Margin = new Padding(5, 4, 5, 4);
        searchShowsButton.Name = "searchShowsButton";
        searchShowsButton.Size = new Size(150, 36);
        searchShowsButton.TabIndex = 2;
        searchShowsButton.Text = "Search for Shows";
        toolTip.SetToolTip(searchShowsButton, "Searches for new shows in the output directories.\r\nThis looks up shows by folder name.");
        searchShowsButton.UseVisualStyleBackColor = true;
        searchShowsButton.Click += SearchShowsButtonClick;
        // 
        // tvShowsList
        // 
        tvShowsList.Dock = DockStyle.Left;
        tvShowsList.DrawMode = DrawMode.OwnerDrawVariable;
        tvShowsList.FormattingEnabled = true;
        tvShowsList.Location = new Point(0, 53);
        tvShowsList.Margin = new Padding(5, 4, 5, 4);
        tvShowsList.Name = "tvShowsList";
        tvShowsList.Size = new Size(236, 999);
        tvShowsList.TabIndex = 1;
        tvShowsList.DrawItem += TvShowsListDrawItem;
        tvShowsList.SelectedIndexChanged += TvShowsListSelectedIndexChanged;
        // 
        // topButtonsFlow
        // 
        topButtonsFlow.Controls.Add(updateAllButton);
        topButtonsFlow.Controls.Add(addShowButton);
        topButtonsFlow.Controls.Add(searchShowsButton);
        topButtonsFlow.Dock = DockStyle.Top;
        topButtonsFlow.Location = new Point(0, 0);
        topButtonsFlow.Margin = new Padding(5, 4, 5, 4);
        topButtonsFlow.Name = "topButtonsFlow";
        topButtonsFlow.Size = new Size(999, 53);
        topButtonsFlow.TabIndex = 0;
        // 
        // TvShows
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(selectedShowTable);
        Controls.Add(tvShowsList);
        Controls.Add(topButtonsFlow);
        Margin = new Padding(5, 4, 5, 4);
        Name = "TvShows";
        Size = new Size(999, 1052);
        Load += TvShowsLoad;
        selectedShowTable.ResumeLayout(false);
        selectedShowTable.PerformLayout();
        ((ISupportInitialize)selectedShowBanner).EndInit();
        customSettingsGroup.ResumeLayout(false);
        customFormatTable.ResumeLayout(false);
        customFormatTable.PerformLayout();
        selectedShowButtons.ResumeLayout(false);
        namesGroup.ResumeLayout(false);
        nameTable.ResumeLayout(false);
        nameTable.PerformLayout();
        episodesGroup.ResumeLayout(false);
        episodesFlow.ResumeLayout(false);
        episodesFlow.PerformLayout();
        topButtonsFlow.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel customFormatTable;
    private Label formatLabel;
    private FlowLayoutPanel topButtonsFlow;
    private GroupBox namesGroup;
    private TableLayoutPanel nameTable;
    private FlowLayoutPanel episodesFlow;
    private Button resetLastUpdatedButton;
    private ToolTip toolTip;
    private IContainer components;
    private ComboBox customDestination;
    private CheckBox useCustomDestinationDirectory;
}