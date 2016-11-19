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
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "register")
                {
                    try
                    {
                        var sti = new Sti();
                        var stillImage = (IStillImage) sti;
                        stillImage.RegisterLaunchApplication("NAPS2: Scan to profile", Application.ExecutablePath);
                        TopMostMessageBox.Show("Succesfully registered as scanner button event.",
                            "NAPS2: Scan to profile", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        TopMostMessageBox.Show(
                            String.Format(
                                "Error registering as scanner button event: {0}\n\nAre you an administrator?",
                                ex.Message), "NAPS2: Scan to profile", MessageBoxButtons.OK);
                    }
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}
