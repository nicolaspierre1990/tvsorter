﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="Log.Designer.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The log.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace TVSorter.View;



using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// The log.
/// </summary>
public partial class Log
{


    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly IContainer components = null;

    /// <summary>
    ///   The log list.
    /// </summary>
    private ListBox logList;



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
        this.logList = new System.Windows.Forms.ListBox();
        this.SuspendLayout();
        // 
        // logList
        // 
        this.logList.Dock = System.Windows.Forms.DockStyle.Fill;
        this.logList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.logList.FormattingEnabled = true;
        this.logList.HorizontalScrollbar = true;
        this.logList.Location = new System.Drawing.Point(0, 0);
        this.logList.Name = "logList";
        this.logList.Size = new System.Drawing.Size(760, 367);
        this.logList.TabIndex = 0;
        this.logList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LogListDrawItem);
        // 
        // Log
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.logList);
        this.Name = "Log";
        this.Size = new System.Drawing.Size(760, 367);
        this.Load += new System.EventHandler(this.LogLoad);
        this.ResumeLayout(false);

    }

}