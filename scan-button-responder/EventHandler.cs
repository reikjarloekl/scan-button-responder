
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using scan_button_responder.Model;
using scan_button_responder.Model.Entities;
using scan_button_responder.NAPS;

namespace scan_button_responder
{
    class EventHandler
    {
        private static String getEventGuid()
        {
            var args = Environment.GetCommandLineArgs();
            var match = Regex.Match(args[2], @"\{([a-fA-F\d-]+)\}");
            if (!match.Success) return null;
            match.NextMatch();
            return match.Groups[1].Value;
        }

        public bool HandleEvent()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length != 3) return false;
            var evtGuid = getEventGuid();
            if (evtGuid == null) return false;
            var evt = EventModel.FindEventByGuid(evtGuid);
            if (evt == null) 
                registerNewEvent(evtGuid);
                else runProfile(evt);
            return true;
        }

        private void runProfile(Event evt)
        {
            var naps = new NapsApp();
            naps.SetProfileName(evt.ProfileName);
            var fileName = NapsProfiles.GetAutoSaveFilename(evt.ProfileName);
            if (fileName != null)
            {
                if (fileName.Contains("$(x)"))
                {
                    var frm = new GetFileNameFrm();
                    frm.ProfileName = evt.ProfileName;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        fileName = fileName.Replace("$(x)", frm.Result.Replace(' ', '-'));
                        naps.SetAutoSaveFilename(fileName);                        
                    } else return;
                } else naps.UseProfilesAutosaveSettings();
            }
            naps.Run();
        }

        private void registerNewEvent(string evtGuid)
        {
            var frm = new RegisterNewEventFrm();
            if (frm.ShowDialog() != DialogResult.OK) return;
            var evt = new Event();
            evt.Id = evtGuid;
            evt.Name = frm.EventName;
            evt.ProfileName = frm.ProfileName;
            EventModel.AddEvent(evt);
        }
    }
}
