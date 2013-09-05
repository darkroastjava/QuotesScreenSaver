using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuotesScreenSaver
{
    public partial class OverlayWindow : Form
    {
        private Point mouseXy = Point.Empty;
        private Random random;

        public OverlayWindow(Screen screen, bool preview, ICollection<string> quotes)
        {
            ActiveScreen = screen;
            Preview = preview;
            Quotes = quotes;
            InitializeComponent();
        }

        public Screen ActiveScreen { get; private set; }
        public bool Preview { get; private set; }
        public ICollection<string> Quotes { get; private set; }

        private void OverlayWindow_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Bounds = ActiveScreen.Bounds;
            if (!Preview) { Cursor.Hide(); }
            TopMost = true;

            Opacity = 0.01;
        }

        private void OverlayWindow_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void OverlayWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void OverlayWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (Preview)
            {
                return;
            }

            if (!mouseXy.IsEmpty)
            {
                if (mouseXy != new Point(e.X, e.Y))
                {
                    Close();
                }
            }
            mouseXy = new Point(e.X, e.Y);
        }
    }
}
