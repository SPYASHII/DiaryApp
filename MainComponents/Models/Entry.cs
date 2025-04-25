using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Models
{
    public struct Entry
    {
        public DateTime Date {  get; }

        public string Text {  get; }

        public Entry(DateTime date, string text)
        {
            Date = date;
            Text = text;
        }

    }
}
