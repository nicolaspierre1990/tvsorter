﻿namespace TVSorter.View;

partial class LicensingDialog
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
        richTextBox1 = new System.Windows.Forms.RichTextBox();
        label1 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new System.Drawing.Point(12, 32);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new System.Drawing.Size(776, 371);
        richTextBox1.TabIndex = 0;
        richTextBox1.Text = "";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(94, 20);
        label1.TabIndex = 1;
        label1.Text = "License code";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(12, 409);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(94, 29);
        button1.TabIndex = 2;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(694, 409);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(94, 29);
        button2.TabIndex = 3;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // LicensingDialog
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Controls.Add(richTextBox1);
        Name = "LicensingDialog";
        Text = "LicensingDialog";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
}