// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ProgressDialog.Designer.cs">
//   2025 - Andrew Jackson & Nicolas Pierre
// </copyright>
// <summary>
//   The dialog showing the progress bar.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View
{


    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;


    /// <summary>
    /// The dialog showing the progress bar.
    /// </summary>
    public partial class ProgressDialog
    {


        /// <summary>
        ///   Required designer variable.
        /// </summary>
        private readonly IContainer components = null;



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
            log = new ListBox();
            exitbtn = new Button();
            SuspendLayout();
            // 
            // log
            // 
            log.FormattingEnabled = true;
            log.ItemHeight = 15;
            log.Location = new Point(0, 0);
            log.Margin = new Padding(4, 3, 4, 3);
            log.Name = "log";
            log.Size = new Size(513, 94);
            log.TabIndex = 0;
            // 
            // exitbtn
            // 
            exitbtn.Location = new Point(426, 100);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(75, 23);
            exitbtn.TabIndex = 1;
            exitbtn.Text = "Exit";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += Exitbtn_Click;
            // 
            // ProgressDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 131);
            ControlBox = false;
            Controls.Add(exitbtn);
            Controls.Add(log);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProgressDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Task";
            ResumeLayout(false);

        }


        private ListBox log;
        private Button exitbtn;
    }
}