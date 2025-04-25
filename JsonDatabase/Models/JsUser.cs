using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDatabase.Models
{
    internal class JsUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int Diary_Id { get; set; }
    }
}
