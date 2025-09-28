namespace TVSorter.View;

partial class StartupWindow
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pictureBox1 = new System.Windows.Forms.PictureBox();
        customProgressBar1 = new TVSorter.Controls.CustomProgressBar();
        versionLabel = new System.Windows.Forms.Label();
        copyLabel = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
        pictureBox1.Location = new System.Drawing.Point(9, 8);
        pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(491, 159);
        pictureBox1.TabIndex = 2;
        pictureBox1.TabStop = false;
        // 
        // customProgressBar1
        // 
        customProgressBar1.CustomText = null;
        customProgressBar1.Location = new System.Drawing.Point(9, 171);
        customProgressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        customProgressBar1.Name = "customProgressBar1";
        customProgressBar1.Size = new System.Drawing.Size(492, 22);
        customProgressBar1.TabIndex = 3;
        // 
        // versionLabel
        // 
        versionLabel.AutoSize = true;
        versionLabel.Location = new System.Drawing.Point(457, 195);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new System.Drawing.Size(31, 15);
        versionLabel.TabIndex = 4;
        versionLabel.Text = "0.0.0";
        // 
        // copyLabel
        // 
        copyLabel.AutoSize = true;
        copyLabel.Location = new System.Drawing.Point(9, 195);
        copyLabel.Name = "copyLabel";
        copyLabel.Size = new System.Drawing.Size(87, 15);
        copyLabel.TabIndex = 5;
        copyLabel.Text = "Copyright 2024";
        // 
        // StartupWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(509, 217);
        ControlBox = false;
        Controls.Add(copyLabel);
        Controls.Add(versionLabel);
        Controls.Add(customProgressBar1);
        Controls.Add(pictureBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        Name = "StartupWindow";
        Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Shown += StartupWindow_Shown;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private System.Windows.Forms.PictureBox pictureBox1;
    private Controls.CustomProgressBar customProgressBar1;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.Label copyLabel;
}