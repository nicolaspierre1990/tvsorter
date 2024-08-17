// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="NumberInputDialog.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   A dialog for number entry.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View
{


    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;


    /// <summary>
    /// A dialog for number entry.
    /// </summary>
    public partial class NumberInputDialog
    {


        /// <summary>
        ///   Required designer variable.
        /// </summary>
        private readonly IContainer components = null;

        /// <summary>
        ///   The cancel button.
        /// </summary>
        private Button cancelButton;

        /// <summary>
        ///   The input text.
        /// </summary>
        private TextBox seasonNumber;

        /// <summary>
        ///   The ok button.
        /// </summary>
        private Button okButton;



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
            TableLayoutPanel table;
            FlowLayoutPanel flowButtons;
            Label seasonLabel;
            Label episodeLabel;
            okButton = new Button();
            cancelButton = new Button();
            episodeNumber = new TextBox();
            seasonNumber = new TextBox();
            table = new TableLayoutPanel();
            flowButtons = new FlowLayoutPanel();
            seasonLabel = new Label();
            episodeLabel = new Label();
            table.SuspendLayout();
            flowButtons.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(flowButtons, 0, 2);
            table.Controls.Add(episodeNumber, 1, 1);
            table.Controls.Add(seasonNumber, 1, 0);
            table.Controls.Add(seasonLabel, 0, 0);
            table.Controls.Add(episodeLabel, 0, 1);
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);
            table.Margin = new Padding(4);
            table.Name = "table";
            table.RowCount = 2;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            table.Size = new Size(248, 94);
            table.TabIndex = 3;
            // 
            // flowButtons
            // 
            table.SetColumnSpan(flowButtons, 2);
            flowButtons.Controls.Add(okButton);
            flowButtons.Controls.Add(cancelButton);
            flowButtons.Dock = DockStyle.Fill;
            flowButtons.FlowDirection = FlowDirection.RightToLeft;
            flowButtons.Location = new Point(0, 56);
            flowButtons.Margin = new Padding(0);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(248, 64);
            flowButtons.TabIndex = 0;
            // 
            // okButton
            // 
            okButton.Location = new Point(156, 4);
            okButton.Margin = new Padding(4);
            okButton.Name = "okButton";
            okButton.Size = new Size(88, 26);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OkButtonClick;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(60, 4);
            cancelButton.Margin = new Padding(4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(88, 26);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButtonClick;
            // 
            // episodeNumber
            // 
            episodeNumber.Dock = DockStyle.Fill;
            episodeNumber.Location = new Point(112, 32);
            episodeNumber.Margin = new Padding(4);
            episodeNumber.Name = "episodeNumber";
            episodeNumber.Size = new Size(132, 23);
            episodeNumber.TabIndex = 1;
            // 
            // seasonNumber
            // 
            seasonNumber.Dock = DockStyle.Fill;
            seasonNumber.Location = new Point(112, 4);
            seasonNumber.Margin = new Padding(4);
            seasonNumber.Name = "seasonNumber";
            seasonNumber.Size = new Size(132, 23);
            seasonNumber.TabIndex = 0;
            // 
            // seasonLabel
            // 
            seasonLabel.Anchor = AnchorStyles.Right;
            seasonLabel.AutoSize = true;
            seasonLabel.Location = new Point(12, 6);
            seasonLabel.Margin = new Padding(4, 0, 4, 0);
            seasonLabel.Name = "seasonLabel";
            seasonLabel.Size = new Size(92, 15);
            seasonLabel.TabIndex = 2;
            seasonLabel.Text = "Season number:";
            // 
            // episodeLabel
            // 
            episodeLabel.Anchor = AnchorStyles.Right;
            episodeLabel.AutoSize = true;
            episodeLabel.Location = new Point(8, 34);
            episodeLabel.Margin = new Padding(4, 0, 4, 0);
            episodeLabel.Name = "episodeLabel";
            episodeLabel.Size = new Size(96, 15);
            episodeLabel.TabIndex = 3;
            episodeLabel.Text = "Episode number:";
            // 
            // NumberInputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 94);
            ControlBox = false;
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "NumberInputDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Episode";
            table.ResumeLayout(false);
            table.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TextBox episodeNumber;
    }
}