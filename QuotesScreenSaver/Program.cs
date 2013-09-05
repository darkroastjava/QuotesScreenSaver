using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuotesScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0,2) == "/c")
                {
                    ShowConfiguration();
                }
                else if (args[0].ToLower() == "/s") // load the screensaver
                {
                    StartScreenSaver();
                }
                else if (args[0].ToLower() == "/p") // load the preview
                {
                    ShowPreview();
                }
            }
            else
            {
                ShowPreview();
            }
        }

        private static void StartScreenSaver()
        {
            ShowScreenSaver(Screen.AllScreens, false);
        }

        private static void ShowScreenSaver(IEnumerable<Screen> screens, bool preview)
        {
            var quotes = ReadQuotes();

            foreach (var screen in screens)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new QuotesScreenSaver(screen, preview, quotes));
            }
        }

        private static ICollection<string> ReadQuotes()
        {
            var quotesFile = @"C:\Dev\QuotesScreenSaver.txt";
            if (!File.Exists(quotesFile))
            {
                return new[] { "Place a quotes file at " + quotesFile };
            }

            return File.ReadAllLines(quotesFile);
        }

        private static void ShowPreview()
        {
            ShowScreenSaver(new[] { Screen.PrimaryScreen }, true);
        }

        private static void ShowConfiguration()
        {
            MessageBox.Show("There is nothing to be configured yet.");
        }
    }
}
