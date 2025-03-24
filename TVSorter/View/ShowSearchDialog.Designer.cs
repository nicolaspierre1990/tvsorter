// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ShowSearchDialog.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Dialog for searching for a show.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View;



using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// Dialog for searching for a show.
/// </summary>
public partial class ShowSearchDialog
{


    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly IContainer components = null;

    /// <summary>
    ///   The close button.
    /// </summary>
    private Button closeButton;

    /// <summary>
    ///   The id column.
    /// </summary>
    private ColumnHeader idColumn;

    /// <summary>
    ///   The list results.
    /// </summary>
    private ListView listResults;

    /// <summary>
    ///   The name column.
    /// </summary>
    private ColumnHeader nameColumn;

    /// <summary>
    ///   The name text.
    /// </summary>
    private TextBox nameText;

    /// <summary>
    ///   The search button.
    /// </summary>
    private Button searchButton;

    /// <summary>
    ///   The select button.
    /// </summary>
    private Button selectButton;



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
        TableLayoutPanel mainTable;
        Label nameLabel;
        listResults = new ListView();
        nameColumn = new ColumnHeader();
        idColumn = new ColumnHeader();
        nameText = new TextBox();
        searchButton = new Button();
        closeButton = new Button();
        selectButton = new Button();
        mainTable = new TableLayoutPanel();
        nameLabel = new Label();
        mainTable.SuspendLayout();
        SuspendLayout();
        // 
        // mainTable
        // 
        mainTable.ColumnCount = 5;
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 107F));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 107F));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 107F));
        mainTable.Controls.Add(listResults, 0, 0);
        mainTable.Controls.Add(nameLabel, 0, 1);
        mainTable.Controls.Add(nameText, 1, 1);
        mainTable.Controls.Add(searchButton, 2, 1);
        mainTable.Controls.Add(closeButton, 4, 1);
        mainTable.Controls.Add(selectButton, 3, 1);
        mainTable.Dock = DockStyle.Fill;
        mainTable.Location = new Point(0, 0);
        mainTable.Margin = new Padding(5, 4, 5, 4);
        mainTable.Name = "mainTable";
        mainTable.RowCount = 2;
        mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 89.31298F));
        mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10.68702F));
        mainTable.Size = new Size(610, 364);
        mainTable.TabIndex = 1;
        // 
        // listResults
        // 
        listResults.Columns.AddRange(new ColumnHeader[] { nameColumn, idColumn });
        mainTable.SetColumnSpan(listResults, 5);
        listResults.Dock = DockStyle.Fill;
        listResults.FullRowSelect = true;
        listResults.Location = new Point(5, 4);
        listResults.Margin = new Padding(5, 4, 5, 4);
        listResults.MultiSelect = false;
        listResults.Name = "listResults";
        listResults.Size = new Size(600, 317);
        listResults.TabIndex = 0;
        listResults.UseCompatibleStateImageBehavior = false;
        listResults.View = View.Details;
        listResults.SelectedIndexChanged += ListResults_SelectedIndexChanged;
        listResults.DoubleClick += ListResultsDoubleClick;
        // 
        // nameColumn
        // 
        nameColumn.Text = "Show Name";
        nameColumn.Width = 338;
        // 
        // idColumn
        // 
        idColumn.Text = "TVDB ID";
        idColumn.Width = 105;
        // 
        // nameLabel
        // 
        nameLabel.Anchor = AnchorStyles.Right;
        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(12, 325);
        nameLabel.Margin = new Padding(5, 0, 5, 0);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new Size(41, 39);
        nameLabel.TabIndex = 1;
        nameLabel.Text = "Name:";
        // 
        // nameText
        // 
        nameText.Dock = DockStyle.Fill;
        nameText.Location = new Point(63, 329);
        nameText.Margin = new Padding(5, 4, 5, 4);
        nameText.Name = "nameText";
        nameText.Size = new Size(221, 27);
        nameText.TabIndex = 2;
        // 
        // searchButton
        // 
        searchButton.Dock = DockStyle.Fill;
        searchButton.Location = new Point(294, 329);
        searchButton.Margin = new Padding(5, 4, 5, 4);
        searchButton.Name = "searchButton";
        searchButton.Size = new Size(97, 31);
        searchButton.TabIndex = 3;
        searchButton.Text = "Search";
        searchButton.UseVisualStyleBackColor = true;
        searchButton.Click += SearchButtonClick;
        // 
        // closeButton
        // 
        closeButton.Dock = DockStyle.Fill;
        closeButton.Location = new Point(508, 329);
        closeButton.Margin = new Padding(5, 4, 5, 4);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(97, 31);
        closeButton.TabIndex = 4;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += CloseButtonClick;
        // 
        // selectButton
        // 
        selectButton.Dock = DockStyle.Fill;
        selectButton.Location = new Point(401, 329);
        selectButton.Margin = new Padding(5, 4, 5, 4);
        selectButton.Name = "selectButton";
        selectButton.Size = new Size(97, 31);
        selectButton.TabIndex = 5;
        selectButton.Text = "Select";
        selectButton.UseVisualStyleBackColor = true;
        selectButton.Click += SelectButtonClick;
        // 
        // ShowSearchDialog
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(610, 364);
        ControlBox = false;
        Controls.Add(mainTable);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(5, 4, 5, 4);
        Name = "ShowSearchDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Show Search";
        Load += ShowSearchDialogLoad;
        mainTable.ResumeLayout(false);
        mainTable.PerformLayout();
        ResumeLayout(false);
    }
}