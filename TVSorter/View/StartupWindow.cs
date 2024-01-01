using System.Windows.Forms;

namespace TVSorter.View;

public partial class StartupWindow : Form
{
    public StartupWindow()
    {
        InitializeComponent();

        this.pictureBox1.Width = 500;
        this.pictureBox1.Height = 100;
        this.pictureBox1.Image = new System.Drawing.Bitmap(Resources.Resources.logo_no_background, 500, 100);
    }
}
