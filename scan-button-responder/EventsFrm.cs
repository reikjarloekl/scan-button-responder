using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using scan_button_responder.Model;
using scan_button_responder.Model.Entities;
using scan_button_responder.NAPS;

namespace scan_button_responder
{
    public partial class EventsFrm : Form
    {
        private Event _event;

        public EventsFrm()
        {
            InitializeComponent();
        }

        private string GetSelectedProfileName()
        {
            return cbProfiles.GetItemText(cbProfiles.SelectedItem);
        }

        private void selectProfileByEvent(Event evt)
        {
            cbProfiles.SelectedIndex = cbProfiles.FindStringExact(evt.ProfileName);
        }

        private void EventsFrm_Load(object sender, EventArgs e)
        {
            var profiles = NapsProfiles.GetProfileNames();
            foreach (var profile in profiles)
            {
                cbProfiles.Items.Add(profile);
            }
            var events = EventModel.GetAllEvents();
            foreach (var evt in events)
            {
                lbEvents.Items.Add(evt.Name);
            }
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void lbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEvents.SelectedItem == null) return;
            var evtName = lbEvents.GetItemText(lbEvents.SelectedItem);
            _event = EventModel.FindEventByName(evtName);
            UpdateControlsFromEvent();
        }

        private void UpdateControlsFromEvent()
        {
            if (_event == null)
            {
                tbName.Text = "";
                cbProfiles.SelectedItem = null;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                tbName.Text = _event.Name;
                selectProfileByEvent(_event);
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_event == null) return;
            _event.Name = tbName.Text;
            _event.ProfileName = GetSelectedProfileName();
            EventModel.UpdateEvent(_event);
            var idx = lbEvents.SelectedIndex;
            lbEvents.Items.RemoveAt(idx); 
            lbEvents.Items.Insert(idx, _event.Name);
            lbEvents.SelectedIndex = idx;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Scanner button", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EventModel.DeleteEvent(_event);
                _event = null;
                UpdateControlsFromEvent();
                lbEvents.SelectedItem = null;
                lbEvents.Items.RemoveAt(lbEvents.SelectedIndex);
            }
        }
    }
}
