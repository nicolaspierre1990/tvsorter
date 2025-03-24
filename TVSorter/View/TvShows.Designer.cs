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
        selectedShowTable.Location = new Point(207, 40);
        selectedShowTable.Margin = new Padding(4, 3, 4, 3);
        selectedShowTable.Name = "selectedShowTable";
        selectedShowTable.RowCount = 8;
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 173F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 164F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
        selectedShowTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
        selectedShowTable.RowStyles.Add(new RowStyle());
        selectedShowTable.Size = new Size(667, 749);
        selectedShowTable.TabIndex = 2;
        // 
        // selectedShowName
        // 
        selectedShowName.Anchor = AnchorStyles.Left;
        selectedShowName.AutoSize = true;
        selectedShowName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        selectedShowName.Location = new Point(4, 7);
        selectedShowName.Margin = new Padding(4, 0, 4, 0);
        selectedShowName.Name = "selectedShowName";
        selectedShowName.Size = new Size(129, 20);
        selectedShowName.TabIndex = 0;
        selectedShowName.Text = "Selected Show";
        // 
        // selectedShowBanner
        // 
        selectedShowBanner.Dock = DockStyle.Fill;
        selectedShowBanner.Location = new Point(4, 38);
        selectedShowBanner.Margin = new Padding(4, 3, 4, 3);
        selectedShowBanner.Name = "selectedShowBanner";
        selectedShowBanner.Size = new Size(659, 167);
        selectedShowBanner.TabIndex = 1;
        selectedShowBanner.TabStop = false;
        // 
        // selectedShowLastUpdated
        // 
        selectedShowLastUpdated.AutoSize = true;
        selectedShowLastUpdated.Dock = DockStyle.Fill;
        selectedShowLastUpdated.Location = new Point(4, 237);
        selectedShowLastUpdated.Margin = new Padding(4, 0, 4, 0);
        selectedShowLastUpdated.Name = "selectedShowLastUpdated";
        selectedShowLastUpdated.Size = new Size(659, 29);
        selectedShowLastUpdated.TabIndex = 2;
        selectedShowLastUpdated.Text = "Last Updated:";
        toolTip.SetToolTip(selectedShowLastUpdated, "The time that the show was last updated in TheTVDB.com's server time (UTC).");
        // 
        // selectedShowTvdb
        // 
        selectedShowTvdb.AutoSize = true;
        selectedShowTvdb.Dock = DockStyle.Fill;
        selectedShowTvdb.Location = new Point(4, 208);
        selectedShowTvdb.Margin = new Padding(4, 0, 4, 0);
        selectedShowTvdb.Name = "selectedShowTvdb";
        selectedShowTvdb.Size = new Size(659, 29);
        selectedShowTvdb.TabIndex = 3;
        selectedShowTvdb.Text = "TVDB ID: ";
        toolTip.SetToolTip(selectedShowTvdb, "The show's ID on TheTVDB.com");
        // 
        // customSettingsGroup
        // 
        customSettingsGroup.Controls.Add(customFormatTable);
        customSettingsGroup.Dock = DockStyle.Fill;
        customSettingsGroup.Location = new Point(4, 269);
        customSettingsGroup.Margin = new Padding(4, 3, 4, 3);
        customSettingsGroup.Name = "customSettingsGroup";
        customSettingsGroup.Padding = new Padding(4, 3, 4, 3);
        customSettingsGroup.Size = new Size(659, 158);
        customSettingsGroup.TabIndex = 4;
        customSettingsGroup.TabStop = false;
        customSettingsGroup.Text = "Custom Settings";
        // 
        // customFormatTable
        // 
        customFormatTable.ColumnCount = 3;
        customFormatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        customFormatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        customFormatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
        customFormatTable.Controls.Add(selectedShowUseCustomFormat, 0, 0);
        customFormatTable.Controls.Add(selectedShowCustomFormatText, 1, 1);
        customFormatTable.Controls.Add(formatLabel, 0, 1);
        customFormatTable.Controls.Add(formatBuilder, 2, 1);
        customFormatTable.Controls.Add(useCustomDestinationDirectory, 0, 2);
        customFormatTable.Controls.Add(destinationLabel, 0, 3);
        customFormatTable.Controls.Add(customDestination, 1, 3);
        customFormatTable.Dock = DockStyle.Fill;
        customFormatTable.Location = new Point(4, 19);
        customFormatTable.Margin = new Padding(0);
        customFormatTable.Name = "customFormatTable";
        customFormatTable.RowCount = 4;
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        customFormatTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        customFormatTable.Size = new Size(651, 136);
        customFormatTable.TabIndex = 3;
        // 
        // selectedShowUseCustomFormat
        // 
        selectedShowUseCustomFormat.Anchor = AnchorStyles.Left;
        selectedShowUseCustomFormat.AutoSize = true;
        customFormatTable.SetColumnSpan(selectedShowUseCustomFormat, 3);
        selectedShowUseCustomFormat.Location = new Point(4, 8);
        selectedShowUseCustomFormat.Margin = new Padding(4, 3, 4, 3);
        selectedShowUseCustomFormat.Name = "selectedShowUseCustomFormat";
        selectedShowUseCustomFormat.Size = new Size(131, 19);
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
        selectedShowCustomFormatText.Location = new Point(96, 38);
        selectedShowCustomFormatText.Margin = new Padding(4, 3, 4, 3);
        selectedShowCustomFormatText.Name = "selectedShowCustomFormatText";
        selectedShowCustomFormatText.Size = new Size(432, 23);
        selectedShowCustomFormatText.TabIndex = 2;
        toolTip.SetToolTip(selectedShowCustomFormatText, "The custom format to use for this show.");
        // 
        // formatLabel
        // 
        formatLabel.Anchor = AnchorStyles.Right;
        formatLabel.AutoSize = true;
        formatLabel.Location = new Point(40, 43);
        formatLabel.Margin = new Padding(4, 0, 4, 0);
        formatLabel.Name = "formatLabel";
        formatLabel.Size = new Size(48, 15);
        formatLabel.TabIndex = 1;
        formatLabel.Text = "Format:";
        // 
        // formatBuilder
        // 
        formatBuilder.Enabled = false;
        formatBuilder.Location = new Point(536, 38);
        formatBuilder.Margin = new Padding(4, 3, 4, 3);
        formatBuilder.Name = "formatBuilder";
        formatBuilder.Size = new Size(111, 25);
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
        useCustomDestinationDirectory.Location = new Point(4, 75);
        useCustomDestinationDirectory.Margin = new Padding(4, 3, 4, 3);
        useCustomDestinationDirectory.Name = "useCustomDestinationDirectory";
        useCustomDestinationDirectory.Size = new Size(204, 19);
        useCustomDestinationDirectory.TabIndex = 4;
        useCustomDestinationDirectory.Text = "Use Custom Destination Directory";
        useCustomDestinationDirectory.UseVisualStyleBackColor = true;
        useCustomDestinationDirectory.CheckedChanged += UseCustomDestinationDirectoryCheckedChanged;
        // 
        // destinationLabel
        // 
        destinationLabel.Anchor = AnchorStyles.Right;
        destinationLabel.AutoSize = true;
        destinationLabel.Location = new Point(18, 111);
        destinationLabel.Margin = new Padding(4, 0, 4, 0);
        destinationLabel.Name = "destinationLabel";
        destinationLabel.Size = new Size(70, 15);
        destinationLabel.TabIndex = 5;
        destinationLabel.Text = "Destination:";
        // 
        // customDestination
        // 
        customDestination.Dock = DockStyle.Fill;
        customDestination.DropDownStyle = ComboBoxStyle.DropDownList;
        customDestination.Enabled = false;
        customDestination.FormattingEnabled = true;
        customDestination.Location = new Point(96, 105);
        customDestination.Margin = new Padding(4, 3, 4, 3);
        customDestination.Name = "customDestination";
        customDestination.Size = new Size(432, 23);
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
        selectedShowButtons.Location = new Point(0, 626);
        selectedShowButtons.Margin = new Padding(0);
        selectedShowButtons.Name = "selectedShowButtons";
        selectedShowButtons.Size = new Size(667, 140);
        selectedShowButtons.TabIndex = 5;
        // 
        // saveButton
        // 
        saveButton.Location = new Point(4, 3);
        saveButton.Margin = new Padding(4, 3, 4, 3);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(88, 27);
        saveButton.TabIndex = 0;
        saveButton.Text = "Save";
        toolTip.SetToolTip(saveButton, "Saves any changes to the show's configuration.");
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButtonClick;
        // 
        // revertButton
        // 
        revertButton.Location = new Point(100, 3);
        revertButton.Margin = new Padding(4, 3, 4, 3);
        revertButton.Name = "revertButton";
        revertButton.Size = new Size(88, 27);
        revertButton.TabIndex = 1;
        revertButton.Text = "Revert";
        toolTip.SetToolTip(revertButton, "Revert's any unsaved changes to the show's configuration.");
        revertButton.UseVisualStyleBackColor = true;
        revertButton.Click += RevertButtonClick;
        // 
        // updateShowButton
        // 
        updateShowButton.Location = new Point(196, 3);
        updateShowButton.Margin = new Padding(4, 3, 4, 3);
        updateShowButton.Name = "updateShowButton";
        updateShowButton.Size = new Size(108, 27);
        updateShowButton.TabIndex = 2;
        updateShowButton.Text = "Update Show";
        toolTip.SetToolTip(updateShowButton, "Updates the show's episode data.");
        updateShowButton.UseVisualStyleBackColor = true;
        updateShowButton.Click += UpdateShowButtonClick;
        // 
        // removeShowButton
        // 
        removeShowButton.Location = new Point(312, 3);
        removeShowButton.Margin = new Padding(4, 3, 4, 3);
        removeShowButton.Name = "removeShowButton";
        removeShowButton.Size = new Size(88, 27);
        removeShowButton.TabIndex = 3;
        removeShowButton.Text = "Remove";
        toolTip.SetToolTip(removeShowButton, "Removes the show from TVSorter.");
        removeShowButton.UseVisualStyleBackColor = true;
        removeShowButton.Click += RemoveShowButtonClick;
        // 
        // resetLastUpdatedButton
        // 
        resetLastUpdatedButton.Location = new Point(408, 3);
        resetLastUpdatedButton.Margin = new Padding(4, 3, 4, 3);
        resetLastUpdatedButton.Name = "resetLastUpdatedButton";
        resetLastUpdatedButton.Size = new Size(134, 27);
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
        namesGroup.Location = new Point(4, 433);
        namesGroup.Margin = new Padding(4, 3, 4, 3);
        namesGroup.Name = "namesGroup";
        namesGroup.Padding = new Padding(4, 3, 4, 3);
        namesGroup.Size = new Size(659, 92);
        namesGroup.TabIndex = 6;
        namesGroup.TabStop = false;
        namesGroup.Text = "Names";
        // 
        // nameTable
        // 
        nameTable.ColumnCount = 3;
        nameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
        nameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        nameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
        nameTable.Controls.Add(folderNameLabel, 0, 0);
        nameTable.Controls.Add(selectedShowFolderNameText, 1, 0);
        nameTable.Controls.Add(alternateNamesButton, 1, 1);
        nameTable.Dock = DockStyle.Fill;
        nameTable.Location = new Point(4, 19);
        nameTable.Margin = new Padding(0);
        nameTable.Name = "nameTable";
        nameTable.RowCount = 2;
        nameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        nameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        nameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
        nameTable.Size = new Size(651, 70);
        nameTable.TabIndex = 4;
        // 
        // folderNameLabel
        // 
        folderNameLabel.Anchor = AnchorStyles.Right;
        folderNameLabel.AutoSize = true;
        folderNameLabel.Location = new Point(11, 10);
        folderNameLabel.Margin = new Padding(4, 0, 4, 0);
        folderNameLabel.Name = "folderNameLabel";
        folderNameLabel.Size = new Size(78, 15);
        folderNameLabel.TabIndex = 1;
        folderNameLabel.Text = "Folder Name:";
        // 
        // selectedShowFolderNameText
        // 
        selectedShowFolderNameText.Dock = DockStyle.Fill;
        selectedShowFolderNameText.Location = new Point(97, 3);
        selectedShowFolderNameText.Margin = new Padding(4, 3, 4, 3);
        selectedShowFolderNameText.Name = "selectedShowFolderNameText";
        selectedShowFolderNameText.Size = new Size(431, 23);
        selectedShowFolderNameText.TabIndex = 2;
        toolTip.SetToolTip(selectedShowFolderNameText, "The folder name that the show is in.");
        // 
        // alternateNamesButton
        // 
        alternateNamesButton.Location = new Point(97, 38);
        alternateNamesButton.Margin = new Padding(4, 3, 4, 3);
        alternateNamesButton.Name = "alternateNamesButton";
        alternateNamesButton.Size = new Size(117, 25);
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
        episodesGroup.Location = new Point(4, 531);
        episodesGroup.Margin = new Padding(4, 3, 4, 3);
        episodesGroup.Name = "episodesGroup";
        episodesGroup.Padding = new Padding(4, 3, 4, 3);
        episodesGroup.Size = new Size(659, 92);
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
        episodesFlow.Location = new Point(4, 19);
        episodesFlow.Margin = new Padding(4, 3, 4, 3);
        episodesFlow.Name = "episodesFlow";
        episodesFlow.Size = new Size(651, 70);
        episodesFlow.TabIndex = 1;
        // 
        // selectedShowUseDvdOrder
        // 
        selectedShowUseDvdOrder.AutoSize = true;
        selectedShowUseDvdOrder.Location = new Point(4, 3);
        selectedShowUseDvdOrder.Margin = new Padding(4, 3, 4, 3);
        selectedShowUseDvdOrder.Name = "selectedShowUseDvdOrder";
        selectedShowUseDvdOrder.Size = new Size(104, 19);
        selectedShowUseDvdOrder.TabIndex = 0;
        selectedShowUseDvdOrder.Text = "Use DVD Order";
        toolTip.SetToolTip(selectedShowUseDvdOrder, "Indicates whether the show should use the DVD order for episodes.");
        selectedShowUseDvdOrder.UseVisualStyleBackColor = true;
        // 
        // selectedShowLockButton
        // 
        selectedShowLockButton.Location = new Point(4, 28);
        selectedShowLockButton.Margin = new Padding(4, 3, 4, 3);
        selectedShowLockButton.Name = "selectedShowLockButton";
        selectedShowLockButton.Size = new Size(105, 27);
        selectedShowLockButton.TabIndex = 1;
        selectedShowLockButton.Text = "Unlock Show";
        toolTip.SetToolTip(selectedShowLockButton, "Locks/Unlocks  the show.");
        selectedShowLockButton.UseVisualStyleBackColor = true;
        selectedShowLockButton.Click += SelectedShowLockButtonClick;
        // 
        // updateAllButton
        // 
        updateAllButton.Location = new Point(4, 3);
        updateAllButton.Margin = new Padding(4, 3, 4, 3);
        updateAllButton.Name = "updateAllButton";
        updateAllButton.Size = new Size(88, 27);
        updateAllButton.TabIndex = 0;
        updateAllButton.Text = "Update All";
        toolTip.SetToolTip(updateAllButton, "Updates the episode data for all the unlocked shows.");
        updateAllButton.UseVisualStyleBackColor = true;
        updateAllButton.Click += UpdateAllButtonClick;
        // 
        // addShowButton
        // 
        addShowButton.Location = new Point(100, 3);
        addShowButton.Margin = new Padding(4, 3, 4, 3);
        addShowButton.Name = "addShowButton";
        addShowButton.Size = new Size(88, 27);
        addShowButton.TabIndex = 1;
        addShowButton.Text = "Add Show";
        toolTip.SetToolTip(addShowButton, "Adds a new show.");
        addShowButton.UseVisualStyleBackColor = true;
        addShowButton.Click += AddShowButtonClick;
        // 
        // searchShowsButton
        // 
        searchShowsButton.Location = new Point(196, 3);
        searchShowsButton.Margin = new Padding(4, 3, 4, 3);
        searchShowsButton.Name = "searchShowsButton";
        searchShowsButton.Size = new Size(131, 27);
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
        tvShowsList.ItemHeight = 20;
        tvShowsList.Location = new Point(0, 40);
        tvShowsList.Margin = new Padding(4, 3, 4, 3);
        tvShowsList.Name = "tvShowsList";
        tvShowsList.Size = new Size(207, 749);
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
        topButtonsFlow.Margin = new Padding(4, 3, 4, 3);
        topButtonsFlow.Name = "topButtonsFlow";
        topButtonsFlow.Size = new Size(874, 40);
        topButtonsFlow.TabIndex = 0;
        // 
        // TvShows
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(selectedShowTable);
        Controls.Add(tvShowsList);
        Controls.Add(topButtonsFlow);
        Margin = new Padding(4, 3, 4, 3);
        Name = "TvShows";
        Size = new Size(874, 789);
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