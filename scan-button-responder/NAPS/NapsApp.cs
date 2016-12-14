using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace scan_button_responder.NAPS
{
    class NapsApp
    {
        private readonly List<String> _argsList = new List<String>();

        public void SetProfileName(String profileName)
        {
            _argsList.Add("-p \"" + profileName + "\"");
        }

        public void SetAutoSaveFilename(String fileName)
        {
            _argsList.Add("-o \"" + fileName + "\"");
        }

        public void UseProfilesAutosaveSettings()
        {
            _argsList.Add("-a");
        }

        public void Run()
        {
            var napsApp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"NAPS2\NAPS2.Console.exe");
            var args = _argsList.Aggregate("", (current, arg) => current + (arg + " "));
            args = args.TrimEnd(' ');
            var p = new Process();
            p.StartInfo.FileName = napsApp;
            p.StartInfo.Arguments = args;
            p.Start();
        }
    }
}
