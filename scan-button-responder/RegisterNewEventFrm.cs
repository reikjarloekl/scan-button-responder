using System;
using System.Windows.Forms;
using scan_button_responder.NAPS;

namespace scan_button_responder
{
    public partial class RegisterNewEventFrm : Form
    {
        public String ProfileName { get { return cbProfiles.GetItemText(cbProfiles.SelectedItem); } }
        public String EventName { get { return tbName.Text; } }

        public RegisterNewEventFrm()
        {
            InitializeComponent();
        }

        private void RegisterNewEventFrm_Load(object sender, System.EventArgs e)
        {
            var profiles = NapsProfiles.GetProfileNames();
            foreach (var profile in profiles)
            {
                cbProfiles.Items.Add(profile);
            }
            btnOk.Enabled = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            TopMost = true;
            BringToFront();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
        }
    }
}
