using System;
using System.Windows.Forms;

namespace scan_button_responder
{
    public partial class GetFileNameFrm : Form
    {

        public String ProfileName { set { Text = value; } }
        public String Result { get { return tbLabel.Text; } }
        public GetFileNameFrm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
