using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDatabase.Models
{
    internal class JsDiary
    {
        public int Id { get; set; }

        public List<JsEntry> Entries { get; set; }
    }
}
