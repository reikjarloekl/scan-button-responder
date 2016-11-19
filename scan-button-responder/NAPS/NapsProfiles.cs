using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace scan_button_responder.NAPS
{
    class NapsProfiles
    {
        private static String GetNapsProfilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"NAPS2\profiles.xml");
        }

        private static XmlDocument GetProfileXmlDocument()
        {
            var naps2ProfileFile = GetNapsProfilePath();
            var xdoc = new XmlDocument();
            xdoc.Load(naps2ProfileFile);
            return xdoc;
        }

        public static IEnumerable<String> GetProfileNames()
        {
            var xdoc = GetProfileXmlDocument();
            var xmlNodeList = xdoc.SelectNodes("/ArrayOfScanProfile/ScanProfile/DisplayName");
            if (xmlNodeList == null)
                yield break;
            foreach (XmlNode node in xmlNodeList)
            {
                yield return node.InnerText;
            }
        }

        public static String GetAutoSaveFilename(String profileName)
        {
            var xdoc = GetProfileXmlDocument();
            var xmlNode = xdoc.SelectSingleNode("/ArrayOfScanProfile/ScanProfile[DisplayName[text() = '" + profileName + "']]/AutoSaveSettings/FilePath");
            if (xmlNode != null) return xmlNode.InnerText;
            return null;
        }
    }
}
