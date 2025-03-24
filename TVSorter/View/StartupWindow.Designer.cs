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
        customProgressBar1 = new Controls.CustomProgressBar();
        versionLabel = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
        pictureBox1.Location = new System.Drawing.Point(10, 10);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(562, 212);
        pictureBox1.TabIndex = 2;
        pictureBox1.TabStop = false;
        // 
        // customProgressBar1
        // 
        customProgressBar1.CustomText = null;
        customProgressBar1.Location = new System.Drawing.Point(10, 228);
        customProgressBar1.Name = "customProgressBar1";
        customProgressBar1.Size = new System.Drawing.Size(562, 29);
        customProgressBar1.TabIndex = 3;
        // 
        // versionLabel
        // 
        versionLabel.AutoSize = true;
        versionLabel.Location = new System.Drawing.Point(522, 260);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new System.Drawing.Size(50, 20);
        versionLabel.TabIndex = 4;
        versionLabel.Text = "label1";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(10, 260);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(110, 20);
        label2.TabIndex = 5;
        label2.Text = "Copyright 2024";
        // 
        // StartupWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(582, 289);
        ControlBox = false;
        Controls.Add(label2);
        Controls.Add(versionLabel);
        Controls.Add(customProgressBar1);
        Controls.Add(pictureBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Name = "StartupWindow";
        Padding = new System.Windows.Forms.Padding(10);
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
    private System.Windows.Forms.Label label2;
}