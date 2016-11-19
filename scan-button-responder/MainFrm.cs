using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using scan_button_responder.Model;
using scan_button_responder.Model.Entities;
using scan_button_responder.NAPS;

namespace scan_button_responder
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private String getEventGuid()
        {
            var args = Environment.GetCommandLineArgs();
            var match = Regex.Match(args[2], @"\{([a-fA-F\d-]+)\}");
            if (match.Success)
            {
                match.NextMatch();
                return match.Groups[1].Value;
            }
            else
            {
                MessageBox.Show("RegEx not found in " + args[2]);
                throw new InvalidDataException();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var evt = EventModel.FindEventByGuid(getEventGuid());
            if (evt == null)
            {
                evt = new Event
                {
                    Id = getEventGuid(),
                    Name = tbEventName.Text,
                    ProfileName = GetSelectedProfileName()
                };
                EventModel.AddEvent(evt);
            }
            else
            {
                evt.ProfileName = GetSelectedProfileName();
                evt.Name = tbEventName.Text;
                EventModel.UpdateEvent(evt);
            }
        }

        private string GetSelectedProfileName()
        {
            return cbProfiles.GetItemText(cbProfiles.SelectedItem);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Event evt = null;
            var args = Environment.GetCommandLineArgs();
            if (args.Length == 3)
            {
                lbDevice.Text = args[1];
                var eventGuid = getEventGuid();
                lbEvent.Text = eventGuid;
                evt = EventModel.FindEventByGuid(eventGuid);
                if (evt != null)
                {
                    tbEventName.Text = evt.Name;
                }
            }
            var profiles = NapsProfiles.GetProfileNames();
            foreach (var profile in profiles)
            {
                cbProfiles.Items.Add(profile);
            }
            if (evt != null)
            {
                cbProfiles.SelectedIndex = cbProfiles.FindStringExact(evt.ProfileName);
                var fileName = NapsProfiles.GetAutoSaveFilename(evt.ProfileName);
                lbFileName.Text = fileName;
                tbFileName.Enabled = fileName.Contains("$(x)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var napsApp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"NAPS2\NAPS2.Console.exe");
            var fileName = NapsProfiles.GetAutoSaveFilename(GetSelectedProfileName());
            var args = "-p \""+ GetSelectedProfileName() + "\"";
            if (fileName.Contains("$(x)"))
            {
                fileName = fileName.Replace("$(x)", tbFileName.Text.Replace(' ', '-'));
                args += " -o \"" + fileName + "\"";
            }
            else args += " -a";
            MessageBox.Show(args);
            var p = new Process();
            p.StartInfo.FileName = napsApp;
            p.StartInfo.Arguments = args;
            p.Start();
        }
    }
}
