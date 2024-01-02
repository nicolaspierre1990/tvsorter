using System;
using System.Drawing;
using System.Windows.Forms;

namespace TVSorter.Controls;

public class CustomProgressBar: ProgressBar
{
    /// <summary>
    /// Gets or sets the text associated with this control.
    /// </summary>
    public string CustomText { get; set; }

    public CustomProgressBar() =>
        // Modify the ControlStyles flags
        //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = ClientRectangle;
        Graphics g = e.Graphics;

        ProgressBarRenderer.DrawHorizontalBar(g, rect);
        rect.Inflate(-3, -3);
        if (Value > 0)
        {
            // As we doing this ourselves we need to draw the chunks on the progress bar
            Rectangle clip = new(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
            ProgressBarRenderer.DrawHorizontalChunks(g, clip);
        }

        // Set the Display text (Either a % amount or our custom text
        int percent = (int)(((double)this.Value / (double)this.Maximum) * 100);
        string text = $"{CustomText} ({percent}%)";

        using Font f = new(FontFamily.GenericSerif, 10);

        SizeF len = g.MeasureString(text, f);
        Point location = new(Convert.ToInt32((Width / 2) - len.Width / 2), Convert.ToInt32((Height / 2) - len.Height / 2));
        // The commented-out code will centre the text into the highlighted area only. This will centre the text regardless of the highlighted area.
        // Draw the custom text
        g.DrawString(text, f, Brushes.Red, location);
    }
}