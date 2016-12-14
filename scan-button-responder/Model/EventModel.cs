using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LiteDB;
using scan_button_responder.Model.Entities;

namespace scan_button_responder.Model
{
    internal class EventModel
    {
        private const string DbName = "EventData.db";

        private static String GetConnectionString()
        {
            return "filename=" + Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), DbName);
        }

        public static Event FindEventByGuid(String guid)
        {
            using (var db = new LiteDatabase(GetConnectionString()))
            {
                var events = db.GetCollection<Event>("events");
                var result = events.FindById(guid);
                return result;
            }

        }

        public static Event FindEventByName(String name)
        {
            using (var db = new LiteDatabase(GetConnectionString()))
            {
                var events = db.GetCollection<Event>("events");
                var result = events.FindOne(t => t.Name.Equals(name));
                return result;
            }

        }

        public static void AddEvent(Event evt)
        {
            using (var db = new LiteDatabase(GetConnectionString()))
            {
                var events = db.GetCollection<Event>("events");
                events.EnsureIndex("Name", true);
                events.Insert(evt);
            }

        }

        public static void UpdateEvent(Event evt)
        {
            using (var db = new LiteDatabase(GetConnectionString()))
            {
                var events = db.GetCollection<Event>("events");
                events.Update(evt);
            }
        }

        public static IEnumerable<Event> GetAllEvents()
        {
            using (var db = new LiteDatabase(GetConnectionString()))
            {
                var events = db.GetCollection<Event>("events");
                return events.FindAll();
            }
        }

        public static void DeleteEvent(Event evt)
        {
            using (var db = new LiteDatabase(GetConnectionString()))
            {
                var events = db.GetCollection<Event>("events");
                events.Delete(evt.Id);
            }
        }
    }
}
