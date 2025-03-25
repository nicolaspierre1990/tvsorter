namespace TVSorter.View;

partial class FormatBuilder
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }


    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.TableLayoutPanel tableMain;
        System.Windows.Forms.FlowLayoutPanel flowButtons;
        System.Windows.Forms.Label formatLabel;
        System.Windows.Forms.Label exampleLabel;
        System.Windows.Forms.Panel panel;
        System.Windows.Forms.GroupBox groupNumbers;
        System.Windows.Forms.GroupBox otherGroup;
        System.Windows.Forms.GroupBox namesGroup;
        System.Windows.Forms.GroupBox dateGroup;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatBuilder));
        okButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        textExample = new System.Windows.Forms.TextBox();
        textFormat = new System.Windows.Forms.TextBox();
        digitalSelector = new System.Windows.Forms.NumericUpDown();
        episodeNumberButton = new System.Windows.Forms.Button();
        seasonNumberButton = new System.Windows.Forms.Button();
        directoryButton = new System.Windows.Forms.Button();
        fileExtensionButton = new System.Windows.Forms.Button();
        folderNameButton = new System.Windows.Forms.Button();
        wordSeparator = new System.Windows.Forms.ComboBox();
        episodeNameButton = new System.Windows.Forms.Button();
        showNameButton = new System.Windows.Forms.Button();
        dateFormat = new System.Windows.Forms.TextBox();
        dateExample = new System.Windows.Forms.TextBox();
        dateButton = new System.Windows.Forms.Button();
        tableMain = new System.Windows.Forms.TableLayoutPanel();
        flowButtons = new System.Windows.Forms.FlowLayoutPanel();
        formatLabel = new System.Windows.Forms.Label();
        exampleLabel = new System.Windows.Forms.Label();
        panel = new System.Windows.Forms.Panel();
        groupNumbers = new System.Windows.Forms.GroupBox();
        otherGroup = new System.Windows.Forms.GroupBox();
        namesGroup = new System.Windows.Forms.GroupBox();
        dateGroup = new System.Windows.Forms.GroupBox();
        tableMain.SuspendLayout();
        flowButtons.SuspendLayout();
        panel.SuspendLayout();
        groupNumbers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)digitalSelector).BeginInit();
        otherGroup.SuspendLayout();
        namesGroup.SuspendLayout();
        dateGroup.SuspendLayout();
        SuspendLayout();
        // 
        // tableMain
        // 
        tableMain.ColumnCount = 2;
        tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
        tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
        tableMain.Controls.Add(flowButtons, 0, 3);
        tableMain.Controls.Add(textExample, 1, 2);
        tableMain.Controls.Add(textFormat, 1, 1);
        tableMain.Controls.Add(formatLabel, 0, 1);
        tableMain.Controls.Add(exampleLabel, 0, 2);
        tableMain.Controls.Add(panel, 0, 0);
        tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableMain.Location = new System.Drawing.Point(0, 0);
        tableMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        tableMain.Name = "tableMain";
        tableMain.RowCount = 4;
        tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
        tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
        tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        tableMain.Size = new System.Drawing.Size(495, 340);
        tableMain.TabIndex = 0;
        // 
        // flowButtons
        // 
        tableMain.SetColumnSpan(flowButtons, 2);
        flowButtons.Controls.Add(okButton);
        flowButtons.Controls.Add(cancelButton);
        flowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        flowButtons.Location = new System.Drawing.Point(0, 294);
        flowButtons.Margin = new System.Windows.Forms.Padding(0);
        flowButtons.Name = "flowButtons";
        flowButtons.Size = new System.Drawing.Size(495, 46);
        flowButtons.TabIndex = 0;
        // 
        // okButton
        // 
        okButton.Location = new System.Drawing.Point(391, 5);
        okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        okButton.Name = "okButton";
        okButton.Size = new System.Drawing.Size(100, 35);
        okButton.TabIndex = 0;
        okButton.Text = "OK";
        okButton.UseVisualStyleBackColor = true;
        okButton.Click += OkButtonClick;
        // 
        // cancelButton
        // 
        cancelButton.Location = new System.Drawing.Point(283, 5);
        cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 35);
        cancelButton.TabIndex = 1;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        cancelButton.Click += CancelButtonClick;
        // 
        // textExample
        // 
        textExample.Dock = System.Windows.Forms.DockStyle.Fill;
        textExample.Location = new System.Drawing.Point(143, 261);
        textExample.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        textExample.Name = "textExample";
        textExample.ReadOnly = true;
        textExample.Size = new System.Drawing.Size(348, 27);
        textExample.TabIndex = 1;
        // 
        // textFormat
        // 
        textFormat.Dock = System.Windows.Forms.DockStyle.Fill;
        textFormat.Location = new System.Drawing.Point(143, 223);
        textFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        textFormat.Name = "textFormat";
        textFormat.Size = new System.Drawing.Size(348, 27);
        textFormat.TabIndex = 2;
        textFormat.TextChanged += TextFormatTextChanged;
        // 
        // formatLabel
        // 
        formatLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
        formatLabel.AutoSize = true;
        formatLabel.Location = new System.Drawing.Point(33, 227);
        formatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        formatLabel.Name = "formatLabel";
        formatLabel.Size = new System.Drawing.Size(102, 20);
        formatLabel.TabIndex = 3;
        formatLabel.Text = "Format String:";
        // 
        // exampleLabel
        // 
        exampleLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
        exampleLabel.AutoSize = true;
        exampleLabel.Location = new System.Drawing.Point(16, 265);
        exampleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        exampleLabel.Name = "exampleLabel";
        exampleLabel.Size = new System.Drawing.Size(119, 20);
        exampleLabel.TabIndex = 4;
        exampleLabel.Text = "Example Output:";
        // 
        // panel
        // 
        tableMain.SetColumnSpan(panel, 2);
        panel.Controls.Add(groupNumbers);
        panel.Controls.Add(otherGroup);
        panel.Controls.Add(namesGroup);
        panel.Controls.Add(dateGroup);
        panel.Dock = System.Windows.Forms.DockStyle.Fill;
        panel.Location = new System.Drawing.Point(4, 5);
        panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        panel.Name = "panel";
        panel.Size = new System.Drawing.Size(487, 208);
        panel.TabIndex = 10;
        // 
        // groupNumbers
        // 
        groupNumbers.AutoSize = true;
        groupNumbers.Controls.Add(digitalSelector);
        groupNumbers.Controls.Add(episodeNumberButton);
        groupNumbers.Controls.Add(seasonNumberButton);
        groupNumbers.Location = new System.Drawing.Point(4, 14);
        groupNumbers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        groupNumbers.Name = "groupNumbers";
        groupNumbers.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
        groupNumbers.Size = new System.Drawing.Size(109, 200);
        groupNumbers.TabIndex = 6;
        groupNumbers.TabStop = false;
        groupNumbers.Text = "Numbers";
        // 
        // digitalSelector
        // 
        digitalSelector.Location = new System.Drawing.Point(8, 118);
        digitalSelector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        digitalSelector.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        digitalSelector.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        digitalSelector.Name = "digitalSelector";
        digitalSelector.Size = new System.Drawing.Size(87, 27);
        digitalSelector.TabIndex = 2;
        digitalSelector.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // episodeNumberButton
        // 
        episodeNumberButton.Location = new System.Drawing.Point(8, 74);
        episodeNumberButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        episodeNumberButton.Name = "episodeNumberButton";
        episodeNumberButton.Size = new System.Drawing.Size(87, 35);
        episodeNumberButton.TabIndex = 1;
        episodeNumberButton.Text = "Episode";
        episodeNumberButton.UseVisualStyleBackColor = true;
        episodeNumberButton.Click += EpisodeNumberButtonClick;
        // 
        // seasonNumberButton
        // 
        seasonNumberButton.Location = new System.Drawing.Point(8, 29);
        seasonNumberButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        seasonNumberButton.Name = "seasonNumberButton";
        seasonNumberButton.Size = new System.Drawing.Size(87, 35);
        seasonNumberButton.TabIndex = 0;
        seasonNumberButton.Text = "Season";
        seasonNumberButton.UseVisualStyleBackColor = true;
        seasonNumberButton.Click += SeasonNumberButtonClick;
        // 
        // otherGroup
        // 
        otherGroup.AutoSize = true;
        otherGroup.Controls.Add(directoryButton);
        otherGroup.Controls.Add(fileExtensionButton);
        otherGroup.Controls.Add(folderNameButton);
        otherGroup.Location = new System.Drawing.Point(343, 14);
        otherGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        otherGroup.Name = "otherGroup";
        otherGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
        otherGroup.Size = new System.Drawing.Size(128, 194);
        otherGroup.TabIndex = 9;
        otherGroup.TabStop = false;
        otherGroup.Text = "Other";
        // 
        // directoryButton
        // 
        directoryButton.Location = new System.Drawing.Point(8, 118);
        directoryButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        directoryButton.Name = "directoryButton";
        directoryButton.Size = new System.Drawing.Size(112, 35);
        directoryButton.TabIndex = 12;
        directoryButton.Text = "Directory";
        directoryButton.UseVisualStyleBackColor = true;
        directoryButton.Click += DirectoryButtonClick;
        // 
        // fileExtensionButton
        // 
        fileExtensionButton.Location = new System.Drawing.Point(8, 74);
        fileExtensionButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        fileExtensionButton.Name = "fileExtensionButton";
        fileExtensionButton.Size = new System.Drawing.Size(112, 35);
        fileExtensionButton.TabIndex = 11;
        fileExtensionButton.Text = "File Extension";
        fileExtensionButton.UseVisualStyleBackColor = true;
        fileExtensionButton.Click += FileExtensionButtonClick;
        // 
        // folderNameButton
        // 
        folderNameButton.Location = new System.Drawing.Point(8, 29);
        folderNameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        folderNameButton.Name = "folderNameButton";
        folderNameButton.Size = new System.Drawing.Size(112, 35);
        folderNameButton.TabIndex = 10;
        folderNameButton.Text = "Folder Name";
        folderNameButton.UseVisualStyleBackColor = true;
        folderNameButton.Click += FolderNameButtonClick;
        // 
        // namesGroup
        // 
        namesGroup.AutoSize = true;
        namesGroup.Controls.Add(wordSeparator);
        namesGroup.Controls.Add(episodeNameButton);
        namesGroup.Controls.Add(showNameButton);
        namesGroup.Location = new System.Drawing.Point(121, 14);
        namesGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        namesGroup.Name = "namesGroup";
        namesGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
        namesGroup.Size = new System.Drawing.Size(103, 200);
        namesGroup.TabIndex = 7;
        namesGroup.TabStop = false;
        namesGroup.Text = "Names";
        // 
        // wordSeparator
        // 
        wordSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        wordSeparator.FormattingEnabled = true;
        wordSeparator.Items.AddRange(new object[] { "[space]", ".", "-", "_" });
        wordSeparator.Location = new System.Drawing.Point(8, 117);
        wordSeparator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        wordSeparator.Name = "wordSeparator";
        wordSeparator.Size = new System.Drawing.Size(85, 28);
        wordSeparator.TabIndex = 2;
        // 
        // episodeNameButton
        // 
        episodeNameButton.Location = new System.Drawing.Point(8, 74);
        episodeNameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        episodeNameButton.Name = "episodeNameButton";
        episodeNameButton.Size = new System.Drawing.Size(87, 35);
        episodeNameButton.TabIndex = 1;
        episodeNameButton.Text = "Episode";
        episodeNameButton.UseVisualStyleBackColor = true;
        episodeNameButton.Click += EpisodeNameButtonClick;
        // 
        // showNameButton
        // 
        showNameButton.Location = new System.Drawing.Point(8, 29);
        showNameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        showNameButton.Name = "showNameButton";
        showNameButton.Size = new System.Drawing.Size(87, 35);
        showNameButton.TabIndex = 0;
        showNameButton.Text = "Show";
        showNameButton.UseVisualStyleBackColor = true;
        showNameButton.Click += ShowNameButtonClick;
        // 
        // dateGroup
        // 
        dateGroup.AutoSize = true;
        dateGroup.Controls.Add(dateFormat);
        dateGroup.Controls.Add(dateExample);
        dateGroup.Controls.Add(dateButton);
        dateGroup.Location = new System.Drawing.Point(232, 14);
        dateGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        dateGroup.Name = "dateGroup";
        dateGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
        dateGroup.Size = new System.Drawing.Size(103, 200);
        dateGroup.TabIndex = 8;
        dateGroup.TabStop = false;
        dateGroup.Text = "Date";
        // 
        // dateFormat
        // 
        dateFormat.Location = new System.Drawing.Point(8, 78);
        dateFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        dateFormat.Name = "dateFormat";
        dateFormat.Size = new System.Drawing.Size(85, 27);
        dateFormat.TabIndex = 1;
        dateFormat.TextChanged += DateFormatTextChanged;
        // 
        // dateExample
        // 
        dateExample.Location = new System.Drawing.Point(8, 118);
        dateExample.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        dateExample.Name = "dateExample";
        dateExample.ReadOnly = true;
        dateExample.Size = new System.Drawing.Size(85, 27);
        dateExample.TabIndex = 2;
        // 
        // dateButton
        // 
        dateButton.Location = new System.Drawing.Point(8, 29);
        dateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        dateButton.Name = "dateButton";
        dateButton.Size = new System.Drawing.Size(87, 35);
        dateButton.TabIndex = 0;
        dateButton.Text = "Date";
        dateButton.UseVisualStyleBackColor = true;
        dateButton.Click += DateButtonClick;
        // 
        // FormatBuilder
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(495, 340);
        Controls.Add(tableMain);
        Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        MinimumSize = new System.Drawing.Size(510, 373);
        Name = "FormatBuilder";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Format Builder";
        Load += FormatBuilderLoad;
        tableMain.ResumeLayout(false);
        tableMain.PerformLayout();
        flowButtons.ResumeLayout(false);
        panel.ResumeLayout(false);
        panel.PerformLayout();
        groupNumbers.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)digitalSelector).EndInit();
        otherGroup.ResumeLayout(false);
        namesGroup.ResumeLayout(false);
        dateGroup.ResumeLayout(false);
        dateGroup.PerformLayout();
        ResumeLayout(false);

    }


    private System.Windows.Forms.TextBox textExample;
    private System.Windows.Forms.TextBox textFormat;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.TextBox dateExample;
    private System.Windows.Forms.Button dateButton;
    private System.Windows.Forms.ComboBox wordSeparator;
    private System.Windows.Forms.Button episodeNameButton;
    private System.Windows.Forms.Button showNameButton;
    private System.Windows.Forms.NumericUpDown digitalSelector;
    private System.Windows.Forms.Button episodeNumberButton;
    private System.Windows.Forms.Button seasonNumberButton;
    private System.Windows.Forms.TextBox dateFormat;
    private System.Windows.Forms.Button directoryButton;
    private System.Windows.Forms.Button fileExtensionButton;
    private System.Windows.Forms.Button folderNameButton;
}
