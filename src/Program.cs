using Decryptor.Forms;
using Decryptor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Decryptor
{
    static class Program
    {
        private static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public static Settings settings;
        public static ThemeTool ThemeT = new ThemeTool();
        public static Theme usingTheme;
        public static float version = 1.3f;
        public static string workPath;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                workPath = args[0];
            }
            catch(IndexOutOfRangeException)
            {
                workPath = Application.StartupPath;
            }
            foreach (string path in Directory.GetFiles(Program.workPath + "\\Themes"))
            {
                Theme t = (Theme) JsonTool.Deserialize(typeof(Theme), path);
                ThemeT.registeredThemes.Add(t);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            t.Interval = 3000;
            t.Tick += onTick;
            t.Start();
            Application.Run(new startUp());
        }

        private static void onTick(object sender, EventArgs e)
        {
            Main main = new Main();
            Application.OpenForms[0].Hide();
            main.Show();
            t.Stop();
        }

    }
}
