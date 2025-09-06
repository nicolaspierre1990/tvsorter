// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ShowSelectDialog.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Dialog for selecting a show.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View;



using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// Dialog for selecting a show.
/// </summary>
public partial class ShowSelectDialog
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
    ///   The select button.
    /// </summary>
    private Button selectButton;

    /// <summary>
    ///   The show list.
    /// </summary>
    private ListBox showList;



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
        FlowLayoutPanel buttonsFlow;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(ShowSelectDialog));
        selectButton = new Button();
        closeButton = new Button();
        showList = new ListBox();
        searchLbl = new Label();
        searchTxt = new TextBox();
        buttonsFlow = new FlowLayoutPanel();
        buttonsFlow.SuspendLayout();
        SuspendLayout();
        // 
        // buttonsFlow
        // 
        buttonsFlow.Controls.Add(selectButton);
        buttonsFlow.Controls.Add(closeButton);
        buttonsFlow.Dock = DockStyle.Bottom;
        buttonsFlow.FlowDirection = FlowDirection.RightToLeft;
        buttonsFlow.Location = new Point(0, 480);
        buttonsFlow.Margin = new Padding(4, 5, 4, 5);
        buttonsFlow.Name = "buttonsFlow";
        buttonsFlow.Size = new Size(295, 46);
        buttonsFlow.TabIndex = 1;
        // 
        // selectButton
        // 
        selectButton.Location = new Point(191, 5);
        selectButton.Margin = new Padding(4, 5, 4, 5);
        selectButton.Name = "selectButton";
        selectButton.Size = new Size(100, 35);
        selectButton.TabIndex = 0;
        selectButton.Text = "Select";
        selectButton.UseVisualStyleBackColor = true;
        selectButton.Click += SelectButtonClick;
        // 
        // closeButton
        // 
        closeButton.Location = new Point(83, 5);
        closeButton.Margin = new Padding(4, 5, 4, 5);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(100, 35);
        closeButton.TabIndex = 1;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += CloseButtonClick;
        // 
        // showList
        // 
        showList.Anchor = AnchorStyles.Left;
        showList.FormattingEnabled = true;
        showList.HorizontalScrollbar = true;
        showList.Location = new Point(2, 38);
        showList.Margin = new Padding(4, 5, 4, 5);
        showList.Name = "showList";
        showList.Size = new Size(289, 444);
        showList.TabIndex = 0;
        // 
        // searchLbl
        // 
        searchLbl.AutoSize = true;
        searchLbl.Location = new Point(2, 9);
        searchLbl.Name = "searchLbl";
        searchLbl.Size = new Size(56, 20);
        searchLbl.TabIndex = 2;
        searchLbl.Text = "Search:";
        // 
        // searchTxt
        // 
        searchTxt.Location = new Point(64, 6);
        searchTxt.Name = "searchTxt";
        searchTxt.PlaceholderText = "Search Show";
        searchTxt.Size = new Size(227, 27);
        searchTxt.TabIndex = 3;
        searchTxt.TextChanged += SearchTxt_TextChanged;
        // 
        // ShowSelectDialog
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(295, 526);
        Controls.Add(searchTxt);
        Controls.Add(searchLbl);
        Controls.Add(buttonsFlow);
        Controls.Add(showList);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4, 5, 4, 5);
        Name = "ShowSelectDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Select Show";
        Load += ShowSelectDialogLoad;
        buttonsFlow.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();

    }
    private Label searchLbl;
    private TextBox searchTxt;
}