using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TVSorter.Controls;

internal class VisualStyleManager
{
    public static Dictionary<string, VisualStyle> StyleDictionary { set; get; }

    public static void AddStyle(string name, Control control) => StyleDictionary.Add(name, new VisualStyle(control));

    public static void ApplyStyle(string stylename, Control control)
    {
        if (StyleDictionary.TryGetValue(stylename, out VisualStyle vs))
        {
            control.BackColor = vs.CBackColor;
            control.ForeColor = vs.CForeColor;
            control.Font = vs.CFont;
        }
    }

    public class VisualStyle(Control control)
    {
        public Color CBackColor { set; get; } = control.BackColor;
        public Color CForeColor { set; get; } = control.ForeColor;
        public Font CFont { set; get; } = control.Font;
    }
}
