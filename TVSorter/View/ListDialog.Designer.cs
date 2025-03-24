// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ListDialog.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The list dialog.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View;



using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// The list dialog.
/// </summary>
public partial class ListDialog
{


    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly IContainer components = null;

    /// <summary>
    ///   The add button.
    /// </summary>
    private Button addButton;

    /// <summary>
    ///   The close button.
    /// </summary>
    private Button closeButton;

    /// <summary>
    ///   The list.
    /// </summary>
    private ListBox list;

    /// <summary>
    ///   The remove button.
    /// </summary>
    private Button removeButton;

    /// <summary>
    ///   The save button.
    /// </summary>
    private Button saveButton;

    /// <summary>
    ///   The text.
    /// </summary>
    private TextBox text;



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
        TableLayoutPanel tableMain;
        FlowLayoutPanel flowBottomButtons;
        closeButton = new Button();
        saveButton = new Button();
        list = new ListBox();
        text = new TextBox();
        addButton = new Button();
        removeButton = new Button();
        tableMain = new TableLayoutPanel();
        flowBottomButtons = new FlowLayoutPanel();
        tableMain.SuspendLayout();
        flowBottomButtons.SuspendLayout();
        SuspendLayout();
        // 
        // tableMain
        // 
        tableMain.ColumnCount = 2;
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 157F));
        tableMain.Controls.Add(flowBottomButtons, 0, 2);
        tableMain.Controls.Add(list, 0, 1);
        tableMain.Controls.Add(text, 0, 0);
        tableMain.Controls.Add(addButton, 1, 0);
        tableMain.Controls.Add(removeButton, 1, 1);
        tableMain.Dock = DockStyle.Fill;
        tableMain.Location = new Point(0, 0);
        tableMain.Margin = new Padding(4, 5, 4, 5);
        tableMain.Name = "tableMain";
        tableMain.RowCount = 3;
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.Size = new Size(408, 365);
        tableMain.TabIndex = 0;
        // 
        // flowBottomButtons
        // 
        tableMain.SetColumnSpan(flowBottomButtons, 2);
        flowBottomButtons.Controls.Add(closeButton);
        flowBottomButtons.Controls.Add(saveButton);
        flowBottomButtons.Dock = DockStyle.Fill;
        flowBottomButtons.FlowDirection = FlowDirection.RightToLeft;
        flowBottomButtons.Location = new Point(0, 319);
        flowBottomButtons.Margin = new Padding(0);
        flowBottomButtons.Name = "flowBottomButtons";
        flowBottomButtons.Size = new Size(408, 46);
        flowBottomButtons.TabIndex = 0;
        // 
        // closeButton
        // 
        closeButton.Location = new Point(304, 5);
        closeButton.Margin = new Padding(4, 5, 4, 5);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(100, 35);
        closeButton.TabIndex = 1;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += CloseButtonClick;
        // 
        // saveButton
        // 
        saveButton.Location = new Point(196, 5);
        saveButton.Margin = new Padding(4, 5, 4, 5);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(100, 35);
        saveButton.TabIndex = 0;
        saveButton.Text = "OK";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButtonClick;
        // 
        // list
        // 
        list.Dock = DockStyle.Fill;
        list.FormattingEnabled = true;
        list.Location = new Point(4, 48);
        list.Margin = new Padding(4, 5, 4, 5);
        list.Name = "list";
        list.Size = new Size(243, 266);
        list.TabIndex = 1;
        // 
        // text
        // 
        text.Dock = DockStyle.Fill;
        text.Location = new Point(4, 5);
        text.Margin = new Padding(4, 5, 4, 5);
        text.Name = "text";
        text.Size = new Size(243, 27);
        text.TabIndex = 2;
        // 
        // addButton
        // 
        addButton.Dock = DockStyle.Fill;
        addButton.Location = new Point(255, 5);
        addButton.Margin = new Padding(4, 5, 4, 5);
        addButton.Name = "addButton";
        addButton.Size = new Size(149, 33);
        addButton.TabIndex = 3;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += AddButtonClick;
        // 
        // removeButton
        // 
        removeButton.Dock = DockStyle.Top;
        removeButton.Location = new Point(255, 48);
        removeButton.Margin = new Padding(4, 5, 4, 5);
        removeButton.Name = "removeButton";
        removeButton.Size = new Size(149, 35);
        removeButton.TabIndex = 4;
        removeButton.Text = "Remove";
        removeButton.UseVisualStyleBackColor = true;
        removeButton.Click += RemoveButtonClick;
        // 
        // ListDialog
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(408, 365);
        ControlBox = false;
        Controls.Add(tableMain);
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
        Margin = new Padding(4, 5, 4, 5);
        Name = "ListDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "ListDialog";
        Load += ListDialogLoad;
        tableMain.ResumeLayout(false);
        tableMain.PerformLayout();
        flowBottomButtons.ResumeLayout(false);
        ResumeLayout(false);
    }
}