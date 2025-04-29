using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Models
{
    public class Diary
    {
        public int Id { get; }

        private List<Entry> _entries;

        public Diary(int id)
        {
            Id = id;
            _entries = new List<Entry>();
        }
        public List<Entry> GetEntries()
        {
            List<Entry> entries = new List<Entry>();

            entries.AddRange(_entries);

            return entries;
        }
        public void Add(Entry entry)
        {
            _entries.Add(entry);
        }
    }
}
