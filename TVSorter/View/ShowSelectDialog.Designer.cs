// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ShowSelectDialog.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Dialog for selecting a show.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View
{


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
            filterTextBox = new TextBox();
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
            buttonsFlow.Location = new Point(0, 576);
            buttonsFlow.Margin = new Padding(4, 3, 4, 3);
            buttonsFlow.Name = "buttonsFlow";
            buttonsFlow.Size = new Size(449, 35);
            buttonsFlow.TabIndex = 1;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(357, 3);
            selectButton.Margin = new Padding(4, 3, 4, 3);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(88, 27);
            selectButton.TabIndex = 0;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += SelectButtonClick;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(261, 3);
            closeButton.Margin = new Padding(4, 3, 4, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(88, 27);
            closeButton.TabIndex = 1;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButtonClick;
            // 
            // showList
            // 
            showList.FormattingEnabled = true;
            showList.ItemHeight = 15;
            showList.Location = new Point(0, 29);
            showList.Margin = new Padding(4, 3, 4, 3);
            showList.Name = "showList";
            showList.Size = new Size(449, 544);
            showList.TabIndex = 0;
            // 
            // filterTextBox
            // 
            filterTextBox.Dock = DockStyle.Top;
            filterTextBox.Location = new Point(0, 0);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(449, 23);
            filterTextBox.TabIndex = 2;
            filterTextBox.Text = "Find show";
            filterTextBox.TextChanged += FilterTextBoxChanged;
            // 
            // ShowSelectDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 611);
            Controls.Add(filterTextBox);
            Controls.Add(buttonsFlow);
            Controls.Add(showList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ShowSelectDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Show";
            Load += ShowSelectDialogLoad;
            buttonsFlow.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox filterTextBox;
    }
}