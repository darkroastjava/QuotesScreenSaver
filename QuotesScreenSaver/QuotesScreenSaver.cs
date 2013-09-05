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
    public partial class QuotesScreenSaver : Form
    {
        private Point mouseXy = Point.Empty;
        private Random random;

        public QuotesScreenSaver(Screen screen, bool preview, ICollection<string> quotes)
        {
            ActiveScreen = screen;
            Preview = preview;
            Quotes = quotes;
            InitializeComponent();

            webBrowser.Navigate("http://www.google.com/");
        }

        public Screen ActiveScreen { get; private set; }
        public bool Preview { get; private set; }
        public ICollection<string> Quotes { get; private set; }

        private void QuotesScreenSaver_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Bounds = ActiveScreen.Bounds;
            if (!Preview) { Cursor.Hide(); }
            TopMost = true;
            random = new Random();

            ChangeQuote(PickRandomQuote());

            var overlayWindow = new OverlayWindow(ActiveScreen, Preview, Quotes);
            overlayWindow.Show();
            overlayWindow.BringToFront();
            overlayWindow.Closed += (o, args) => Close();
        }

        private string PickRandomQuote()
        {
            var dice = random.Next(Quotes.Count);
            return Quotes.ElementAt(dice);
        }

        private void ChangeQuote(string quote)
        {
            QuoteLabel.Text = quote;
            QuoteLabel.Left = (Width - QuoteLabel.Width)/2;
            QuoteLabel.Top = (Height - QuoteLabel.Height)/2;
        }
    }
}
