// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="Settings.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The settings tab.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View
{


    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;


    /// <summary>
    /// The settings tab.
    /// </summary>
    public partial class Settings
    {



        /// <summary>
        ///   The add destination button.
        /// </summary>
        private Button addDestinationButton;

        /// <summary>
        ///   The delete empty check.
        /// </summary>
        private CheckBox deleteEmptyCheck;

        /// <summary>
        ///   The destination list.
        /// </summary>
        private ListBox destinationList;

        /// <summary>
        ///   The file extensions button.
        /// </summary>
        private Button fileExtensionsButton;

        /// <summary>
        ///   The folder dialog.
        /// </summary>
        private FolderBrowserDialog folderDialog;

        /// <summary>
        ///   The format builder button.
        /// </summary>
        private Button formatBuilderButton;

        /// <summary>
        ///   The format text.
        /// </summary>
        private TextBox formatText;

        /// <summary>
        ///   The group directories.
        /// </summary>
        private GroupBox groupDirectories;

        /// <summary>
        ///   The recurse subdirectories check.
        /// </summary>
        private CheckBox recurseSubdirectoriesCheck;

        /// <summary>
        ///   The reg ex button.
        /// </summary>
        private Button regExButton;

        /// <summary>
        ///   The remove destination button.
        /// </summary>
        private Button removeDestinationButton;

        /// <summary>
        ///   The rename if exists check.
        /// </summary>
        private CheckBox renameIfExistsCheck;

        /// <summary>
        ///   The revert button.
        /// </summary>
        private Button revertButton;

        /// <summary>
        ///   The save button.
        /// </summary>
        private Button saveButton;

        /// <summary>
        ///   The source browse.
        /// </summary>
        private Button sourceBrowse;

        /// <summary>
        ///   The source text.
        /// </summary>
        private TextBox sourceText;



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
            TableLayoutPanel mainTable;
            TableLayoutPanel tableDirectories;
            Label sourceLabel;
            Label destinationListLabel;
            FlowLayoutPanel destinationButtonsFlow;
            Label defaultDestinationLabel;
            GroupBox sortOptionsGroup;
            FlowLayoutPanel sortOptionsFlow;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Settings));
            GroupBox searchOptionsGroup;
            FlowLayoutPanel searchOptionsFlow;
            Button editOverwriteKeywordsButton;
            GroupBox formatOptionsGroup;
            TableLayoutPanel formatTable;
            Label formatLabel;
            FlowLayoutPanel flowBottomButtons;
            groupDirectories = new GroupBox();
            sourceText = new TextBox();
            sourceBrowse = new Button();
            destinationList = new ListBox();
            addDestinationButton = new Button();
            removeDestinationButton = new Button();
            defaultDestinationDirectory = new ComboBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            addIgnore_btn = new Button();
            removeIgnore_btn = new Button();
            ignoreList = new ListBox();
            recurseSubdirectoriesCheck = new CheckBox();
            deleteEmptyCheck = new CheckBox();
            renameIfExistsCheck = new CheckBox();
            addUnmatchedShowsCheck = new CheckBox();
            unlockAndUpdateCheck = new CheckBox();
            lockShowWithNoNewEpisodesCheck = new CheckBox();
            regExButton = new Button();
            fileExtensionsButton = new Button();
            formatText = new TextBox();
            formatBuilderButton = new Button();
            revertButton = new Button();
            saveButton = new Button();
            folderDialog = new FolderBrowserDialog();
            toolTip = new ToolTip(components);
            mainTable = new TableLayoutPanel();
            tableDirectories = new TableLayoutPanel();
            sourceLabel = new Label();
            destinationListLabel = new Label();
            destinationButtonsFlow = new FlowLayoutPanel();
            defaultDestinationLabel = new Label();
            sortOptionsGroup = new GroupBox();
            sortOptionsFlow = new FlowLayoutPanel();
            searchOptionsGroup = new GroupBox();
            searchOptionsFlow = new FlowLayoutPanel();
            editOverwriteKeywordsButton = new Button();
            formatOptionsGroup = new GroupBox();
            formatTable = new TableLayoutPanel();
            formatLabel = new Label();
            flowBottomButtons = new FlowLayoutPanel();
            mainTable.SuspendLayout();
            groupDirectories.SuspendLayout();
            tableDirectories.SuspendLayout();
            destinationButtonsFlow.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            sortOptionsGroup.SuspendLayout();
            sortOptionsFlow.SuspendLayout();
            searchOptionsGroup.SuspendLayout();
            searchOptionsFlow.SuspendLayout();
            formatOptionsGroup.SuspendLayout();
            formatTable.SuspendLayout();
            flowBottomButtons.SuspendLayout();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 1;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTable.Controls.Add(groupDirectories, 0, 0);
            mainTable.Controls.Add(sortOptionsGroup, 0, 2);
            mainTable.Controls.Add(searchOptionsGroup, 0, 3);
            mainTable.Controls.Add(formatOptionsGroup, 0, 1);
            mainTable.Controls.Add(flowBottomButtons, 0, 4);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(0, 0);
            mainTable.Margin = new Padding(4, 5, 4, 5);
            mainTable.Name = "mainTable";
            mainTable.RowCount = 5;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 146F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            mainTable.Size = new Size(979, 1003);
            mainTable.TabIndex = 0;
            // 
            // groupDirectories
            // 
            groupDirectories.AutoSize = true;
            groupDirectories.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupDirectories.Controls.Add(tableDirectories);
            groupDirectories.Dock = DockStyle.Fill;
            groupDirectories.Location = new Point(4, 5);
            groupDirectories.Margin = new Padding(4, 5, 4, 5);
            groupDirectories.Name = "groupDirectories";
            groupDirectories.Padding = new Padding(4, 5, 4, 5);
            groupDirectories.Size = new Size(971, 616);
            groupDirectories.TabIndex = 0;
            groupDirectories.TabStop = false;
            groupDirectories.Text = "Directory Settings";
            // 
            // tableDirectories
            // 
            tableDirectories.AutoSize = true;
            tableDirectories.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableDirectories.ColumnCount = 3;
            tableDirectories.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168F));
            tableDirectories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableDirectories.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableDirectories.Controls.Add(sourceLabel, 0, 0);
            tableDirectories.Controls.Add(sourceText, 1, 0);
            tableDirectories.Controls.Add(sourceBrowse, 2, 0);
            tableDirectories.Controls.Add(destinationListLabel, 0, 1);
            tableDirectories.Controls.Add(destinationList, 1, 1);
            tableDirectories.Controls.Add(destinationButtonsFlow, 2, 1);
            tableDirectories.Controls.Add(defaultDestinationDirectory, 1, 3);
            tableDirectories.Controls.Add(label1, 0, 2);
            tableDirectories.Controls.Add(flowLayoutPanel1, 2, 2);
            tableDirectories.Controls.Add(ignoreList, 1, 2);
            tableDirectories.Controls.Add(defaultDestinationLabel, 0, 3);
            tableDirectories.Dock = DockStyle.Fill;
            tableDirectories.Location = new Point(4, 25);
            tableDirectories.Margin = new Padding(4, 5, 4, 5);
            tableDirectories.Name = "tableDirectories";
            tableDirectories.RowCount = 4;
            tableDirectories.RowStyles.Add(new RowStyle());
            tableDirectories.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableDirectories.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableDirectories.RowStyles.Add(new RowStyle());
            tableDirectories.Size = new Size(963, 586);
            tableDirectories.TabIndex = 0;
            // 
            // sourceLabel
            // 
            sourceLabel.Anchor = AnchorStyles.Right;
            sourceLabel.AutoSize = true;
            sourceLabel.Location = new Point(42, 21);
            sourceLabel.Margin = new Padding(4, 0, 4, 0);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(122, 20);
            sourceLabel.TabIndex = 0;
            sourceLabel.Text = "Source Directory:";
            // 
            // sourceText
            // 
            sourceText.Dock = DockStyle.Fill;
            sourceText.Location = new Point(172, 5);
            sourceText.Margin = new Padding(4, 5, 4, 5);
            sourceText.Name = "sourceText";
            sourceText.ReadOnly = true;
            sourceText.Size = new Size(647, 27);
            sourceText.TabIndex = 1;
            toolTip.SetToolTip(sourceText, "The source directory to search for TV Show files.");
            // 
            // sourceBrowse
            // 
            sourceBrowse.Dock = DockStyle.Fill;
            sourceBrowse.Location = new Point(827, 5);
            sourceBrowse.Margin = new Padding(4, 5, 4, 5);
            sourceBrowse.Name = "sourceBrowse";
            sourceBrowse.Size = new Size(132, 52);
            sourceBrowse.TabIndex = 2;
            sourceBrowse.Text = "Browse";
            sourceBrowse.UseVisualStyleBackColor = true;
            sourceBrowse.Click += SourceBrowseClick;
            // 
            // destinationListLabel
            // 
            destinationListLabel.Anchor = AnchorStyles.Right;
            destinationListLabel.AutoSize = true;
            destinationListLabel.Location = new Point(75, 163);
            destinationListLabel.Margin = new Padding(4, 0, 4, 0);
            destinationListLabel.Name = "destinationListLabel";
            destinationListLabel.Size = new Size(89, 40);
            destinationListLabel.TabIndex = 5;
            destinationListLabel.Text = "Destination Directories:";
            // 
            // destinationList
            // 
            destinationList.Dock = DockStyle.Fill;
            destinationList.FormattingEnabled = true;
            destinationList.Location = new Point(172, 67);
            destinationList.Margin = new Padding(4, 5, 4, 5);
            destinationList.Name = "destinationList";
            destinationList.Size = new Size(647, 233);
            destinationList.TabIndex = 6;
            toolTip.SetToolTip(destinationList, "All the directories where TV Shows are stored. Only the selected one will have TV moved to it but all will be used in Missing and Duplicate episode searches.");
            // 
            // destinationButtonsFlow
            // 
            destinationButtonsFlow.AutoSize = true;
            destinationButtonsFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            destinationButtonsFlow.Controls.Add(addDestinationButton);
            destinationButtonsFlow.Controls.Add(removeDestinationButton);
            destinationButtonsFlow.Dock = DockStyle.Fill;
            destinationButtonsFlow.FlowDirection = FlowDirection.TopDown;
            destinationButtonsFlow.Location = new Point(823, 62);
            destinationButtonsFlow.Margin = new Padding(0);
            destinationButtonsFlow.Name = "destinationButtonsFlow";
            destinationButtonsFlow.Size = new Size(140, 243);
            destinationButtonsFlow.TabIndex = 7;
            // 
            // addDestinationButton
            // 
            addDestinationButton.Location = new Point(4, 5);
            addDestinationButton.Margin = new Padding(4, 5, 4, 5);
            addDestinationButton.Name = "addDestinationButton";
            addDestinationButton.Size = new Size(132, 35);
            addDestinationButton.TabIndex = 0;
            addDestinationButton.Text = "Add";
            addDestinationButton.UseVisualStyleBackColor = true;
            addDestinationButton.Click += AddDestinationButtonClick;
            // 
            // removeDestinationButton
            // 
            removeDestinationButton.Location = new Point(4, 50);
            removeDestinationButton.Margin = new Padding(4, 5, 4, 5);
            removeDestinationButton.Name = "removeDestinationButton";
            removeDestinationButton.Size = new Size(132, 35);
            removeDestinationButton.TabIndex = 1;
            removeDestinationButton.Text = "Remove";
            removeDestinationButton.UseVisualStyleBackColor = true;
            removeDestinationButton.Click += RemoveDestinationButtonClick;
            // 
            // defaultDestinationDirectory
            // 
            defaultDestinationDirectory.Dock = DockStyle.Fill;
            defaultDestinationDirectory.DropDownStyle = ComboBoxStyle.DropDownList;
            defaultDestinationDirectory.FormattingEnabled = true;
            defaultDestinationDirectory.Location = new Point(172, 553);
            defaultDestinationDirectory.Margin = new Padding(4, 5, 4, 5);
            defaultDestinationDirectory.Name = "defaultDestinationDirectory";
            defaultDestinationDirectory.Size = new Size(647, 28);
            defaultDestinationDirectory.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(50, 416);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 10;
            label1.Text = "Ignored folders:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(addIgnore_btn);
            flowLayoutPanel1.Controls.Add(removeIgnore_btn);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(823, 305);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(140, 243);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // addIgnore_btn
            // 
            addIgnore_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addIgnore_btn.Location = new Point(4, 5);
            addIgnore_btn.Margin = new Padding(4, 5, 4, 5);
            addIgnore_btn.Name = "addIgnore_btn";
            addIgnore_btn.Size = new Size(128, 35);
            addIgnore_btn.TabIndex = 0;
            addIgnore_btn.Text = "Add";
            addIgnore_btn.UseVisualStyleBackColor = true;
            addIgnore_btn.Click += AddIgnoreButtonClick;
            // 
            // removeIgnore_btn
            // 
            removeIgnore_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            removeIgnore_btn.Location = new Point(4, 50);
            removeIgnore_btn.Margin = new Padding(4, 5, 4, 5);
            removeIgnore_btn.Name = "removeIgnore_btn";
            removeIgnore_btn.Size = new Size(128, 35);
            removeIgnore_btn.TabIndex = 1;
            removeIgnore_btn.Text = "Remove";
            removeIgnore_btn.UseVisualStyleBackColor = true;
            removeIgnore_btn.Click += RemoveIgnoreButtonClick;
            // 
            // ignoreList
            // 
            ignoreList.Dock = DockStyle.Fill;
            ignoreList.FormattingEnabled = true;
            ignoreList.Location = new Point(172, 310);
            ignoreList.Margin = new Padding(4, 5, 4, 5);
            ignoreList.Name = "ignoreList";
            ignoreList.Size = new Size(647, 233);
            ignoreList.TabIndex = 11;
            // 
            // defaultDestinationLabel
            // 
            defaultDestinationLabel.Anchor = AnchorStyles.Right;
            defaultDestinationLabel.AutoSize = true;
            defaultDestinationLabel.Location = new Point(23, 557);
            defaultDestinationLabel.Margin = new Padding(4, 0, 4, 0);
            defaultDestinationLabel.Name = "defaultDestinationLabel";
            defaultDestinationLabel.Size = new Size(141, 20);
            defaultDestinationLabel.TabIndex = 8;
            defaultDestinationLabel.Text = "Default Destination:";
            // 
            // sortOptionsGroup
            // 
            sortOptionsGroup.Controls.Add(sortOptionsFlow);
            sortOptionsGroup.Dock = DockStyle.Fill;
            sortOptionsGroup.Location = new Point(4, 714);
            sortOptionsGroup.Margin = new Padding(4, 5, 4, 5);
            sortOptionsGroup.Name = "sortOptionsGroup";
            sortOptionsGroup.Padding = new Padding(4, 5, 4, 5);
            sortOptionsGroup.Size = new Size(971, 136);
            sortOptionsGroup.TabIndex = 1;
            sortOptionsGroup.TabStop = false;
            sortOptionsGroup.Text = "Sort Options";
            // 
            // sortOptionsFlow
            // 
            sortOptionsFlow.Controls.Add(recurseSubdirectoriesCheck);
            sortOptionsFlow.Controls.Add(deleteEmptyCheck);
            sortOptionsFlow.Controls.Add(renameIfExistsCheck);
            sortOptionsFlow.Controls.Add(addUnmatchedShowsCheck);
            sortOptionsFlow.Controls.Add(unlockAndUpdateCheck);
            sortOptionsFlow.Controls.Add(lockShowWithNoNewEpisodesCheck);
            sortOptionsFlow.Dock = DockStyle.Fill;
            sortOptionsFlow.FlowDirection = FlowDirection.TopDown;
            sortOptionsFlow.Location = new Point(4, 25);
            sortOptionsFlow.Margin = new Padding(4, 5, 4, 5);
            sortOptionsFlow.Name = "sortOptionsFlow";
            sortOptionsFlow.Size = new Size(963, 106);
            sortOptionsFlow.TabIndex = 0;
            // 
            // recurseSubdirectoriesCheck
            // 
            recurseSubdirectoriesCheck.AutoSize = true;
            recurseSubdirectoriesCheck.Location = new Point(4, 5);
            recurseSubdirectoriesCheck.Margin = new Padding(4, 5, 4, 5);
            recurseSubdirectoriesCheck.Name = "recurseSubdirectoriesCheck";
            recurseSubdirectoriesCheck.Size = new Size(181, 24);
            recurseSubdirectoriesCheck.TabIndex = 0;
            recurseSubdirectoriesCheck.Text = "Recurse Subdirectories";
            toolTip.SetToolTip(recurseSubdirectoriesCheck, "When selected, this option will search the subdirectories of the source directory as well.");
            recurseSubdirectoriesCheck.UseVisualStyleBackColor = true;
            // 
            // deleteEmptyCheck
            // 
            deleteEmptyCheck.AutoSize = true;
            deleteEmptyCheck.Location = new Point(4, 39);
            deleteEmptyCheck.Margin = new Padding(4, 5, 4, 5);
            deleteEmptyCheck.Name = "deleteEmptyCheck";
            deleteEmptyCheck.Size = new Size(220, 24);
            deleteEmptyCheck.TabIndex = 1;
            deleteEmptyCheck.Text = "Delete Empty Subdirectories";
            toolTip.SetToolTip(deleteEmptyCheck, "When selected, this option will delete subdirectories of Source Directory after files have been moved out of them if this leaves the directory empty.");
            deleteEmptyCheck.UseVisualStyleBackColor = true;
            // 
            // renameIfExistsCheck
            // 
            renameIfExistsCheck.AutoSize = true;
            renameIfExistsCheck.Location = new Point(4, 73);
            renameIfExistsCheck.Margin = new Padding(4, 5, 4, 5);
            renameIfExistsCheck.Name = "renameIfExistsCheck";
            renameIfExistsCheck.Size = new Size(292, 24);
            renameIfExistsCheck.TabIndex = 2;
            renameIfExistsCheck.Text = "Rename if Episode Exists at Destination";
            toolTip.SetToolTip(renameIfExistsCheck, "When selected, this option will search the destination directoy for the episode being processed and renamed the copy there if it exists with a different name.");
            renameIfExistsCheck.UseVisualStyleBackColor = true;
            // 
            // addUnmatchedShowsCheck
            // 
            addUnmatchedShowsCheck.AutoSize = true;
            addUnmatchedShowsCheck.Location = new Point(304, 5);
            addUnmatchedShowsCheck.Margin = new Padding(4, 5, 4, 5);
            addUnmatchedShowsCheck.Name = "addUnmatchedShowsCheck";
            addUnmatchedShowsCheck.Size = new Size(281, 24);
            addUnmatchedShowsCheck.TabIndex = 3;
            addUnmatchedShowsCheck.Text = "Add Unmatched Shows Automatically";
            toolTip.SetToolTip(addUnmatchedShowsCheck, resources.GetString("addUnmatchedShowsCheck.ToolTip"));
            addUnmatchedShowsCheck.UseVisualStyleBackColor = true;
            // 
            // unlockAndUpdateCheck
            // 
            unlockAndUpdateCheck.AutoSize = true;
            unlockAndUpdateCheck.Location = new Point(304, 39);
            unlockAndUpdateCheck.Margin = new Padding(4, 5, 4, 5);
            unlockAndUpdateCheck.Name = "unlockAndUpdateCheck";
            unlockAndUpdateCheck.Size = new Size(268, 24);
            unlockAndUpdateCheck.TabIndex = 4;
            unlockAndUpdateCheck.Text = "Unlock and Update Locked Matches";
            toolTip.SetToolTip(unlockAndUpdateCheck, "When selected, this option will unlock any shows that are locked and update them if a match is found.");
            unlockAndUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // lockShowWithNoNewEpisodesCheck
            // 
            lockShowWithNoNewEpisodesCheck.AutoSize = true;
            lockShowWithNoNewEpisodesCheck.Location = new Point(304, 73);
            lockShowWithNoNewEpisodesCheck.Margin = new Padding(4, 5, 4, 5);
            lockShowWithNoNewEpisodesCheck.Name = "lockShowWithNoNewEpisodesCheck";
            lockShowWithNoNewEpisodesCheck.Size = new Size(352, 24);
            lockShowWithNoNewEpisodesCheck.TabIndex = 5;
            lockShowWithNoNewEpisodesCheck.Text = "Lock Show After 3 Weeks With No New Episodes\r\n";
            toolTip.SetToolTip(lockShowWithNoNewEpisodesCheck, "When selected, during an update, if the show hasn't \r\nhad any new episodes for 3 weeks, the show will be\r\nlocked and skipped in future updates.");
            lockShowWithNoNewEpisodesCheck.UseVisualStyleBackColor = true;
            // 
            // searchOptionsGroup
            // 
            searchOptionsGroup.Controls.Add(searchOptionsFlow);
            searchOptionsGroup.Dock = DockStyle.Fill;
            searchOptionsGroup.Location = new Point(4, 860);
            searchOptionsGroup.Margin = new Padding(4, 5, 4, 5);
            searchOptionsGroup.Name = "searchOptionsGroup";
            searchOptionsGroup.Padding = new Padding(4, 5, 4, 5);
            searchOptionsGroup.Size = new Size(971, 76);
            searchOptionsGroup.TabIndex = 2;
            searchOptionsGroup.TabStop = false;
            searchOptionsGroup.Text = "Search Options";
            // 
            // searchOptionsFlow
            // 
            searchOptionsFlow.Controls.Add(regExButton);
            searchOptionsFlow.Controls.Add(fileExtensionsButton);
            searchOptionsFlow.Controls.Add(editOverwriteKeywordsButton);
            searchOptionsFlow.Dock = DockStyle.Fill;
            searchOptionsFlow.Location = new Point(4, 25);
            searchOptionsFlow.Margin = new Padding(4, 5, 4, 5);
            searchOptionsFlow.Name = "searchOptionsFlow";
            searchOptionsFlow.Size = new Size(963, 46);
            searchOptionsFlow.TabIndex = 0;
            // 
            // regExButton
            // 
            regExButton.Location = new Point(4, 5);
            regExButton.Margin = new Padding(4, 5, 4, 5);
            regExButton.Name = "regExButton";
            regExButton.Size = new Size(181, 35);
            regExButton.TabIndex = 0;
            regExButton.Text = "Edit Regular Expressions";
            toolTip.SetToolTip(regExButton, "Edit the regular expressions used for searching.\r\nSee http://code.google.com/p/tvsorter for more\r\ninformation.");
            regExButton.UseVisualStyleBackColor = true;
            regExButton.Click += RegExButtonClick;
            // 
            // fileExtensionsButton
            // 
            fileExtensionsButton.Location = new Point(193, 5);
            fileExtensionsButton.Margin = new Padding(4, 5, 4, 5);
            fileExtensionsButton.Name = "fileExtensionsButton";
            fileExtensionsButton.Size = new Size(181, 35);
            fileExtensionsButton.TabIndex = 1;
            fileExtensionsButton.Text = "Edit File Extensions";
            toolTip.SetToolTip(fileExtensionsButton, "Edit the file extensions that are searched.");
            fileExtensionsButton.UseVisualStyleBackColor = true;
            fileExtensionsButton.Click += FileExtensionsButtonClick;
            // 
            // editOverwriteKeywordsButton
            // 
            editOverwriteKeywordsButton.Location = new Point(382, 5);
            editOverwriteKeywordsButton.Margin = new Padding(4, 5, 4, 5);
            editOverwriteKeywordsButton.Name = "editOverwriteKeywordsButton";
            editOverwriteKeywordsButton.Size = new Size(195, 35);
            editOverwriteKeywordsButton.TabIndex = 2;
            editOverwriteKeywordsButton.Text = "Edit Overwrite Keywords";
            toolTip.SetToolTip(editOverwriteKeywordsButton, resources.GetString("editOverwriteKeywordsButton.ToolTip"));
            editOverwriteKeywordsButton.UseVisualStyleBackColor = true;
            editOverwriteKeywordsButton.Click += EditOverwriteKeywordsButtonClick;
            // 
            // formatOptionsGroup
            // 
            formatOptionsGroup.Controls.Add(formatTable);
            formatOptionsGroup.Dock = DockStyle.Fill;
            formatOptionsGroup.Location = new Point(4, 631);
            formatOptionsGroup.Margin = new Padding(4, 5, 4, 5);
            formatOptionsGroup.Name = "formatOptionsGroup";
            formatOptionsGroup.Padding = new Padding(4, 5, 4, 5);
            formatOptionsGroup.Size = new Size(971, 73);
            formatOptionsGroup.TabIndex = 3;
            formatOptionsGroup.TabStop = false;
            formatOptionsGroup.Text = "Format Options";
            // 
            // formatTable
            // 
            formatTable.ColumnCount = 3;
            formatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168F));
            formatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formatTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            formatTable.Controls.Add(formatLabel, 0, 0);
            formatTable.Controls.Add(formatText, 1, 0);
            formatTable.Controls.Add(formatBuilderButton, 2, 0);
            formatTable.Dock = DockStyle.Fill;
            formatTable.Location = new Point(4, 25);
            formatTable.Margin = new Padding(4, 5, 4, 5);
            formatTable.Name = "formatTable";
            formatTable.RowCount = 1;
            formatTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formatTable.Size = new Size(963, 43);
            formatTable.TabIndex = 0;
            // 
            // formatLabel
            // 
            formatLabel.Anchor = AnchorStyles.Right;
            formatLabel.AutoSize = true;
            formatLabel.Location = new Point(55, 11);
            formatLabel.Margin = new Padding(4, 0, 4, 0);
            formatLabel.Name = "formatLabel";
            formatLabel.Size = new Size(109, 20);
            formatLabel.TabIndex = 0;
            formatLabel.Text = "Output Format:";
            // 
            // formatText
            // 
            formatText.Dock = DockStyle.Fill;
            formatText.Location = new Point(172, 5);
            formatText.Margin = new Padding(4, 5, 4, 5);
            formatText.Name = "formatText";
            formatText.Size = new Size(647, 27);
            formatText.TabIndex = 1;
            toolTip.SetToolTip(formatText, "The formatting string used to set the output path for an episode. This setting can be overriden on a per show basis.");
            // 
            // formatBuilderButton
            // 
            formatBuilderButton.Dock = DockStyle.Top;
            formatBuilderButton.Location = new Point(827, 5);
            formatBuilderButton.Margin = new Padding(4, 5, 4, 5);
            formatBuilderButton.Name = "formatBuilderButton";
            formatBuilderButton.Size = new Size(132, 25);
            formatBuilderButton.TabIndex = 2;
            formatBuilderButton.Text = "Format Builder";
            formatBuilderButton.UseVisualStyleBackColor = true;
            formatBuilderButton.Click += FormatBuilderButtonClick;
            // 
            // flowBottomButtons
            // 
            flowBottomButtons.Controls.Add(revertButton);
            flowBottomButtons.Controls.Add(saveButton);
            flowBottomButtons.Dock = DockStyle.Fill;
            flowBottomButtons.FlowDirection = FlowDirection.RightToLeft;
            flowBottomButtons.Location = new Point(4, 946);
            flowBottomButtons.Margin = new Padding(4, 5, 4, 5);
            flowBottomButtons.Name = "flowBottomButtons";
            flowBottomButtons.Size = new Size(971, 52);
            flowBottomButtons.TabIndex = 4;
            // 
            // revertButton
            // 
            revertButton.Location = new Point(867, 5);
            revertButton.Margin = new Padding(4, 5, 4, 5);
            revertButton.Name = "revertButton";
            revertButton.Size = new Size(100, 35);
            revertButton.TabIndex = 0;
            revertButton.Text = "Revert";
            revertButton.UseVisualStyleBackColor = true;
            revertButton.Click += RevertButtonClick;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(759, 5);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 35);
            saveButton.TabIndex = 1;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButtonClick;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainTable);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Settings";
            Size = new Size(979, 1003);
            Load += SettingsLoad;
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            groupDirectories.ResumeLayout(false);
            groupDirectories.PerformLayout();
            tableDirectories.ResumeLayout(false);
            tableDirectories.PerformLayout();
            destinationButtonsFlow.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            sortOptionsGroup.ResumeLayout(false);
            sortOptionsFlow.ResumeLayout(false);
            sortOptionsFlow.PerformLayout();
            searchOptionsGroup.ResumeLayout(false);
            searchOptionsFlow.ResumeLayout(false);
            formatOptionsGroup.ResumeLayout(false);
            formatTable.ResumeLayout(false);
            formatTable.PerformLayout();
            flowBottomButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private ToolTip toolTip;
        private CheckBox addUnmatchedShowsCheck;
        private CheckBox unlockAndUpdateCheck;
        private IContainer components = null;
        private CheckBox lockShowWithNoNewEpisodesCheck;
        private ComboBox defaultDestinationDirectory;
        private Label label1;
        private ListBox ignoreList;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button addIgnore_btn;
        private Button removeIgnore_btn;
    }
}