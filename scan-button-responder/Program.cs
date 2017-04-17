using System;
using System.Windows.Forms;
using ScanToEvernote;
using scan_button_responder.StiWorks;

namespace scan_button_responder
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "register":
                        try
                        {
                            var sti = new Sti();
                            var stillImage = (IStillImage)sti;
                            stillImage.RegisterLaunchApplication("NAPS2: Scan to profile", Application.ExecutablePath);
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            TopMostMessageBox.Show(
                                String.Format(
                                    "Error registering as scanner button event: {0}\n\nAre you an administrator?",
                                    ex.Message), "NAPS2: Scan to profile", MessageBoxButtons.OK);
                        }
                        return -1;
                    case "unregister":
                        try
                        {
                            var sti = new Sti();
                            var stillImage = (IStillImage)sti;
                            stillImage.UnregisterLaunchApplication("NAPS2: Scan to profile");
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            TopMostMessageBox.Show(
                                String.Format(
                                    "Error registering as scanner button event: {0}\n\nAre you an administrator?",
                                    ex.Message), "NAPS2: Scan to profile", MessageBoxButtons.OK);
                        }
                        return -1;
                }
            }
            var evtHandler = new EventHandler();
            if (evtHandler.HandleEvent()) return 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EventsFrm());
            return 0;
        }
    }
}
