using MainComponents.Models;
using JsonDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializationDatabase.Interfaces;

namespace JsonDatabase
{
    public class JsonDataConverter : IDataConverter<JsUser, JsDiary>
    {
        public User Convert(JsUser jsUser)
        {
            User user = new User(jsUser.Id, jsUser.Diary_Id)
            {
                Login = jsUser.Login,
                Password = jsUser.Password,
            };

            return user;
        }

        public JsUser Convert(User user)
        {
            JsUser jsUSer = new JsUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Diary_Id = user.Diary_Id
            };

            return jsUSer;
        }

        public Diary Convert(JsDiary jsDiary)
        {
            Diary diary = new Diary(jsDiary.Id);

            foreach (var jsEntry in jsDiary.Entries)
            {
                diary.Add(Convert(jsEntry));
            }

            return diary;
        }

        public JsDiary Convert(Diary diary)
        {
            JsDiary jsDiary = new JsDiary()
            {
                Id= diary.Id,
            };

            var entries = diary.GetEntries();

            foreach (var entry in entries)
            {
                jsDiary.Entries.Add(Convert(entry));
            }

            return jsDiary;
        }
        private JsEntry Convert(Entry entry)
        {
            JsEntry jsEntry = new JsEntry()
            {
                Date = entry.Date,
                Text = entry.Text,
            };

            return jsEntry;
        }
        private Entry Convert(JsEntry jsEntry)
        {
            Entry entry = new Entry(jsEntry.Date, jsEntry.Text);

            return entry;
        }
    }
}
