using System;
using System.Windows.Forms;
using AbcYazilim.OgrenciTakip.UI.Win.GeneralForms;

namespace AbcYazilim.OgrenciTakip.UI.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.Run(mainForm: new AnaForm());
        }
    }
}
