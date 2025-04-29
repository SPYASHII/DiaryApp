using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDatabase.Models
{
    public class JsDiary
    {
        public int Id { get; set; }

        public List<JsEntry> Entries { get; set; } = new List<JsEntry>();
    }
}
